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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_01_Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraActivationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menue_System_Autorisation = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menue_Configuration_Digital_IO = new System.Windows.Forms.ToolStripMenuItem();
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_SavePictures = new System.Windows.Forms.Button();
            this.btn_LifePicture = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_Softkeyboard = new System.Windows.Forms.Button();
            this.lbl_Camera = new System.Windows.Forms.Label();
            this.numUpDown_CamNr = new System.Windows.Forms.NumericUpDown();
            this.btn_ScreenSaver = new System.Windows.Forms.Button();
            this.btn_PrintImage = new System.Windows.Forms.Button();
            this.btn_InspectionPlanLoad = new System.Windows.Forms.Button();
            this.btn_InspectionPlanEdit = new System.Windows.Forms.Button();
            this.btn_Password = new System.Windows.Forms.Button();
            this.gb_Buttons = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label80 = new System.Windows.Forms.Label();
            this.lbl_UserLevel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.menuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_CamNr)).BeginInit();
            this.gb_Buttons.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.Menue_System_Autorisation,
            this.configurationToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // cameraActivationToolStripMenuItem
            // 
            this.cameraActivationToolStripMenuItem.Name = "cameraActivationToolStripMenuItem";
            this.cameraActivationToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cameraActivationToolStripMenuItem.Text = "Camera Activation";
            // 
            // Menue_System_Autorisation
            // 
            this.Menue_System_Autorisation.Name = "Menue_System_Autorisation";
            this.Menue_System_Autorisation.Size = new System.Drawing.Size(172, 22);
            this.Menue_System_Autorisation.Text = "Authorization";
            this.Menue_System_Autorisation.Click += new System.EventHandler(this.Menue_System_Autorisation_Click);
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
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // Menue_Configuration_Digital_IO
            // 
            this.Menue_Configuration_Digital_IO.Name = "Menue_Configuration_Digital_IO";
            this.Menue_Configuration_Digital_IO.Size = new System.Drawing.Size(182, 22);
            this.Menue_Configuration_Digital_IO.Text = "Digital Input/Output";
            this.Menue_Configuration_Digital_IO.Click += new System.EventHandler(this.Menue_Configuration_Digital_IO_Click);
            // 
            // modbusTCPToolStripMenuItem
            // 
            this.modbusTCPToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Modbus;
            this.modbusTCPToolStripMenuItem.Name = "modbusTCPToolStripMenuItem";
            this.modbusTCPToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.modbusTCPToolStripMenuItem.Text = "ModbusTCP";
            // 
            // tCPIPSocketToolStripMenuItem
            // 
            this.tCPIPSocketToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.TCP_IP;
            this.tCPIPSocketToolStripMenuItem.Name = "tCPIPSocketToolStripMenuItem";
            this.tCPIPSocketToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.tCPIPSocketToolStripMenuItem.Text = "TCP_IP_Socket";
            // 
            // sickPLRToolStripMenuItem
            // 
            this.sickPLRToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.Sick_PLR;
            this.sickPLRToolStripMenuItem.Name = "sickPLRToolStripMenuItem";
            this.sickPLRToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.sickPLRToolStripMenuItem.Text = "Sick PLR";
            // 
            // pLCSocketToolStripMenuItem
            // 
            this.pLCSocketToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.TCP_IP;
            this.pLCSocketToolStripMenuItem.Name = "pLCSocketToolStripMenuItem";
            this.pLCSocketToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.pLCSocketToolStripMenuItem.Text = "PLC Socket";
            // 
            // softPLCToolStripMenuItem
            // 
            this.softPLCToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.SoftPLC;
            this.softPLCToolStripMenuItem.Name = "softPLCToolStripMenuItem";
            this.softPLCToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.softPLCToolStripMenuItem.Text = "Soft PLC";
            // 
            // cameracalibrationToolStripMenuItem
            // 
            this.cameracalibrationToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.CamCalib;
            this.cameracalibrationToolStripMenuItem.Name = "cameracalibrationToolStripMenuItem";
            this.cameracalibrationToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cameracalibrationToolStripMenuItem.Text = "Cameracalibration";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
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
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btn_SavePictures);
            this.groupBox2.Controls.Add(this.btn_LifePicture);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.btn_Softkeyboard);
            this.groupBox2.Controls.Add(this.lbl_Camera);
            this.groupBox2.Controls.Add(this.numUpDown_CamNr);
            this.groupBox2.Controls.Add(this.btn_ScreenSaver);
            this.groupBox2.Controls.Add(this.btn_PrintImage);
            this.groupBox2.Controls.Add(this.btn_InspectionPlanLoad);
            this.groupBox2.Controls.Add(this.btn_InspectionPlanEdit);
            this.groupBox2.Controls.Add(this.btn_Password);
            this.groupBox2.Location = new System.Drawing.Point(0, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1270, 65);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(592, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 48);
            this.button3.TabIndex = 35;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(646, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 48);
            this.button2.TabIndex = 35;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(700, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 48);
            this.button1.TabIndex = 35;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_SavePictures
            // 
            this.btn_SavePictures.BackColor = System.Drawing.Color.LightGray;
            this.btn_SavePictures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SavePictures.Image = ((System.Drawing.Image)(resources.GetObject("btn_SavePictures.Image")));
            this.btn_SavePictures.Location = new System.Drawing.Point(6, 10);
            this.btn_SavePictures.Name = "btn_SavePictures";
            this.btn_SavePictures.Size = new System.Drawing.Size(48, 48);
            this.btn_SavePictures.TabIndex = 50;
            this.btn_SavePictures.Tag = "1";
            this.btn_SavePictures.UseVisualStyleBackColor = false;
            this.btn_SavePictures.Click += new System.EventHandler(this.btn_SavePictures_Click);
            // 
            // btn_LifePicture
            // 
            this.btn_LifePicture.BackColor = System.Drawing.Color.LightGray;
            this.btn_LifePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LifePicture.Image = ((System.Drawing.Image)(resources.GetObject("btn_LifePicture.Image")));
            this.btn_LifePicture.Location = new System.Drawing.Point(60, 10);
            this.btn_LifePicture.Name = "btn_LifePicture";
            this.btn_LifePicture.Size = new System.Drawing.Size(48, 48);
            this.btn_LifePicture.TabIndex = 50;
            this.btn_LifePicture.Tag = "1";
            this.btn_LifePicture.UseVisualStyleBackColor = false;
            this.btn_LifePicture.Click += new System.EventHandler(this.btn_LifePicture_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.LightGray;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.Location = new System.Drawing.Point(114, 10);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(48, 48);
            this.button10.TabIndex = 50;
            this.button10.Tag = "1";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.Location = new System.Drawing.Point(169, 10);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(48, 48);
            this.button9.TabIndex = 50;
            this.button9.Tag = "1";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.Location = new System.Drawing.Point(223, 10);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(48, 48);
            this.button8.TabIndex = 50;
            this.button8.Tag = "1";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(277, 9);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(48, 48);
            this.button7.TabIndex = 50;
            this.button7.Tag = "1";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(331, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(48, 48);
            this.button6.TabIndex = 50;
            this.button6.Tag = "1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(385, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(48, 48);
            this.button5.TabIndex = 50;
            this.button5.Tag = "1";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(440, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 48);
            this.button4.TabIndex = 50;
            this.button4.Tag = "1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btn_Softkeyboard
            // 
            this.btn_Softkeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Softkeyboard.Image = ((System.Drawing.Image)(resources.GetObject("btn_Softkeyboard.Image")));
            this.btn_Softkeyboard.Location = new System.Drawing.Point(520, 13);
            this.btn_Softkeyboard.Name = "btn_Softkeyboard";
            this.btn_Softkeyboard.Size = new System.Drawing.Size(48, 48);
            this.btn_Softkeyboard.TabIndex = 50;
            this.btn_Softkeyboard.Tag = "1";
            this.btn_Softkeyboard.UseVisualStyleBackColor = true;
            // 
            // lbl_Camera
            // 
            this.lbl_Camera.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Camera.Image = ((System.Drawing.Image)(resources.GetObject("lbl_Camera.Image")));
            this.lbl_Camera.Location = new System.Drawing.Point(788, 14);
            this.lbl_Camera.Name = "lbl_Camera";
            this.lbl_Camera.Size = new System.Drawing.Size(41, 43);
            this.lbl_Camera.TabIndex = 54;
            // 
            // numUpDown_CamNr
            // 
            this.numUpDown_CamNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numUpDown_CamNr.Location = new System.Drawing.Point(831, 14);
            this.numUpDown_CamNr.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDown_CamNr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown_CamNr.Name = "numUpDown_CamNr";
            this.numUpDown_CamNr.Size = new System.Drawing.Size(47, 44);
            this.numUpDown_CamNr.TabIndex = 53;
            this.numUpDown_CamNr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_ScreenSaver
            // 
            this.btn_ScreenSaver.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ScreenSaver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ScreenSaver.Image = ((System.Drawing.Image)(resources.GetObject("btn_ScreenSaver.Image")));
            this.btn_ScreenSaver.Location = new System.Drawing.Point(932, 11);
            this.btn_ScreenSaver.Name = "btn_ScreenSaver";
            this.btn_ScreenSaver.Size = new System.Drawing.Size(48, 48);
            this.btn_ScreenSaver.TabIndex = 55;
            this.btn_ScreenSaver.Tag = "1";
            this.btn_ScreenSaver.UseVisualStyleBackColor = false;
            this.btn_ScreenSaver.Click += new System.EventHandler(this.btn_ScreenSaver_Click);
            // 
            // btn_PrintImage
            // 
            this.btn_PrintImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_PrintImage.Image = ((System.Drawing.Image)(resources.GetObject("btn_PrintImage.Image")));
            this.btn_PrintImage.Location = new System.Drawing.Point(1014, 11);
            this.btn_PrintImage.Name = "btn_PrintImage";
            this.btn_PrintImage.Size = new System.Drawing.Size(48, 48);
            this.btn_PrintImage.TabIndex = 37;
            this.btn_PrintImage.UseVisualStyleBackColor = true;
            // 
            // btn_InspectionPlanLoad
            // 
            this.btn_InspectionPlanLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_InspectionPlanLoad.Image = ((System.Drawing.Image)(resources.GetObject("btn_InspectionPlanLoad.Image")));
            this.btn_InspectionPlanLoad.Location = new System.Drawing.Point(1097, 11);
            this.btn_InspectionPlanLoad.Name = "btn_InspectionPlanLoad";
            this.btn_InspectionPlanLoad.Size = new System.Drawing.Size(48, 48);
            this.btn_InspectionPlanLoad.TabIndex = 37;
            this.btn_InspectionPlanLoad.UseVisualStyleBackColor = true;
            this.btn_InspectionPlanLoad.Click += new System.EventHandler(this.btn_InspectionPlanLoad_Click);
            // 
            // btn_InspectionPlanEdit
            // 
            this.btn_InspectionPlanEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_InspectionPlanEdit.Image = ((System.Drawing.Image)(resources.GetObject("btn_InspectionPlanEdit.Image")));
            this.btn_InspectionPlanEdit.Location = new System.Drawing.Point(1151, 10);
            this.btn_InspectionPlanEdit.Name = "btn_InspectionPlanEdit";
            this.btn_InspectionPlanEdit.Size = new System.Drawing.Size(57, 48);
            this.btn_InspectionPlanEdit.TabIndex = 37;
            this.btn_InspectionPlanEdit.UseVisualStyleBackColor = true;
            // 
            // btn_Password
            // 
            this.btn_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Password.Image = ((System.Drawing.Image)(resources.GetObject("btn_Password.Image")));
            this.btn_Password.Location = new System.Drawing.Point(1214, 10);
            this.btn_Password.Name = "btn_Password";
            this.btn_Password.Size = new System.Drawing.Size(48, 48);
            this.btn_Password.TabIndex = 36;
            this.btn_Password.UseVisualStyleBackColor = true;
            this.btn_Password.Click += new System.EventHandler(this.btn_Password_Click1);
            // 
            // gb_Buttons
            // 
            this.gb_Buttons.Controls.Add(this.groupBox3);
            this.gb_Buttons.Location = new System.Drawing.Point(900, 98);
            this.gb_Buttons.Name = "gb_Buttons";
            this.gb_Buttons.Size = new System.Drawing.Size(358, 831);
            this.gb_Buttons.TabIndex = 17;
            this.gb_Buttons.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label80);
            this.groupBox3.Controls.Add(this.lbl_UserLevel);
            this.groupBox3.Location = new System.Drawing.Point(12, 481);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 50);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label80.Location = new System.Drawing.Point(9, 16);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(53, 24);
            this.label80.TabIndex = 20;
            this.label80.Text = "User";
            // 
            // lbl_UserLevel
            // 
            this.lbl_UserLevel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_UserLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_UserLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_UserLevel.Location = new System.Drawing.Point(90, 15);
            this.lbl_UserLevel.Name = "lbl_UserLevel";
            this.lbl_UserLevel.Size = new System.Drawing.Size(234, 27);
            this.lbl_UserLevel.TabIndex = 19;
            this.lbl_UserLevel.Text = "Userlevel";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.ItemSize = new System.Drawing.Size(55, 21);
            this.tabControl.Location = new System.Drawing.Point(6, 98);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(877, 652);
            this.tabControl.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(869, 623);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Image";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(863, 617);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(869, 623);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "All Images";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(869, 623);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Value";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(869, 623);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Manual Function";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Form_01_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 841);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.gb_Buttons);
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
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_CamNr)).EndInit();
            this.gb_Buttons.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem Menue_System_Autorisation;
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
        private System.Windows.Forms.Button btn_InspectionPlanEdit;
        private System.Windows.Forms.Button btn_InspectionPlanLoad;
        private System.Windows.Forms.Button btn_PrintImage;
        private System.Windows.Forms.Button btn_ScreenSaver;
        private System.Windows.Forms.NumericUpDown numUpDown_CamNr;
        private System.Windows.Forms.Label lbl_Camera;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_Softkeyboard;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_SavePictures;
        private System.Windows.Forms.Button btn_LifePicture;
        private System.Windows.Forms.GroupBox gb_Buttons;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_UserLevel;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

