using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS_KEHRATEC
{
    using System.Data.OleDb;
    public partial class Form_02_InspectionPlanLoad : Form
    {
        string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + ClassDaten.sDATA_PATH + "ApplicationDB.mdb;";
        string sSelectInspectionPlanBez = "SELECT InspectionPlanName, Comment FROM InspectionPlan";

        OleDbConnection conn = null;

        OleDbDataAdapter daInspectionPlan = null;
        DataSet dr = null;

        const string INI_FILENAME = "Application.ini";
        const string INI_SECTION = "LoadInspectionPlan";

        public Form_02_InspectionPlanLoad()
        {
            InitializeComponent();
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            string sFileName= ClassDaten.sHELP_PATH + "Help_InspectionPlanLoad.pdf";

            try
            {
                System.Diagnostics.Process.Start(sFileName);
            }
            catch (Exception myException)
            {

                MessageBox.Show("Error while loading file " + sFileName + "! " + myException.Message);

            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Do you really want to load data from file " + cb_InspectionPlanName.Text + "?", "Load data", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (result == DialogResult.OK)
            {
                LoadAllInspectionPlanData(cb_InspectionPlanName.Text);
                ClassIniFile.WriteLogBook(ClassDaten.LOGBOOK_FILENAME, ClassDaten.structSystemData.sUserLevel,
                                          ClassDaten.structPassword.sActUserName, "Inspectionplan '" + cb_InspectionPlanName.Text + "' loaded");


                //ClassHalconApplication.InitCameras();




            }







        }

        public void LoadAllInspectionPlanData(string sInspectionPlanName)
        {
            ClassDBFunctions.LoadInspectionPlan(sInspectionPlanName, ref ClassDaten.structInspectionPlanData, ref ClassDaten.structMesUnitData);
            ClassDBFunctions.LoadMesPrograms(sInspectionPlanName);
            ClassDBFunctions.LoadVisionData(sInspectionPlanName, ref ClassDaten.structVisionData);
            ClassDBFunctions.LoadRoboterData(sInspectionPlanName, ref ClassDaten.structRoboterData);
            ClassDBFunctions.LoadCalParametr();

            ClassDBFunctions.ReadMesProgCounterData();
            ClassDBFunctions.ReadMesUnitCounterData();

            ClassDaten.structSystemData.sActualInspectionPlan = sInspectionPlanName;
            ClassDaten.structSystemData.bNewInspectionPlanLoaded = true;
            switch (ClassDaten.structOptionData.iUnitType)
            {
                case (int)ClassDaten.UnitTyp.SlitDisk1:
                    if (!ClassDaten.structSystemData.bTestFlag)
                       Load

                    break;
                case (int)ClassDaten.UnitTyp.GlasDisk1:
                case (int)ClassDaten.UnitTyp.GlasV1:
                    break;

            }
            WriteIniData(ClassDaten.sDATA_PATH + INI_FILENAME);




        }


        private void SetCommentText(DataSet ds)
        {
            DataTable dt = ds.Tables["InspectionPlan"];
            foreach (DataRow cRow in dt.Rows)
            {
                if (cRow["InspectionPlanName"].ToString()==cb_InspectionPlanName.Text)
                {
                    lbl_Comment.Text = cRow["Comment"].ToString();
                      
                }
            }
        }

        public void WriteIniData(string sFileName)
        {
            ClassIniFile classIniFile = new ClassIniFile(sFileName);
            if (!ClassDaten.structSystemData.sActualInspectionPlan.Contains("Kal"))            
                classIniFile.WriteString(INI_SECTION, "ActualInspectionPlan", ClassDaten.structSystemData.sActualInspectionPlan);

            classIniFile.WriteString(INI_SECTION, "ProofFIFOCount", string.Format("{0:D}", " ")); // ClassIOApplication.iProofFIFOCount)
        }

        private void OnSelectedindex(object sender, EventArgs e)
        {

        }

    }
}
