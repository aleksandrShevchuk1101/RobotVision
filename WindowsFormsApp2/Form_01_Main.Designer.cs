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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_01_Main));
            this.btn_F2_Stop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl_UserLevel = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpPicture = new System.Windows.Forms.TabPage();
            this.listBoxMesValue = new System.Windows.Forms.ListBox();
            this.btn_Edit_Tolerance = new System.Windows.Forms.Button();
            this.tpAllPictures = new System.Windows.Forms.TabPage();
            this.tpValues = new System.Windows.Forms.TabPage();
            this.tpManualMode_SlitDisk1 = new System.Windows.Forms.TabPage();
            this.tpManualMode_GlasDisk1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_MesControl = new System.Windows.Forms.Button();
            this.btn_BDE = new System.Windows.Forms.Button();
            this.btn_Error = new System.Windows.Forms.Button();
            this.btn_LightControl = new System.Windows.Forms.Button();
            this.btn_LifePicture = new System.Windows.Forms.Button();
            this.btn_InspectionPlanEdit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip7 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menue_Help_Information = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpPicture.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_F2_Stop
            // 
            this.btn_F2_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_F2_Stop.Location = new System.Drawing.Point(13, 72);
            this.btn_F2_Stop.Name = "btn_F2_Stop";
            this.btn_F2_Stop.Size = new System.Drawing.Size(153, 36);
            this.btn_F2_Stop.TabIndex = 0;
            this.btn_F2_Stop.Tag = "104";
            this.btn_F2_Stop.Text = "F2 Stop";
            this.btn_F2_Stop.UseVisualStyleBackColor = true;
            this.btn_F2_Stop.Click += new System.EventHandler(this.btn_F2_Stop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_F2_Stop);
            this.groupBox1.Location = new System.Drawing.Point(12, 537);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 118);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(900, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 831);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_UserLevel);
            this.groupBox4.Controls.Add(this.label80);
            this.groupBox4.Location = new System.Drawing.Point(12, 481);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 50);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
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
            // label80
            // 
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label80.Location = new System.Drawing.Point(9, 16);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(53, 24);
            this.label80.TabIndex = 0;
            this.label80.Text = "User";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 823);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1274, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel.Text = "State";
            // 
            // timer1
            // 
            this.timer1.Interval = 60;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpPicture);
            this.tabControl.Controls.Add(this.tpAllPictures);
            this.tabControl.Controls.Add(this.tpValues);
            this.tabControl.Controls.Add(this.tpManualMode_SlitDisk1);
            this.tabControl.Controls.Add(this.tpManualMode_GlasDisk1);
            this.tabControl.Location = new System.Drawing.Point(6, 98);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(877, 652);
            this.tabControl.TabIndex = 4;
            // 
            // tpPicture
            // 
            this.tpPicture.Controls.Add(this.listBoxMesValue);
            this.tpPicture.Controls.Add(this.btn_Edit_Tolerance);
            this.tpPicture.Location = new System.Drawing.Point(4, 22);
            this.tpPicture.Name = "tpPicture";
            this.tpPicture.Padding = new System.Windows.Forms.Padding(3);
            this.tpPicture.Size = new System.Drawing.Size(869, 626);
            this.tpPicture.TabIndex = 0;
            this.tpPicture.Text = "Image";
            this.tpPicture.UseVisualStyleBackColor = true;
            // 
            // listBoxMesValue
            // 
            this.listBoxMesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxMesValue.FormattingEnabled = true;
            this.listBoxMesValue.ItemHeight = 20;
            this.listBoxMesValue.Location = new System.Drawing.Point(6, 15);
            this.listBoxMesValue.Name = "listBoxMesValue";
            this.listBoxMesValue.Size = new System.Drawing.Size(831, 484);
            this.listBoxMesValue.TabIndex = 141;
            // 
            // btn_Edit_Tolerance
            // 
            this.btn_Edit_Tolerance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Edit_Tolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit_Tolerance.Location = new System.Drawing.Point(301, 567);
            this.btn_Edit_Tolerance.Name = "btn_Edit_Tolerance";
            this.btn_Edit_Tolerance.Size = new System.Drawing.Size(112, 27);
            this.btn_Edit_Tolerance.TabIndex = 3;
            this.btn_Edit_Tolerance.Text = "Ändern";
            this.toolTip3.SetToolTip(this.btn_Edit_Tolerance, "System starten");
            this.btn_Edit_Tolerance.UseVisualStyleBackColor = false;
            this.btn_Edit_Tolerance.Click += new System.EventHandler(this.btn_Edit_Tolerance_Click);
            // 
            // tpAllPictures
            // 
            this.tpAllPictures.Location = new System.Drawing.Point(4, 22);
            this.tpAllPictures.Name = "tpAllPictures";
            this.tpAllPictures.Padding = new System.Windows.Forms.Padding(3);
            this.tpAllPictures.Size = new System.Drawing.Size(869, 626);
            this.tpAllPictures.TabIndex = 1;
            this.tpAllPictures.Text = "All Images";
            this.tpAllPictures.UseVisualStyleBackColor = true;
            // 
            // tpValues
            // 
            this.tpValues.Location = new System.Drawing.Point(4, 22);
            this.tpValues.Name = "tpValues";
            this.tpValues.Size = new System.Drawing.Size(869, 626);
            this.tpValues.TabIndex = 2;
            this.tpValues.Text = "Values";
            this.tpValues.UseVisualStyleBackColor = true;
            // 
            // tpManualMode_SlitDisk1
            // 
            this.tpManualMode_SlitDisk1.Location = new System.Drawing.Point(4, 22);
            this.tpManualMode_SlitDisk1.Name = "tpManualMode_SlitDisk1";
            this.tpManualMode_SlitDisk1.Size = new System.Drawing.Size(869, 626);
            this.tpManualMode_SlitDisk1.TabIndex = 3;
            this.tpManualMode_SlitDisk1.Text = "Manual Funktion";
            this.tpManualMode_SlitDisk1.UseVisualStyleBackColor = true;
            // 
            // tpManualMode_GlasDisk1
            // 
            this.tpManualMode_GlasDisk1.Location = new System.Drawing.Point(4, 22);
            this.tpManualMode_GlasDisk1.Name = "tpManualMode_GlasDisk1";
            this.tpManualMode_GlasDisk1.Size = new System.Drawing.Size(869, 626);
            this.tpManualMode_GlasDisk1.TabIndex = 4;
            this.tpManualMode_GlasDisk1.Text = "Manual Function";
            this.tpManualMode_GlasDisk1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox3.Controls.Add(this.btn_MesControl);
            this.groupBox3.Controls.Add(this.btn_BDE);
            this.groupBox3.Controls.Add(this.btn_Error);
            this.groupBox3.Controls.Add(this.btn_LightControl);
            this.groupBox3.Controls.Add(this.btn_LifePicture);
            this.groupBox3.Controls.Add(this.btn_InspectionPlanEdit);
            this.groupBox3.Location = new System.Drawing.Point(0, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1909, 65);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // btn_MesControl
            // 
            this.btn_MesControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MesControl.Location = new System.Drawing.Point(646, 11);
            this.btn_MesControl.Name = "btn_MesControl";
            this.btn_MesControl.Size = new System.Drawing.Size(48, 48);
            this.btn_MesControl.TabIndex = 38;
            this.toolTip1.SetToolTip(this.btn_MesControl, "Systemcheck");
            this.btn_MesControl.UseVisualStyleBackColor = true;
            this.btn_MesControl.Click += new System.EventHandler(this.btn_MesControl_Click);
            // 
            // btn_BDE
            // 
            this.btn_BDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BDE.Location = new System.Drawing.Point(440, 11);
            this.btn_BDE.Name = "btn_BDE";
            this.btn_BDE.Size = new System.Drawing.Size(48, 48);
            this.btn_BDE.TabIndex = 24;
            this.toolTip2.SetToolTip(this.btn_BDE, "LiveData");
            this.btn_BDE.UseVisualStyleBackColor = true;
            this.btn_BDE.Click += new System.EventHandler(this.btn_BDE_Click);
            // 
            // btn_Error
            // 
            this.btn_Error.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Error.Location = new System.Drawing.Point(700, 11);
            this.btn_Error.Name = "btn_Error";
            this.btn_Error.Size = new System.Drawing.Size(48, 48);
            this.btn_Error.TabIndex = 35;
            this.toolTip4.SetToolTip(this.btn_Error, "Errormessages");
            this.btn_Error.UseVisualStyleBackColor = false;
            this.btn_Error.Click += new System.EventHandler(this.btn_Error_Click);
            // 
            // btn_LightControl
            // 
            this.btn_LightControl.BackColor = System.Drawing.Color.LightGray;
            this.btn_LightControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LightControl.Location = new System.Drawing.Point(169, 10);
            this.btn_LightControl.Name = "btn_LightControl";
            this.btn_LightControl.Size = new System.Drawing.Size(48, 48);
            this.btn_LightControl.TabIndex = 16;
            this.toolTip5.SetToolTip(this.btn_LightControl, "Light Control");
            this.btn_LightControl.UseVisualStyleBackColor = false;
            this.btn_LightControl.Click += new System.EventHandler(this.btn_LightControl_Click);
            // 
            // btn_LifePicture
            // 
            this.btn_LifePicture.BackColor = System.Drawing.Color.LightGray;
            this.btn_LifePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LifePicture.Image = ((System.Drawing.Image)(resources.GetObject("btn_LifePicture.Image")));
            this.btn_LifePicture.Location = new System.Drawing.Point(60, 10);
            this.btn_LifePicture.Name = "btn_LifePicture";
            this.btn_LifePicture.Size = new System.Drawing.Size(48, 48);
            this.btn_LifePicture.TabIndex = 15;
            this.toolTip6.SetToolTip(this.btn_LifePicture, "Lifeimage");
            this.btn_LifePicture.UseVisualStyleBackColor = false;
            this.btn_LifePicture.Click += new System.EventHandler(this.btn_LifePicture_Click);
            // 
            // btn_InspectionPlanEdit
            // 
            this.btn_InspectionPlanEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InspectionPlanEdit.Location = new System.Drawing.Point(1151, 10);
            this.btn_InspectionPlanEdit.Name = "btn_InspectionPlanEdit";
            this.btn_InspectionPlanEdit.Size = new System.Drawing.Size(57, 48);
            this.btn_InspectionPlanEdit.TabIndex = 17;
            this.toolTip7.SetToolTip(this.btn_InspectionPlanEdit, "Edit Inspectionplan");
            this.btn_InspectionPlanEdit.Click += new System.EventHandler(this.btn_InspectionPlanEdit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1274, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menue_Help_Information});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // Menue_Help_Information
            // 
            this.Menue_Help_Information.Name = "Menue_Help_Information";
            this.Menue_Help_Information.Size = new System.Drawing.Size(180, 22);
            this.Menue_Help_Information.Text = "Information";
            this.Menue_Help_Information.Click += new System.EventHandler(this.Menue_Help_Information_Click);
            // 
            // Form_01_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 845);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_01_Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_01_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpPicture.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_F2_Stop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpPicture;
        private System.Windows.Forms.TabPage tpAllPictures;
        private System.Windows.Forms.TabPage tpValues;
        private System.Windows.Forms.TabPage tpManualMode_SlitDisk1;
        private System.Windows.Forms.TabPage tpManualMode_GlasDisk1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_MesControl;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_UserLevel;
        private System.Windows.Forms.ListBox listBoxMesValue;
        private System.Windows.Forms.Button btn_BDE;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Button btn_Edit_Tolerance;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.Button btn_Error;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.Button btn_LightControl;
        private System.Windows.Forms.ToolTip toolTip5;
        private System.Windows.Forms.Button btn_LifePicture;
        private System.Windows.Forms.ToolTip toolTip6;
        private System.Windows.Forms.Button btn_InspectionPlanEdit;
        private System.Windows.Forms.ToolTip toolTip7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menue_Help_Information;
    }
}

