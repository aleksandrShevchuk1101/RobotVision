using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_KEHRATEC
{
    class ClassIOApplication
    {
        static public uint nDigInput;


        static public bool GetDigitalInput(uint nInput)
        {
            if ((nDigInput & nInput) != 0)
                return true;
            else
                return false;
        }

        static public uint GetDigitalInputs(uint nInput)
        {
            return nDigInput;
        }



    }
}
