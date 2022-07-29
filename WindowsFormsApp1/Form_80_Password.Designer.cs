namespace CS_KEHRATEC
{
    partial class Form_80_Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_80_Password));
            this.btn_OK = new System.Windows.Forms.Button();
            this.cmd_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.Image = ((System.Drawing.Image)(resources.GetObject("btn_OK.Image")));
            this.btn_OK.Location = new System.Drawing.Point(12, 12);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(56, 48);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // cmd_Cancel
            // 
            this.cmd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmd_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("cmd_Cancel.Image")));
            this.cmd_Cancel.Location = new System.Drawing.Point(276, 13);
            this.cmd_Cancel.Name = "cmd_Cancel";
            this.cmd_Cancel.Size = new System.Drawing.Size(48, 48);
            this.cmd_Cancel.TabIndex = 2;
            this.cmd_Cancel.Click += new System.EventHandler(this.cmd_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_Password);
            this.groupBox1.Location = new System.Drawing.Point(12, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 68);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // tb_Password
            // 
            this.tb_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Password.Location = new System.Drawing.Point(16, 24);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(280, 26);
            this.tb_Password.TabIndex = 0;
            // 
            // Form_80_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 166);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.cmd_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form_80_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Password";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button cmd_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Password;
    }
}