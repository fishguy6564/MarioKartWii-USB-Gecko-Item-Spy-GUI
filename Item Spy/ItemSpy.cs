using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using FTDIUSBGecko;
using Item_Spy;
using System.Drawing.Text;

namespace Item_Spy
{
    public partial class ItemSpy : Form
    {
        private static MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
        private static String curdir = Directory.GetCurrentDirectory();
        private bool[] settings = new bool[2];
        private System.Threading.Thread t;
        private PrivateFontCollection p;
        private USBGecko gecko;
        private Bitmap othersRank;
        private Bitmap others;
        private Bitmap myRank;
        private Bitmap me;
        private Bitmap bg;
        private Room currentRoom;
        private int dumpSpeed;

        private long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        private bool isNameSet = false;

        public ItemSpy()
        {
            InitializeComponent();
        }


        private void ItemSpy_Load(object sender, EventArgs e)
        {
            currentRoom = new Room();
            others = new Bitmap("Assets\\others.png");
            othersRank = new Bitmap("Assets\\othersrank.png");
            me = new Bitmap("Assets\\me.png");
            myRank = new Bitmap("Assets\\myrank.png");
            gecko = MainForm.gecko;
            load_ini();
            t = new System.Threading.Thread(Update_Program);
            t.Start();
        }

        private void ItemSpy_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                gecko.Disconnect();
            }
            catch { }

            mainForm.connectButton.Text = "Connect";
            t.Abort();
            mainForm.isFormOpen = false;
            mainForm.spyForm = new ItemSpy();
        }

        private void load_ini()
        {
            try
            {
                String bgDirectory;

                INIFile ini = new INIFile(curdir + @"\Settings.ini");
                dumpSpeed = Int32.Parse(ini.Read("Settings", "Speed"));
                bgDirectory = ini.Read("Settings", "background");

                if (Int32.Parse(ini.Read("Settings", "disablebox")) == 0) settings[0] = false;
                else settings[0] = true;

                if (Int32.Parse(ini.Read("Settings", "highlight")) == 0) settings[1] = false;
                else settings[1] = true;

                try
                {
                    bg = new Bitmap(bgDirectory);
                }
                catch
                {
                    bg = null;
                }

                if (Int32.Parse(ini.Read("Settings", "bg_enable")) == 1) bg = null;


            }
            catch
            {
                dumpSpeed= 240;
                settings[0] = false;
                settings[1] = false;
            }
        }

        private byte[] dump(UInt32 addr, UInt32 size)
        {
            byte[] data = new byte[size];
            MemoryStream miniDump = new MemoryStream();

            try
            {
                gecko.Dump(addr, addr + size, miniDump);
                miniDump.Seek(0, SeekOrigin.Begin);
                miniDump.Read(data, 0, (int)size);
            }
            catch
            {
                t.Abort();
                this.Close();
            }
            return data;
        }

        private Bitmap Get_Item_Icon(int id)
        {
            String[] filenames = {
                "gs.png", "rs.png", "ba.png",
                "fi.png", "ki.png", "tk.png",
                "bo.png", "bs.png", "th.png",
                "st.png", "gk.png", "bk.png",
                "ge.png", "pb.png", "tc.png",
                "bb.png", "tg.png", "tr.png",
                "tb.png"
            };

            if (id >= 0x13) id = 0x04;

            return new Bitmap("Assets\\Items\\" + filenames[id]);
        }

        private Bitmap Get_Player_Icon(int id)
        {
            String[] filenames = {
                "mr.png", "bpc.png", "wl.png",
                "kp.png", "bds.png", "ka.png",
                "bmr.png", "lg.png", "ko.png",
                "dk.png", "ys.png", "wr.png",
                "blg.png", "kk.png", "nk.png",
                "ds.png", "pc.png", "ca.png",
                "dd.png", "kt.png", "jr.png",
                "bk.png", "fk.png", "rs.png",
                "mii_m.png", "mii_f.png"
            };

            if (id > 0x19)
            {
                if ((id & 1) == 0) id = 0x18;
                else id = 0x19;
            }

            return new Bitmap("Assets\\Characters\\" + filenames[id]);
        }

        private Bitmap getItemBox()
        {
            return new Bitmap("Assets\\Items\\item_box.png");
        }

        private FontFamily getFont()
        {
            if(p == null)
            {
                p = new PrivateFontCollection();
                p.AddFontFile("Assets\\Fonts\\ctmkf.ttf"); //Using font by Chadderz
            }

            return new FontFamily("ctmkf", p);
        }

        private byte[] getCharacters()
        {
            return dump(0x800014B0, 0xC);
        }

        private int getPlayerAmount(byte[] data)
        {
            UInt32 value;
            byte[] buffer = new byte[4];
            Buffer.BlockCopy(data, 12, buffer, 0, 4);
            value = buffer[1];
            return (int)value;
        }

        private String formatString(String s)
        {
            String accumulator = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Substring(i, 1).Equals("\0")) break;
                accumulator = accumulator + s.Substring(i, 1);
            }
            return accumulator;
        }

        private String[] getNames(byte[] data, int max)
        {
            String[] names = new String[max];

            for(int i = 0; i < max; i++)
            {
                UInt32 value;
                String name;
                byte[] nameBytes;
                byte[] buffer = new byte[4];
                
                Buffer.BlockCopy(data, 16 + i * 4, buffer, 0, 4);
                value = BitConverter.ToUInt32(buffer, 0);
                value = ByteSwap.Swap(value);

                nameBytes = dump(value, 0x14);
                name = formatString(Encoding.BigEndianUnicode.GetString(nameBytes));

                names[i] = name;
            }


            return names;
        }

        private byte[] getDynamicData()
        {
            return dump(0x800014F0, 0x40);
        }

        private byte[] getStaticData()
        {
            return dump(0x800014B0, 0x40);
        }

        private bool isRace(byte[] data)
        {
            UInt32 value;
            byte[] buffer = new byte[4];
            Buffer.BlockCopy(data, 12, buffer, 0, 4);
            value = BitConverter.ToUInt32(buffer, 0);
            value = ByteSwap.Swap(value);
            return value == 1;
        }

        private int getMyIndex(byte[] data)
        {
            UInt32 value;
            byte[] buffer = new byte[4];
            Buffer.BlockCopy(data, 12, buffer, 0, 4);
            value = buffer[0];
            return (int)value;
        }

        private byte[] getPositionData(byte[] data)
        {
            byte[] buffer = new byte[12];
            Buffer.BlockCopy(data, 0, buffer, 0, 12);
            return buffer;
        }

        private byte[] getKartInfo(byte[] data)
        {
            byte[] buffer = new byte[12];
            Buffer.BlockCopy(data, 0, buffer, 0, 12);
            return buffer;
        }

        private byte[][] getItemData(byte[] data)
        {
            byte[][] itemData = new byte[12][];

            for(int i = 0; i < 12; i++)
            {
                itemData[i] = new byte[4];
                Buffer.BlockCopy(data, 16 + i * 4, itemData[i], 0, 4);
            }
            return itemData;
        }

        private void updatePlayerData()
        {
            long current = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long difference = current - start;
            if ((int)(current - start) >= dumpSpeed)
            {
                byte[] dynamicData = getDynamicData();
                byte[] positionData = getPositionData(dynamicData);
                byte[][] itemData = getItemData(dynamicData);

                if (isRace(dynamicData))
                {

                    if (!isNameSet)
                    {
                        byte[] staticData = getStaticData();
                        byte[] characterData = getKartInfo(staticData);
                        int maxPlayers = getPlayerAmount(staticData);
                        int myIndex = getMyIndex(staticData);
                        String[] names = getNames(staticData, maxPlayers);
                        isNameSet = true;

                        currentRoom.setMaxPlayers(maxPlayers);

                        for (int i = 0; i < maxPlayers; i++)
                        {
                            Player p;

                            if (i == myIndex) p = new Player(names[i], characterData[i], true);
                            else p = new Player(names[i], characterData[i], false);
                            currentRoom.add(p, i);
                        }
                    }

                    currentRoom.update(positionData, itemData);
                    /*
                    for (int i = 0; i < currentRoom.getMaxPlayers(); i++)
                    {
                        play[i].setItem(itemData[i][0]);
                        play[i].setItemState(itemData[i][1]);
                        currentRoom.add(play[i], positionData[i]);
                    }*/


                }
                else
                {
                    currentRoom.clear();
                    isNameSet = false;
                }
                start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }
        }

        private void Update_Program()
        {
            while (true)
            {
                updatePlayerData();
                Invalidate();
            }
        }

        private void ItemSpy_Paint(object sender, PaintEventArgs e)
        {
            
            int playerAmount;
            Graphics graphics = e.Graphics;

            Font nameFont = new Font(getFont(), 10);
            Font positionFont = new Font(getFont(), 12);

            playerAmount = currentRoom.getMaxPlayers();

            if (bg != null)
            {
                graphics.DrawImage(bg, 0, 0, 180, 365);
            }

            for (int i = 0; i < playerAmount; i++)
            {
                Player p;
                int itemState;
                int itemID;

                p = currentRoom.get(i);
                if(p != null)
                {
                    itemState = p.getItemState();
                    itemID = p.getItem();

                    if (p.isMain() && !settings[1])
                    {
                        graphics.DrawImage(me, 18, -5 + (30 * i));
                        graphics.DrawImage(myRank, 0, -4 + (30 * i));
                    }
                    else
                    {
                        graphics.DrawImage(others, 18, -5 + (30 * i));
                        graphics.DrawImage(othersRank, 0, -4 + (30 * i));
                    }

                    graphics.DrawString(p.getName(), nameFont, Brushes.Black, 54, 10 + (30 * i));

                    if ((itemState >= 3 && itemState <= 7) || (settings[0] && itemState != 0))
                    {
                        graphics.DrawImage(Get_Item_Icon(itemID), 145, 4 + (30 * i));
                    }
                    else if (itemState >= 1 && itemState <= 2)
                    {
                        graphics.DrawImage(getItemBox(), 145, 4 + (30 * i));
                    }

                    if (i >= 9)
                    {
                        graphics.DrawString((i + 1).ToString(), positionFont, Brushes.Black, 1, 8 + (30 * i));
                    }
                    else
                    {
                        graphics.DrawString((i + 1).ToString(), positionFont, Brushes.Black, 6, 8 + (30 * i));
                    }

                    graphics.DrawImage(Get_Player_Icon(p.getCharacter()), 32, 4 + (30 * i));
                }
            }
        }
    }
}
