using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_KEHRATEC
{
    public enum SavePicture {OnlyOK, OnlyNOK, All };
    public partial class Form_06_SavePictureSelect : Form
    {
        int iValue = 0;
        public Form_06_SavePictureSelect()
        {
            InitializeComponent();
            iValue = ClassDaten.structSystemData.iSavePictureMode;
            switch (ClassDaten.structSystemData.iSavePictureMode)
            {
                case (int)SavePicture.OnlyOK:
                    rb_OnlyOK.Checked = true;
                    break;
                case (int)SavePicture.OnlyNOK:
                    rb_OnlyNOK.Checked = true;
                    break;
                case (int)SavePicture.All:
                    rb_OnlyOK.Checked = true;
                    break;
            }

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

        }

        private void cmd_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            ClassDaten.structSystemData.iSavePictureMode = this.iValue;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton myRadioButton = (RadioButton)sender;
            this.iValue =Convert.ToInt32(myRadioButton.Tag);
        }
    }
}
