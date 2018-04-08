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

namespace Gargape.Vistas
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

        private void FrmCarga_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }

        private void FrmCarga_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void FrmCarga_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }

        private void FrmCarga_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            pict = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count < 10) 
            {
                pict[count].BackgroundImage = global::Gargape.Properties.Resources.Circle2;
                count++;
            }

            if (panel2.Width <300)
            {
                panel2.Width = panel2.Width + 30;
            }

            if (progressBarControl1.Properties.EditValueChangedDelay < 100) 
            {
                progressBarControl1.Properties.EditValueChangedDelay = progressBarControl1.Properties.EditValueChangedDelay + 10;
                progressBarControl1.PerformStep();
                progressBarControl1.Update();

                progressPanel1.Description = "Cargando el sistema al " + progressBarControl1.Properties.EditValueChangedDelay + " %";
                labelControl2.Text = "CARGANDO EL SISTEMA AL "+progressBarControl1.Properties.EditValueChangedDelay +" %";
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("Carga Completa");
                this.Close();
            }
        }
    }
}