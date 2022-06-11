using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }






    class ClassDaten
    {





    }
}
