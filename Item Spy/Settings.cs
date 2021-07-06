using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Item_Spy
{
    public partial class Settings : Form
    {
        private static String curdir = Directory.GetCurrentDirectory();
        private static MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();

        public Settings()
        {
            InitializeComponent();
        }

        private void load_ini()
        {
            try
            {
                INIFile ini = new INIFile(curdir + @"\Settings.ini");

                dumpSpeed.Value = Int32.Parse(ini.Read("Settings", "speed"));
                bufferChoice.SelectedIndex = Int32.Parse(ini.Read("Settings", "disablebox"));
                hlightMain.SelectedIndex = Int32.Parse(ini.Read("Settings", "highlight"));
                bgSwitch.SelectedIndex = Int32.Parse(ini.Read("Settings", "bg_enable"));
                try
                {
                    bgFile.Text = ini.Read("Settings", "background");
                }
                catch
                {
                    bgFile.Text = "";
                }
            }
            catch
            {
                dumpSpeed.Value = 240;
                bufferChoice.SelectedIndex = 0;
                hlightMain.SelectedIndex = 0;
                bgSwitch.SelectedIndex = 1;
                bgFile.Text = "";
            }
        }

        private void save_ini()
        {
            INIFile ini = new INIFile(curdir + @"\Settings.ini");
            ini.Write("Settings", "speed", dumpSpeed.Value.ToString());
            ini.Write("Settings", "disablebox", bufferChoice.SelectedIndex.ToString());
            ini.Write("Settings", "highlight", hlightMain.SelectedIndex.ToString());
            ini.Write("Settings", "bg_enable", bgSwitch.SelectedIndex.ToString());
            ini.Write("Settings", "background", bgFile.Text);
        }

        private void dumpSpeed_KeyUp(object sender, KeyEventArgs e)
        {
            int value;

            value = (int)dumpSpeed.Value;

            if (value < dumpSpeed.Minimum) dumpSpeed.Value = dumpSpeed.Minimum;
            if (value > dumpSpeed.Maximum) dumpSpeed.Value = dumpSpeed.Maximum;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            load_ini();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            save_ini();
            this.Close();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.isFormOpen = false;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openBG.ShowDialog() == DialogResult.OK)
            {
                bgFile.Text = openBG.FileName;
            }


        }

        private void creditsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
