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
    public partial class Form_95_DIDO_32 : Form
    {
        const int MAX_DIDO = 16;

        private PictureBox[] pbxInPtr= new PictureBox[MAX_DIDO];
        private PictureBox[] pbxOutPtr= new PictureBox[MAX_DIDO];
        private Label[] lblInPtr = new Label[MAX_DIDO];
        private Label[] lblOutPtr = new Label[MAX_DIDO];


        string sIniSectionText = string.Empty;
        private Image LED_gn_ein;
        private Image LED_gn_aus;
        private Image ImageSchlossZu;
        private Image ImageSchlossOffen;




        private string sMeldetextAktiv;
        private string sMeldetextDeaktiv;
        private uint uiDigInput;


        public Form_95_DIDO_32(string FileNme)
        {
            InitializeComponent();

            GetAllPointer();

            sIniSectionText = "DIDO_TEXT";

            LED_gn_ein = new Bitmap("..\\..\\Bilder\\LED_ON.bmp");
            LED_gn_aus = new Bitmap("..\\..\\Bilder\\LED_OFF.bmp");
            ImageSchlossZu = new Bitmap("..\\..\\Bilder\\Schloss_Zu.ico");
            ImageSchlossOffen = new Bitmap("..\\..\\Bilder\\Schloss_Offen.ico");

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            timerSetInput.Stop();
            timerSetInput.Dispose();
            this.Close();
        }

        private void lbl_LED_A_16_Click(object sender, EventArgs e)
        {





        }

        private void GetAllPointer()
        {
            lblInPtr[0] = lbl_LED_E_1;
            lblInPtr[1] = lbl_LED_E_2;
            lblInPtr[2] = lbl_LED_E_3;
            lblInPtr[3] = lbl_LED_E_4;
            lblInPtr[4] = lbl_LED_E_5;
            lblInPtr[5] = lbl_LED_E_6;
            lblInPtr[6] = lbl_LED_E_7;
            lblInPtr[7] = lbl_LED_E_8;
            lblInPtr[8] = lbl_LED_E_9;
            lblInPtr[9] = lbl_LED_E_10;
            lblInPtr[10] = lbl_LED_E_11;
            lblInPtr[11] = lbl_LED_E_12;
            lblInPtr[12] = lbl_LED_E_13;
            lblInPtr[13] = lbl_LED_E_14;
            lblInPtr[14] = lbl_LED_E_15;
            lblInPtr[15] = lbl_LED_E_16;

            lblOutPtr[0] = lbl_LED_A_1;
            lblOutPtr[1] = lbl_LED_A_2;
            lblOutPtr[2] = lbl_LED_A_3;
            lblOutPtr[3] = lbl_LED_A_4;
            lblOutPtr[4] = lbl_LED_A_5;
            lblOutPtr[5] = lbl_LED_A_6;
            lblOutPtr[6] = lbl_LED_A_7;
            lblOutPtr[7] = lbl_LED_A_8;
            lblOutPtr[8] = lbl_LED_A_9;
            lblOutPtr[9] = lbl_LED_A_10;
            lblOutPtr[10] = lbl_LED_A_11;
            lblOutPtr[11] = lbl_LED_A_12;
            lblOutPtr[12] = lbl_LED_A_13;
            lblOutPtr[13] = lbl_LED_A_14;
            lblOutPtr[14] = lbl_LED_A_15;
            lblOutPtr[15] = lbl_LED_A_16;

        }
        private void SetInputs()
        {
            int k = 1;
            pbxInPtr[0] = pbx_LED_E_1;
            pbxInPtr[1] = pbx_LED_E_2;
            pbxInPtr[2] = pbx_LED_E_3;
            pbxInPtr[3] = pbx_LED_E_4;
            pbxInPtr[4] = pbx_LED_E_5;
            pbxInPtr[5] = pbx_LED_E_6;
            pbxInPtr[6] = pbx_LED_E_7;
            pbxInPtr[7] = pbx_LED_E_8;
            pbxInPtr[8] = pbx_LED_E_9;
            pbxInPtr[9] = pbx_LED_E_10;
            pbxInPtr[10] = pbx_LED_E_11;
            pbxInPtr[11] = pbx_LED_E_12;
            pbxInPtr[12] = pbx_LED_E_13;
            pbxInPtr[13] = pbx_LED_E_14;
            pbxInPtr[14] = pbx_LED_E_15;
            pbxInPtr[15] = pbx_LED_E_16;

            //Получить текущий статус ввода
            uiDigInput = ClassIOApplication.GetDigitalInputs(0);
          

            if (numUpDownSide.Value==1)
            {
                for (k = 0;  k< MAX_DIDO; k++)
                {
                    if ((uiDigInput & (1 << k)) == 0)
                        this.pbxInPtr[k].Image = LED_gn_aus;
                    else
                       this.pbxInPtr[k].Image = LED_gn_ein;
 
                }
            }
            else
            {
                for (k = 0; k < MAX_DIDO; k++)
                {
                    if ((uiDigInput&(1<<(1+16)))==0)
                        this.pbxInPtr[k].Image = LED_gn_aus;
                    else
                        this.pbxInPtr[k].Image = LED_gn_ein;
                }
            }

        }

        private void SetOutputs()
        {
            int k = 1;

            pbxOutPtr[0] = pbx_LED_A_1;
            pbxOutPtr[1] = pbx_LED_A_2;
            pbxOutPtr[2] = pbx_LED_A_3;
            pbxOutPtr[3] = pbx_LED_A_4;
            pbxOutPtr[4] = pbx_LED_A_5;
            pbxOutPtr[5] = pbx_LED_A_6;
            pbxOutPtr[6] = pbx_LED_A_7;
            pbxOutPtr[7] = pbx_LED_A_8;
            pbxOutPtr[8] = pbx_LED_A_9;
            pbxOutPtr[9] = pbx_LED_A_10;
            pbxOutPtr[10] = pbx_LED_A_11;
            pbxOutPtr[11] = pbx_LED_A_12;
            pbxOutPtr[12] = pbx_LED_A_13;
            pbxOutPtr[13] = pbx_LED_A_14;
            pbxOutPtr[14] = pbx_LED_A_15;
            pbxOutPtr[15] = pbx_LED_A_16;

            //Получить текущий статус ввода
            uiDigInput = ClassIOApplication.GetDigitalInputs(0);

            if (numUpDownSide.Value==1)
            {
                for (k = 0; k < MAX_DIDO; k++)
                {
                    if ((uiDigInput & (1 << k)) == 0)
                        this.pbxOutPtr[k].Image = LED_gn_aus;
                    else
                        this.pbxOutPtr[k].Image = LED_gn_ein;
                }
            }
            else
            {
                for (k = 0;  k< MAX_DIDO; k++)
                {
                    if ((uiDigInput & (1 << (k + 16))) == 0)
                        this.pbxOutPtr[k].Image = LED_gn_aus;
                    else
                        this.pbxOutPtr[k].Image = LED_gn_ein;
                }
            }

        }

        private void timerSetInput_Tick(object sender, EventArgs e)
        {
            SetInputs();
            SetOutputs();
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            string sFileName = ClassDaten.sHELP_PATH + "Help_Digital_IO.pdf";
            try
            {
                System.Diagnostics.Process.Start(sFileName);
              //  MessageBox.Show(System.IO.Directory.GetCurrentDirectory());


            }
            catch (Exception myException)
            {
                MessageBox.Show("Erroe while reading file  " + sFileName+"! " + myException.Message);
            }
        }

        private void btn_Password_Click(object sender, EventArgs e)
        {
            if (IsAllowed())
            {
                this.btn_Password.Image = ImageSchlossOffen;
                this.lbl_MessageText.Text = sMeldetextAktiv;
            }
            else
            {
                this.btn_Password.Image = ImageSchlossZu;
                this.lbl_MessageText.Text = sMeldetextDeaktiv;
            }
        }


        public bool IsAllowed()
        {
            return false;
        }
    }
}
