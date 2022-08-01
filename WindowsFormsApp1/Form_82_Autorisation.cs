using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace CS_KEHRATEC
{
    public partial class Form_82_Autorisation : Form
    {
        TextBox[] tb_NamePtr = new TextBox[ClassDaten.MAX_WORKER];
        TextBox[] tb_PasswordPtr = new TextBox[ClassDaten.MAX_WORKER];
        RadioButton[] rb_LoadProgramsPtr = new RadioButton[ClassDaten.MAX_WORKER];
        RadioButton[] rb_EditProgramsPtr = new RadioButton[ClassDaten.MAX_WORKER];

        string sCRYPTO_FILENAME = ClassDaten.sDATA_PATH + "Autorisation.Dat";
        string sCRYPTO_KEY_FILENAME = ClassDaten.sDATA_PATH + "AutorisationKey.Dat";

        private DESCryptoServiceProvider des= new DESCryptoServiceProvider();

        public Form_82_Autorisation()
        {
            InitializeComponent();
            GetAllPointer();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you really want to save Data?", "Save data",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (result== DialogResult.OK)
            {
                foreach (Control c in gb_Autorisation.Controls)
                {
                    if (c.Name.Contains("tb_Name")) ClassDaten.structAutorisation[Convert.ToInt32(c.Tag)].sName = c.Text;
                    if (c.Name.Contains("tb_Password")) ClassDaten.structAutorisation[Convert.ToInt32(c.Tag)].sName = c.Text;
                }

                ClassDaten.structAutorisation[0].bLoadProgrsms = rb_LoadPrograms0.Checked;
                ClassDaten.structAutorisation[1].bLoadProgrsms = rb_LoadPrograms1.Checked;
                ClassDaten.structAutorisation[2].bLoadProgrsms = rb_LoadPrograms2.Checked;
                ClassDaten.structAutorisation[3].bLoadProgrsms = rb_LoadPrograms3.Checked;
                ClassDaten.structAutorisation[4].bLoadProgrsms = rb_LoadPrograms4.Checked;
                ClassDaten.structAutorisation[5].bLoadProgrsms = rb_LoadPrograms5.Checked;
                ClassDaten.structAutorisation[6].bLoadProgrsms = rb_LoadPrograms6.Checked;
                ClassDaten.structAutorisation[7].bLoadProgrsms = rb_LoadPrograms7.Checked;
                ClassDaten.structAutorisation[8].bLoadProgrsms = rb_LoadPrograms8.Checked;
                ClassDaten.structAutorisation[9].bLoadProgrsms = rb_LoadPrograms9.Checked;
                ClassDaten.structAutorisation[10].bLoadProgrsms = rb_LoadPrograms10.Checked;
                ClassDaten.structAutorisation[11].bLoadProgrsms = rb_LoadPrograms11.Checked;

                ClassDaten.structAutorisation[0].bEditPrograms = rb_EditPrograms0.Checked;
                ClassDaten.structAutorisation[1].bEditPrograms = rb_EditPrograms1.Checked;
                ClassDaten.structAutorisation[2].bEditPrograms = rb_EditPrograms2.Checked;
                ClassDaten.structAutorisation[3].bEditPrograms = rb_EditPrograms3.Checked;
                ClassDaten.structAutorisation[4].bEditPrograms = rb_EditPrograms4.Checked;
                ClassDaten.structAutorisation[5].bEditPrograms = rb_EditPrograms5.Checked;
                ClassDaten.structAutorisation[6].bEditPrograms = rb_EditPrograms6.Checked;
                ClassDaten.structAutorisation[7].bEditPrograms = rb_EditPrograms7.Checked;
                ClassDaten.structAutorisation[8].bEditPrograms = rb_EditPrograms8.Checked;
                ClassDaten.structAutorisation[9].bEditPrograms = rb_EditPrograms9.Checked;
                ClassDaten.structAutorisation[10].bEditPrograms = rb_EditPrograms10.Checked;
                ClassDaten.structAutorisation[11].bEditPrograms = rb_EditPrograms11.Checked;


            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void GetAllPointer()
        {
            tb_NamePtr[0] = tb_Name0;
            tb_NamePtr[1] = tb_Name1;
            tb_NamePtr[2] = tb_Name2;
            tb_NamePtr[3] = tb_Name3;
            tb_NamePtr[4] = tb_Name4;
            tb_NamePtr[5] = tb_Name5;
            tb_NamePtr[6] = tb_Name6;
            tb_NamePtr[7] = tb_Name7;
            tb_NamePtr[8] = tb_Name8;
            tb_NamePtr[9] = tb_Name9;
            tb_NamePtr[10] = tb_Name10;
            tb_NamePtr[11] = tb_Name11;

            tb_PasswordPtr[0] = tb_Password0;
            tb_PasswordPtr[1] = tb_Password1;
            tb_PasswordPtr[2] = tb_Password2;
            tb_PasswordPtr[3] = tb_Password3;
            tb_PasswordPtr[4] = tb_Password4;
            tb_PasswordPtr[5] = tb_Password5;
            tb_PasswordPtr[6] = tb_Password6;
            tb_PasswordPtr[7] = tb_Password7;
            tb_PasswordPtr[8] = tb_Password8;
            tb_PasswordPtr[9] = tb_Password9;
            tb_PasswordPtr[10] = tb_Password10;
            tb_PasswordPtr[11] = tb_Password11;


            rb_LoadProgramsPtr[0] = rb_LoadPrograms0;
            rb_LoadProgramsPtr[1] = rb_LoadPrograms1;
            rb_LoadProgramsPtr[2] = rb_LoadPrograms2;
            rb_LoadProgramsPtr[3] = rb_LoadPrograms3;
            rb_LoadProgramsPtr[4] = rb_LoadPrograms4;
            rb_LoadProgramsPtr[5] = rb_LoadPrograms5;
            rb_LoadProgramsPtr[6] = rb_LoadPrograms6;
            rb_LoadProgramsPtr[7] = rb_LoadPrograms7;
            rb_LoadProgramsPtr[8] = rb_LoadPrograms8;
            rb_LoadProgramsPtr[9] = rb_LoadPrograms9;
            rb_LoadProgramsPtr[10] = rb_LoadPrograms10;
            rb_LoadProgramsPtr[11] = rb_LoadPrograms11;

            rb_EditProgramsPtr[0] = rb_EditPrograms0;
            rb_EditProgramsPtr[1] = rb_EditPrograms1;
            rb_EditProgramsPtr[2] = rb_EditPrograms2;
            rb_EditProgramsPtr[3] = rb_EditPrograms3;
            rb_EditProgramsPtr[4] = rb_EditPrograms4;
            rb_EditProgramsPtr[5] = rb_EditPrograms5;
            rb_EditProgramsPtr[6] = rb_EditPrograms6;
            rb_EditProgramsPtr[7] = rb_EditPrograms7;
            rb_EditProgramsPtr[8] = rb_EditPrograms8;
            rb_EditProgramsPtr[9] = rb_EditPrograms9;
            rb_EditProgramsPtr[10] = rb_EditPrograms10;
            rb_EditProgramsPtr[11] = rb_EditPrograms11;
        }

        public void ReadCryptoData()
        {
            int iTextLenght = 0;

        }

        public void WriteCryptData()
        {
            byte[] byteArr = new byte[128];
            ICryptoTransform desEncrypt= des.CreateDecryptor();

            FileStream fs = new FileStream(sCRYPTO_FILENAME, FileMode.Create, FileAccess.Write);

            CryptoStream cryptoStrm = new CryptoStream(fs, desEncrypt, CryptoStreamMode.Write);


            for (int i = 0; i < ClassDaten.MAX_WORKER; i++)
            {
                byteArr[0] = (byte)tb_NamePtr[i].Text.Length;
                cryptoStrm.Write(byteArr, 0, 1);

                for (int k = 0; k < tb_NamePtr[i].Text.Length; k++)
                {
                    byteArr[k] = (byte)tb_NamePtr[i].Text[k];
                }
                cryptoStrm.Write(byteArr, 0, tb_NamePtr[i].Text.Length);


                byteArr[0] = (byte)tb_PasswordPtr[i].Text.Length;
                cryptoStrm.Write(byteArr, 0, 1);
                for (int k = 0; k < tb_PasswordPtr[i].Text.Length; k++)
                {
                    byteArr[k] = (byte)tb_PasswordPtr[i].Text[k];
                }
                cryptoStrm.Write(byteArr, 0, tb_PasswordPtr[i].Text.Length);

                if (rb_LoadProgramsPtr[i].Checked)
                    byteArr[0] = 1;
                else
                    byteArr[0] = 0;
                cryptoStrm.Write(byteArr, 0, 1);

                if (rb_EditProgramsPtr[i].Checked)
                    byteArr[0] = 1;
                else
                    byteArr[0] = 0;
                cryptoStrm.Write(byteArr, 0, 1);
            }
            cryptoStrm.Close();

            FileStream s = new FileStream(sCRYPTO_KEY_FILENAME, FileMode.Create, FileAccess.Write);
            BinaryWriter b = new BinaryWriter(s);
            b.Write(des.Key);
            b.Write(des.IV);
            b.Close();
            s.Close();
        }
    }
}
