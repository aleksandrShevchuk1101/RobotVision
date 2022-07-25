namespace CS_KEHRATEC
{
    partial class Form_01_Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraActivationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modbusTCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPIPSocketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sickPLRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLCSocketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.softPLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameracalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menue_Help_Information = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analogueInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Password = new System.Windows.Forms.Button();
            this.Menue_Configuration_Digital_IO = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1270, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.shutDownToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // shutDownToolStripMenuItem
            // 
            this.shutDownToolStripMenuItem.Name = "shutDownToolStripMenuItem";
            this.shutDownToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.shutDownToolStripMenuItem.Text = "ShutDown";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraActivationToolStripMenuItem,
            this.authorizationToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // cameraActivationToolStripMenuItem
            // 
            this.cameraActivationToolStripMenuItem.Name = "cameraActivationToolStripMenuItem";
            this.cameraActivationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cameraActivationToolStripMenuItem.Text = "Camera Activation";
            // 
            // authorizationToolStripMenuItem
            // 
            this.authorizationToolStripMenuItem.Name = "authorizationToolStripMenuItem";
            this.authorizationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.authorizationToolStripMenuItem.Text = "Authorization";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menue_Configuration_Digital_IO,
            this.modbusTCPToolStripMenuItem,
            this.tCPIPSocketToolStripMenuItem,
            this.sickPLRToolStripMenuItem,
            this.pLCSocketToolStripMenuItem,
            this.softPLCToolStripMenuItem,
            this.cameracalibrationToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // modbusTCPToolStripMenuItem
            // 
            this.modbusTCPToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Modbus;
            this.modbusTCPToolStripMenuItem.Name = "modbusTCPToolStripMenuItem";
            this.modbusTCPToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.modbusTCPToolStripMenuItem.Text = "ModbusTCP";
            // 
            // tCPIPSocketToolStripMenuItem
            // 
            this.tCPIPSocketToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.TCP_IP;
            this.tCPIPSocketToolStripMenuItem.Name = "tCPIPSocketToolStripMenuItem";
            this.tCPIPSocketToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.tCPIPSocketToolStripMenuItem.Text = "TCP_IP_Socket";
            // 
            // sickPLRToolStripMenuItem
            // 
            this.sickPLRToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Sick_PLR;
            this.sickPLRToolStripMenuItem.Name = "sickPLRToolStripMenuItem";
            this.sickPLRToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.sickPLRToolStripMenuItem.Text = "Sick PLR";
            // 
            // pLCSocketToolStripMenuItem
            // 
            this.pLCSocketToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.TCP_IP;
            this.pLCSocketToolStripMenuItem.Name = "pLCSocketToolStripMenuItem";
            this.pLCSocketToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.pLCSocketToolStripMenuItem.Text = "PLC Socket";
            // 
            // softPLCToolStripMenuItem
            // 
            this.softPLCToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.SoftPLC;
            this.softPLCToolStripMenuItem.Name = "softPLCToolStripMenuItem";
            this.softPLCToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.softPLCToolStripMenuItem.Text = "Soft PLC";
            // 
            // cameracalibrationToolStripMenuItem
            // 
            this.cameracalibrationToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.CamCalib;
            this.cameracalibrationToolStripMenuItem.Name = "cameracalibrationToolStripMenuItem";
            this.cameracalibrationToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.cameracalibrationToolStripMenuItem.Text = "Cameracalibration";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menue_Help_Information,
            this.userManualToolStripMenuItem,
            this.analogueInputToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // Menue_Help_Information
            // 
            this.Menue_Help_Information.Name = "Menue_Help_Information";
            this.Menue_Help_Information.Size = new System.Drawing.Size(199, 22);
            this.Menue_Help_Information.Text = "Information";
            this.Menue_Help_Information.Click += new System.EventHandler(this.Menue_Help_Information_Click);
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.userManualToolStripMenuItem.Text = "User Manual";
            // 
            // analogueInputToolStripMenuItem
            // 
            this.analogueInputToolStripMenuItem.Name = "analogueInputToolStripMenuItem";
            this.analogueInputToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.analogueInputToolStripMenuItem.Text = "Analogue Input/Output";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.btn_Password);
            this.groupBox2.Location = new System.Drawing.Point(0, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1270, 65);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // btn_Password
            // 
            this.btn_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Password.Location = new System.Drawing.Point(1214, 10);
            this.btn_Password.Name = "btn_Password";
            this.btn_Password.Size = new System.Drawing.Size(48, 48);
            this.btn_Password.TabIndex = 36;
            this.btn_Password.UseVisualStyleBackColor = true;
            this.btn_Password.Click += new System.EventHandler(this.btn_Password_Click);
            // 
            // Menue_Configuration_Digital_IO
            // 
            this.Menue_Configuration_Digital_IO.Name = "Menue_Configuration_Digital_IO";
            this.Menue_Configuration_Digital_IO.Size = new System.Drawing.Size(186, 26);
            this.Menue_Configuration_Digital_IO.Text = "Digital Input/Output";
            this.Menue_Configuration_Digital_IO.Click += new System.EventHandler(this.Menue_Configuration_Digital_IO_Click);
            // 
            // Form_01_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 841);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_01_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "VisionControl";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraActivationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menue_Help_Information;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analogueInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modbusTCPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCPIPSocketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sickPLRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLCSocketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem softPLCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameracalibrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Password;
        private System.Windows.Forms.ToolStripMenuItem Menue_Configuration_Digital_IO;
    }
}

