using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using HalconDotNet;

namespace CS_KEHRATEC
{


    public partial class Form_01_Main : Form
    {
        private Thread halconThread, IOThread;
        private bool bHalconError_1;


        public enum Mode { Inputs, Outputs };

        const string INI_FILENAME = "Application.ini";
        const string INI_UNIT_SECTION = "UNIT";
        const int MAX_DONGLE_TIME = 60;        // Dongle Prüfzyklus in sec     
        const int MAX_INTERVALL_TIME = 1;

        const int MAX_BUTTONS = 12;
        const int MAX_LED = 12;
        const int MAX_PB = 15;
        const int MAX_VALUES = 0;

        bool bToleranceEditMode = false;
        bool bSPSStopped = false;
        bool bSPSError = false;
        int iIntervalCount = 0;

        static int iDataRequestStepNr = 0;
        static bool bSetMesDataFlag = false;
        static bool bSreenSaverOFF = false;

        Label[] lbl_MesProgPtr;

        NumericUpDown[] numUpDown_Col0Ptr;
        NumericUpDown[] numUpDown_Col1Ptr;
        NumericUpDown[] numUpDown_Col2Ptr;

        Label[] lbl_Col3Ptr;
        Label[] lbl_UnitPtr;

        Label[] lbl_ResultPtr = new Label[ClassDaten.MAX_CAMERAS];

        Form_30_Messages formMessages = new Form_30_Messages(ref ClassDaten.ushOldErrorData);

        Form_06_SavePictureSelect formPictureSelect = new Form_06_SavePictureSelect();

        public static Form_12_ShowProcessData form_ShowProcessData;


        public static Form_33_PLC_Socket formPLC_Socket;
        public static Form_31_TCP_IP_Socket form_TCP_IP_Socket;
        public static Form_32_Modbus_TCP formModbus_TCP;
        public static Form_53_Sick_PLR formSick_PLR;


        private Label[] lblValuePtr = new Label[MAX_VALUES + 1];
        private Label[] lblLEDPtr   = new Label[MAX_LED + 1];
        private PictureBox[] pbLEDPtr = new PictureBox[MAX_PB + 1];

        private int[] iOP_LEDColor = new int[MAX_LED + 1];
        private int[] iOP_BtnColor = new int[MAX_BUTTONS + 1];
        private double[] dValue = new double[MAX_VALUES + 1];

        private Image Disk_10;
        private Image Disk_12;
        private Image Disk_20;
        private Image Disk_24;
        private Image LED_Red;
        private Image LED_Green;

        HWindowControl[] HWindowCtrlPtr = new HWindowControl[7];
        static MessageHelper msg = new MessageHelper();

        public Form_01_Main()
        {
            InitializeComponent();
            this.Width = 1280;
            this.Height = 1024;

            GetAllPointer();

            // Instantiate classes to read the values
            Form_56_Options form_Options = new Form_56_Options();
            form_Options.Dispose();

            //Read authorization data
            Form_82_Autorisation formAutorisation = new Form_82_Autorisation();
            formAutorisation.Dispose();

            // Read the hour meter
            Form_40_BDE formBDE = new Form_40_BDE();
            //**
            formBDE.Dispose();

            //Load last InspectionPlan
            Form_02_InspectionPlanLoad form_InspectionPlanLoad = new Form_02_InspectionPlanLoad();
            form_InspectionPlanLoad.ReadIniData(ClassDaten.sDATA_PATH+INI_FILENAME);
            form_InspectionPlanLoad.LoadAllInspectionPlanData(ClassDaten.structSystemData.sActualInspectionPlan);
            ClassDaten.structSystemData.iRequestedTyp = ClassDaten.structRoboterData.iTypNr;
            form_InspectionPlanLoad.Dispose();
            SetCamButtons();

            //Load active cameras
            Form_07_CameraActivation formCameraActivation = new Form_07_CameraActivation();
            formCameraActivation.Dispose();

            Form_41_Packaging formPackaging = new Form_41_Packaging();
            //**
            formPackaging.Dispose();

            Form_42_Counter formCounter = new Form_42_Counter();
            //**
            formCounter.Dispose();

            Form_55_Config_DIDO_32 form_Config_DIDO = new Form_55_Config_DIDO_32();
            Form_81_ChangePassword form_ChangePassword=new Form_81_ChangePassword();

            btn_F2_Stop.Enabled = false;

            //Make unneeded menu options invisible

            SetUnitOptions();

            //Set all measurement program labels
            SetMesProgLabels();
            ClassDaten.structSystemData.bNewInspectionPlanLoaded = false;

            // Initialize IO
            //**

            //Initialisiere Halcon

            Thread.CurrentThread.Name = "Main";
            //IntPtr iPA=Process.Ge


            InstanceObjects();

            //Activate IO thread
            IOThread = new Thread(new ThreadStart(myIOAppRun));
            IOThread.Name = "IOThread";
            IOThread.IsBackground = true;
            //If there is more than one processor, set higher priority
            if (ClassDaten.structSystemData.iProcessorCount>1)
            {
                IOThread.Priority = ThreadPriority.AboveNormal;
            }

            IOThread.Start();

            ClassDaten.structSystemData.bNewInspectionPlanLoaded = true;
            ClassDBFunctions.ReadMesProgCounterData();
            ClassDBFunctions.ReadMesUnitCounterData();

            toolStripStatusLabel.Text = "Program started";

            //ClassHalconApplication.SetBigWindow(true);
            timer1.Enabled = true;

            ClassDaten.structSystemData.i_OP_PictureNr = 1;
            ClassDaten.structSystemData.iActualCamNr = 1;

            tabControl.TabPages[0].Text="Image Camera " + ClassDaten.structSystemData.iActualCamNr;

            switch (ClassDaten.structOptionData.iUnitType)
            {
                case (int)ClassDaten.UnitTyp.RobotVision:
                    Start();
                    break;
            }

        }

        private void AbortThread()
        {
            ClassDaten.structSystemData.bIORunState = false;




        }






        private void btn_ProcessMode_Click()
        {
            if (!ClassDaten.structSystemData.bProcessMode)
            {

                switch (ClassDaten.structOptionData.iUnitType)
                {
                    case (int)ClassDaten.UnitTyp.SlitDisk1:
                    case (int)ClassDaten.UnitTyp.GlasDisk1:
                    case (int)ClassDaten.UnitTyp.GlasV1:
                        if (!ClassDaten.structOptionData.bWithoutExternalTrigger)
                        {
                            if (true)
                            {

                            }
                        }
                }





            }





        }


        private void Start()
        {
            btn_F2_Stop.Enabled = false;

            bSPSStopped = false;


            

        }

        private void Form_01_Main_Load(object sender, EventArgs e)
        {

        }

        private void btn_MesControl_Click(object sender, EventArgs e)
        {

        }

        public bool IsAllowed(int Mode)
        {
            if (ClassDaten.structPassword.sActUserName!=string.Empty)
            {
                if (ClassDaten.structPassword.bAdvisorPassword3_OK)
                    ClassDaten.structPassword.sActUserName = "Admin";
                lbl_UserLevel.Text=ClassDaten.structPassword.sActUserName;
            }
            else
            {
                if (ClassDaten.structPassword.bSupervisorPassword_OK)
                {
                    ClassDaten.structSystemData.sUserLevel = "SUPERVISOR";
                    ClassDaten.structPassword.sActUserName = "";

                }
            }

        }


        private void ShowPasswordLevel()
        {

        }

        private void btn_F2_Stop_Click(object sender, EventArgs e)
        {




        }
    }


    
}
