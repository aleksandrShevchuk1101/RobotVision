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



    public class ClassDaten
    {

        public static string sHELP_PATH = "..\\..\\..\\..\\..\\..\\VisionControl\\Help\\";


        public static SystemData structSystemData= new SystemData();

       
        public static Password structPassword = new Password();

        public const int MAX_WORKER = 12;





    }
}
