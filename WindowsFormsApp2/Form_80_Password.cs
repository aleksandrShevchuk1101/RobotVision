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
            tb_Password.Text = "";
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (tb_Password.Text=="")
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
                    ClassDaten.structPassword.sActUserName = "";
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
                        ClassDaten.structPassword.sActUserName = "";
                        this.Close();
                    }
                    else
                    {
                        if (ProofAutorisation(tb_Password.Text)==2)
                        {
                            ClassDaten.structPassword.sActUserName = GetActUserName(tb_Password.Text);
                            ClassDaten.structPassword.bSupervisorPassword_OK = false;
                            ClassDaten.structPassword.bAdvisorPassword1_OK = false;
                            ClassDaten.structPassword.bAdvisorPassword2_OK = true;
                            ClassDaten.structPassword.bAdvisorPassword3_OK = false;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            if (ProofAutorisation(tb_Password.Text)==1)
                            {
                                ClassDaten.structPassword.sActUserName = GetActUserName(tb_Password.Text);
                                ClassDaten.structPassword.bSupervisorPassword_OK = false;
                                ClassDaten.structPassword.bAdvisorPassword1_OK = true;
                                ClassDaten.structPassword.bAdvisorPassword2_OK = false;
                                ClassDaten.structPassword.bAdvisorPassword3_OK = false;
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Keine Zugangsberechtigung!", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                ClassDaten.structPassword.bSupervisorPassword_OK = false;
                                ClassDaten.structPassword.bAdvisorPassword1_OK = false;
                                ClassDaten.structPassword.bAdvisorPassword2_OK = false;
                                ClassDaten.structPassword.bAdvisorPassword3_OK = false;

                            }
                        }
                    }
                }
            }
        }

        private string GetActUserName(string sPassword)
        {
            string sUserName = string.Empty;
            for (int k = 0; k < ClassDaten.MAX_WORKER; k++)
            {
                if (sPassword == ClassDaten.structAutorisation[k].sPassword)
                    sUserName = ClassDaten.structAutorisation[k].sName;
            }
            return sUserName;
        }

        private void cmd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void OnShown(object Sender, EventArgs e)
        {
            tb_Password.Text = "";
            if (tb_Password.CanFocus)
                tb_Password.Focus();
        }

        private void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_OK_Click(this, e);

        }


        private void OnClick(object sender, EventArgs e)
        {
            ClassDLLImports.LoadSoftkeyboard(true);
        }

        public int ProofAutorisation(string sPassword)
        {
            int iResult = 0;
            for (int k = 0; k < ClassDaten.MAX_WORKER; k++)
            {
                if ((sPassword == ClassDaten.structAutorisation[k].sPassword) &&
                        (ClassDaten.structAutorisation[k].bLoadPrograms))
                {
                    iResult = 1;
                }
                if ((sPassword == ClassDaten.structAutorisation[k].sPassword) &&
                        (ClassDaten.structAutorisation[k].bEditPrograms))
                {
                    iResult = 2;
                }
            }
            return iResult;
        }


        public void Reset()
        {
            ClassDaten.structPassword.bAdvisorPassword1_OK = false;
            ClassDaten.structPassword.bAdvisorPassword2_OK = false;
            ClassDaten.structPassword.bAdvisorPassword3_OK = false;
            ClassDaten.structPassword.bSupervisorPassword_OK = false;
            ClassDaten.structPassword.sActUserName = "";
        }



    }
}
