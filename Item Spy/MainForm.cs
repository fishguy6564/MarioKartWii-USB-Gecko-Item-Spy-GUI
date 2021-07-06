using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTDIUSBGecko;

namespace Item_Spy
{
    public partial class MainForm : Form
    {
        public static USBGecko gecko;
        public ItemSpy spyForm;
        public Settings settingsForm;
        public bool isFormOpen = false;

        public MainForm()
        {
            InitializeComponent();
        } 

        private void MainForm_Load(object sender, EventArgs e)
        {
            gecko = new USBGecko();
            spyForm = new ItemSpy();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (gecko.connected)
            {
                try { gecko.Disconnect(); }
                catch { }
                spyForm.Close();
                spyForm = new ItemSpy();
                connectButton.Text = "Connect";
                isFormOpen = false;
            }
            else
            {
                try
                {
                    if (!isFormOpen)
                    {
                        gecko.Connect();
                        spyForm.Show();
                        connectButton.Text = "Disconnect";
                        isFormOpen = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Error!");
                    spyForm.Close();
                    isFormOpen = false;
                }
            }
        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            if (!isFormOpen)
            {
                settingsForm = new Settings();
                settingsForm.Show();
                isFormOpen = true;
            }
        }
    }
}
