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

        private void Menue_System_Autorisation_Click(object sender, EventArgs e)
        {

            //if (IsAllowed((int)ClassDaten.PasswordType.Advisor2))
            //{
                Form_82_Autorisation formAutorisation = new Form_82_Autorisation();
                formAutorisation.ShowDialog();
            //}

        }

        public bool IsAllowed(int Mode)
        {
            Form_80_Password form_Password = new Form_80_Password();
            bool bPassWordOK = false;

            switch (Mode)
            {
                case (int)ClassDaten.PasswordType.Advisor1:
                    if (ClassDaten.structPassword.bAdvisorPassword1_OK ||
                        ClassDaten.structPassword.bAdvisorPassword2_OK ||
                        ClassDaten.structPassword.bAdvisorPassword3_OK ||
                        ClassDaten.structPassword.bSupervisorPassword_OK)
                        bPassWordOK = true;
                    break;
                case (int)ClassDaten.PasswordType.Advisor2:
                    if (ClassDaten.structPassword.bAdvisorPassword2_OK ||
                        ClassDaten.structPassword.bAdvisorPassword3_OK ||
                        ClassDaten.structPassword.bSupervisorPassword_OK)
                        bPassWordOK = true;
                    break;
                case (int)ClassDaten.PasswordType.Advisor3:
                    if (ClassDaten.structPassword.bAdvisorPassword3_OK ||
                        ClassDaten.structPassword.bSupervisorPassword_OK)
                        bPassWordOK = true;
                    break;
                case (int)ClassDaten.PasswordType.Supervisor:
                    if (ClassDaten.structPassword.bSupervisorPassword_OK)
                        bPassWordOK = true;
                    break;
            }

            if (bPassWordOK)
                return true;
            else
            {
                MessageBox.Show("Log on required !!!");
                return false;
            }


        }



        private void ShowPasswordLevel()
        {
            if (ClassDaten.structPassword.sActUserName != string.Empty)
            {

                if (ClassDaten.structPassword.bAdvisorPassword3_OK)
                    ClassDaten.structPassword.sActUserName = "Admin";
                lbl_UserLevel.Text = ClassDaten.structPassword.sActUserName;
            }
            else
            {
                if (ClassDaten.structPassword.bSupervisorPassword_OK)
                {
                    ClassDaten.structSystemData.sUserLevel = "SUPERVISOR";
                    ClassDaten.structPassword.sActUserName = "";
                }
                else
                {
                    if (ClassDaten.structPassword.bAdvisorPassword1_OK)
                        ClassDaten.structSystemData.sUserLevel = "ADVISOR1";
                    else
                    {
                        if (ClassDaten.structPassword.bAdvisorPassword2_OK)
                            ClassDaten.structSystemData.sUserLevel = "ADVISOR2";
                        else
                        {
                            if (ClassDaten.structPassword.bAdvisorPassword3_OK)
                                ClassDaten.structSystemData.sUserLevel = "Admin";
                            else
                                ClassDaten.structSystemData.sUserLevel = "";
                        }
                    }
                }
                lbl_UserLevel.Text = ClassDaten.structSystemData.sUserLevel;
            }
        }
    

     }

}
