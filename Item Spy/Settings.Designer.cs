namespace Item_Spy
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dumpSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bufferChoice = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.hlightMain = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openBG = new System.Windows.Forms.OpenFileDialog();
            this.bgFile = new System.Windows.Forms.TextBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.bgSwitch = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dumpSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dumpSpeed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dumpSpeed
            // 
            this.dumpSpeed.Location = new System.Drawing.Point(89, 31);
            this.dumpSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.dumpSpeed.Name = "dumpSpeed";
            this.dumpSpeed.Size = new System.Drawing.Size(51, 20);
            this.dumpSpeed.TabIndex = 2;
            this.dumpSpeed.Tag = "";
            this.dumpSpeed.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.dumpSpeed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dumpSpeed_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dump Every";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ms";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(37, 285);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(113, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save Settings";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Item Box Buffer";
            // 
            // bufferChoice
            // 
            this.bufferChoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bufferChoice.FormattingEnabled = true;
            this.bufferChoice.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.bufferChoice.Location = new System.Drawing.Point(94, 31);
            this.bufferChoice.Name = "bufferChoice";
            this.bufferChoice.Size = new System.Drawing.Size(46, 21);
            this.bufferChoice.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Highlight Main Player";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bufferChoice);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(10, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 58);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.hlightMain);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(10, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 58);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // hlightMain
            // 
            this.hlightMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hlightMain.FormattingEnabled = true;
            this.hlightMain.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.hlightMain.Location = new System.Drawing.Point(94, 31);
            this.hlightMain.Name = "hlightMain";
            this.hlightMain.Size = new System.Drawing.Size(46, 21);
            this.hlightMain.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bgSwitch);
            this.groupBox4.Controls.Add(this.openFileButton);
            this.groupBox4.Controls.Add(this.bgFile);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(10, 204);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(175, 58);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Background";
            // 
            // openBG
            // 
            this.openBG.Filter = "\"Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg;*.jpeg\"\"";
            // 
            // bgFile
            // 
            this.bgFile.Location = new System.Drawing.Point(48, 32);
            this.bgFile.Name = "bgFile";
            this.bgFile.ReadOnly = true;
            this.bgFile.Size = new System.Drawing.Size(92, 20);
            this.bgFile.TabIndex = 6;
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(140, 31);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(24, 22);
            this.openFileButton.TabIndex = 7;
            this.openFileButton.Text = "...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // bgSwitch
            // 
            this.bgSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bgSwitch.FormattingEnabled = true;
            this.bgSwitch.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.bgSwitch.Location = new System.Drawing.Point(6, 31);
            this.bgSwitch.Name = "bgSwitch";
            this.bgSwitch.Size = new System.Drawing.Size(40, 21);
            this.bgSwitch.TabIndex = 5;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 330);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dumpSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown dumpSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox bufferChoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox hlightMain;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TextBox bgFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openBG;
        private System.Windows.Forms.ComboBox bgSwitch;
    }
}