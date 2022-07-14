using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace CS_KEHRATEC
{

    public struct SampleUnion
    {
        public byte Flag1;
        public byte Flag2;
        public byte Flag3;
        public byte Flag4;
        public uint Composite;
    }

    public  struct Autorisation
    {
        public string sName;
        public string sPassword;
        public bool bLoadPrograms;
        public bool bEditPrograms;

        public void Init()
        {
            sName = "";
            sPassword = "";
            bLoadPrograms = false;
            bEditPrograms = false;
        }

    }

    public struct BoxData
    {
        public double dX0_Offset; // X offset from calibration plate
        public double dY0_Offset; // Y offset from calibration plate
        public double dZ0_Offset; // Z offset from calibration plate
        public double dPhi0_Offset;  // Phi Offset von Kalibrierplatte
        public double dX0_MoveOffset;  // X Verschiebeoffset Basis
        public double dY0_MoveOffset;  // Y Verschiebeoffset Basis

    }


    public struct CalibrationParameter
    {
        public int iCameraNr;
        public int iLayerNr;
        public double dFocalLength;
        public double dKappa;
        public double dSx; // Размер пикселя X в [м]
        public double dSy; // Размер пикселя Y в [м]
        public int iCx; // Центр изображения в направлении X (MaxColumns/2)
        public int iCy; // Центр изображения в направлении Y (MaxColumns/2)
        public int iNumColums; // Ширина изображения в направлении X (MaxColumns)
        public int iNumRows; // Высота изображения в направлении Y (MaxRows)
        public double dVx;
        public double dVy;
        public double dVz;
        public string sCaltabName;
        public int iNumImages; // Количество изображений для калибровки
        public double dPixelDistance; // Расстояние между пикселями в [м]
        public double dDx;     // Базовое смещение по X - направление в [м]
        public double dDy;     // Базовое смещение по Y - направление в [м]
        public double dDz;     // Базовое смещение по Z - направление в [м]
        public double dDAlpha; // Базовое вращение вокруг Z в [°]
        public double dMoveDx; // Сдвиг изображения по оси X - направление в [м]
        public double dMoveDy; // Сдвиг изображения по оси Y - направление в [м]
        public double dMoveDz; // Сдвиг изображения по оси Z - направление в [м]
        public double dSizeGauss; // коэффициент сглаживания
        public int iMarkThreshold; // Значение серого для распознавания меток
        public int iMinDiametrMarks; // 
        public int iStartThreshold;
        public int iDeltaThreshold;
        public int iMinThreshold;
        public double dAlpha;
        public int iMinContLength;      // Минимальная длина контура
        public int iMaxDiameterMarks;   // Maximaler Durchmesse der Marken
        public string sEstimateParams;  // параметры оценки
        public string sMethod;          // Methode zur Origin Festlegung 0=Mittelpkt Caltab, 1= 3-Pkt. Methode (3 Punkte auf Caltab)
        public string sSystemTyp;       // Kamerasystemtyp (Single, Stereo)
        public int iAquisitionTime;     // Belichtungszeit
    }

    public struct CamPara
    {
        public object hv_FGHandle;      // Handle fьr Kamera
        public bool bActiv;
        public bool bCameraActivPreset;
        public bool bDoubleTriggerFlag;
        public bool bExternalTrigger;
        public int iCameraTyp;  // Зональная камера, линейная камера
        public int iCameraHWTyp; // Тип оборудования, например Basler, GigEVision....
        public int iTimeoutTime; // Время ожидания в мс
        public int iAquisitionTime;
        public int iGain; // // Армирование

    }

    public struct ComData
    {
        public string sComName; // Ком - обозначение
        public string sBoardName;  // Имя платы (Hischer = cifx0)
        public string sServer; // Имя_сервера для сокет-сервера
        public string sIPAddress; // 172.16.17.255 fьr Modbus
        public int iChannel;     // 512
        public int iPort;
        public int iPort_PC;
        public int iRack;
        public int iSlot;
        public byte byteUnit;
        public int iIDNrInputs;
        public int iIDNrOutputs;
        public int iStartAdrDigInputs;
        public int iStartAdrDigOutputs;
        public int iStartAdrAnaInputs;
        public int iNumDigInputBytes;
        public int iNumDigOutputBytes;
        public int iNumAnaInputs;
        public int iNumAnaOutputs;
        public int iTimeOut;
        public byte[] byteDigInputBuffer;
        public byte[] byteDigOutputBuffer;
        public byte[] byteDigOutputBufferResult;
        public byte[] byteAnaInputBuffer;
        public byte[] byteAnaOutputBuffer;
        public double dOffsetX;
        public double dOffsetY;
        public double dOffsetZ;
        public bool bRightSide;
        public string sFTP_Folder;                  // FTP execute - Verzeichnis
        public string sFTP_UserName;                // FTP Username
        public string sFTP_Password;                // FTP Passwort
    }

    public struct Counter
    {
        // данные счетчика
        public int iTotalParts;
        public int iTotalOKParts;
        public int iTotalNOKParts;
        public int iQuantityStopNIOParts;
        public int iTotalUntested;
        public int iSeriesErrorCount;
        public int iPortionQuantityCount;
        public int iCleaningIntervallCount;

        public int iCountNIOCam1;
        public int iCountNIOCam2;
        public int iCountNIOCam3;
        public int iCountNIOCam4;
        public int iCountNIOCam5;
        public int iCountNIOCam6;

    }

    public struct InspectionPlanData
    {
        public string sInspectionPlanName;
        public string sComment;
        public string sAdvisorName;
        public int iInspectionPlanTyp;

        //Раздел системы измерения
        public bool bHeightMeasure;             //Sensor fьr Hцhenmessung aktiv
        public bool bDepthMeasure;              //Sensor fьr Tiefenmessung aktiv
        public bool bHoleCheck;                 //Sensor fьr Lochprьfung aktiv
        public bool bThreadCheck;               //Sensor fьr Gewindeprьfung aktiv
        public bool bResSensorCheck;            //Reservesensor aktiv
        public bool bFestoCheck;                //Festo Checkbox aktiv

        //Rubrik Zufuhr
        public double dVMaxSpiralOutput;        //Vmax Wendelfцrderer in %
        public int iVMaxDiskRotation;           //Vmax Drehteller (Programmnumern)
        public double dVMaxRoleSelector;        //Vmax Rollenselector in %
        public double dVMaxLinearOutput1;       //Vmax Linearfцrderer 1 in %
        public double dVMaxLinearOutput2;       //Vmax Linearfцrderer 2 in %
        public int iProofFIFOIntervall;         //FiFO Prьfinterval nach x - Teilen

        public int iDelayTimeRoleSelector;      // Verzцgerungszeit Rollenselector
        public int iDelayTimeSpiralOutputOn;    // Verzцgerungszeit Wendelfцrderer
        public int iDelayTimeDiskOn;            // Verzцgerungszeit Teller Ein
        public int iMinOffTimeMaterialSensor;   // Stausensor min. Auszeit
        public int iMinOnTimeMaterialSensor;    // Stausensor min. Einzeit

        //Rubrik Zдhler
        public int iPortionQuantity;
        public bool bPortionQuantityActiv;
        public int iQuantityStop;
        public int iQuantityStopNIO;
        public int iCleaningIntervall;
        public int iSeriesError;
        public int iMinPerformance;             //Minimale Prьfleistung
        public double dMaxNIOPercent;

        //Rubrik Timing
        public int[] iTriggerDelay;
        public int[] iTriggerDelay2;
        public int iActualOutputNozzle;
        public int iOutputNozzle1Delay;         //Ausblasverzцgerung
        public int iOutputNozzle1Time;          //Ausblaszeit
        public int iOutputNozzle2Delay;         //Ausblasverzцgerung
        public int iOutputNozzle2Time;          //Ausblaszeit
        public int iOutputNozzle3Delay;         //Ausblasverzцgerung
        public int iOutputNozzle3Time;          //Ausblaszeit
        public int iOutputNozzle4Delay;         //Ausblasverzцgerung
        public int iOutputNozzle4Time;          //Ausblaszeit
        public bool[] bDoubleTriggerFlag;

        //Системный раздел
        public int iDisktyp;

        public string[] sStartTimeCam;
        public string[] sEndTimeCam;
        public string[] sTimeStampCam;
        public string[] sCalTimeStampCam;
        public int[] iCurrencyTimeCam;


        public void Init()
        {
            iTriggerDelay = new int[ClassDaten.MAX_CAMERAS];
            iTriggerDelay2 = new int[ClassDaten.MAX_CAMERAS];
            bDoubleTriggerFlag = new bool[ClassDaten.MAX_CAMERAS];

            sStartTimeCam = new string[ClassDaten.MAX_CAMERAS];
            sEndTimeCam = new string[ClassDaten.MAX_CAMERAS];
            sTimeStampCam = new string[ClassDaten.MAX_CAMERAS];
            sCalTimeStampCam = new string[ClassDaten.MAX_CAMERAS];
            iCurrencyTimeCam = new int[ClassDaten.MAX_CAMERAS];

            sInspectionPlanName = "";
            sComment = "";
            sAdvisorName = "";
            iInspectionPlanTyp = 0;

        }



    }


    public struct LightControlData
    {
        //Allgemeine Paremeter fьr Light Controler
        public int iOut1_Mode;              // 0=Off, 1=Constant, 2=Trigger, 3=Test
        public int iOut1_Dominance;         // Dominante Ьberwachung bei S6000 0=Current, 1=Timing
        public int iOut1_TriggerEdge;       // 0=Positive Flanke, 1= Negative Flanke
        public int iOut1_Chan1Current;      // Stom
        public int iOut1_Chan2Current;      // Stom
        public int iOut1_Chan3Current;      // Stom
        public int iOut1_Chan4Current;      // Stom
        public int iOut1_Chan5Current;      // Stom
        public int iOut1_Chan6Current;      // Stom
        public int iOut1_OnTime;            // Pulsdauer
        public int iOut1_TrigDelayTime;     // Verzцgerungszeit
        public int iOut1_HoldTime;          // Wartezeit nach Puls
        public int iOut1_TrigRepeat;        // Anzahl Trigger fьr Testmode
        public int iOut1_TrigRepeatOffTime; // OffTime
        public int iOut2_Mode;              // 0=Off, 1=Constant, 2=Trigger, 3=Test
        public int iOut2_Dominance;         // Dominante Ьberwachung bei S6000 0=Current, 1=Timing
        public int iOut2_TriggerEdge;       // 0=Positive Flanke, 1= Negative Flanke
        public int iOut2_Chan1Current;      // Stom
        public int iOut2_Chan2Current;      // Stom
        public int iOut2_Chan3Current;      // Stom
        public int iOut2_Chan4Current;      // Stom
        public int iOut2_Chan5Current;      // Stom
        public int iOut2_Chan6Current;      // Stom
        public int iOut2_OnTime;            // Pulsdauer
        public int iOut2_TrigDelayTime;     // Verzцgerungszeit
        public int iOut2_HoldTime;          // Wartezeit nach Puls
        public int iOut2_TrigRepeat;        // Anzahl Trigger fьr Testmode
        public int iOut2_TrigRepeatOffTime; // OffTime
    }

    public struct MesProgData
    {
        // Целевые значения из базы данных
        //Sollwerte aus Datenbank
        public string sInspectionPlanName;
        public int iID;
        public string sMesProgName;
        public int iRefNr;
        public int iCameraNr;
        public int iCameraTyp;
        public int iMesUnitNr;
        public bool bMesProgActiv;
        public bool bRotationEnable;
        public bool bOverLength;
        public ulong ulMesToolCode;
        public double dNominalValue;
        public double dMaxTol;
        public double dMinTol;
        public string sUnit;
        public double dMesValue;
        public double dCalValue;
        public string sBW_WB;
        public int iThreshold;
        public int iLowGray;
        public int iHighGray;
        public double dAlpha;
        public int iGrayPercent;
        public int iGrayOffset;
        public string sMesTyp1;
        public string sMesTyp2;
        public string sMesTyp3;
        public int iMin1;
        public int iMax1;
        public int iMin2;
        public int iMax2;
        public int iMin3;
        public int iMax3;
        public int iMin4;
        public int iMax4;

        //Istwerte
        public bool bCalibrationMode;
        public double dRealMesValue;
        public int iActRefNr;
        public int iOKParts;
        public int iTotalParts;
        public int iMinTolNOKParts;
        public int iMaxTolNOKParts;

        public void Init()
        {
            //Sollwerte aus Datenbank
            sInspectionPlanName = "";
            sMesProgName = "";
            iCameraNr = 0;
            iCameraTyp = 0;
            iMesUnitNr = 0;
            bMesProgActiv = false;
            bRotationEnable = false;
            bOverLength = false;
            ulMesToolCode = 0;
            dNominalValue = 0;
            dMaxTol = 0;
            dMinTol = 0;
            sUnit = "";
            dMesValue = 0;
            dCalValue = 0;
            sBW_WB = "";
            iLowGray = 0;
            iHighGray = 0;
            dAlpha = 0.0;
            iGrayPercent = 0;
            iGrayOffset = 0;
            sMesTyp1 = "";
            sMesTyp2 = "";
            sMesTyp3 = "";
            iMin1 = 0;
            iMax1 = 0;
            iMin2 = 0;
            iMax2 = 0;
            iMin3 = 0;
            iMax3 = 0;
            iMin4 = 0;
            iMax4 = 0;

            //Istwerte
            bCalibrationMode = false;
            dRealMesValue = 0.0;
            iActRefNr = 0;
        }

    }

    public struct MeasurementData
    {
        // определенные координаты ящика
        public double d_X_Value;
        public double d_Y_Value;
        public double d_Angle_Value;

        public void Init()
        {
            d_X_Value = 0.0;
            d_Y_Value = 0.0;
            d_Angle_Value = 0.0;
        }
    }


    public struct MesUnitData
    {
        public string sMesProgName;
        public int iMesUnitNr;
        //Zдhler
        public int iTotalParts;
        public int iTotalOKParts;
        public int iTotalNOKParts;
        public int iTotalUntested;
        public int iOKParts;
        public int iMinTolNOKParts;         //Anzahl Werte < MinTol    
        public int iMaxTolNOKParts;         //Anzahl Werte > MaxTol
        //Werte
        public double dMesValue;
        public double dNominalValue;        //Sollwert fьr Sensor 
        public double dMaxTol;              //Oberer Toleranzwert fьr Sensor 
        public double dMinTol;              //Unterer Toleranzwert fьr Sensor 

        public void Init()
        {
            sMesProgName = string.Empty;
            iMesUnitNr = 0;
            iTotalParts = 0;
            iTotalOKParts = 0;
            iTotalNOKParts = 0;
            iTotalUntested = 0;
            iOKParts = 0;
            iMinTolNOKParts = 0;
            iMaxTolNOKParts = 0;
            dMesValue = 0.0;
            dMesValue = 0.0;
            dNominalValue = 0.0;
            dMaxTol = 0.0;
            dMinTol = 0.0;
        }
    }

    public struct OptionData
    {
        //Заданные параметры из Form_56_Options
        public int iPeriferieTyp;            //Periferietyp (Bus, PCI - Karte etc.)
        public int iMesUnitNr;
        public bool[] bMesUnitActiv;
        public int iUnitType;                // Art der Anlage 1=Selector, 2=Schlitzteller, 3=V-Rutsche
        public int iInspectionPlanTypes;     // erlaubte Prьfplantypen
        public ulong[] ulMesToolsCamera;     // erlaubte Mestools Seitenkamera
        public int[] iMesToolsUnit;          // Fьr 8 Messeinheiten erlaubte Messtools
        public int iSystemModi;
        public string sInspectionPlanPath;
        public bool bWithoutExternalTrigger;

        public void Init()
        {
            bMesUnitActiv = new bool[ClassDaten.MAX_MES_UNITS];
            ulMesToolsCamera = new ulong[ClassDaten.MAX_CAMERA_TYPES];
            iMesToolsUnit = new int[ClassDaten.MAX_MES_UNITS];
        }

    }

    public struct PackCounter
    {
        //Упаковка Упаковка
        public int iContainerCount;     //Behдlterstьckzahl Gesamt
        public int iContainerCount2;    //Behдlterstьckzahl Zwischensumme

        public int iPiecesPerBox;       //Sollwert Teile / Karton

        public int iNumberOfBoxes;      //Sollwert Anzahl Kartons
        public int iPiecesSlowMode;     //Sollwert Antahl langsam

        public int iTotalIOCount;       //Istwert Total IO
        public int iPicesPerBoxCount;   //Istwert Teile / Karton
        public int iBoxesCount;         //Anzahl Kartons
    }

    public struct Password
    {
        // Form_80_Passwort
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

    public struct ProductStateData
    {
        public bool bActiv;                             // Staus Aktiv / Deaktiv
        public int iCounter;                            // Zдhler fьr Inkrementalgeberpulse
        public bool bResultIO;                          // Ergebnis IO
        public bool bResultSideKameraNIO;               // Ergebnis NIO Seitenkamera
        public bool bResultHeadKameraNIO;               // Ergebnis NIO Kopfkamera

        public void Init()
        {
            bActiv = false;
            iCounter = 0;
            bResultIO = false;
            bResultSideKameraNIO = false;
            bResultHeadKameraNIO = false;
        }

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
            dWeight = 0.0;
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

    public struct ResultPara
    {
        public int iCameraTyp;
        public bool bModelFound;

        public void Init()
        {
            iCameraTyp = -1;
            bModelFound = false;
        }
    }


    public struct SimPara
    {
        //Специфические данные модуля
        public ClassDaten.ContainerTyp enumContainertyp;
        public string sInspectionPlanName;
        public int iCameraNr;
        public int iModulIndex;
        public int iGripNr;
        public int iLayerNr;
        public int iPictureNr;
    }

    public struct SystemData
    {
        //Общие параметры системы
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

    public struct TCP_IP_SocketData
    {
        public string sServer;
        public string sID;
        public string sIPAddress;
        public int iPort;
        public int iRack;
        public int iSlot;
    }

    public struct VisionData
    {
        public string sInspectionPlanName;
        public int iInspectionPlanTyp;
        public int iCameraNr;
        public int iNumMatches;
        public int iNumLevels;
        public int iContrast;
        public int iMinContrast;
        public double dPhiOffset;
        public double dMinScoreMain;
        public double dMinScore;
        public double dMinScale;
        public double dGreediness;
        public int iAquisitionTime;
        public double dAngleStart;
        public double dAngleExtent;
        public int iGrayPercent;
        public int iGrayOffset;
        public string sMetric;
        public int iMinContourLength;
        public int iMaskWidth;
        public int iMaskHeight;

        public int iResult;


        public void Init()
        {
            sInspectionPlanName = string.Empty;
            iInspectionPlanTyp = 0;
            iCameraNr = 0;
            iNumLevels = 0;
            iContrast = 0;
            iMinContrast = 0;
            dPhiOffset = 0.0;
            dMinScore = 0.0;
            dMinScale = 0.0;
            dGreediness = 0.0;
            iResult = 0;
            iAquisitionTime = 0;
            dAngleStart = 0.0;
            dAngleExtent = 0.0;
            iGrayPercent = 0;
            iGrayOffset = 0;
            sMetric = string.Empty;
            iMinContourLength = 0;
            iMaskWidth = 0;
            iMaskHeight = 0;
        }
    }


    public class ClassDaten
    {
        //static ClassDaten()
        //{
        //    struct
        //}

        public enum PasswordTyp {Advisor1, Advisor2, Advisor3, Supervisor };

        public enum CameraTyp { LineScan, MatrixPosControl, Matrix };

        public static string[] sCameraTyp = { "Zeilenkamera", "Matrix Kamera PosControl", "Matrix Kamera" };

        public enum CameraHWTyp { IDS_uEye, Basler_GigE, MatrixVisionMVSigma, LeutronPicPortH4S, GigEVision, SickPLR3000 };
        
        public static string[] sCameraHWTyp = { "IDS_uEye", "Basler_GigE", "MatrixVisionMVSigma", "LeutronPicPortH4S", "GigEVision", "SickPLR3000" };
        public static string[] sUnit = { "mm", "mmІ", "%", "°", "Pixel", "PixelІ", "Stk", "GW", "    " };

        public enum ContainerTyp   // Behдltertyp
        {
            Tablar, LatticeBox, BigBox, Conveyor
        };

         public enum DataRoot { Image, Reference };

         public enum MessageTyp { Error, ErrorGone, ErrorStop, Info };

        public enum ShowImageMode { Show, Reference, ShowThread, Calibration };

        public enum ContourTyp { Circle, FourEdge, SixEdge };
        public enum ContourMode { Outer, Inner, InnerHole };

        public enum RegionTyp { Rectangle, Rectangle2, Nurbs, Circle, Ellipse };
        public enum PeriferieTyp
        {
            AddiData_PCIe1532 = 1, AddiData_PCIe1564 = 2, ModbusTCP = 4, ProfibusMaster = 8, ProfibusSlave = 16,
            SoftPLC = 32, SocketPLC = 64, TCPSocketServer = 128, TCPSocketClient = 256, SoftKeyboard = 512,
            AddiData_PCIe3521 = 1024
        };

        public static string[] sPeriferieTyp =
        { "AddiData_PCIe1532", "AddiData_PCIe1564", "ModbusTCP", "ProfibusMaster", "ProfibusSlave",
                  "SoftPLC", "SocketPLC", "TCPSocketServer", "TCPSocketClient", "Softkeyboard",
                  "AddiData_PCIe3521"
         };

        public enum InspectionPlanTyp
        {
            MeasurementElement, CasePosition
        };

        public enum MesToolCodeHeadCamera   //Kopfkamera
        {
            OuterDiameterCircle, InnerDiameterCircle, OuterDiameterToolMeasure, OuterDiameterCornerMeasure,
            InnerContourDiameterToolMeasure, InnerContourDiameterCornerMeasure, OuterContour, InnerContour, GrayProfileCircle,
            Shaving, Reserve1, Contour, Centricity, Area, Diameter, Length, BlobAna, MultiHolesAngle, MultiHolesDiameter, MultiHolesCircleDiameter
        };
        public enum MesToolCodeThreadCamera //Gewindekamera
        {
            Thread, ThreadDistance, Polyring
        };

        public enum MesToolCodeBackLight
        {
            MesRectHorContour = 11, MesRectVertContour = 12, MesHorContour = 13, MesVertContour = 14, CurvatureHorContour = 15,
            ThreePointHorContour = 21, ThreePointVertContour = 22,
            PhaseAngle = 31, Contour = 32, InnerCircleShaving = 33, CircleArea = 34, CircleDistance = 35,
            CircleInnerDiameter = 41, CircleOuterDiameter = 42, ContourCentricity = 43, MultiHolesDiameter = 44, MultiHolesAngle = 45, MultiHolesCircleDiameter = 46,
            NutCornerDiameter = 51, NutToolDiameter = 52, NutCornerDiameter4Edge = 53, NutToolDiameter4Edge = 54,
            ThreadLength = 61, ThreadDiff = 62, ThreadOuterDiameter = 63, ThreadInnerDiameter = 64, ThreadAngle = 65, ThreadAngleDiff = 66,
            ThreadCount = 71, ThreadShaving = 72,
            NutThreads = 81, NutThreadDiff = 82, NutPolyRing = 83, BlobAnalysis = 84, Coordinates = 85, SpecialContour = 86
        };

        public enum MesUnit1 //Messeinheit 1 Hцhenmessung
        {
            MaxHeight, NeckHeight
        };

        public enum UnitTyp //Anlagentyp
        {   // Glasteller, Glas V-Rutsche, Schlitzteller, Stanzenkontrolle, Robotvision  
            GlasDisk1, GlasV1, SlitDisk1, StampControl, RobotVision
        };

        public static string[] sUnitTyp = { "GlasDisk1", "GlasV1", "SlitDisk1", "StampControl", "RobotVision" };

        public enum LightTyp //Beleuchtungstyp
        {
            None, Flat, Ring_DarkField, Ring
        };

        //-------------------------------------------------------------------------------------------------- ---------
        // Data to PLC
        public static int MAX_DBytes = 128;
        public static byte[] DB200_Comunication = new byte[MAX_DBytes];
        public static byte[] DB202_Comunication = new byte[MAX_DBytes];


        // Data from PLC
        public static int MAX_DW = 64;
        public static ushort[] Db201_Communication = new ushort[MAX_DW];

        public static bool bWriteSPS = false;

        public static int iSPSReceive;
        public static int iSPSSend;
        public static int iOldSPSend;

        public static int RESET_ALL_COUNTER = 0x0004;
        public static int SLOW_DRIVE_ON = 0x0008;
        public static int HEIGHT_MES_ON = 0x0010;
        public static int DEPTH_MES_ON = 0x0020;
        public static int HOLE_MES_ON = 0x0040;
        public static int RES_SENSOR_MES_ON = 0x0100;
        public static int FESTO_MES_ON = 0x0200;

        public static int HOME_POS_REACHED = 0x0001;
        public static int SPS_STOPPED = 0x0002;
        public static int ALL_COUNTER_RESETED = 0x0004;

        public static int DATA_READY = 0x0001;
        public static int THREAD_MES_ON = 0x0002;
        public static int PART_NOT_FOUND = 0x0004;              // Kein Teil gefunden
        public static int PART_FOUND = 0x0008;                  // Korrektes Teil gefunden
        public static int ERROR_PART_FOUND = 0x0010;            // Fremdkцrper gefunden, Lage ist nicht leer
        public static int ERROR_PART_ANGLE = 0x0020;            // Drehwinkel des Teiles ausser Toleranz
        public static int ERROR_BASE_OFFSET = 0x0020;           // Error bei Basis Offsetermittlung
        public static int RES_1 = 0x0040;                       // Reserve
        public static int RES_2 = 0x0080;                       // Reserve
        public static int MODE_QUANTITY_RUN = 0x0100;           // Modus "nur Anzahl WT's bearbeiten" 
        public static int MODE_L1 = 0x0200;                     // Modus "Schwerlastbetrieb, nur Layer 1" 
        public static int MODE_L1_L2 = 0x0400;                  // Modus "Layer 1 + 2" 
        public static int RES_3 = 0x0800;                       // Reserve
        public static int CAMERA1_ACTIV = 0x1000;               // Kamera 1 Aktiv
        public static int CAMERA2_ACTIV = 0x2000;               // Kamera 2 Aktiv

        public static int CAMERA1_REQ = 0x0001;                 // Kamera1 angefordert

        public static int MODE_QUANTITY_RUN_READY = 0x0020;     // Modus "nur Anzahl WT's bearbeiten" fertig
        //-----------------------------------------------------------------------------------------------------------
        // Camera calibration options

        public static string[] sCalTabName = { "caltab_6.descr", "caltab_10.descr", "caltab_30.descr", "caltab_100.descr", "caltab_200.descr", "caltab_400.descr", "caltab_800.descr" };
        public static string[] sEstimateOption = { "all", "pose", "camera", "alpha", "beta", "gamma", "transx", "transy", "trans", "focus", "kappa", "poly", "poly_rad_2", "poly_rad_4", "poly_rad_6", "poly_tan_2", "cx", "cy", "sx", "sy", "vx", "vy", "vz" };
        public static string[] sCameraSytemTyp = { "Single", "Stereo" };
        public static string[] sCameraCalMethod = { "Center Origin", "3 Point" };

        // Options for measurement tools
        public static string[] sMesTypString1 = { "Std", "Max", "Min", "T-Pkt", "S-Pkt", "Exznt", "M-Linie", "Kante" };
        public static string[] sMesTypString2 = { "Std", "Direkt" };
        public static string[] sMesTypString3 = { "Ref=0", "+Tol" };
        public static string[] sMesTypString4 = { "Sym", "Asym" };
        public static string[] sMesTypString5 = { "Aussen", "Innen" };
        public static string[] sSWOption = { "SW_WS", "WS_SW", "Alle" };

        public const double IMAGE_ZOOM_VALUE = 0.65; // Коэффициент увеличения для масштабирования

        public const int MAX_CAMERAS = 6;
        public const int MAX_LAYER = 1;
        public const int MAX_CAMERA_TYPES = 3;
        public const int MAX_UNIT_TYPES = 3;                          // Max. Anzahl Maschinentypen  
        public const int MAX_MES_UNITS = 8;                           // Max. Anzahl Messeinheiten (Keine kameras)
        public const int MAX_STRUCT_MESPROGDATA = 50;                 // Max. StrukturgrцЯe fьr Messprogrammdaten  
        public const int MAX_STRUCT_MESUNITDATA = 10;                 // Max. StrukturgrцЯe fьr Messsystemdaten 

        public const int MAX_TEST_PICTURES = 2000;                    // Максимальное количество тестовых изображений для моделирования
        public const int MAX_IMAGE_COUNT = 2000;                      // Максимальное количество сохраняемых изображений на камеру

        public const int MAX_WORKER = 12;                             //Максимальное количество рабочих для авторизации

        public const int MAX_PRODUCT_STATE_DATA = 30;                 // Maximale Anzahl Produktstrukturen
        public const int MAX_INSPECTION_PLAN_TYPES = 16;
        public const int MAX_OPTIONS = 34;                            // Максимальное количество вариантов измерения, текст находится в "EnglishText.ini"
        public static int iMaxInspectionPlanTypes = 13;                // Доступно до 13 типов планов тестирования
        public static int[] iMaxOptions = { 27, 4, 30 };              // Установите параметры, доступные для головной, резьбовой и боковой камер
        public static int[] iMaxOptionsMesUnit = { 2, 0, 0, 0, 0, 0, 0, 0 }; // Задать параметры, доступные для 8 единиц измерения

        public const string LOGBOOK_FILENAME = "Logbook.txt";
        public const string DEFAULT_PASSWORD = "*KEHRATEC";

        public static string sDATA_PATH = "..\\..\\..\\VisionControl\\Data\\";
        public static string sMESSAGE_PATH = "..\\..\\..\\VisionControl\\Messages";
        public static string sHELP_PATH = "..\\..\\..\\VisionControl\\Help\\";
        public static string sINSPECTIONPLAN_PATH = "..\\..\\..\\VisionControl\\InspectionPlanFiles\\";
        public const string SUBDIRECTORY_CALIBRATION_DATA = "CalibrationData";
        public const string SUBDIRECTORY_REGIONS = "Regions";
        public const string SUBDIRECTORY_IMAGES = "Images";
        public const string SUBDIRECTORY_REFERENCE = "Reference";
        public const string REFERENCE = "Reference";

        //Параметры камеры и позы из калибровки камеры
        public const string CAM_POSE_CAMERA = "CamPoseCamera";
        public const string CAM_PAR_CAMERA = "CamParCamera";
        public const string MAP_IMAGE_CAMERA = "MapImageCamera";
        public const string RECT_PAR_CAMERA = "RectParCamera";
        public const string DISPARITY = "DisparityCamera";
        public const string CAM_POSE_LEFT_TO_RIGHT = "CamPose_LeftToRight";
        public const string HOMMAT3D_RECT_CCS_TO_WCS = "HomMat3d_RectCCS_to_WCS";
        public const string RECT_L_POS_RECT_R = "RectLPosRectR";
        public const string STEREO_CAM_SETUP_MODEL = "StereoCamSetupModel";


        //Области для головных камер
        public const string OUTER_DIAMETER_REGION_HEAD_CAMERA = "OuterDiameterRegionHeadCamera";
        public const string INNER_DIAMETER_REGION_HEAD_CAMERA = "InnerDiameterRegionHeadCamera";
        public const string OUTER_CONTOUR_REGION1_HEAD_CAMERA = "OuterContourRegion1HeadCamera";
        public const string OUTER_CONTOUR_REGION2_HEAD_CAMERA = "OuterContourRegion2HeadCamera";
        public const string INNER_CONTOUR_REGION1_HEAD_CAMERA = "InnerContourRegion1HeadCamera";
        public const string INNER_CONTOUR_REGION2_HEAD_CAMERA = "InnerContourRegion2HeadCamera";
        public const string CONTOUR_REGION_HEAD_CAMERA = "ContourRegionHeadCamera";
        public const string CONTOUR_MODEL_HEAD_CAMERA = "ContourModelHeadCamera";
        public const string CENTRICITY_REGION1_HEAD_CAMERA = "CentricityRegion1HeadCamera";
        public const string CENTRICITY_REGION2_HEAD_CAMERA = "CentricityRegion2HeadCamera";
        public const string BLOB_ANA_REGION1_HEAD_CAMERA = "BlobAnaRegion1HeadCamera";
        public const string BLOB_ANA_REGION2_HEAD_CAMERA = "BlobAnaRegion2HeadCamera";
        public const string GRAY_PROFILE_REGION1_HEAD_CAMERA = "GrayProfileRegion1HeadCamera";
        public const string GRAY_PROFILE_REGION2_HEAD_CAMERA = "GrayProfileRegion2HeadCamera";
        public const string AREA_REGION_HEAD_CAMERA = "AreaRegionHeadCamera";
        public const string DIAMETER_REGION1_HEAD_CAMERA = "DiameterRegion1HeadCamera";
        public const string DIAMETER_REGION2_HEAD_CAMERA = "DiameterRegion2HeadCamera";
        public const string SHAVING_INPUTREGION_HEAD_CAMERA = "ShavingInputRegionHeadCamera";
        public const string SHAVING_REGION_HEAD_CAMERA = "ShavingRegionHeadCamera";
        public const string LENGTH_REGION1_HEAD_CAMERA = "LengthRegion1HeadCamera";
        public const string LENGTH_REGION2_HEAD_CAMERA = "LengthRegion2HeadCamera";
        public const string MAIN_MODEL1_HEAD_CAMERA = "MainModel1HeadCamera";
        public const string MAIN_MODEL2_HEAD_CAMERA = "MainModel2HeadCamera";
        public const string MAIN_REGION1_REF_HEAD_CAMERA = "MainRegion1RefHeadCamera";
        public const string MAIN_REGION2_REF_HEAD_CAMERA = "MainRegion2RefHeadCamera";

        //Области для камер с резьбой
        public const string MAIN_REGION_THREAD_CAMERA = "MainRegionThreadCamera";
        public const string THREAD_REGION_THREAD_CAMERA = "ThreadRegionThreadCamera";
        public const string POLYRING_REGION_THREAD_CAMERA = "PolyringRegionThreadCamera";
        public const string INNER_CONTOUR_REGION_THREAD_CAMERA = "InnerCoutourRegionThreadCamera";
        public const string REGIONREF_THREAD_CAMERA = "RegionRefThreadCamera";
        public const string INNER_CONTOUR_MODEL_THREAD_CAMERA = "InnerContourModelThreadCamera";

        //Области для камер
        public const string SHAVING_REGION1_CAMERA = "ShavingRegion1Camera";
        public const string SHAVING_REGION2_CAMERA = "ShavingRegion2Camera";
        public const string SEARCH_REGION_CAMERA = "SearchRegionCamera";
        public const string NURBS_MAIN_REGION1_CAMERA = "NurbsMainRegion1Camera";
        public const string NURBS_MAIN_REGION2_CAMERA = "NurbsMainRegion2Camera";
        public const string MAIN_REGION1_CAMERA = "MainRegion1Camera";
        public const string MAIN_REGION2_CAMERA = "MainRegion2Camera";
        public const string EXCLUSION_REGION1_CAMERA = "ExclusionRegion1Camera";
        public const string EXCLUSION_REGION2_CAMERA = "ExclusionRegion2Camera";
        public const string MES_POINT_REGION_CAMERA = "MesPointRegionCamera";
        public const string DISK_REGION1_CAMERA = "DiskRegion1Camera";
        public const string DISK_REGION2_CAMERA = "DiskRegion2Camera";
        public const string MAIN_MODEL1_CAMERA = "MainModellCamera";
        public const string MAIN_MODEL2_CAMERA = "MainModel2Camera";
        public const string MAIN_MODEL_REGION1_CAMERA = "MainModelRegion1Camera";
        public const string MAIN_MODEL_REGION2_CAMERA = "MainModelRegion2Camera";
        public const string MAIN_REGION1_REF_CAMERA = "MainRegion1RefCamera";
        public const string MAIN_REGION2_REF_CAMERA = "MainRegion2RefCamera";
        public const string NURBS_EXCLUSION_REGION_CAMERA = "NurbsExclusionRegionCamera";

        public const string GRIP_REGION_CAMERA = "GripRegionCamera";
        public const string CIRCLE_DIAMETER_REGION_1_CAMERA = "CircleDiameterRegion1Camera";
        public const string CIRCLE_DIAMETER_REGION_2_CAMERA = "CircleDiameterRegion2Camera";
        public const string CIRCLE_DISTANCE_REGION_CAMERA = "CircleDistanceRegionCamera";
        public const string DIAMETER_REGION_1_CAMERA = "DiameterRegion1Camera";
        public const string DIAMETER_REGION_2_CAMERA = "DiameterRegion2Camera";
        public const string LENGTH_REGION_1_CAMERA = "LengthRegion1Camera";
        public const string LENGTH_REGION_2_CAMERA = "LengthRegion2Camera";
        public const string LENGTH_TO_LINE_REGION1_CAMERA = "LengthToLineRegion1Camera";
        public const string LENGTH_TO_LINE_REGION2_CAMERA = "LengthToLineRegion2Camera";
        public const string LENGTH_TO_LINE_REGION3_CAMERA = "LengthToLineRegion3Camera";
        public const string THREAD_REGION_CAMERA = "ThreadRegionCamera";
        public const string MESDIAMETER_REGION_CAMERA = "MesDiameterRegionCamera";
        public const string MESLENGTH_REGION_CAMERA = "MesLengthRegionCamera";
        public const string CONTOUR_REGION_CAMERA = "ContourRegionCamera";
        public const string CONTOUR_MODEL_CAMERA = "ContourModelCamera";
        public const string CURVATURE_REGION_1_CAMERA = "CurvatureRegion1Camera";
        public const string CURVATURE_REGION_2_CAMERA = "CurvatureRegion2Camera";
        public const string PHASEANGLE_REGION_CAMERA = "PhaseAngleRegionCamera";
        public const string HOLES_REGION1_CAMERA = "HolesRegion1Camera";
        public const string HOLES_REGION2_CAMERA = "HolesRegion2Camera";
        public const string HOLES_REGION3_CAMERA = "HolesRegion3Camera";
        public const string CONTOUR_REGION1_CAMERA = "ContourRegion1Camera";
        public const string CONTOUR_REGION2_CAMERA = "ContourRegion2Camera";
        public const string CONTOUR_REGION3_CAMERA = "ContourRegion3Camera";
        public const string CONTOUR_REGION4_CAMERA = "ContourRegion4Camera";

        // i_OP_PictureNr 10 = Большое изображение камеры
        // i_OP_PictureNr 20 = отображение значения
        // i_OP_PictureNr 30 = Все изображения
        // i_OP_PictureNr 40 = Всегда установочное изображение
        // i_OP_PictureNr 41 = окно для единицы измерения (установочное изображение)
        // i_OP_PictureNr 42 = окно для управления bibus (установочное изображение)
        // i_OP_PictureNr 43 = окно для общего. Проверка дисковода (экран настройки)
        // i_OP_PictureNr 44 = окно для общего. Управление приводом камеры (экран настройки)

        // имя типа вложения
        public static string sUnitName;
        public static int MAX_ERROR_WORDS = 3;
        public static int MAX_TEXT_WORDS = 3;
        public static ushort[] ushErrorData = new ushort[MAX_ERROR_WORDS];
        public static ushort[] ushOldErrorData = new ushort[MAX_ERROR_WORDS];
        public static ushort[] ushTextData = new ushort[MAX_TEXT_WORDS];
        public static ushort[] ushOldTextData = new ushort[MAX_TEXT_WORDS];

        // Создаем необходимые структуры
        public static BoxData structBoxData = new BoxData();
        public static ResultPara[] structResultPara = new ResultPara[MAX_CAMERAS];
        public static InspectionPlanData structInspectionPlanData = new InspectionPlanData();
        public static CamPara[] structCamPara = new CamPara[MAX_CAMERAS];
        public static SystemData structSystemData = new SystemData();
        public static OptionData structOptionData = new OptionData();
        public static CalibrationParameter[,] structCalParam = new CalibrationParameter[MAX_CAMERAS, MAX_LAYER];
        public static ProductStateData[] structProductStateData = new ProductStateData[ClassDaten.MAX_PRODUCT_STATE_DATA];
        public static RoboterData structRoboterData = new RoboterData();
        public static VisionData[] structVisionData = new VisionData[MAX_CAMERAS];
        public static MesProgData[] structMesProgData = new MesProgData[MAX_STRUCT_MESPROGDATA];
        public static MesUnitData[] structMesUnitData = new MesUnitData[MAX_STRUCT_MESUNITDATA];
        public static PackCounter structPackCounter = new PackCounter();
        public static Counter structCounter = new Counter();
        public static Autorisation[] structAutorisation = new Autorisation[MAX_WORKER];
        public static TCP_IP_SocketData struct_TCP_IP_Socketdata = new TCP_IP_SocketData();
        public static MesProgData structMesProgDataCal = new MesProgData();  // Form_23_MesProgCalibration
        public static MeasurementData[] structBaseOffsets = new MeasurementData[MAX_CAMERAS];
        public static Password structPassword = new Password();  // Form_80_Password
        public static SimPara structSimPara = new SimPara();

        // Form_96_AIAO 
        public static int iAI_Bits = 16;    // Разрешение аналогового входа
        public static int iAO_Bits = 15;    // Analog Output Auflцsung APCI 3521 15 Bits, 0V .. + 10V unipolar!!
        public const int MAX_AI_CHANNEL = 4;
        public const int MAX_AO_CHANNEL = 4;

        static public int[] iAnalogInput = new int[MAX_AI_CHANNEL];
        static public int[] iAnalogOutput = new int[MAX_AO_CHANNEL];

        // Signale fьr alle Systeme
        public static uint input_DigitalTriggerCams;            // Triggersignal von LS
        public static uint input_TriggerCam_1;                  // Triggersignal Camera 1
        public static uint input_TriggerCam_2;                  // Triggersignal Camera 2
        public static uint input_TriggerCam_3;                  // Triggersignal Camera 3
        public static uint input_TriggerCam_4;                  // Triggersignal Camera 4
        public static uint input_TriggerCam_5;                  // Triggersignal Camera 5
        public static uint input_TriggerCam_6;                  // Triggersignal Camera 6
        public static uint input_IncrementSensor;               // Inkrementalgebersignal
        public static uint input_IO_Sensor;                     // TAW Signal von IO - LS

        public static uint inputChangeBoxOK;                    // Kartonwechsel erfolgt
        public static uint inputRemovalConveyorReady;           // BTB Auslaufband
        public static uint inputLS_LinearOutputEmpty;           // Staulichtschranke Linearfцrderer (Leer = 1)
        public static uint input_Isolator_SensorOn;             // Verreinzelung TAW 
        public static uint input_Isolator_On;                   // Verreinzelung Aktiv
        public static uint input_Isolator_Off;                  // Verreinzelung Aus
        public static uint input_LinearOutputEmpty;             // Staulichtschranke Linearfцrderer (Leer = 1)
        public static uint input_LinearInputEmpty;              // Staulichtschranke Linearfцrderer (Leer = 1)
        public static uint inputLS_Preselect;                   // Vereinzelungslichschranke am Einlaufband
        public static uint inputLS1_Activ;                      // Linearfцrderer 1 aktiv    
        public static uint inputLS2_Activ;                      // Linearfцrderer 2 aktiv  
        public static uint inputSpiralOutputEmpty;              // Fьllstand Wendelfцrderer (Leer = 1)
        public static uint inputAirPressureOK;                  // Luftdruck OK

        public static uint input_LS_Preselect;                  // Vereinzelungslichschranke am Einlaufband
        public static uint input_SpiralOutputEmpty;             // Fьllstand Wendelfцrderer (Leer = 1)
        public static uint input_LS_DistanceMes;                // Lichtschranke Distanzmessung
        public static uint input_LS_IO_Flap;                    // Teil an IO/NIO Klappe
        public static uint input_Ini_Flap_NIO;                  // Klappe in NIO Position
        public static uint input_Ini_Flap_IO;                   // Klappe in IO Position
        public static uint input_LS_IOCount;                    // IO- Zдhllichtschranke
        public static uint input_E_Stop;                        // Not Aus (0) Emergency Stop
        public static uint input_SystemDeactivated;             // System deaktiviert

        public static uint inputNIO_1_InPushPos;                // Pusher NIO 1 (Seitenkamera) ausgefahren
        public static uint inputNIO_1_InBackPos;                // Pusher NIO 1 (Seitenkamera) eingefahren
        public static uint inputNIO_2_InPushPos;                // Pusher NIO 2 (Kopfkamera) ausgefahren
        public static uint inputNIO_2_InBackPos;                // Pusher NIO 2 (Kopfkamera) eingefahren
        public static uint inputIO_InPushPos;                   // Pusher NIO 2 (Kopfkamera) ausgefahren
        public static uint inputIO_InBackPos;                   // Pusher NIO 2 (Kopfkamera) eingefahren

        public static uint input_OK_SignalQuit;                 // IO/NIO Ergebnis von SPS akzeptiert
        public static uint input_OK_SignalQuitCam1;             // IO/NIO Ergebnis von SPS akzeptiert Kamera 1
        public static uint input_OK_SignalQuitCam2;             // IO/NIO Ergebnis von SPS akzeptiert Kamera 2
        public static uint input_OK_Signal;                     // Gesamtergebnis IO
        public static uint input_NOK_Signal;                    // Gesamtergebnis NIO

        public static uint input_Height_OK_Signal;              // Ergebnis Hцhenmessung IO
        public static uint input_Height_NOK_Signal;             // Ergebnis Hцhenmessung NIO
        public static uint input_Depth_OK_Signal;               // Ergebnis Tiefenmessung IO
        public static uint input_Depth_NOK_Signal;              // Ergebnis Tiefenmessung NIO

        public static uint input_USV_Alarm;                     // USV Alarm Signal
        public static uint input_USV_Battery;                   // USV Alarm Battery
        public static uint input_USV_Charge;                    // USV Alarm Charge

        public static uint output_TriggerCam_1;                 // Triggerausgang
        public static uint output_TriggerCam_2;                 // Triggerausgang
        public static uint output_TriggerCam_3;                 // Triggerausgang
        public static uint output_TriggerCam_4;                 // Triggerausgang
        public static uint output_TriggerCam_5;                 // Triggerausgang
        public static uint output_TriggerCam_6;                 // Triggerausgang

        public static uint output_NIO_1_Valve;                  // NIO Dьse, Pusher oder Klappe
        public static uint output_NIO_2_Valve;                  // NIO Dьse, Pusher oder Klappe
        public static uint output_IO_Valve;                     // IO Dьse oder Klappe

        public static uint output_IO_Valve1;                    // IO Dьse oder Klappe
        public static uint output_IO_Valve2;                    // IO Dьse oder Klappe
        public static uint output_IO_Valve3;                    // IO Dьse oder Klappe

        public static uint output_DriveDisable;                 // Antriebsmotor /Disable
        public static uint output_DriveDirection;               // Antriebsmotor Richtung
        public static uint output_DriveBrake;                   // Antriebsmotor /Bremse

        public static uint output_Isolator_On;                  // Vereinzelung aktiv
        public static uint output_Isolator_Off;                 // Vereinzelung Aus

        public static uint outputFlatlight;                     // Ausgang Fдchenleuchte
        public static uint outputRinglight;                     // Ausgang Ringleuchte

        public static uint outputRemovalConveyorOn;             // Auslaufband Ein
        public static uint outputPreselectConveyorOn;           // Vereinzelungsband Ein
        public static uint outputPreselectNozzleOn;             // Vereinzelungsbanddьse Ein
        public static uint outputLinearOutput1On;               // Linearfцrderer 1 Ein
        public static uint outputLinearOutput2On;               // Linearfцrderer 2 Ein
        public static uint outputSpiralOutputOn;                // Wendelfцrderer Ein
        public static uint outputSpiralOutputMode;              // Wendelfцrderer Modus ohne Schwingweitensensor
        public static uint outputBoxOutputOn;                   // Bunker Ein
        public static uint outputCamReady;                      // Kameraauswertung fertig
        public static uint outputNoMaterial;                    // Materialmangel
        public static uint outputPCActive;                      // Messprogramm aktiv
        public static uint outputChangeBox;                     // Kartonwechsel
        public static uint outputError;                         // Stцrungsleuchte
        public static uint outputTriggerWatchdog;               // Lifebit
        public static uint outputE_Stop_Light;                  // Not - Aus Leuchte (LM)
        public static uint outputServiceLight;                  // Einrichtlampe
        public static uint outputEnable;                        // Freigabesignal

        public static uint outputCam1Activ;                     // Kamera aktiv
        public static uint outputCam2Activ;                     // Kamera aktiv
        public static uint outputDataReady;                     // Daten liegen an
        public static uint outputPartFound;                     // Teil gefunden
        public static uint outputPartNotFound;                  // Teil nicht gefunden

        public static uint output_TriggerQuitCam1;              // Triggerquittierung an SPS Kamera 1
        public static uint output_TriggerQuitCam2;              // Triggerquittierung an SPS Kamera 2
        public static uint output_TriggerQuit;                  // Triggerquittierung an SPS
        public static uint output_NOK_Cam;                      // Ergebnis NIO an SPS
        public static uint output_OK_Cam;                       // Ergebnis IO an SPS
        public static uint output_NOK_Cam1;                     // Ergebnis NIO an SPS Kamera 1
        public static uint output_OK_Cam1;                      // Ergebnis IO an SPS Kamera 1
        public static uint output_NOK_Cam2;                     // Ergebnis NIO an SPS Kamera 2 
        public static uint output_OK_Cam2;                      // Ergebnis IO an SPS Kamera 2

        public static uint output_PreselectConveyorOn;          // Vereinzelungsband Ein
        public static uint output_PreselectNozzleOn;            // Vereinzelungsbanddьse Ein


        public static SampleUnion su = new SampleUnion();


        static public byte[] StructureToByteArray(object obj)
        {
            try
            {
                int len = Marshal.SizeOf(obj);
                byte[] arr = new byte[len];
                IntPtr ptr = Marshal.AllocHGlobal(len);
                Marshal.StructureToPtr(obj, ptr, false);
                Marshal.Copy(ptr, arr, 0, len);
                Marshal.FreeHGlobal(ptr);
                return arr;

            }
            catch
            {

            }
            return null;
        }
        

        static public void ByteArrayToStructure(byte[] bytearray, ref object obj)
        {
            int len = Marshal.SizeOf(obj);

            IntPtr i = Marshal.AllocHGlobal(len);
            try
            {
                Marshal.Copy(bytearray, 0, i, len);
                obj = Marshal.PtrToStructure(i, obj.GetType());
                Marshal.FreeHGlobal(i);
            }
            catch
            {
                Marshal.FreeHGlobal(i);
            }
        }

        public static void CreateDirectories(string sInspectionPlanName)
        {
            DirectoryInfo Directory;
            DirectoryInfo SubDirectory;

            string sDirectory = sINSPECTIONPLAN_PATH + sInspectionPlanName;

            try
            {
                Directory = new DirectoryInfo(sInspectionPlanName);
                if (Directory.Exists==false)
                {
                    Directory.Create();
                    SubDirectory = Directory.CreateSubdirectory(ClassDaten.SUBDIRECTORY_IMAGES);
                    SubDirectory = Directory.CreateSubdirectory(ClassDaten.SUBDIRECTORY_REFERENCE);
                    SubDirectory = Directory.CreateSubdirectory(ClassDaten.SUBDIRECTORY_REGIONS);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error DeleteDirectories", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public static void DeleteAllFiles(string sSource)
        {
            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);

            try
            {
                FileInfo[] fi = di.GetFiles(sSource);

                foreach (FileInfo fiTemp in fi)
                {
                    File.Delete(fiTemp.Name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
        
        }


        public static string GetInspectionPlanPath(string sSlash)
        {
            string sInspectionPlanPath = sINSPECTIONPLAN_PATH;

            DirectoryInfo Directory;

            Directory = new DirectoryInfo(sInspectionPlanPath);

            if (Directory.Exists==true)
            {
                sInspectionPlanPath = Directory.FullName;
            }
            return sInspectionPlanPath;

        }


        public static void GetMesToolCode(ulong ulMesToolCode)
        {
            if ((ulMesToolCode & 0x00000001) == 0x00000001) ClassDaten.structInspectionPlanData.bHeightMeasure = true; else ClassDaten.structInspectionPlanData.bHeightMeasure = false;
            if ((ulMesToolCode & 0x00000002) == 0x00000002) ClassDaten.structInspectionPlanData.bHeightMeasure = true; else ClassDaten.structInspectionPlanData.bDepthMeasure = false;
            if ((ulMesToolCode & 0x00000004) == 0x00000004) ClassDaten.structInspectionPlanData.bHoleCheck = true; else ClassDaten.structInspectionPlanData.bHoleCheck = false;
            if ((ulMesToolCode & 0x00000008) == 0x00000008) ClassDaten.structInspectionPlanData.bThreadCheck = true; else ClassDaten.structInspectionPlanData.bThreadCheck = false;
            if ((ulMesToolCode & 0x00000010) == 0x00000010) ClassDaten.structInspectionPlanData.bResSensorCheck = true; else ClassDaten.structInspectionPlanData.bResSensorCheck = false;
            if ((ulMesToolCode & 0x00000020) == 0x00000020) ClassDaten.structInspectionPlanData.bFestoCheck = true; else ClassDaten.structInspectionPlanData.bFestoCheck = false;
        }


        public static void MoveFile(string sSource, string sDestination)
        {
            try
            {
                File.Copy(sSource, sDestination, true);
                File.Delete(sSource);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void MoveAllFiles(string sSource, string sPath)
        {
            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);
            try
            {
                FileInfo[] fi = di.GetFiles(sSource);


                foreach(FileInfo fiTemp in fi)
                {
                    File.Copy(fiTemp.Name, sPath + fiTemp.Name, true);
                    File.Delete(fiTemp.Name);
                
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public static void SetAllDataPathes()
        {
            ClassDaten.sDATA_PATH = "..\\..\\..\\"+ClassDaten.sUnitName+"\\Data\\";
            ClassDaten.sMESSAGE_PATH = "..\\..\\..\\" + ClassDaten.sUnitName + "\\Messages\\";
            ClassDaten.sHELP_PATH = "..\\..\\..\\" + ClassDaten.sUnitName + "\\Help\\";
            ClassDaten.sINSPECTIONPLAN_PATH = "..\\..\\..\\" + ClassDaten.sUnitName + "\\InspectionPlanFiles\\";
        }



    }
}
