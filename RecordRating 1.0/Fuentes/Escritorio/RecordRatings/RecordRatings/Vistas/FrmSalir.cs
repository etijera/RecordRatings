using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLUserControls;
using GLReferences.Properties;

namespace RecordRatings.Vistas
{
    public partial class FrmSalir : BasicForm
    {
        #region Propiedades
        public string Tipo { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;

        #endregion

        #region Metodos
        public FrmSalir()
        {
            InitializeComponent();
        }

        public void DoForm(string tip)
        {           
            if (tip.Equals("Reiniciar"))
            {                
                LblPregunta.Text = "¿Esta seguro que desea reiniciar " + Resources.AppName + "?";
                LblNameFrm.Text = Tipo;
                LblNameFrm.Location = new Point(141, 3);
            }
            else
            {
                LblPregunta.Text = "¿Esta seguro que desea salir de " + Resources.AppName + "?";
                LblNameFrm.Text = Tipo;
                LblNameFrm.Location = new Point(155, 3);
            }
        }

        #endregion

        #region Eventos
        private void BtnSi_Click(object sender, EventArgs e)
        {
            if (Tipo.Equals("Salir"))
            {
                Application.Exit();
            }
            else
            {
                Application.Restart();
            }
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmSalir_Load(object sender, EventArgs e)
        {
            DoForm(Tipo);
        }       

        private void LnkLblCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); 
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }

        #endregion

        private void LblNameFrm_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void LblNameFrm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }

        private void LblNameFrm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }


    }
}
