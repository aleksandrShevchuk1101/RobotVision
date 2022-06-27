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

        public static int CounterUnitExists(string sInspectionPlanName, int iMesToolNr)
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
            catch (Exception)
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
            catch (Exception)
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









    }
}
