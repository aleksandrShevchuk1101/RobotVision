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
    public partial class Form_80_Password : Form
    {
        public Form_80_Password()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (tb_Password.Text == "")
            {
                ClassDaten.structPassword.bSupervisorPassword_OK = false;
                ClassDaten.structPassword.bAdvisorPassword1_OK = false;
                ClassDaten.structPassword.bAdvisorPassword2_OK = false;
                ClassDaten.structPassword.bAdvisorPassword3_OK = false;
                ClassDaten.structPassword.sActUserName = "";
                this.DialogResult = DialogResult.No;
                this.Close();

            }
            else
            {
                if (tb_Password.Text==ClassDaten.structPassword.sSupervisorPassword)
                {
                    ClassDaten.structPassword.bSupervisorPassword_OK = true;
                    ClassDaten.structPassword.bAdvisorPassword1_OK = false;
                    ClassDaten.structPassword.bAdvisorPassword2_OK = false;
                    ClassDaten.structPassword.bAdvisorPassword3_OK = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    if (tb_Password.Text == ClassDaten.structPassword.sAdvisorPassword3)
                    {
                        ClassDaten.structPassword.bSupervisorPassword_OK = false;
                        ClassDaten.structPassword.bAdvisorPassword1_OK = false;
                        ClassDaten.structPassword.bAdvisorPassword2_OK = false;
                        ClassDaten.structPassword.bAdvisorPassword3_OK = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                    {

                    }
                }
            }
        }

        private void cmd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int ProofAutorisation(string sPassword)
        {
            int iResult = 0;

            for (int k = 0; k < ClassDaten.MAX_WORKER; k++)
            {

            }
        } 


    }
}
