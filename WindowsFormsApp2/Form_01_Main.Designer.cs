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
            this.btn_F2_Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_F2_Stop
            // 
            this.btn_F2_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_F2_Stop.Location = new System.Drawing.Point(593, 376);
            this.btn_F2_Stop.Name = "btn_F2_Stop";
            this.btn_F2_Stop.Size = new System.Drawing.Size(184, 58);
            this.btn_F2_Stop.TabIndex = 0;
            this.btn_F2_Stop.Text = "F2 Stop";
            this.btn_F2_Stop.UseVisualStyleBackColor = true;
            this.btn_F2_Stop.Click += new System.EventHandler(this.btn_F2_Stop_Click);
            // 
            // Form_01_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 704);
            this.Controls.Add(this.btn_F2_Stop);
            this.Name = "Form_01_Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_01_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_F2_Stop;
    }
}

