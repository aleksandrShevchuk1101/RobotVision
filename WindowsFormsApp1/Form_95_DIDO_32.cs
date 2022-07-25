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
        public Form_95_DIDO_32()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            timerSetInput.Stop();
            timerSetInput.Dispose();
            this.Close();
        }
    }
}
