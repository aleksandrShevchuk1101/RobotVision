using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace CS_KEHRATEC
{
    public class ClassIniFile
    {
        string sFileName;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);


        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
          string key, string def, StringBuilder retVal,
          int size, string filePath);


        public ClassIniFile(string sIniFileName)
        {
            this.sFileName = sIniFileName;
        }

        public static bool ReadBinaryData(string sFileName, out byte[] Data)
        {
            BinaryReader b = null;
            Data = null;

            try
            {
                if (File.Exists(sFileName))
                {
                    using (b = new BinaryReader(File.OpenRead(sFileName)))
                    {
                        int iLenght = (int)b.BaseStream.Length;
                        Data = b.ReadBytes(iLenght);
                    }
                    b.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error at ReadBinarydata : " + e.Message);
                b.Close();
            }

            return false;

        }

        public string ReadString(string sSection, string sKey, string sDefault)
        {
            try
            {
                string sPath = Path.GetFullPath(this.sFileName);
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(sSection, sKey, sDefault, temp, 255, sPath);
                return temp.ToString();


            }
            catch (Exception e)
            {
                MessageBox.Show("Error at ReadString : " + e.Message);
                return sDefault;

            }
        }

        public static bool WriteBinaryData(string sFileName, byte[] Data)
        {
            BinaryWriter Writer = null;

            try
            {
                Writer = new BinaryWriter(File.OpenWrite(sFileName));


                Writer.Write(Data);
                Writer.Flush();
                Writer.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error at WriteBinarydata : " + e.Message);
                Writer.Flush();
                Writer.Close();
            }
            return false;
        }
        public void WriteString(string sSection, string sKey, string sValue)
        {
            try
            {
                string sPath = Path.GetFullPath(this.sFileName);
                WritePrivateProfileString(sSection, sKey, sValue, sPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error at WriteString :" + e.Message);

            }
        }

        public static void WriteLogBook(string sFileName, string sUser, string sUserName, string sString)
        {
            const int MAX_STRINGS = 500;
            DateTime Dtime = DateTime.Now;
            string sDateTime = Dtime.ToString();
            string[] sArrText = new string[MAX_STRINGS];
            string t = string.Empty;
            int iStringCount = 0;
            string sPath = "..\\..\\..\\" + ClassDaten.sUnitName + "\\Messages\\";

            string sDataString = sDateTime + " " +
                                 string.Format("{0,-15}", sUser) +
                                 string.Format("{0,-20}", sUserName) +
                                 string.Format("{0,-50}", sString);

            FileStream s;
            StreamWriter w;

            if (File.Exists(sPath + sFileName))
            {

                s = new FileStream(sPath + sFileName, FileMode.Open);
                StreamReader r = new StreamReader(s, new UnicodeEncoding());


                try
                {
                    iStringCount = 0;
                    while (((t = r.ReadLine()) != null) && (iStringCount < MAX_STRINGS - 1))
                    {
                        sArrText[iStringCount] = t;
                        iStringCount++;
                    }
                    r.Close();
                    s.Close();


                }
                catch (Exception e)
                {
                    r.Close();
                    s.Close();
                    MessageBox.Show("Error at WriteLogBook :" + e.Message);
                    MessageBox.Show(e.Message);
                }

                File.Delete(sPath + sFileName);

            }

            if (File.Exists(sPath + sFileName))
            {
                try
                {
                    s = new FileStream(sPath + sFileName, FileMode.Append);
                    w = new StreamWriter(s, new UnicodeEncoding());

                    w.WriteLine(sDataString);

                    for (int i = 0; i < iStringCount; i++)
                        w.WriteLine(sArrText[i]);

                    w.Close();
                    s.Close();

                }
                catch (Exception e)
                {

                    MessageBox.Show("Error at WriteLogBook :" + e.Message);
                }

            }
            else
            {

                try
                {

                    if (Directory.Exists(sPath))
                    {
                        s = new FileStream(sPath + sFileName, FileMode.Create);
                        w = new StreamWriter(s, new UnicodeEncoding());
                        w.WriteLine(sDataString);
                        for (int i = 0; i < iStringCount; i++)
                            w.WriteLine(sArrText[i]);
                        w.Close();
                        s.Close();

                    }
                    else
                        return;

                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at WriteLogBook :" + e.Message);

                }
            }
        }

        public static void WriteTelegramm(string sFileName, string sString)
        {
            FileStream s;
            StreamWriter w;


            if (File.Exists(sFileName))
            {
                File.Delete(sFileName);
            }

            if (File.Exists(sFileName))
            {
                try
                {
                    s = new FileStream(sFileName, FileMode.Append);
                    w = new StreamWriter(s);

                    w.WriteLine(sString);
                    w.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error at WriteTelegram :" + e.Message);
                }
            }
            else
            {
                try
                {
                    s = new FileStream(sFileName, FileMode.Create);
                    w = new StreamWriter(s);
                    w.WriteLine(sString);
                    w.Close();

                }
                catch (Exception e)
                {

                    MessageBox.Show("Error at WriteTelegram :" + e.Message);
                }
            }

        }

    }
}