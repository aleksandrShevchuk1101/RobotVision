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

            //GetAllPointer();

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
            //SetCamButtons();

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
            if (IsAllowed((int)ClassDaten.PasswordTyp.Advisor1))
            {
                ClassDaten.structSystemData.bMesControlFlag= !ClassDaten.structSystemData.bMesControlFlag;
                if (ClassDaten.structSystemData.bMesControlFlag)
                {
                    btn_MesControl.BackColor = Color.Red;
                    ClassDaten.structSystemData.sOldInspectionPlan = ClassDaten.structSystemData.sActualInspectionPlan;
                    ClassDaten.structSystemData.sActualInspectionPlan = "Kalibrier- Programm";
                }
                else
                {
                    btn_MesControl.BackColor = Color.LightGray;
                    ClassDaten.structSystemData.sActualInspectionPlan = ClassDaten.structSystemData.sOldInspectionPlan;

                }

            }
            else
            {
                ClassDaten.structSystemData.bMesControlFlag = false;
                btn_MesControl.BackColor = Color.LightGray;
            }
        }

        private void btn_Cam_Click(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            int iCamNr = Convert.ToInt32(myButton.Tag);
            SetActualCamNr(iCamNr);
        }



        public bool IsAllowed(int Mode)
        {
            Form_80_Password form_80_Password = new Form_80_Password();
            bool bPassWordOk = false;

            switch (Mode)
            {
                case (int)ClassDaten.PasswordTyp.Advisor1:
                    if (ClassDaten.structPassword.bAdvisorPassword1_OK ||
                        ClassDaten.structPassword.bAdvisorPassword2_OK ||
                        ClassDaten.structPassword.bAdvisorPassword3_OK ||
                        ClassDaten.structPassword.bSupervisorPassword_OK)
                        bPassWordOk = true;
                    break;
                case (int)ClassDaten.PasswordTyp.Advisor2:
                    if (ClassDaten.structPassword.bAdvisorPassword2_OK ||
                        ClassDaten.structPassword.bAdvisorPassword3_OK ||
                        ClassDaten.structPassword.bSupervisorPassword_OK)
                           bPassWordOk = true;
                    break;
                case (int)ClassDaten.PasswordTyp.Supervisor:
                    if (ClassDaten.structPassword.bSupervisorPassword_OK)        
                        bPassWordOk = true;             
                    break;
            }
            ShowPasswordLevel();

            if (bPassWordOk)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void ShowPasswordLevel()
        {
            if (ClassDaten.structPassword.sActUserName!=string.Empty)
            {
                if (ClassDaten.structPassword.bAdvisorPassword3_OK)
                    ClassDaten.structPassword.sActUserName = "Admin";

                lbl_UserLevel.Text = ClassDaten.structPassword.sActUserName;
            }
            else
            {
                if (ClassDaten.structPassword.bSupervisorPassword_OK)
                {
                    ClassDaten.structSystemData.sUserLevel = "SUPERVISIOR";
                    ClassDaten.structPassword.sActUserName = "";
                    //Menue_Configuration_Options.Visible = true;
                }
                else
                {
                    if (ClassDaten.structPassword.bAdvisorPassword1_OK)
                        ClassDaten.structSystemData.sUserLevel = "ADVISOR1";

                    else
                    {
                        if (ClassDaten.structPassword.bAdvisorPassword2_OK)
                            ClassDaten.structSystemData.sUserLevel = "ADVISOR1";
                        else
                        {
                            if (ClassDaten.structPassword.bAdvisorPassword3_OK)
                                ClassDaten.structSystemData.sUserLevel = "Admin";
                            else

                                ClassDaten.structSystemData.sUserLevel = "";
                        }
                    }

                   // Menue_Configuration_Options.Visible = false;
                }
                lbl_UserLevel.Text = ClassDaten.structSystemData.sUserLevel;
            }
        }

        private void SetActualCamNr(int iNr)
        {
            if (ClassDaten.structCamPara[iNr - 1].bActiv)
            {
                ClassDaten.structSystemData.iActualCamNr = iNr;
                SetMesProgLabels();
            }
        }

        private void SetMesProgLabels()
        {
            int k, i;
            int iRowDistance = 40;
            float fSize = 16F;
            listBoxMesValue.Controls.Clear();

            lbl_MesProgPtr = new Label[ClassDaten.structSystemData.iMesProgramsFound];
            numUpDown_Col0Ptr = new NumericUpDown[ClassDaten.structSystemData.iMesProgramsFound];
            numUpDown_Col1Ptr= new NumericUpDown[ClassDaten.structSystemData.iMesProgramsFound];
            numUpDown_Col2Ptr = new NumericUpDown[ClassDaten.structSystemData.iMesProgramsFound];

            lbl_Col3Ptr = new Label[ClassDaten.structSystemData.iMesProgramsFound];
            lbl_UnitPtr= new Label[ClassDaten.structSystemData.iMesProgramsFound];


            for (i=0,k = 0; k < ClassDaten.structSystemData.iMesProgramsFound; k++)
            {
                //Отфильтровать программы измерений для текущей камеры
                if (ClassDaten.structMesProgData[k].iCameraNr== ClassDaten.structSystemData.iActualCamNr)
                {
                    lbl_MesProgPtr[k]=new Label();
                    lbl_MesProgPtr[i].Name = "label" + i;
                    lbl_MesProgPtr[i].Location = new System.Drawing.Point(17, 20 + (i * iRowDistance));
                    lbl_MesProgPtr[i].Text = string.Empty;
                    lbl_MesProgPtr[i].TextAlign = ContentAlignment.MiddleLeft;
                    lbl_MesProgPtr[i].Size = new Size(340, 31);
                    lbl_MesProgPtr[i].Font = new Font("Microsoft Sans Serif", fSize, FontStyle.Bold, GraphicsUnit.Point, (byte)(0));

                    listBoxMesValue.Controls.Add(lbl_MesProgPtr[i]);

                    // Создаем минимальный допуск к элементу управления
                    numUpDown_Col0Ptr[i] = new NumericUpDown();
                    numUpDown_Col0Ptr[i].Location = new Point(370, 20 + (i* iRowDistance));
                    numUpDown_Col0Ptr[i].Name = "numUpDownCol0"+i;
                    numUpDown_Col0Ptr[i].Size = new Size(80,24);
                    numUpDown_Col0Ptr[i].TabIndex = 1;
                    numUpDown_Col0Ptr[i].DecimalPlaces = 2;
                    numUpDown_Col0Ptr[i].Increment = (decimal)0.01;
                    numUpDown_Col0Ptr[i].Font = new Font("Microsoft Sans Serif", fSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    numUpDown_Col0Ptr[i].Minimum = (decimal)-100.0;
                    numUpDown_Col0Ptr[i].Maximum= (decimal)100.0;
                    numUpDown_Col0Ptr[i].Value = 0;
                    numUpDown_Col0Ptr[i].TextAlign = HorizontalAlignment.Right;
                    numUpDown_Col0Ptr[i].Validating += new CancelEventHandler(this.OnValidating);

                    listBoxMesValue.Controls.Add(numUpDown_Col0Ptr[i]);

                    // Создаем уставку для управления
                    numUpDown_Col1Ptr[i] = new NumericUpDown();
                    numUpDown_Col1Ptr[i].Location = new System.Drawing.Point(460, 20 + (i * iRowDistance));
                    numUpDown_Col1Ptr[i].Name = "numUpDownCol1" + i;
                    numUpDown_Col1Ptr[i].Size = new System.Drawing.Size(80, 24);
                    numUpDown_Col1Ptr[i].TabIndex = 1;
                    numUpDown_Col1Ptr[i].DecimalPlaces = 2;
                    numUpDown_Col1Ptr[i].Increment = (decimal)0.01;
                    numUpDown_Col1Ptr[i].Font = new System.Drawing.Font("Microsoft Sans Serif", fSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    numUpDown_Col1Ptr[i].Minimum = (decimal)0.0;
                    numUpDown_Col1Ptr[i].Maximum = (decimal)1000.0;
                    numUpDown_Col1Ptr[i].Value = 0;
                    numUpDown_Col1Ptr[i].TextAlign = HorizontalAlignment.Right;
                    numUpDown_Col1Ptr[i].Validating += new System.ComponentModel.CancelEventHandler(this.OnValidating);

                    listBoxMesValue.Controls.Add(numUpDown_Col1Ptr[i]);

                    // Max Toleranz zum Control kreieren
                    numUpDown_Col2Ptr[i] = new NumericUpDown();
                    numUpDown_Col2Ptr[i].Location = new System.Drawing.Point(550, 20 + (i * iRowDistance));
                    numUpDown_Col2Ptr[i].Name = "numUpDownCol2" + i;
                    numUpDown_Col2Ptr[i].Size = new System.Drawing.Size(80, 24);
                    numUpDown_Col2Ptr[i].TabIndex = 1;
                    numUpDown_Col2Ptr[i].DecimalPlaces = 2;
                    numUpDown_Col2Ptr[i].Increment = (decimal)0.01;
                    numUpDown_Col2Ptr[i].Font = new System.Drawing.Font("Microsoft Sans Serif", fSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    numUpDown_Col2Ptr[i].Minimum = (decimal)0.0;
                    numUpDown_Col2Ptr[i].Maximum = (decimal)100.0;
                    numUpDown_Col2Ptr[i].Value = 0;
                    numUpDown_Col2Ptr[i].TextAlign = HorizontalAlignment.Right;
                    numUpDown_Col2Ptr[i].Validating += new System.ComponentModel.CancelEventHandler(this.OnValidating);

                    listBoxMesValue.Controls.Add(numUpDown_Col2Ptr[i]);


                    // Создаем фактическое значение для элемента управления

                    // Istwert zum Control kreieren
                    lbl_Col3Ptr[i] = new Label();
                    lbl_Col3Ptr[i].Name = "lblCol3" + i;
                    lbl_Col3Ptr[i].Location = new System.Drawing.Point(640, 20 + (i * iRowDistance));
                    lbl_Col3Ptr[i].Text = string.Empty;
                    lbl_Col3Ptr[i].Size = new System.Drawing.Size(80, 31);
                    lbl_Col3Ptr[i].Font = new System.Drawing.Font("Microsoft Sans Serif", fSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lbl_Col3Ptr[i].TextAlign = ContentAlignment.MiddleRight;

                    listBoxMesValue.Controls.Add(lbl_Col3Ptr[i]);

                    // Unit (Einheit) zum Control kreieren
                    lbl_UnitPtr[i] = new Label();
                    lbl_UnitPtr[i].Name = "lblCol4" + i;
                    lbl_UnitPtr[i].Location = new System.Drawing.Point(730, 20 + (i * iRowDistance));
                    lbl_UnitPtr[i].Text = string.Empty;
                    lbl_UnitPtr[i].Size = new System.Drawing.Size(90, 31);
                    lbl_UnitPtr[i].Font = new System.Drawing.Font("Microsoft Sans Serif", fSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lbl_UnitPtr[i].TextAlign = ContentAlignment.MiddleLeft;

                    listBoxMesValue.Controls.Add(lbl_UnitPtr[i]);

                    i++;

                }

            }


            for (k = 0, i=0;  k< ClassDaten.structSystemData.iMesProgramsFound; k++)
            {
                if (ClassDaten.structMesProgData[k].iCameraNr == ClassDaten.structSystemData.iActualCamNr)
                {
                    if (ClassDaten.structMesProgData[k].sMesProgName == "")
                    {
                        lbl_MesProgPtr[i].Visible = false;
                        numUpDown_Col0Ptr[i].Visible = false;
                        numUpDown_Col1Ptr[i].Visible = false;
                        numUpDown_Col2Ptr[i].Visible = false;

                        lbl_Col3Ptr[i].Visible = false;
                        lbl_UnitPtr[i].Visible = false;
                    }
                    else
                    {
                        lbl_MesProgPtr[i].Text = ClassDaten.structMesProgData[k].sMesProgName;
                        lbl_Col3Ptr[i].Text = string.Format("{0:000.000}", ClassDaten.structMesProgData[k].dRealMesValue);
                        lbl_UnitPtr[i].Text = string.Format("{0:G}", ClassDaten.structMesProgData[k].sUnit);


                        lbl_MesProgPtr[i].Visible = true;
                        numUpDown_Col0Ptr[i].Visible = true;
                        numUpDown_Col1Ptr[i].Visible = true;
                        numUpDown_Col2Ptr[i].Visible = true;
                        lbl_Col3Ptr[i].Visible = true;
                        lbl_UnitPtr[i].Visible = true;

                        if (ClassDaten.structMesProgData[k].bMesProgActiv)
                        {
                            lbl_MesProgPtr[i].Enabled = true;
                            numUpDown_Col0Ptr[i].Enabled = true;
                            numUpDown_Col1Ptr[i].Enabled = true;
                            numUpDown_Col2Ptr[i].Enabled = true;
                            lbl_Col3Ptr[i].Enabled = true;
                            lbl_UnitPtr[i].Enabled = true;
                            lbl_MesProgPtr[i].BackColor = Color.LightGray;
                            numUpDown_Col0Ptr[i].BackColor = Color.LightGray;
                            numUpDown_Col1Ptr[i].BackColor = Color.LightGray;
                            numUpDown_Col2Ptr[i].BackColor = Color.LightGray;
                            lbl_Col3Ptr[i].BackColor = Color.Lime;


                        }
                        else
                        {
                            //Messprogramm vorhanden aber nicht aktiv
                            lbl_MesProgPtr[i].Enabled = false;
                            numUpDown_Col0Ptr[i].Enabled = false;
                            numUpDown_Col1Ptr[i].Enabled = false;
                            numUpDown_Col2Ptr[i].Enabled = false;
                            lbl_Col3Ptr[i].Enabled = false;
                            lbl_UnitPtr[i].Enabled = false;
                            lbl_MesProgPtr[i].BackColor = Color.White;
                            numUpDown_Col0Ptr[i].BackColor = Color.White;
                            numUpDown_Col1Ptr[i].BackColor = Color.White;
                            numUpDown_Col2Ptr[i].BackColor = Color.White;
                            lbl_Col3Ptr[i].BackColor = Color.White;
                        }

                    }
                    i++;
                }
            }
        }

        private void btn_BDE_Click(object sender, EventArgs e)
        {
            Form_40_BDE formBDE = new Form_40_BDE();
            formBDE.ShowDialog();

        }

        private void btn_Edit_Tolerance_Click(object sender, EventArgs e)
        {
            bToleranceEditMode = !bToleranceEditMode;
            ClassDLLImports.LoadSoftkeyboard(true);

            switch (ClassDaten.structOptionData.iUnitType)
            {
                case (int)ClassDaten.UnitTyp.StampControl:
                    ToleranceInput();
                    break;
                default:
                    if (IsAllowed((int)ClassDaten.PasswordTyp.Advisor2))
                       ToleranceInput();
                    break;

            }

        }

        private void btn_F2_Stop_Click(object sender, EventArgs e)
        {




        }

        private void btn_Error_Click(object sender, EventArgs e)
        {
            if (!formMessages.Created)
            {
                formMessages.Visible = true;
                formMessages.Show();
            }
            else
            {
                formMessages.Visible = true;
                formMessages.Activate();

            }
        }

        private void btn_LightControl_Click(object sender, EventArgs e)
        {
            if (IsAllowed((int)ClassDaten.PasswordTyp.Advisor2))
            {
                switch (ClassDaten.structOptionData.iUnitType)
                {
                    case (int)ClassDaten.UnitTyp.SlitDisk1:
                    case (int)ClassDaten.UnitTyp.GlasDisk1:
                        Form_52_Smartek_LightControler formSmartekLightControler;
                        formSmartekLightControler = new Form_52_Smartek_LightControler(ClassDaten.structSystemData.sActualInspectionPlan, (int)ClassDaten.LightTyp.Flat, (int)ClassDaten.LightTyp.Ring_DarkField);
                        formSmartekLightControler.ShowDialog();
                        break;
                }
            }
        }

        private void btn_LifePicture_Click(object sender, EventArgs e)
        {
            if (!ProofRunstate())
            {
                tabControl.SelectedIndex = 0;
                ClassDaten.structSystemData.bLifeImageFlag=!ClassDaten.structSystemData.bLifeImageFlag;
                if (ClassDaten.structSystemData.bLifeImageFlag)
                    btn_LifePicture.BackColor = Color.Red;
                else
                    btn_LifePicture.BackColor = Color.LightGray;
            }
            else
            {
                ClassDaten.structSystemData.bLifeImageFlag = false;
                btn_LifePicture.BackColor = Color.LightGray;
            }
        }

        private void ToleranceInput()
        {
            int i, k;


            if (bToleranceEditMode)
            {
                btn_Edit_Tolerance.Text = "Change stop";
                for (k = 0, i = 0; k < ClassDaten.structSystemData.iMesProgramsFound; k++)
                {
                    if (ClassDaten.structMesProgData[k].iCameraNr == ClassDaten.structSystemData.iActualCamNr)
                    {

                        numUpDown_Col0Ptr[i].Value = Convert.ToDecimal(ClassDaten.structMesProgData[k].dMinTol);
                        numUpDown_Col1Ptr[i].Value = Convert.ToDecimal(ClassDaten.structMesProgData[k].dNominalValue);
                        numUpDown_Col2Ptr[i].Value = Convert.ToDecimal(ClassDaten.structMesProgData[k].dMaxTol);


                        if (ClassDaten.structMesProgData[k].bMesProgActiv)
                        {
                            numUpDown_Col0Ptr[i].Enabled = true;
                            numUpDown_Col1Ptr[i].Enabled = true;
                            numUpDown_Col2Ptr[i].Enabled = true;
                        }
                        i++;
                    }
                }
            }
            else
            {
                btn_Edit_Tolerance.Text = "Change";
                for (k = 0,i=0;  k< ClassDaten.structSystemData.iMesProgramsFound; k++)
                {
                    if (ClassDaten.structMesProgData[k].iCameraNr == ClassDaten.structSystemData.iActualCamNr)
                    {
                        if (i< ClassDaten.structSystemData.iMesProgramsFound)
                        {
                            numUpDown_Col0Ptr[i].Enabled = false;
                            numUpDown_Col1Ptr[i].Enabled = false;
                            numUpDown_Col2Ptr[i].Enabled = false;
                            i++;
                        }
                    }
                }

            }
        }

        private void btn_InspectionPlanEdit_Click(object sender, EventArgs e)
        {

        }

        private bool ProofRunstate()
        {
            if (ClassDaten.structSystemData.bRunState)
            {
                MessageBox.Show("Please push the STOP- Button first !!!");
                return false;
            }
            else
                return true;

        }

        private void Menue_Help_Information_Click(object sender, EventArgs e)
        {
            Form_91_Info form_Info = new Form_91_Info();
            form_Info.ShowDialog();
        }

        private void Start()
        {

        }

    }


    
}
