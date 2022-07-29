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
    public partial class Form_01_Main : Form
    {
        public Form_01_Main()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ProofRunState())
            {
                this.Close();
            }
        }


        private bool ProofRunState()
        {
            if (ClassDaten.structSystemData.bRunState)
            {
                MessageBox.Show("Please push the STOP - Button first!!!");
                return true;

            }
            return false;
        }

        private void Menue_Help_Information_Click(object sender, EventArgs e)
        {
            Form_91_Info form_Info = new Form_91_Info();
            form_Info.ShowDialog();
        }

        private void btn_Password_Click1(object sender, EventArgs e)
        {
            Form_80_Password formPassword = new Form_80_Password();
            formPassword.ShowDialog();
        }

        private void btn_Password_Click_1(object sender, EventArgs e)
        {

        }


        private void digitalInputToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Menue_Configuration_Digital_IO_Click(object sender, EventArgs e)
        {
            Form_95_DIDO_32 form_DIDO = new Form_95_DIDO_32("");
            form_DIDO.ShowDialog();
        }

        private void btn_ScreenSaver_Click(object sender, EventArgs e)
        {

        }

        private void btn_Softkeyboard_Click(object sender, EventArgs e)
        {

        }

        private void btn_BDE_Click(object sender, EventArgs e)
        {

        }
    }
}
