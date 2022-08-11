using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CS_KEHRATEC
{
    public partial class Form_30_Messages : Form
    {


        string sFileName = ClassDaten.sMESSAGE_PATH + "Messages.txt";
        public Form_30_Messages()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


        public void ReadAllMessages()
        {
            string t, delimStr = ";";
            char[] delimiter = delimStr.ToCharArray();
            string[] split = null;


            if (File.Exists(sFileName))
            {
                FileStream s = new FileStream(sFileName, FileMode.Open);
                StreamReader r = new StreamReader(s, new UnicodeEncoding());

            }

        }
    }
}
