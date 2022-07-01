namespace CS_KEHRATEC
{
    partial class Form_02_InspectionPlanLoad
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
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Help = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Comment = new System.Windows.Forms.Label();
            this.cb_InspectionPlanName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_Picture = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.gb_Picture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(716, 12);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(48, 48);
            this.btn_Load.TabIndex = 0;
            this.btn_Load.Text = "button1";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_Help
            // 
            this.btn_Help.Location = new System.Drawing.Point(783, 12);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(48, 48);
            this.btn_Help.TabIndex = 0;
            this.btn_Help.Text = "button2";
            this.btn_Help.UseVisualStyleBackColor = true;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(847, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(48, 48);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.Text = "button3";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Comment);
            this.groupBox1.Controls.Add(this.cb_InspectionPlanName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 165);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choise";
            // 
            // lbl_Comment
            // 
            this.lbl_Comment.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Comment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Comment.Location = new System.Drawing.Point(10, 119);
            this.lbl_Comment.Name = "lbl_Comment";
            this.lbl_Comment.Size = new System.Drawing.Size(497, 24);
            this.lbl_Comment.TabIndex = 3;
            // 
            // cb_InspectionPlanName
            // 
            this.cb_InspectionPlanName.Location = new System.Drawing.Point(10, 54);
            this.cb_InspectionPlanName.Name = "cb_InspectionPlanName";
            this.cb_InspectionPlanName.Size = new System.Drawing.Size(497, 28);
            this.cb_InspectionPlanName.Sorted = true;
            this.cb_InspectionPlanName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Comment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inspection Plan Name";
            // 
            // gb_Picture
            // 
            this.gb_Picture.Controls.Add(this.pictureBox1);
            this.gb_Picture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_Picture.Location = new System.Drawing.Point(552, 82);
            this.gb_Picture.Name = "gb_Picture";
            this.gb_Picture.Size = new System.Drawing.Size(359, 288);
            this.gb_Picture.TabIndex = 16;
            this.gb_Picture.TabStop = false;
            this.gb_Picture.Text = "Image";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(21, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form_02_InspectionPlanLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 383);
            this.ControlBox = false;
            this.Controls.Add(this.gb_Picture);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Help);
            this.Controls.Add(this.btn_Load);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form_02_InspectionPlanLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Inspection Plan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_Picture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_Help;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_InspectionPlanName;
        private System.Windows.Forms.Label lbl_Comment;
        private System.Windows.Forms.GroupBox gb_Picture;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}