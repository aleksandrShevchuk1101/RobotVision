using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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
        public bool bCamerActivPresent;
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

    public struct InspectionData
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

        public enum PasswordTyp {Advisor1, Advisor2, Advisor3, Advisor };

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



    }
}
