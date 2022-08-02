namespace CS_KEHRATEC
{
    partial class Form_06_SavePictureSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_06_SavePictureSelect));
            this.btn_Close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rb_OnlyNOK = new System.Windows.Forms.RadioButton();
            this.rb_OnlyOK = new System.Windows.Forms.RadioButton();
            this.btn_Load = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.Location = new System.Drawing.Point(450, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(48, 48);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.rb_OnlyNOK);
            this.groupBox1.Controls.Add(this.rb_OnlyOK);
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 157);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton1.Location = new System.Drawing.Point(24, 98);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(434, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All Images";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rb_OnlyNOK
            // 
            this.rb_OnlyNOK.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_OnlyNOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_OnlyNOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_OnlyNOK.Location = new System.Drawing.Point(24, 68);
            this.rb_OnlyNOK.Name = "rb_OnlyNOK";
            this.rb_OnlyNOK.Size = new System.Drawing.Size(434, 24);
            this.rb_OnlyNOK.TabIndex = 0;
            this.rb_OnlyNOK.TabStop = true;
            this.rb_OnlyNOK.Text = "NOK Images Only";
            this.rb_OnlyNOK.UseVisualStyleBackColor = true;
            // 
            // rb_OnlyOK
            // 
            this.rb_OnlyOK.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_OnlyOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_OnlyOK.Location = new System.Drawing.Point(24, 38);
            this.rb_OnlyOK.Name = "rb_OnlyOK";
            this.rb_OnlyOK.Size = new System.Drawing.Size(434, 24);
            this.rb_OnlyOK.TabIndex = 0;
            this.rb_OnlyOK.TabStop = true;
            this.rb_OnlyOK.Text = "OK Images Only";
            this.rb_OnlyOK.UseVisualStyleBackColor = true;
            // 
            // btn_Load
            // 
            this.btn_Load.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Load.Image = ((System.Drawing.Image)(resources.GetObject("btn_Load.Image")));
            this.btn_Load.Location = new System.Drawing.Point(391, 12);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(48, 48);
            this.btn_Load.TabIndex = 15;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // Form_06_SavePictureSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 242);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Close);
            this.Name = "Form_06_SavePictureSelect";
            this.Text = "Choice Images to Save";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_OnlyNOK;
        private System.Windows.Forms.RadioButton rb_OnlyOK;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btn_Load;
    }
}