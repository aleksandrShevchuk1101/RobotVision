using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_KEHRATEC
{


    public partial class Form_01_Main : Form
    {

        bool bSPSStopped = false;

        public Form_01_Main()
        {
            InitializeComponent();
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

        private void btn_F2_Stop_Click(object sender, EventArgs e)
        {




        }
    }


    
}
