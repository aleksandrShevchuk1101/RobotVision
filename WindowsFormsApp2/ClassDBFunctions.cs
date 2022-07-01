using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace CS_KEHRATEC
{
    class ClassDBFunctions
    {
        static string sDB_FileName = ClassDaten.sDATA_PATH + "ApplicationDB.mdb";
        static string sIniFileName = ClassDaten.sDATA_PATH + "Application.ini";
        static string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + ClassDaten.sDATA_PATH + "ApplicationDB.mdb;";
        static string sSelectRoboterData = "SELECT * FROM RoboterData WHERE InspectionPlanName LIKE";
        static string sSelectVisionData = "Select * FROM VisionData WHERE InspectionPlanName LIKE";


        static OleDbConnection conn = null;

        static ClassDBFunctions()
        {

        }


        public static void CopyColums(ref DataTable dt, string sInspectionPlanName, string sNewInspectionPlanName)
        {
            try
            {
                DataRow[] cRow = dt.Select();
                for (int i = 0; i < cRow.Length; i++)
                {
                    if (cRow[i]["InspectionPlanName"].ToString()== sInspectionPlanName)
                    {
                        DataRow newRow = dt.NewRow();

                        object[] ar = new object[cRow[i].Table.Columns.Count];
                        int j = 0;


                        foreach (DataColumn column in cRow[i].Table.Columns)
                        {
                            ar[j] = cRow[i][column];
                            j++;
                        }

                        j = 0;

                        foreach (DataColumn column in newRow.Table.Columns)
                        {

                            if ((column.ColumnName != "InspectionPlanName") &&
                                (column.ColumnName.ToLower() != "autowert"))
                            {
                                object o = ar.GetValue(j);
                                newRow[column.ColumnName] = ar.GetValue(j);

                            }
                            j++;
                        }
                        newRow["InspectionPlanName"] = sNewInspectionPlanName;
                        dt.Rows.Add(newRow);
                    }
                }

            }
            catch (Exception exception)
            {

                MessageBox.Show("Error while copying column values : " + exception.Message);

            }
            finally
            {
                conn.Close();
            }


        } 

        public static int CounterDataExists(string sInspectionPlanName, int iID)
        {
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sSelectCounterData = "SELECT * FROM [Counter] WHERE " +
                            "(InspectionPlanName = '" + sInspectionPlanName + "') AND " +
                            "(ID = " + iID + ")";

            OleDbConnection conn = null;

            conn= new OleDbConnection(sConnection);

            OleDbCommand cmd = new OleDbCommand(sSelectCounterData, conn);
            OleDbDataReader dr;
            int Result = 0;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result = 1;

                }

                dr.Close();

                if (Result==0)
                    Result = 2;

            }
            catch (Exception exception)
            {

                MessageBox.Show("Error while reading Counter - Data : " + exception.Message);

            }
            finally
            {
                conn.Close();
            }

            return Result;

        }

        public static int CounterDataUnitExists(string sInspectionPlanName, int iMesToolNr)
        {
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sSelectCounterData = "Select * from [counter] where " + "(InspectionPlanName = '" + sInspectionPlanName + "') AND " +
                                        "(MesUnitNr = " + iMesToolNr + ")";

            OleDbConnection conn = null;
            conn= new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectCounterData, conn);
            OleDbDataReader dr;
            int Result = 0;

            try
            {
                conn.Open();
                dr=cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result = 1;
                }

                if (Result==0)
                    Result = 2;


            }
            catch (Exception exception)
            {

                MessageBox.Show("Error while reading ToolCounter - Data : " + exception.Message);
            }
            finally
            {
                conn.Close();
            }

            return Result;
        }

        public static void DeleteCounterData(string sInspectionPlanName,  int iID)
        {
            int iResult = 0;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sCommand = string.Empty;

            OleDbConnection conn = null;

            conn = new OleDbConnection(sConnection);
            iResult = ClassDBFunctions.CounterDataExists(ClassDaten.structSystemData.sActualInspectionPlan, iID);
            if (iResult==1)
            {
                sCommand = "DELETE * FROM [Counter] WHERE " +
                           "(InspectionPlanName = '" + sInspectionPlanName + "')" + " AND " +
                          "(ID = " + iID + ")";

                OleDbCommand cmd = new OleDbCommand(sCommand, conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();



                }
                catch (Exception exception)
                {

                    MessageBox.Show("Error while deleting Counterdata from IDNr. '" + iID + "' :" + exception.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        public static void DeleteData(string sInspectionPlanName, string sDataBaseName)
        {
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sCommand = "DELETE * FROM ["+ sDataBaseName+"] WHERE (InspectionPlanName=";


            OleDbConnection conn = null;

            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sCommand, conn);


            OleDbDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                dr.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error while deleting " + sInspectionPlanName + " in " + sDataBaseName + " : " + exception.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        public static int InspectionPlanExists(string sInspectionPlanName)
        {
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sSelectData = "SELECT * FROM [InspectionPlan] WHERE " + "(InspectionPlanName='"+ sInspectionPlanName+"')";

            OleDbConnection conn = null;


            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectData,conn);
            OleDbDataReader dr;

            int Result = 0;
            string sMesProg;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sMesProg = dr["Comment"].ToString();
                    Result = 1;
                }
                dr.Close();
                if (Result == 0)
                    Result = 2;
            }
            catch (Exception exception)
            {

                MessageBox.Show("Error while reading InspectionPlan - Data : " + exception.Message);
            }
            finally
            {
                conn.Close();
            }

            return Result;


        }

        private static void GetMesProgData(ref MesProgData structMesProgData, OleDbDataReader dr)
        {
            //Form MesProgEdit
            structMesProgData.iID = StrToInt(dr["ID"]);
            structMesProgData.sMesProgName = dr["MesProgName"].ToString();
            structMesProgData.iRefNr = StrToInt(dr["RefNr"]);
            structMesProgData.iCameraNr = StrToInt(dr["CameraNr"]);
            structMesProgData.iCameraTyp = StrToInt(dr["CameraTyp"]);
            structMesProgData.iMesUnitNr = StrToInt(dr["MesUnitNr"]);

            structMesProgData.bMesProgActiv = (bool)dr["MesProgActiv"];
            structMesProgData.ulMesToolCode = (ulong)StrToDouble(dr["MesToolCode"]);
            structMesProgData.bRotationEnable = (bool)dr["RotationEnable"];
            structMesProgData.bOverLength = (bool)dr["OverLength"];

            //Form MesProgNominalValue
            structMesProgData.dNominalValue = StrToDouble(dr["NominalValue"]);
            structMesProgData.dMaxTol = StrToDouble(dr["MaxTol"]);
            structMesProgData.dMinTol = StrToDouble(dr["MinTol"]);
            structMesProgData.sUnit = dr["Unit"].ToString();

            //Form MesProgCalibration
            structMesProgData.dMesValue = StrToDouble(dr["MesValue"]);
            structMesProgData.dCalValue = StrToDouble(dr["CalValue"]);

            //Form MesProgCalibration
            structMesProgData.sBW_WB = dr["BW_WB"].ToString();
            structMesProgData.iThreshold = StrToInt(dr["Threshold"]);
            structMesProgData.iLowGray = StrToInt(dr["LowGray"]);
            structMesProgData.iHighGray = StrToInt(dr["HighGray"]);
            structMesProgData.dAlpha = StrToDouble(dr["Alpha"]);
            structMesProgData.iGrayPercent = StrToInt(dr["GrayPercent"]);
            structMesProgData.iGrayOffset = StrToInt(dr["GrayOffset"]);
            structMesProgData.sMesTyp1 = dr["MesTyp1"].ToString();
            structMesProgData.sMesTyp2 = dr["MesTyp2"].ToString();
            structMesProgData.sMesTyp3 = dr["MesTyp3"].ToString();
            structMesProgData.iMin1 = StrToInt(dr["Min1"]);
            structMesProgData.iMax1 = StrToInt(dr["Max1"]);
            structMesProgData.iMin2 = StrToInt(dr["Min2"]);
            structMesProgData.iMax2 = StrToInt(dr["Max2"]);
            structMesProgData.iMin3 = StrToInt(dr["Min3"]);
            structMesProgData.iMax3 = StrToInt(dr["Max3"]);
            structMesProgData.iMin4 = StrToInt(dr["Min4"]);
            structMesProgData.iMax4 = StrToInt(dr["Max4"]);

        }


        public static bool LightParameterExists(string sInspectionPlanName)
        {
            bool bExist = false;

            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;

            string sSelectCommand = "SELECT * FROM [LightParameter] WHERE " + "InspectionPlanName = '" + sInspectionPlanName + "'";

            OleDbConnection conn = null;

            conn= new OleDbConnection(sConnection);

            OleDbCommand cmd = new OleDbCommand(sSelectCommand, conn);
            OleDbDataReader dr;

            try
            {
                conn.Open();
                dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    bExist = true;

                }

                dr.Close();

            }
            catch (Exception exception)
            {

                MessageBox.Show("Lightparameter do not exist: " + exception.Message);

            }
            finally
            {
                conn.Close();
            }
            return bExist;

        }

        public static void LoadCalParametr()
        {
            for (int i = 0; i < ClassDaten.MAX_CAMERAS; i++)
            {
                for (int k = 0; k < ClassDaten.MAX_LAYER; k++)
                {
                    ClassDBFunctions.LoadCalibrationParam(i + 1, k + 1, ref ClassDaten.structCalParam[i, k]);
                }
            }
        }


        public static bool LoadCalibrationParam(int iCameraNr, int iLayerNr, ref CalibrationParameter structCalParam)
        {
            conn = new OleDbConnection(sConnection);
            string sSelectData = "SELECT * FROM [CalibrationParameter] WHERE " + "(CameraNr = + " + iCameraNr + ") AND " +
                                "(LayerNr = " + iLayerNr + ")";

            OleDbCommand cmd = new OleDbCommand(sSelectData, conn);
            OleDbDataReader dr;

            bool dDataFound = false;

            try
            {
                conn.Open();
                dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    structCalParam.dPixelDistance = StrToDouble(dr["PixelDistance"]);
                    structCalParam.dDx = StrToDouble(dr["DX"]);
                    structCalParam.dDy = StrToDouble(dr["DY"]);
                    structCalParam.dDz = StrToDouble(dr["DZ"]);
                    structCalParam.dDAlpha = StrToDouble(dr["DAlpha"]);
                    structCalParam.dMoveDx = StrToDouble(dr["MoveDX"]);
                    structCalParam.dMoveDy = StrToDouble(dr["MoveDY"]);
                    structCalParam.dMoveDz = StrToDouble(dr["MoveDZ"]);
                    dDataFound = true;
                }

                dr.Close();


            }
            catch (Exception exception)
            {
                string sMessage = "Erroe while reading Access- Data : " + exception.Message;


            }
            finally
            {
                conn.Close();
            }

            return dDataFound;



        }


        public static void LoadInspectionPlan(string sInspectionPlanName, ref InspectionPlanData structInspectionPlanData, ref MesUnitData[] structMesUnitData)
        {
            string sSelectInspectionPlan = "SELECT * FROM InspectionPlan WHERE InspectionPlanName LIKE";


            conn= new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectInspectionPlan + "'"+sInspectionPlanName+"'", conn);
            OleDbDataReader dr;


            try
            {
                conn.Open();
                dr=cmd.ExecuteReader();

                while (dr.Read())
                {
                    //Rubrik InspectionPlandaten
                    structInspectionPlanData.sComment = dr["Comment"].ToString();
                    structInspectionPlanData.sAdvisorName = dr["AdvisorName"].ToString();
                    structInspectionPlanData.iInspectionPlanTyp = StrToInt(dr["InspectionPlantyp"]);

                    //Rubrik Zufuhr
                    structInspectionPlanData.dVMaxSpiralOutput = StrToDouble(dr["VMaxSpiralOutput"]);
                    structInspectionPlanData.iVMaxDiskRotation = StrToInt(dr["VMaxDiskRotation"]);
                    structInspectionPlanData.dVMaxRoleSelector = StrToDouble(dr["VMaxRoleSelector"]);
                    structInspectionPlanData.dVMaxLinearOutput1 = StrToDouble(dr["VMaxLinearOutput1"]);
                    structInspectionPlanData.dVMaxLinearOutput2 = StrToDouble(dr["VMaxLinearOutput2"]);
                    structInspectionPlanData.iProofFIFOIntervall = StrToInt(dr["ProofFIFOIntervall"]);
                    structInspectionPlanData.iDelayTimeRoleSelector = StrToInt(dr["DelayTimeRoleSelector"]);
                    structInspectionPlanData.iDelayTimeSpiralOutputOn = StrToInt(dr["DelayTimeSpiralOutputOn"]);
                    structInspectionPlanData.iDelayTimeDiskOn = StrToInt(dr["DelayTimeDiskOn"]);
                    structInspectionPlanData.iMinOffTimeMaterialSensor = StrToInt(dr["MinOffTimeMaterialSensor"]);
                    structInspectionPlanData.iMinOnTimeMaterialSensor = StrToInt(dr["MinOnTimeMaterialSensor"]);

                    //Rubrik Zдhler
                    structInspectionPlanData.iPortionQuantity = StrToInt(dr["PortionQuantity"]);
                    structInspectionPlanData.bPortionQuantityActiv = (bool)dr["PortionQuantityActiv"];
                    structInspectionPlanData.iQuantityStop = StrToInt(dr["QuantityStop"]);
                    structInspectionPlanData.iQuantityStopNIO = StrToInt(dr["QuantityStopNIO"]);
                    structInspectionPlanData.iCleaningIntervall = StrToInt(dr["CleaningIntervall"]);
                    structInspectionPlanData.iSeriesError = StrToInt(dr["SeriesError"]);
                    structInspectionPlanData.iMinPerformance = StrToInt(dr["MinPerformance"]);
                    structInspectionPlanData.dMaxNIOPercent = StrToDouble(dr["MaxNIOPercent"]);

                    //Rubrik Timing
                    structInspectionPlanData.iTriggerDelay[0] = StrToInt(dr["TriggerDelayCam1"]);
                    structInspectionPlanData.iTriggerDelay[1] = StrToInt(dr["TriggerDelayCam2"]);
                    structInspectionPlanData.iTriggerDelay[2] = StrToInt(dr["TriggerDelayCam3"]);
                    structInspectionPlanData.iTriggerDelay[3] = StrToInt(dr["TriggerDelayCam4"]);
                    structInspectionPlanData.iTriggerDelay[4] = StrToInt(dr["TriggerDelayCam5"]);
                    structInspectionPlanData.iTriggerDelay[5] = StrToInt(dr["TriggerDelayCam6"]);

                    structInspectionPlanData.iTriggerDelay2[0] = StrToInt(dr["TriggerDelay2Cam1"]);
                    structInspectionPlanData.iTriggerDelay2[1] = StrToInt(dr["TriggerDelay2Cam2"]);
                    structInspectionPlanData.iTriggerDelay2[2] = StrToInt(dr["TriggerDelay2Cam3"]);
                    structInspectionPlanData.iTriggerDelay2[3] = StrToInt(dr["TriggerDelay2Cam4"]);
                    structInspectionPlanData.iTriggerDelay2[4] = StrToInt(dr["TriggerDelay2Cam5"]);
                    structInspectionPlanData.iTriggerDelay2[5] = StrToInt(dr["TriggerDelay2Cam6"]);

                    structInspectionPlanData.iActualOutputNozzle = StrToInt(dr["ActualOutputNozzle"]);
                    structInspectionPlanData.iOutputNozzle1Delay = StrToInt(dr["OutputNozzle1Delay"]);
                    structInspectionPlanData.iOutputNozzle1Time = StrToInt(dr["OutputNozzle1Time"]);
                    structInspectionPlanData.iOutputNozzle2Delay = StrToInt(dr["OutputNozzle2Delay"]);
                    structInspectionPlanData.iOutputNozzle2Time = StrToInt(dr["OutputNozzle2Time"]);
                    structInspectionPlanData.iOutputNozzle3Delay = StrToInt(dr["OutputNozzle3Delay"]);
                    structInspectionPlanData.iOutputNozzle3Time = StrToInt(dr["OutputNozzle3Time"]);
                    structInspectionPlanData.iOutputNozzle4Delay = StrToInt(dr["OutputNozzle4Delay"]);
                    structInspectionPlanData.iOutputNozzle4Time = StrToInt(dr["OutputNozzle4Time"]);

                    //Rubrik System
                    structInspectionPlanData.sTimeStampCam[0] = dr["TimeStampCam1"].ToString();
                    structInspectionPlanData.sTimeStampCam[1] = dr["TimeStampCam2"].ToString();
                    structInspectionPlanData.sTimeStampCam[2] = dr["TimeStampCam3"].ToString();
                    structInspectionPlanData.sTimeStampCam[3] = dr["TimeStampCam4"].ToString();
                    structInspectionPlanData.sTimeStampCam[4] = dr["TimeStampCam5"].ToString();
                    structInspectionPlanData.sTimeStampCam[5] = dr["TimeStampCam6"].ToString();

                    structInspectionPlanData.iCurrencyTimeCam[0] = StrToInt(dr["CurrencyTimeCam1"]);
                    structInspectionPlanData.iCurrencyTimeCam[1] = StrToInt(dr["CurrencyTimeCam2"]);
                    structInspectionPlanData.iCurrencyTimeCam[2] = StrToInt(dr["CurrencyTimeCam3"]);
                    structInspectionPlanData.iCurrencyTimeCam[3] = StrToInt(dr["CurrencyTimeCam4"]);
                    structInspectionPlanData.iCurrencyTimeCam[4] = StrToInt(dr["CurrencyTimeCam5"]);
                    structInspectionPlanData.iCurrencyTimeCam[5] = StrToInt(dr["CurrencyTimeCam6"]);

                    structInspectionPlanData.iDisktyp = StrToInt(dr["Disktyp"]);

                    // Ralf prьfen!!!
                    // Vorbelegung
                    structMesUnitData[0].sMesProgName = "Hцhenmessung";
                    structMesUnitData[0].iMesUnitNr = 1;
                    structMesUnitData[1].sMesProgName = "Tiefenmessung";
                    structMesUnitData[1].iMesUnitNr = 2;
                    structMesUnitData[2].sMesProgName = "Lochprьfung";
                    structMesUnitData[2].iMesUnitNr = 3;
                    structMesUnitData[3].sMesProgName = "Gewindeprьfung";
                    structMesUnitData[3].iMesUnitNr = 4;
                    structMesUnitData[4].sMesProgName = "Reserve Sensor Prьfung";
                    structMesUnitData[4].iMesUnitNr = 5;

                }
                dr.Close();
            }
            catch (Exception exception)
            {

                MessageBox.Show("Error while reading Access- data : " + exception.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        public static void LoadMesProgram(string sInspectionPlanName, string sMesProgName, int iCameraNr, ref MesProgData structMesProgData)
        {
            string sSelectMesProg="SELECT * FROM MesPrograms WHERE " + "(InspectionPlanName = '" + sInspectionPlanName + "') AND " +
                            "(CameraNr = " + iCameraNr + ") AND " +
                            "(MesProgName = '" + sMesProgName + "')";

            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectMesProg, conn);
            OleDbDataReader dr;

            try
            {
                conn.Open();
                dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    GetMesProgData(ref structMesProgData, dr);
                }
                dr.Close();
            }
            catch ( Exception exception)
            {

                MessageBox.Show("Error while reading Access- data : " + exception.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void LoadMesPrograms(string sInspectionPlanName)
        {
            string sSelectMesProg = "SELECT * FROM MesPrograms WHERE InspectionPlanName LIKE ";
            int k = 0;

            ClassDaten.structSystemData.iMesProgramsFound = 0;
            ClassDaten.structSystemData.iActivMesProgramsFound = 0;

            // Voreinstellung aller Kameras
            for (int i = 0; i < ClassDaten.MAX_CAMERAS; i++)
            {
                if (ClassDaten.structCamPara[i].iCameraTyp == (int)ClassDaten.CameraTyp.Matrix)
                {
                    ClassDaten.structCamPara[i].bActiv = false;                             // Deaktiv
                    ClassDaten.structCamPara[i].bDoubleTriggerFlag = false;                 // Doppeltrigger
                }
                else
                {
                    ClassDaten.structCamPara[i].bActiv = ClassDaten.structCamPara[i].bCameraActivPreset;
                }
            }

            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectMesProg + "'" + sInspectionPlanName + "'", conn);
            OleDbDataReader dr;
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                for (k = 0; k < ClassDaten.MAX_STRUCT_MESPROGDATA; k++)
                {
                    ClassDaten.structMesProgData[k].Init();
                }

                k = 0;
                while (dr.Read())
                {
                    GetMesProgData(ref ClassDaten.structMesProgData[k], dr);

                    //Automatische Kameratyp - und Aktiv - Einstellung
                    // Ralf prьfen!!
                    ClassDaten.structCamPara[ClassDaten.structMesProgData[k].iCameraNr - 1].iCameraTyp = ClassDaten.structMesProgData[k].iCameraTyp;
                    if (ClassDaten.structCamPara[ClassDaten.structMesProgData[k].iCameraNr - 1].bCameraActivPreset)
                    {   // Wenn die Supervisor Einistellung fьr die entsprechende Kamera 'aktiv' ist
                        ClassDaten.structCamPara[ClassDaten.structMesProgData[k].iCameraNr - 1].bActiv = true;
                    }

                    if (!ClassDaten.structCamPara[ClassDaten.structMesProgData[k].iCameraNr - 1].bActiv)
                        ClassDaten.structMesProgData[k].bMesProgActiv = false;

                    //Zдhle die aktiven Messprogramme
                    if (ClassDaten.structMesProgData[k].bMesProgActiv)
                        ClassDaten.structSystemData.iActivMesProgramsFound++;
                    //Zдhle alle Messprogramme
                    ClassDaten.structSystemData.iMesProgramsFound++;

                    // Bei Ьberlдnge Doppeltrigger - Flag aktivieren
                    if (ClassDaten.structMesProgData[k].bOverLength)
                        ClassDaten.structCamPara[ClassDaten.structMesProgData[k].iCameraNr - 1].bDoubleTriggerFlag = true;

                    k++;
                }

                dr.Close();
            }

            catch (Exception exception)
            {
                MessageBox.Show("Error while reading Access- Data : " + exception.Message);
            }

            finally
            {
                conn.Close();
            }
        }



        public static bool LoadRoboterData(string sInspectionPlanName, ref RoboterData structRoboterData)
        {
            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectRoboterData + "'" + sInspectionPlanName + "'", conn);
            OleDbDataReader dr;
            bool bDataFound = false;


            try
            {
                conn.Open();
                dr=cmd.ExecuteReader();
                while (dr.Read())
                {
                    structRoboterData.sInspectionPlanName = (string)dr["InspectionPlanName"];
                    structRoboterData.iTypNr = StrToInt(dr["TypNr"]);
                    structRoboterData.iOptions = StrToInt(dr["Options"]);
                    structRoboterData.dLength = StrToDouble(dr["Length"]);
                    structRoboterData.dWidth = StrToDouble(dr["Width"]);
                    structRoboterData.dHeight = StrToDouble(dr["Height"]);
                    structRoboterData.dDiameter = StrToDouble(dr["Diameter"]);
                    structRoboterData.dRotAngleVertAxis = StrToDouble(dr["RotAngleVertAxis"]);
                    structRoboterData.dRotAngleHorAxis = StrToDouble(dr["RotAngleHorAxis"]);
                    structRoboterData.dMaxRotAngle = StrToDouble(dr["MaxRotAngle"]);
                    structRoboterData.dMinRotAngle = StrToDouble(dr["MinRotAngle"]);
                    structRoboterData.iGripperNr = StrToInt(dr["GripperNr"]);
                    structRoboterData.iGripperFingerNr = StrToInt(dr["GripperFingerNr"]);
                    structRoboterData.dGripAngleHorAxis = StrToDouble(dr["GripAngleHorAxis"]);
                    structRoboterData.dGripHeight = StrToDouble(dr["GripHeight"]);
                    structRoboterData.dGripDepth = StrToDouble(dr["GripDepth"]);
                    structRoboterData.iMax_X = StrToInt(dr["Max_X"]);
                    structRoboterData.iMax_Y = StrToInt(dr["Max_Y"]);
                    structRoboterData.dDistance_X = StrToDouble(dr["Distance_X"]);
                    structRoboterData.dDistance_Y = StrToDouble(dr["Distance_Y"]);
                    structRoboterData.dWeight = StrToDouble(dr["Weight"]);
                    structRoboterData.iPrismaSelect = StrToInt(dr["PrismaSelect"]);
                    bDataFound = true;
                }
                dr.Close();

            }
            catch (Exception exception)
            {

                MessageBox.Show("Error while readingr Access- Data : " + exception.Message);
            }
            finally
            {
                conn.Close();
            }

            return bDataFound;

        }

        public static string GetInspektionsPlanNamefromRoboterData(int iTypNr)
        {
            string sInspektionsPlanName = string.Empty;
            conn = new OleDbConnection(sConnection);

            string sCmd = "SELECT * FROM [RoboterData] WHERE " + "(TypNr= " + iTypNr + ")";

            OleDbCommand cmd = new OleDbCommand(sCmd, conn);
            OleDbDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (iTypNr == StrToInt(dr["TypNr"]))
                    {
                        sInspektionsPlanName = (string)dr["InspectionPlanName"];
                    }
                }
                dr.Close();
            }
            catch (Exception exception)
            {

                MessageBox.Show("No Roboterdata found! " + exception.Message);
            }
            finally
            {
                conn.Close();
            }
            return sInspektionsPlanName;

        }

        public static bool LoadVisionData(string sInspectionPlanName, ref VisionData[] structVisionData)
        {
            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectVisionData + "'" + sInspectionPlanName + "'", conn);
            OleDbDataReader dr;

            bool bDataFound = false;

            try
            {
                conn.Open();
                dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    int iCamNr = StrToInt(dr["CameraNr"]);
                    if (iCamNr>0)
                    {
                        structVisionData[iCamNr - 1].sInspectionPlanName = (string)dr["InspectionPlanName"];
                        structVisionData[iCamNr - 1].iInspectionPlanTyp = StrToInt(dr["InspectionPlanTyp"]);
                        structVisionData[iCamNr - 1].iCameraNr = StrToInt(dr["CameraNr"]);
                        structVisionData[iCamNr - 1].iNumLevels = StrToInt(dr["NumLevels"]);
                        structVisionData[iCamNr - 1].iContrast = StrToInt(dr["Contrast"]);
                        structVisionData[iCamNr - 1].iMinContrast = StrToInt(dr["MinContrast"]);
                        structVisionData[iCamNr - 1].dMinScoreMain = StrToDouble(dr["MinScoreMain"]);
                        structVisionData[iCamNr - 1].dMinScore = StrToDouble(dr["MinScore"]);
                        structVisionData[iCamNr - 1].dMinScale = StrToDouble(dr["MinScale"]);
                        structVisionData[iCamNr - 1].dGreediness = StrToDouble(dr["Greediness"]);
                        structVisionData[iCamNr - 1].iNumMatches = StrToInt(dr["NumMatches"]);
                        structVisionData[iCamNr - 1].iAquisitionTime = StrToInt(dr["AquisitionTime"]);
                        structVisionData[iCamNr - 1].dAngleStart = StrToInt(dr["AngleStart"]);
                        structVisionData[iCamNr - 1].dAngleExtent = StrToInt(dr["AngleExtent"]);
                        structVisionData[iCamNr - 1].iGrayPercent = StrToInt(dr["GrayPercent"]);
                        structVisionData[iCamNr - 1].iGrayOffset = StrToInt(dr["GrayOffset"]);
                        //structVisionData[iCamNr - 1].sMetric = (string)dr["Metric"];
                        structVisionData[iCamNr - 1].iMinContourLength = StrToInt(dr["MinContourLength"]);
                        structVisionData[iCamNr - 1].iMaskWidth = StrToInt(dr["MaskWidth"]);
                        structVisionData[iCamNr - 1].iMaskHeight = StrToInt(dr["MaskHeight"]);
                        bDataFound = true;
                    }
                }
                dr.Close();
            }
            catch (Exception exception)
            {

                MessageBox.Show("Error while reading Access- data : " + exception.Message);
            }
            finally
            {
                conn.Close();
            }
            return bDataFound;
        }

        public static bool SmartLightParameterExists(string sInspectionPlanName)
        {
            bool bExist = false;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sSelectComand = "SELECT * FROM [SmartekLightParameter] WHERE " +
                                        "InspectionPlanName = '" + sInspectionPlanName + "'";


            OleDbConnection conn = null;

            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectComand, conn);
            OleDbDataReader dr;

            try
            {
                conn.Open();
                dr =  cmd.ExecuteReader();
                while (dr.Read())
                {
                    bExist = true;
                }
                dr.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Light parameter do not exist : " + exception.Message);
            }
            finally
            {
                conn.Close();
            }

            return bExist;

        }

        public static int ReadLastMesProgID()
        {
            int iLastMesProgID = 0, iMesProgID;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            OleDbConnection conn = null;

            string sSelectMesProg = "SELECT * FROM MesPrograms";

            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectMesProg, conn);
            OleDbDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    iMesProgID = StrToInt(dr["ID"]);
                    if (iMesProgID> iLastMesProgID)
                    {
                        iLastMesProgID = iMesProgID;
                    }
                }

                dr.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error while reading of last ID- Number : " + exception.Message);
               
            }
            finally
            {
                conn.Close();
            }

            return iLastMesProgID;
        }


        public static void ReadMesProgCamData(string sInspectionPlanName)
        {
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            OleDbConnection conn = null;

            string sSelectMesProg = "SELECT * FROM MesPrograms WHERE InspectionPlanName LIKE ";

            for (int i = 0; i < ClassDaten.MAX_CAMERAS; i++)
            {
                if (ClassDaten.structCamPara[i].iCameraTyp==(int)ClassDaten.CameraTyp.Matrix)
                {
                    ClassDaten.structCamPara[i].bActiv = false;
                }
                else
                {
                    ClassDaten.structCamPara[i].bActiv = ClassDaten.structCamPara[i].bCameraActivPreset;
                }
            }



            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectMesProg+ "'"+ sInspectionPlanName+"'", conn);
            OleDbDataReader dr;

            int k = 0;

            try
            {
                conn.Open();
                dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClassDaten.structMesProgData[k].iCameraNr = StrToInt(dr["CameraNr"]);
                    ClassDaten.structMesProgData[k].iCameraTyp= StrToInt(dr["CameraTyp"]);
                    ClassDaten.structMesProgData[k].bMesProgActiv = (bool)dr["MesProgActiv"];


                    //Automatische Kameratyp - und Aktiv - Einstellung
                    ClassDaten.structCamPara[ClassDaten.structMesProgData[k].iCameraNr - 1].iCameraTyp = ClassDaten.structMesProgData[k].iCameraTyp;
                    if (ClassDaten.structCamPara[ClassDaten.structMesProgData[k].iCameraNr - 1].bCameraActivPreset)
                    {   // Wenn die Supervisor Einistellung fьr die entsprechende Kamera 'aktiv' ist
                        ClassDaten.structCamPara[ClassDaten.structMesProgData[k].iCameraNr - 1].bActiv = true;
                    }
                }
                dr.Close();
            }
            catch (Exception exception)
            {

                MessageBox.Show("Error while reading Access- camera data : " + exception.Message);

            }
            finally
            {
                conn.Close();
            }






        }

        public static void ReadMesProgCounterData()
        {
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sSelectCounterData;

            OleDbConnection conn = null;
            conn = new OleDbConnection(sConnection);
            OleDbDataReader dr;


            for (int k = 0; k < ClassDaten.structSystemData.iMesProgramsFound; k++)
            {

                sSelectCounterData = "SELECT * FROM [Counter] WHERE " + "(InspectionPlanName + '" + ClassDaten.structSystemData.sActualInspectionPlan + "') AND " +
                                    "(MesProgName = '" + ClassDaten.structMesProgData[k].sMesProgName + "') AND " +
                                    "(ID = " + ClassDaten.structMesProgData[k].iID + ")" + " AND " +
                                    "(MesUnitNr = 0 )";



                OleDbCommand cmd = new OleDbCommand(sSelectCounterData, conn);

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ClassDaten.structCounter.iTotalParts = StrToInt(dr["TotalParts"]);
                        ClassDaten.structCounter.iTotalOKParts = StrToInt(dr["TotalOKParts"]);
                        ClassDaten.structCounter.iTotalNOKParts = StrToInt(dr["TotalNOKParts"]);
                        ClassDaten.structCounter.iTotalUntested = StrToInt(dr["TotalUntested"]);
                        ClassDaten.structMesProgData[k].iOKParts = StrToInt(dr["OKParts"]);
                        ClassDaten.structMesProgData[k].iMinTolNOKParts = StrToInt(dr["MinTolNOKParts"]);
                        ClassDaten.structMesProgData[k].iMaxTolNOKParts = StrToInt(dr["MaxTolNOKParts"]);
                    }
                    dr.Close();

                }
                catch (Exception exception)
                {

                    MessageBox.Show("Error while reading Counter - data : " + exception.Message);

                }
                finally
                {
                    conn.Close();
                }

            }
        }


        public static void ReadMesUnitCounterData()
        {
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sSelectCounterData;

            OleDbConnection conn = null;
            conn = new OleDbConnection(sConnection);
            OleDbDataReader dr;

            sSelectCounterData = "SELECT * FROM [Counter] WHERE " +
                                 "(InspectionPlanName = '" + ClassDaten.structSystemData.sActualInspectionPlan + "') AND " +
                                 "(MesUnitNr > 0 )";

            OleDbCommand cmd = new OleDbCommand(sSelectCounterData, conn);
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                int k = 0;
                while (dr.Read())
                {
                    //RS Test
                    //ClassDaten.structMesUnitData[k].sMesProgName = dr["MesProgName"].ToString();
                    ClassDaten.structMesUnitData[k].iTotalParts = StrToInt(dr["TotalParts"]);
                    ClassDaten.structMesUnitData[k].iTotalOKParts = StrToInt(dr["TotalOKParts"]);
                    ClassDaten.structMesUnitData[k].iTotalNOKParts = StrToInt(dr["TotalNOKParts"]);
                    ClassDaten.structMesUnitData[k].iTotalUntested = StrToInt(dr["TotalUntested"]);
                    ClassDaten.structMesUnitData[k].iOKParts = StrToInt(dr["OKParts"]);
                    ClassDaten.structMesUnitData[k].iMinTolNOKParts = StrToInt(dr["MinTolNOKParts"]);
                    ClassDaten.structMesUnitData[k].iMaxTolNOKParts = StrToInt(dr["MaxTolNOKParts"]);
                    k++;
                }
                dr.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error while reading Measurementsystem - Counter - data : " + exception.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public static bool ReadLightParameter(string sInspectionPlanName, ref LightControlData structLC_Data)
        {

            bool bResult = false;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sSelectCommand = "SELECT * FROM [LightParameter] WHERE " +
                                        "InspectionPlanName = '" + sInspectionPlanName + "'";

            OleDbConnection conn = null;

            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectCommand, conn);
            OleDbDataReader dr;


            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    structLC_Data.iOut1_Mode = StrToInt(dr["Out1_Mode"]);
                    structLC_Data.iOut1_Dominance = StrToInt(dr["Out1_Dominance"]);
                    structLC_Data.iOut1_TriggerEdge = StrToInt(dr["Out1_TriggerEdge"]);
                    structLC_Data.iOut1_Chan1Current = StrToInt(dr["Out1_Chan1Current"]);
                    structLC_Data.iOut1_Chan2Current = StrToInt(dr["Out1_Chan2Current"]);
                    structLC_Data.iOut1_Chan3Current = StrToInt(dr["Out1_Chan3Current"]);
                    structLC_Data.iOut1_Chan4Current = StrToInt(dr["Out1_Chan4Current"]);
                    structLC_Data.iOut1_Chan5Current = StrToInt(dr["Out1_Chan5Current"]);
                    structLC_Data.iOut1_Chan6Current = StrToInt(dr["Out1_Chan6Current"]);
                    structLC_Data.iOut1_OnTime = StrToInt(dr["Out1_OnTime"]);
                    structLC_Data.iOut1_TrigDelayTime = StrToInt(dr["Out1_TrigDelayTime"]);
                    structLC_Data.iOut1_HoldTime = StrToInt(dr["Out1_HoldTime"]);
                    structLC_Data.iOut1_TrigRepeat = StrToInt(dr["Out1_TrigRepeat"]);
                    structLC_Data.iOut1_TrigRepeatOffTime = StrToInt(dr["Out1_TrigRepeatOffTime"]);
                    structLC_Data.iOut2_Mode = StrToInt(dr["Out2_Mode"]);
                    structLC_Data.iOut2_Dominance = StrToInt(dr["Out2_Dominance"]);
                    structLC_Data.iOut2_TriggerEdge = StrToInt(dr["Out2_TriggerEdge"]);
                    structLC_Data.iOut2_Chan1Current = StrToInt(dr["Out2_Chan1Current"]);
                    structLC_Data.iOut2_Chan2Current = StrToInt(dr["Out2_Chan2Current"]);
                    structLC_Data.iOut2_Chan3Current = StrToInt(dr["Out2_Chan3Current"]);
                    structLC_Data.iOut2_Chan4Current = StrToInt(dr["Out2_Chan4Current"]);
                    structLC_Data.iOut2_Chan5Current = StrToInt(dr["Out2_Chan5Current"]);
                    structLC_Data.iOut2_Chan6Current = StrToInt(dr["Out2_Chan6Current"]);
                    structLC_Data.iOut2_OnTime = StrToInt(dr["Out2_OnTime"]);
                    structLC_Data.iOut2_TrigDelayTime = StrToInt(dr["Out2_TrigDelayTime"]);
                    structLC_Data.iOut2_HoldTime = StrToInt(dr["Out2_HoldTime"]);
                    structLC_Data.iOut2_TrigRepeat = StrToInt(dr["Out2_TrigRepeat"]);
                    structLC_Data.iOut2_TrigRepeatOffTime = StrToInt(dr["Out2_TrigRepeatOffTime"]);
                    bResult = true;
                }
                dr.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error while reading Lightparameter : " + exception.Message);
            }
            finally
            {
                conn.Close();
            }
            return bResult;




        }


        public static bool ReadLightParameter(string sInspectionPlanName,
            ref Form_52_Smartek_LightControler.SmartekLightControlerData structLC_Data)
        {
            bool bResult = false;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sSelectCommand = "SELECT * FROM [SmartekLightParameter] WHERE " +
                                        "InspectionPlanName = '" + sInspectionPlanName + "'";


            OleDbConnection conn = null;

            conn = new OleDbConnection(sConnection);
            OleDbCommand cmd = new OleDbCommand(sSelectCommand, conn);
            OleDbDataReader dr;


            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    structLC_Data.sIP_Adress = dr["IP_Adress"].ToString();
                    structLC_Data.iMode = StrToInt(dr["Mode"]);
                    structLC_Data.iTriggerEdge = StrToInt(dr["TriggerEdge"]);
                    structLC_Data.dOutputVoltage = StrToDouble(dr["OutputVoltage"]);
                    structLC_Data.bOutputVoltAutoSense = (bool)dr["OutputVoltageAutoSense"];
                    structLC_Data.structChParameter[0].dOutputCurrent = StrToDouble(dr["Ch1_Current"]);
                    structLC_Data.structChParameter[1].dOutputCurrent = StrToDouble(dr["Ch2_Current"]);
                    structLC_Data.structChParameter[2].dOutputCurrent = StrToDouble(dr["Ch3_Current"]);
                    structLC_Data.structChParameter[3].dOutputCurrent = StrToDouble(dr["Ch4_Current"]);
                    structLC_Data.structChParameter[0].dTriggerDelayTime = StrToDouble(dr["Ch1_TriggerDelayTime"]);
                    structLC_Data.structChParameter[1].dTriggerDelayTime = StrToDouble(dr["Ch2_TriggerDelayTime"]);
                    structLC_Data.structChParameter[2].dTriggerDelayTime = StrToDouble(dr["Ch3_TriggerDelayTime"]);
                    structLC_Data.structChParameter[3].dTriggerDelayTime = StrToDouble(dr["Ch4_TriggerDelayTime"]);
                    structLC_Data.structChParameter[0].dTriggerOnTime = StrToDouble(dr["Ch1_TriggerOnTime"]);
                    structLC_Data.structChParameter[1].dTriggerOnTime = StrToDouble(dr["Ch2_TriggerOnTime"]);
                    structLC_Data.structChParameter[2].dTriggerOnTime = StrToDouble(dr["Ch3_TriggerOnTime"]);
                    structLC_Data.structChParameter[3].dTriggerOnTime = StrToDouble(dr["Ch4_TriggerOnTime"]);
                    structLC_Data.structChParameter[0].dTriggerOffTime = StrToDouble(dr["Ch1_TriggerOffTime"]);
                    structLC_Data.structChParameter[1].dTriggerOffTime = StrToDouble(dr["Ch2_TriggerOffTime"]);
                    structLC_Data.structChParameter[2].dTriggerOffTime = StrToDouble(dr["Ch3_TriggerOffTime"]);
                    structLC_Data.structChParameter[3].dTriggerOffTime = StrToDouble(dr["Ch4_TriggerOffTime"]);
                    structLC_Data.structChParameter[0].iTriggerIndex = StrToInt(dr["Ch1_TriggerIndex"]);
                    structLC_Data.structChParameter[1].iTriggerIndex = StrToInt(dr["Ch2_TriggerIndex"]);
                    structLC_Data.structChParameter[2].iTriggerIndex = StrToInt(dr["Ch3_TriggerIndex"]);
                    structLC_Data.structChParameter[3].iTriggerIndex = StrToInt(dr["Ch4_TriggerIndex"]);
                    structLC_Data.structChParameter[0].bTriggerEnabled = (bool)dr["Ch1_TriggerEnable"];
                    structLC_Data.structChParameter[1].bTriggerEnabled = (bool)dr["Ch2_TriggerEnable"];
                    structLC_Data.structChParameter[2].bTriggerEnabled = (bool)dr["Ch3_TriggerEnable"];
                    structLC_Data.structChParameter[3].bTriggerEnabled = (bool)dr["Ch4_TriggerEnable"];
                    structLC_Data.bCam1_Light1_Enable = (bool)dr["Cam1_Light1_Enable"];
                    structLC_Data.bCam1_Light2_Enable = (bool)dr["Cam1_Light2_Enable"];
                    structLC_Data.bCam1_Light3_Enable = (bool)dr["Cam1_Light3_Enable"];
                    structLC_Data.bCam1_Light4_Enable = (bool)dr["Cam1_Light4_Enable"];
                    structLC_Data.bCam2_Light1_Enable = (bool)dr["Cam2_Light1_Enable"];
                    structLC_Data.bCam2_Light2_Enable = (bool)dr["Cam2_Light2_Enable"];
                    structLC_Data.bCam2_Light3_Enable = (bool)dr["Cam2_Light3_Enable"];
                    structLC_Data.bCam2_Light4_Enable = (bool)dr["Cam2_Light4_Enable"];
                    bResult = true;
                }
                dr.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error while reading Lightparameter : " + exception.Message);
            }
            finally
            {
                conn.Close();
            }
            return bResult;

        }


        public static int StrToInt(object Object)
        {
            string sText= Object.ToString();
            if (Object.ToString() == "")
                sText = "0";
            return int.Parse(sText);

        }
        public static double StrToDouble(object Object)
        {
            string sText=Object.ToString();
            if (Object.ToString() == "")
                sText = "0";
            return double.Parse(sText);
        }


        public static bool TableDataExists(string sTableName, string sInspectionPlanName)
        {
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sCommand = "SELECT * FROM " + sTableName + " WHERE (InspectionPlanName =";

            OleDbConnection conn = null;

            conn = new OleDbConnection(sConnection);

            OleDbCommand cmd = new OleDbCommand(sCommand + "'" + sInspectionPlanName + "')", conn);


            OleDbDataReader dr;
            bool Exist = false;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Exist = true;
                }
                dr.Close();
            }
            catch (Exception exception)
            {

                MessageBox.Show("Error while proof Datentable " + sTableName + " , " + exception.Message);
            }
            finally
            {
                conn.Close();
            
            }

            return Exist;
        }


        public static void UpdateCounter(string sInspectionPlanName, string sMesProgName, int iID)
        {
            int Result;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sUpdate;


            OleDbConnection conn = null;

            conn = new OleDbConnection(sConnection);

            Result = ClassDBFunctions.CounterDataExists(sInspectionPlanName, iID);

            if (Result==1)
            {
                sUpdate = "UPDATE [Counter] SET" +
                        " MesProgName= '" + sMesProgName + "'" +
                        "WHERE (InspectionPlanName= '" + sInspectionPlanName + "')" + " AND " +
                        "(ID = )" + iID + ")";

                OleDbCommand cmd = new OleDbCommand(sUpdate, conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception exception)
                {

                    MessageBox.Show("Error while Update Counter- Measurementprogramname : " + exception.Message);

                }
                finally
                {
                    conn.Close();
                }
            }

        }


        public static void WriteMesProgCounter()
        {
            int k = 0, Result;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sUpdate, sInsert;

            OleDbConnection conn = null;
            conn = new OleDbConnection(sConnection);

            Form_41_Packaging formPacking = new Form_41_Packaging();
            formCounter.WriteIniData(sIniFileName);
            formCounter.Dispose();


            Form_42_Counter formCounter= new Form_42_Counter();
            formCounter.WriteIniData(sIniFileName);
            formCounter.Dispose();

            for  (k = 0; k < ClassDaten.structSystemData.iMesProgramsFound; k++)
            {
                Result = ClassDBFunctions.CounterDataExists(ClassDaten.structSystemData.sActualInspectionPlan,
                       ClassDaten.structMesProgData[k].iID);

                if (Result==1)
                {
                    sUpdate = "UPDATE [Counter] SET" +
                              " TotalParts = " + ClassDaten.structCounter.iTotalParts + "," +
                              " TotalOKParts = " + ClassDaten.structCounter.iTotalOKParts + "," +
                              " TotalNOKParts = " + ClassDaten.structCounter.iTotalNOKParts + "," +
                              " TotalUntested = " + ClassDaten.structCounter.iTotalUntested + "," +
                              " OKParts = " + ClassDaten.structMesProgData[k].iOKParts + "," +
                              " MinTolNOKParts = " + ClassDaten.structMesProgData[k].iMinTolNOKParts + "," +
                              " MaxTolNOKParts = " + ClassDaten.structMesProgData[k].iMaxTolNOKParts +
                              " WHERE (InspectionPlanName = '" + ClassDaten.structSystemData.sActualInspectionPlan + "')" + " AND " +
                              "(ID = " + ClassDaten.structMesProgData[k].iID + ")" + " AND " +
                              "(MesUnitNr = " + ClassDaten.structMesProgData[k].iMesUnitNr + ")";



                    OleDbCommand cmd = new OleDbCommand(sUpdate, conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Error while Update Counter - data : " + exception.Message);
                        break;
                        
                    }
                    finally
                    {
                        conn.Close();

                    }
                }

                if (Result==2)
                {
                    sInsert = "INSERT INTO [Counter] "+
                              "(InspectionPlanName, MesProgName, ID, MesUnitNr, TotalParts, TotalOKParts, TotalNOKParts, TotalUntested, OKParts, MinTolNOKParts, MaxTolNOKParts ) VALUES " +
                              "('" + ClassDaten.structSystemData.sActualInspectionPlan + "'," +
                              "'" + ClassDaten.structMesProgData[k].sMesProgName + "'," +
                              ClassDaten.structMesProgData[k].iID + "," +
                              ClassDaten.structMesProgData[k].iMesUnitNr + "," +
                              ClassDaten.structCounter.iTotalParts + "," +
                              ClassDaten.structCounter.iTotalOKParts + "," +
                              ClassDaten.structCounter.iTotalNOKParts + "," +
                              ClassDaten.structCounter.iTotalUntested + "," +
                              ClassDaten.structMesProgData[k].iOKParts + "," +
                              ClassDaten.structMesProgData[k].iMinTolNOKParts + "," +
                              ClassDaten.structMesProgData[k].iMaxTolNOKParts + ")";

                    OleDbCommand cmd = new OleDbCommand(sInsert, conn);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Error while Insert to Counter - data : " + exception.Message);
                        break;

                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }

        }

        public static void WriteMesUnitCounter()
        {
            int k = 0, Result;
            int iNull = 0;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sUpdate, sInsert;

            OleDbConnection conn = null;
            conn = new OleDbConnection(sConnection);

            // Vorbelegung
            ClassDaten.structMesUnitData[0].sMesProgName = "Hцhenmessung";
            ClassDaten.structMesUnitData[0].iMesUnitNr = 1;
            ClassDaten.structMesUnitData[1].sMesProgName = "Tiefenmessung";
            ClassDaten.structMesUnitData[1].iMesUnitNr = 2;
            ClassDaten.structMesUnitData[2].sMesProgName = "Lochprьfung";
            ClassDaten.structMesUnitData[2].iMesUnitNr = 3;
            ClassDaten.structMesUnitData[3].sMesProgName = "Gewindeprьfung";
            ClassDaten.structMesUnitData[3].iMesUnitNr = 4;
            ClassDaten.structMesUnitData[4].sMesProgName = "Reserve Sensor Prьfung";
            ClassDaten.structMesUnitData[4].iMesUnitNr = 5;

            //TotalCounter und Errors aus Messprogrammen updaten
            for (k = 0; k < ClassDaten.MAX_MES_UNITS; k++)
            {
                Result = ClassDBFunctions.CounterDataUnitExists(ClassDaten.structSystemData.sActualInspectionPlan,
                    ClassDaten.structMesUnitData[k].iMesUnitNr);

                if (Result == 1)
                {
                    sUpdate = "UPDATE [Counter] SET" +
                              " TotalParts = " + ClassDaten.structCounter.iTotalParts + "," +
                              " TotalOKParts = " + ClassDaten.structCounter.iTotalOKParts + "," +
                              " TotalNOKParts = " + ClassDaten.structCounter.iTotalNOKParts + "," +
                              " TotalUntested = " + ClassDaten.structCounter.iSeriesErrorCount + "," +
                              " OKParts = " + ClassDaten.structMesUnitData[k].iOKParts + "," +
                              " MinTolNOKParts = " + ClassDaten.structMesUnitData[k].iMinTolNOKParts + "," +
                              " MaxTolNOKParts = " + ClassDaten.structMesUnitData[k].iMaxTolNOKParts +
                              " WHERE (InspectionPlanName = '" + ClassDaten.structSystemData.sActualInspectionPlan + "')" + " AND " +
                              "(ID = 0)" + " AND " +
                              "(MesUnitNr = " + ClassDaten.structMesUnitData[k].iMesUnitNr + ")";

                    OleDbCommand cmd = new OleDbCommand(sUpdate, conn);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Error while Update Counter - data : " + exception.Message);
                        break;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    if (Result == 2)
                    {
                        sInsert = "INSERT INTO [Counter] " +
                            "(InspectionPlanName, MesProgName, ID, MesUnitNr, TotalParts, TotalOKParts, TotalNOKParts, TotalUntested, OKParts, MinTolNOKParts, MaxTolNOKParts ) VALUES " +
                            "('" + ClassDaten.structSystemData.sActualInspectionPlan + "'," +
                            "'" + ClassDaten.structMesUnitData[k].sMesProgName + "'," +
                            iNull + "," +
                            ClassDaten.structMesUnitData[k].iMesUnitNr + "," +
                            ClassDaten.structCounter.iTotalParts + "," +
                            ClassDaten.structCounter.iTotalOKParts + "," +
                            ClassDaten.structCounter.iTotalNOKParts + "," +
                            ClassDaten.structCounter.iTotalUntested + "," +
                            ClassDaten.structMesUnitData[k].iOKParts + "," +
                            ClassDaten.structMesUnitData[k].iMinTolNOKParts + "," +
                            ClassDaten.structMesUnitData[k].iMaxTolNOKParts + ")";

                        OleDbCommand cmd = new OleDbCommand(sInsert, conn);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Error while Insert to Counter - data : " + exception.Message);
                            break;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }

        public static bool WriteLightParameter(int iOutput, string sInspectionPlanName, LightControlData structLC_Data)
        {
            bool bResult = false;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sUpdate, sInsert;

            OleDbConnection conn = null;
            conn = new OleDbConnection(sConnection);

            if (LightParameterExists(sInspectionPlanName))
            {
                if (iOutput == 1)
                {
                    sUpdate = "UPDATE [LightParameter] SET" +
                        " Out1_Mode = " + structLC_Data.iOut1_Mode + "," +
                        " Out1_Dominance = " + structLC_Data.iOut1_Dominance + "," +
                        " Out1_TriggerEdge = " + structLC_Data.iOut1_TriggerEdge + "," +
                        " Out1_Chan1Current = " + structLC_Data.iOut1_Chan1Current + "," +
                        " Out1_Chan2Current = " + structLC_Data.iOut1_Chan2Current + "," +
                        " Out1_Chan3Current = " + structLC_Data.iOut1_Chan3Current + "," +
                        " Out1_Chan4Current = " + structLC_Data.iOut1_Chan4Current + "," +
                        " Out1_Chan5Current = " + structLC_Data.iOut1_Chan5Current + "," +
                        " Out1_Chan6Current = " + structLC_Data.iOut1_Chan6Current + "," +
                        " Out1_OnTime = " + structLC_Data.iOut1_OnTime + "," +
                        " Out1_TrigDelayTime = " + structLC_Data.iOut1_TrigDelayTime + "," +
                        " Out1_HoldTime = " + structLC_Data.iOut1_HoldTime + "," +
                        " Out1_TrigRepeat = " + structLC_Data.iOut1_TrigRepeat + "," +
                        " Out1_TrigRepeatOffTime = " + structLC_Data.iOut1_TrigRepeatOffTime +
                        " WHERE (InspectionPlanName = '" + sInspectionPlanName + "')";
                }
                else
                {
                    sUpdate = "UPDATE [LightParameter] SET" +
                       " Out2_Mode = " + structLC_Data.iOut2_Mode + "," +
                       " Out2_Dominance = " + structLC_Data.iOut2_Dominance + "," +
                       " Out2_TriggerEdge = " + structLC_Data.iOut2_TriggerEdge + "," +
                       " Out2_Chan1Current = " + structLC_Data.iOut2_Chan1Current + "," +
                       " Out2_Chan2Current = " + structLC_Data.iOut2_Chan2Current + "," +
                       " Out2_Chan3Current = " + structLC_Data.iOut2_Chan3Current + "," +
                       " Out2_Chan4Current = " + structLC_Data.iOut2_Chan4Current + "," +
                       " Out2_Chan5Current = " + structLC_Data.iOut2_Chan5Current + "," +
                       " Out2_Chan6Current = " + structLC_Data.iOut2_Chan6Current + "," +
                       " Out2_OnTime = " + structLC_Data.iOut2_OnTime + "," +
                       " Out2_TrigDelayTime = " + structLC_Data.iOut2_TrigDelayTime + "," +
                       " Out2_HoldTime = " + structLC_Data.iOut2_HoldTime + "," +
                       " Out2_TrigRepeat = " + structLC_Data.iOut2_TrigRepeat + "," +
                       " Out2_TrigRepeatOffTime = " + structLC_Data.iOut2_TrigRepeatOffTime +
                       " WHERE (InspectionPlanName = '" + sInspectionPlanName + "')";
                }

                OleDbCommand cmd = new OleDbCommand(sUpdate, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    bResult = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error while Update Lightparameter : " + exception.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                if (iOutput == 1)
                {
                    sInsert = "INSERT INTO [LightParameter] " +
                        "( InspectionPlanName," +
                        " Out1_Mode, Out1_Dominance, Out1_TriggerEdge, " +
                        " Out1_Chan1Current, Out1_Chan2Current, Out1_Chan3Current, Out1_Chan4Current, Out1_Chan5Current, Out1_Chan6Current," +
                        " Out1_OnTime, Out1_TrigDelayTime, Out1_HoldTime, Out1_TrigRepeat, Out1_TrigRepeatOffTime" +
                        ") VALUES " +

                        "('" + sInspectionPlanName + "'," +

                        structLC_Data.iOut1_Mode + "," +
                        structLC_Data.iOut1_Dominance + "," +
                        structLC_Data.iOut1_TriggerEdge + "," +
                        structLC_Data.iOut1_Chan1Current + "," +
                        structLC_Data.iOut1_Chan2Current + "," +
                        structLC_Data.iOut1_Chan3Current + "," +
                        structLC_Data.iOut1_Chan4Current + "," +
                        structLC_Data.iOut1_Chan5Current + "," +
                        structLC_Data.iOut1_Chan6Current + "," +
                        structLC_Data.iOut1_OnTime + "," +
                        structLC_Data.iOut1_TrigDelayTime + "," +
                        structLC_Data.iOut1_HoldTime + "," +
                        structLC_Data.iOut1_TrigRepeat + "," +
                        structLC_Data.iOut1_TrigRepeatOffTime + ")";

                }
                else
                {
                    sInsert = "INSERT INTO [LightParameter] " +
                        "( InspectionPlanName," +
                        " Out2_Mode, Out2_Dominance, Out2_TriggerEdge, " +
                        " Out2_Chan1Current, Out2_Chan2Current, Out2_Chan3Current, Out2_Chan4Current, Out2_Chan5Current, Out2_Chan6Current," +
                        " Out2_OnTime, Out2_TrigDelayTime, Out2_HoldTime, Out2_TrigRepeat, Out2_TrigRepeatOffTime" +
                        ") VALUES " +

                        "('" + sInspectionPlanName + "'," +
                        structLC_Data.iOut2_Mode + "," +
                        structLC_Data.iOut2_Dominance + "," +
                        structLC_Data.iOut2_TriggerEdge + "," +
                        structLC_Data.iOut2_Chan1Current + "," +
                        structLC_Data.iOut2_Chan2Current + "," +
                        structLC_Data.iOut2_Chan3Current + "," +
                        structLC_Data.iOut2_Chan4Current + "," +
                        structLC_Data.iOut2_Chan5Current + "," +
                        structLC_Data.iOut2_Chan6Current + "," +
                        structLC_Data.iOut2_OnTime + "," +
                        structLC_Data.iOut2_TrigDelayTime + "," +
                        structLC_Data.iOut2_HoldTime + "," +
                        structLC_Data.iOut2_TrigRepeat + "," +
                        structLC_Data.iOut2_TrigRepeatOffTime + ")";
                }

                OleDbCommand cmd = new OleDbCommand(sInsert, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    bResult = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error while Insert to Lightparameter : " + exception.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return bResult;
        }

        public static bool WriteSmartekLightParameter(string sInspectionPlanName,
                         Form_52_Smartek_LightControler.SmartekLightControlerData structLC_Data)
        {
            bool bResult = false;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sUpdate, sInsert;

            OleDbConnection conn = null;
            conn = new OleDbConnection(sConnection);

            if (SmartekLightParameterExists(sInspectionPlanName))
            {
                sUpdate = "UPDATE [SmartekLightParameter] SET" +
                    " IP_Adress = '" + structLC_Data.sIP_Adress + "'," +
                    " Mode = " + structLC_Data.iMode + "," +
                    " TriggerEdge = " + structLC_Data.iTriggerEdge + "," +
                    " OutputVoltage = " + Convert.ToInt32(structLC_Data.dOutputVoltage) + "," +
                    " OutputVoltageAutoSense = " + structLC_Data.bOutputVoltAutoSense + "," +
                    " Ch1_Current = " + structLC_Data.structChParameter[0].dOutputCurrent + "," +
                    " Ch2_Current = " + structLC_Data.structChParameter[1].dOutputCurrent + "," +
                    " Ch3_Current = " + structLC_Data.structChParameter[2].dOutputCurrent + "," +
                    " Ch4_Current = " + structLC_Data.structChParameter[3].dOutputCurrent + "," +
                    " Ch1_TriggerDelayTime = " + structLC_Data.structChParameter[0].dTriggerDelayTime + "," +
                    " Ch2_TriggerDelayTime = " + structLC_Data.structChParameter[1].dTriggerDelayTime + "," +
                    " Ch3_TriggerDelayTime = " + structLC_Data.structChParameter[2].dTriggerDelayTime + "," +
                    " Ch4_TriggerDelayTime = " + structLC_Data.structChParameter[3].dTriggerDelayTime + "," +
                    " Ch1_TriggerOnTime = " + structLC_Data.structChParameter[0].dTriggerOnTime + "," +
                    " Ch2_TriggerOnTime = " + structLC_Data.structChParameter[1].dTriggerOnTime + "," +
                    " Ch3_TriggerOnTime = " + structLC_Data.structChParameter[2].dTriggerOnTime + "," +
                    " Ch4_TriggerOnTime = " + structLC_Data.structChParameter[3].dTriggerOnTime + "," +
                    " Ch1_TriggerOffTime = " + structLC_Data.structChParameter[0].dTriggerOffTime + "," +
                    " Ch2_TriggerOffTime = " + structLC_Data.structChParameter[1].dTriggerOffTime + "," +
                    " Ch3_TriggerOffTime = " + structLC_Data.structChParameter[2].dTriggerOffTime + "," +
                    " Ch4_TriggerOffTime = " + structLC_Data.structChParameter[3].dTriggerOffTime + "," +
                    " Ch1_TriggerIndex = " + structLC_Data.structChParameter[0].iTriggerIndex + "," +
                    " Ch2_TriggerIndex = " + structLC_Data.structChParameter[1].iTriggerIndex + "," +
                    " Ch3_TriggerIndex = " + structLC_Data.structChParameter[2].iTriggerIndex + "," +
                    " Ch4_TriggerIndex = " + structLC_Data.structChParameter[3].iTriggerIndex + "," +
                    " Ch1_TriggerEnable = " + structLC_Data.structChParameter[0].bTriggerEnabled + "," +
                    " Ch2_TriggerEnable = " + structLC_Data.structChParameter[1].bTriggerEnabled + "," +
                    " Ch3_TriggerEnable = " + structLC_Data.structChParameter[2].bTriggerEnabled + "," +
                    " Ch4_TriggerEnable = " + structLC_Data.structChParameter[3].bTriggerEnabled + "," +
                    " Cam1_Light1_Enable = " + structLC_Data.bCam1_Light1_Enable + "," +
                    " Cam1_Light2_Enable = " + structLC_Data.bCam1_Light2_Enable + "," +
                    " Cam1_Light3_Enable = " + structLC_Data.bCam1_Light3_Enable + "," +
                    " Cam1_Light4_Enable = " + structLC_Data.bCam1_Light4_Enable + "," +
                    " Cam2_Light1_Enable = " + structLC_Data.bCam2_Light1_Enable + "," +
                    " Cam2_Light2_Enable = " + structLC_Data.bCam2_Light2_Enable + "," +
                    " Cam2_Light3_Enable = " + structLC_Data.bCam2_Light3_Enable + "," +
                    " Cam2_Light4_Enable = " + structLC_Data.bCam2_Light4_Enable +
                    " WHERE (InspectionPlanName = '" + sInspectionPlanName + "')";

                OleDbCommand cmd = new OleDbCommand(sUpdate, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    bResult = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error while Update Lightparameter : " + exception.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                sInsert = "INSERT INTO [SmartekLightParameter] " +
                    "( InspectionPlanName," +

                    " IP_Adress, Mode, TriggerEdge, OutputVoltage, OutputVoltageAutoSense," +
                    " Ch1_Current, Ch2_Current, Ch3_Current, Ch4_Current," +
                    " Ch1_TriggerDelayTime, Ch2_TriggerDelayTime, Ch3_TriggerDelayTime, Ch4_TriggerDelayTime," +
                    " Ch1_TriggerOnTime, Ch2_TriggerOnTime, Ch3_TriggerOnTime,  Ch4_TriggerOnTime," +
                    " Ch1_TriggerOffTime, Ch2_TriggerOffTime, Ch3_TriggerOffTime, Ch4_TriggerOffTime," +
                    " Ch1_TriggerIndex, Ch2_TriggerIndex, Ch3_TriggerIndex, Ch4_TriggerIndex," +
                    " Ch1_TriggerEnable, Ch2_TriggerEnable, Ch3_TriggerEnable, Ch4_TriggerEnable," +
                    " Cam1_Light1_Enable, Cam1_Light2_Enable, Cam1_Light3_Enable, Cam1_Light4_Enable," +
                    " Cam2_Light1_Enable, Cam2_Light2_Enable, Cam2_Light3_Enable, Cam2_Light4_Enable" +
                    ") VALUES " +

                    "('" + sInspectionPlanName + "'," +
                    "'" + structLC_Data.sIP_Adress + "'," +
                    structLC_Data.iMode + "," +
                    structLC_Data.iTriggerEdge + "," +
                    Convert.ToInt32(structLC_Data.dOutputVoltage) + "," +
                    structLC_Data.bOutputVoltAutoSense + "," +
                    structLC_Data.structChParameter[0].dOutputCurrent + "," +
                    structLC_Data.structChParameter[1].dOutputCurrent + "," +
                    structLC_Data.structChParameter[2].dOutputCurrent + "," +
                    structLC_Data.structChParameter[3].dOutputCurrent + "," +
                    structLC_Data.structChParameter[0].dTriggerDelayTime + "," +
                    structLC_Data.structChParameter[1].dTriggerDelayTime + "," +
                    structLC_Data.structChParameter[2].dTriggerDelayTime + "," +
                    structLC_Data.structChParameter[3].dTriggerDelayTime + "," +
                    structLC_Data.structChParameter[0].dTriggerOnTime + "," +
                    structLC_Data.structChParameter[1].dTriggerOnTime + "," +
                    structLC_Data.structChParameter[2].dTriggerOnTime + "," +
                    structLC_Data.structChParameter[3].dTriggerOnTime + "," +
                    structLC_Data.structChParameter[0].dTriggerOffTime + "," +
                    structLC_Data.structChParameter[1].dTriggerOffTime + "," +
                    structLC_Data.structChParameter[2].dTriggerOffTime + "," +
                    structLC_Data.structChParameter[3].dTriggerOffTime + "," +
                    structLC_Data.structChParameter[0].iTriggerIndex + "," +
                    structLC_Data.structChParameter[1].iTriggerIndex + "," +
                    structLC_Data.structChParameter[2].iTriggerIndex + "," +
                    structLC_Data.structChParameter[3].iTriggerIndex + "," +
                    structLC_Data.structChParameter[0].bTriggerEnabled + "," +
                    structLC_Data.structChParameter[1].bTriggerEnabled + "," +
                    structLC_Data.structChParameter[2].bTriggerEnabled + "," +
                    structLC_Data.structChParameter[3].bTriggerEnabled + "," +
                    structLC_Data.bCam1_Light1_Enable + "," +
                    structLC_Data.bCam1_Light2_Enable + "," +
                    structLC_Data.bCam1_Light3_Enable + "," +
                    structLC_Data.bCam1_Light4_Enable + "," +
                    structLC_Data.bCam1_Light1_Enable + "," +
                    structLC_Data.bCam1_Light2_Enable + "," +
                    structLC_Data.bCam1_Light3_Enable + "," +
                    structLC_Data.bCam1_Light4_Enable + ")";

                OleDbCommand cmd = new OleDbCommand(sInsert, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    bResult = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error while Insert to Lightparameter : " + exception.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return bResult;
        }


        public static void WriteToleranceValues()
        {
            int k = 0;
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sUpdate;


            OleDbConnection conn = null;
            conn = new OleDbConnection(sConnection);

            try
            {
                conn.Open();
                for (k = 0; k < ClassDaten.structSystemData.iMesProgramsFound; k++)
                {
                       sUpdate = "UPDATE [MesPrograms] SET" +
                      " MaxTol = '" + ClassDaten.structMesProgData[k].dMaxTol + "'," +
                      " NominalValue = '" + ClassDaten.structMesProgData[k].dNominalValue + "'," +
                      " MinTol = '" + ClassDaten.structMesProgData[k].dMinTol + "'" +
                      " WHERE (InspectionPlanName = '" + ClassDaten.structSystemData.sActualInspectionPlan + "')" + " AND " +
                      "(MesProgName = '" + ClassDaten.structMesProgData[k].sMesProgName + "')";

                    OleDbCommand cmd = new OleDbCommand(sUpdate, conn);

                    cmd.ExecuteNonQuery();

                }

                conn.Close();


            }
            catch (Exception exception)
            {

                MessageBox.Show("Error while Update Tolerance - data : " + exception.Message);
            }
            finally
            {
                conn.Close();

            }

        }

        public static void WriteUserParameter(string sInspectionPlan)
        {
            string sConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + sDB_FileName;
            string sUpdate;

            OleDbConnection conn = null;
            conn = new OleDbConnection(sConnection);

            sUpdate = "UPDATE [InspectionPlan] SET" +
                " VMaxSpiralOutput = " + ClassDaten.structInspectionPlanData.dVMaxSpiralOutput + "," +
                " VMaxRoleSelector = " + ClassDaten.structInspectionPlanData.dVMaxRoleSelector + "," +
                " VMaxLinearOutput1 = " + ClassDaten.structInspectionPlanData.dVMaxLinearOutput1 + "," +
                " VMaxLinearOutput2 = " + ClassDaten.structInspectionPlanData.dVMaxLinearOutput2 + "," +
                " PortionQuantityActiv = " + ClassDaten.structInspectionPlanData.bPortionQuantityActiv + "," +
                " QuantityStop = " + ClassDaten.structInspectionPlanData.iQuantityStop + "," +
                " VMaxDiskRotation = " + ClassDaten.structInspectionPlanData.iVMaxDiskRotation +
                " WHERE (InspectionPlanName = '" + sInspectionPlan + "')";

            OleDbCommand cmd = new OleDbCommand(sUpdate, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error while Update Userdata : " + exception.Message);
            }
            finally
            {
                conn.Close();
            }
        }




    }
}
