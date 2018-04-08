using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLUserControls;

namespace RecordRatings.Vistas
{
    public partial class FrmCarga : BasicForm
    {
        Point formPosition;
        Boolean mouseAction;
        PictureBox[] pict ;//= new PictureBox();
        int count = 0;

        public FrmCarga()
        {
            InitializeComponent();
        }        

        private void FrmCarga_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (panel2.Width < 300)
            {
                count = count + 10;
                panel2.Width = panel2.Width + 30;

                labelControl2.Text = "CARGANDO EL SISTEMA AL " + count + " %";
                
            }
            else
            {
                timer1.Enabled = false;
                DialogResult = DialogResult.OK;
            }
        }

    }
}