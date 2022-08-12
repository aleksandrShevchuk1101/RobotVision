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
using System.Collections;

namespace CS_KEHRATEC
{
    public partial class Form_30_Messages : Form
    {
        public struct MessageData
        {
            public string sDate;
            public string sTime;
            public string sState;
            public string sMessage;
        }
        public struct ErrorText
        {
            public string sErrorNr;
            public string sErrorText;
        }

        public ArrayList MessageList = new ArrayList();
        public ArrayList MessageTextList = new ArrayList();
        public ErrorText structErrortext = new ErrorText();

        string sFileName = ClassDaten.sMESSAGE_PATH + "Messages.txt";
        string sMessageFileName = ClassDaten.sDATA_PATH + "AGPC_OP_Text.txt";
        ushort[] ushOldErrorData;

        const int MAX_MESSAGES = 50;

        public class ComparerClass : IComparer
        {

        }

        public Form_30_Messages(ref ushort[] ushErrorData)
        {
            InitializeComponent();
            this.ushOldErrorData = ushErrorData;
            ReadAllMessages();         
            RefreshListView();
            ReadAllMessagesText();

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
        }

        private void RefreshListView()
        {
            int iNr = 0;
            IEnumerator objMyEnum = MessageList.GetEnumerator();
            MessageData structMessageData= new MessageData();

            ListView.Items.Clear();

            while (objMyEnum.MoveNext())
            {
                iNr++;
                Object obj = objMyEnum.Current;
                structMessageData = (MessageData)obj;
                ListViewItem lvi = new ListViewItem("Dick");
                lvi.SubItems.Add(structMessageData.sDate);
                lvi.SubItems.Add(structMessageData.sTime);
                lvi.SubItems.Add(structMessageData.sState);
                lvi.SubItems.Add(structMessageData.sMessage);
                ListView.Items.Add(lvi);                                                 
            }
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
                MessageData structMessageData = new MessageData();


                try
                {
                    while ((t=r.ReadLine()) !=null)
                    {
                        split = t.Split(delimiter,4);
                        structMessageData.sDate = split[0];
                        structMessageData.sTime =  split[1];
                        structMessageData.sState = split[2];
                        structMessageData.sMessage = split[3];
                        MessageList.Add(structMessageData);

                    }
                    r.Close();
                }
                catch (Exception e)
                {
                    r.Close();
                    MessageBox.Show(e.Message);
                    
                }

            }

        }

        public void ReadAllMessagesText()
        {
            string t, delimStr = ")";
            char[] delimiter = delimStr.ToCharArray();
            string[] split = null;

            if (File.Exists(sMessageFileName))
            {
                FileStream s = new FileStream(sMessageFileName, FileMode.Open);
                StreamReader r = new StreamReader(s, new UnicodeEncoding());
                structErrortext = new ErrorText();

                try
                {
                    while ((t = r.ReadLine()) != null)
                    {
                        split = t.Split(delimiter, 2);
                        structErrortext.sErrorNr = split[0];
                        structErrortext.sErrorText= split[1];
                        MessageTextList.Add(structErrortext);
                    }

                    r.Close();

                }
                catch (Exception e)
                {
                    r.Close();
                    MessageBox.Show("Error while reading messagestrings into memory: " + e.Message);
                }



            }


        }

        private void WriteAllMessages()
        {
            FileStream s;
            StreamWriter w;

            try
            {
                s = new FileStream(sFileName, FileMode.Create);
                w = new StreamWriter(s, new UnicodeEncoding());
                WriteValues(w, MessageList);
                w.Close();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);

            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you really want to delete all messages?", "Delete all messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (result== DialogResult.OK)
            {
                ListView.Items.Clear();
                MessageList.Clear();
                RefreshListView();
                File.Delete(sFileName);

                for (int i = 0; i < this.ushOldErrorData.Length; i++)
                    this.ushOldErrorData[i] = 0;

            }



        }

        public static void WriteValues(StreamWriter w, IEnumerable myList)
        {
            IEnumerator objMyEnum=myList.GetEnumerator();
            MessageData structMessageData = new MessageData();
            while (objMyEnum.MoveNext())
            {
                Object obj = objMyEnum.Current;
                structMessageData = (MessageData)obj;
                w.WriteLine("{0}",
                    structMessageData.sDate + ";" +
                    structMessageData.sTime + ";" + 
                    structMessageData.sState+ ";" +
                    structMessageData.sMessage);
            }
        }
    }
}
