using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_KEHRATEC
{
    public struct SystemData
    {
        //Allgemeine Systemparameter 
        public string sAquireImageError;
        public int i_OP_PictureNr;
        public int i_OP_OldPictureNr;
        public int i_OP_ButtonNr;
        public int i_OP_OldButtonNr;

        public string sUserLevel;
        public bool bWriteImageFlag;
        public bool bLifeImageFlag;
        public bool bCalFlag;
        public bool bConstantCalValue;

        public int iActualCamNr;
        public int iRequestedCamNr;             //Angeforderte KameraNr
        public int iRequestedTyp;               //Angeforderter Typ
        public int iRequestedModel;             //Angefordertes Merkmal
        public int iActualTabPage;
        public int iProcessorCount;
        public int iIncCounter;                 // Counter fьr Inkrementalgeber
        public int iSavePictureMode;            // Modus 
        public bool bShowCamResult;             // Merker fьr Kameraergebnisse
        public bool bTestFlag;                  //Aktiviert den Test Mode (Office Version)
        public bool bRunState;
        public bool bProcessMode;
        public bool bIORunState;
        public int iShowMode;                   //Aktiviert die Grafische Ergebnisanzeige
        public bool bVisionSystemIsBusy;        //Bildverarbeitung aktiv
        public string sLanguageFileName;
        public long lWorkTimer;                 //Betriebsstundenzдhler
        public long lProductTimer;              //Schichtstundenzдhler
        public double dPerformance;

        // Form_02_PruefplanLoad
        public int iActivMesProgramsFound;
        public int iMesProgramsFound;
        public string sActualInspectionPlan;
        public string sOldInspectionPlan;
        public bool bNewInspectionPlanLoaded;


        //Form_12_ShowProcessData
        public double dProcessPerformance;
        public double dProcessCycleTime;
        public double dProcessCycleTimeMax;

        // Form_20_DataRoot
        public int iDataRoot;                   // 0=Image, 1=Referenz 
        public int iRefNr;                      // 1 = 1. Referenzbild, 2 = 2. Referencebild
        public bool bMesControlFlag;            // Flag fьr Kontrollmessung
        public int iID;                         // ID Nummer fьr Regionen

        public string sInspectionPlanPath;
        public int iLayerNr;
        public double dRealPixelValue;
        public bool bRegionMode;

        public void Init()
        {
            iRefNr = 1;
            iLayerNr = 1;
            bMesControlFlag = false;         

    }
    }
    public struct Autorisation
    {
        public string sName;
        public string sPassword;
        public bool bLoadProgrsms;
        public bool bEditPrograms;


        public void Init()
        {
            sName = "";
            sPassword = "";
            bLoadProgrsms = false;
            bEditPrograms = false;
        }
    }
    public struct Password
    {
        public string sAdvisorPassword1;
        public string sAdvisorPassword2;
        public string sAdvisorPassword3;
        public string sSupervisorPassword;
        public bool bAdvisorPassword1_OK;
        public bool bAdvisorPassword2_OK;
        public bool bAdvisorPassword3_OK;
        public bool bSupervisorPassword_OK;
        public string sActUserName;
    }
    public struct RoboterData
    {
        public string sInspectionPlanName;
        public int iTypNr;
        public int iOptions;
        public double dLength;
        public double dWidth;
        public double dHeight;
        public double dDiameter;
        public double dRotAngleVertAxis;
        public double dRotAngleHorAxis;
        public double dMaxRotAngle;
        public double dMinRotAngle;
        public int iGripperNr;
        public int iGripperFingerNr;
        public double dGrip_X;
        public double dGrip_Y;
        public double dGripAngleVertAxis;
        public double dGripAngleHorAxis;
        public double dGripHeight;
        public double dGripDepth;
        public int iMax_X;
        public int iMax_Y;
        public double dDistance_X;
        public double dDistance_Y;
        public double dWeight;
        public int iPrismaSelect;

        public void InitMesValues()
        {
            dGrip_X = 0.0;
            dGrip_Y = 0.0;
            dGripAngleVertAxis = 0.0;
            dGripAngleHorAxis = 0.0;
        }

        public void Init()
        {
            sInspectionPlanName = "";
            iTypNr = 0;
            iOptions = 0;
            dLength = 0.0;
            dWidth = 0.0;
            dHeight = 0.0;
            dDiameter = 0.0;
            dRotAngleVertAxis = 0.0;
            dRotAngleHorAxis = 0.0;
            dMaxRotAngle = 0.0;
            dMinRotAngle = 0.0;
            iGripperNr = 0;
            iGripperFingerNr = 0;
            dGrip_X = 0.0;
            dGrip_Y = 0.0;
            dGripAngleVertAxis = 0.0;
            dGripAngleHorAxis = 0.0;
            dGripHeight = 0.0;
            dGripDepth = 0.0;
            iMax_X = 0;
            iMax_Y = 0;
            dDistance_X = 0.0;
            dDistance_Y = 0.0;
            dWeight = 0.0;
            iPrismaSelect = 0;
        }
    }


    public class ClassDaten
    {

        public static string sHELP_PATH = "..\\..\\..\\..\\VisionControl\\Help\\";
        public static string sDATA_PATH = "..\\..\\..\\..\\VisionControl\\Data\\";
        public static string sMESSAGE_PATH = "..\\..\\..\\..\\VisionControl\\Messages\\";
        public const int MAX_WORKER = 12;
        public static int MAX_ERROR_WORDS = 2;

        public static SystemData structSystemData= new SystemData();

       
        public static Password structPassword = new Password();
        public static Autorisation[] structAutorisation = new Autorisation[MAX_WORKER];
        public static RoboterData structRoboterData= new RoboterData();
        public enum PasswordType { Advisor1,Advisor2,Advisor3, Supervisor };



        public static string DEFAULT_PASSWORD = "*KEHRATEC*";


        public static ushort[] ushOldErrorData = new ushort[MAX_ERROR_WORDS];
       





    }
}
