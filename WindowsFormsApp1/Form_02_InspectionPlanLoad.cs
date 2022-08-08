using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;


namespace CS_KEHRATEC
{
    public partial class Form_02_InspectionPlanLoad : Form
    {
        string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source="+ ClassDaten.sDATA_PATH+ "AppDB.mdb;";
        string sSelectInspectionPlanBez = "SELECT InspectionPlanName, Comment FROM InspectionPlan";


        OleDbConnection conn = null;
        OleDbDataAdapter daInspectionPlan = null;
        DataSet ds = null;

        public Form_02_InspectionPlanLoad()
        {
            InitializeComponent();
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            string sFileName=ClassDaten.sHELP_PATH + "Help_InspectionPlanLoad.pdf";

            try
            {
                System.Diagnostics.Process.Start(sFileName);
            }
            catch(Exception myException)
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

            result = MessageBox.Show("Do you really want to load data from file " + cb_InspectionPlanName.Text + "?",
                "Load data", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (result==DialogResult.OK)
            {

            }


        }

        private void SetCommnetText(DataSet ds)
        {
            DataTable dt = ds.Tables["InspectionPlan"];
            foreach (DataRow cRow in dt.Rows)
            {
                if (cRow["InspectionPlanName"].ToString() == cb_InspectionPlanName.Text)
                {
                    lbl_Comment.Text = cRow["Comment"].ToString();
                }
            }
        }
        private void On_InspectiionPlan_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(sConnection);
            daInspectionPlan = new OleDbDataAdapter(sSelectInspectionPlanBez, conn);

            OleDbCommandBuilder cb = new OleDbCommandBuilder(daInspectionPlan);
            this.ds = new DataSet();
            try
            {
                conn.Open();
                daInspectionPlan.Fill(ds, "InspectionPlan");
                conn.Close();
                bindingSource1.DataSource = ds.Tables["InspectionPlan"];
                cb_InspectionPlanName.DataSource = bindingSource1;
                cb_InspectionPlanName.DisplayMember = "InspectionPlanName";

                SetCommnetText(ds);

            }
            catch(Exception exception)
            {
                MessageBox.Show("Error while reading Access- Data : " + exception.Message);

            }
            finally
            {
                conn.Close();
            }

        }

        private void ReadPicture(string sInspectionPlanName)
        {






        }
        private void cb_InspectionPlanName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCommnetText(this.ds);
        }
    }
}
