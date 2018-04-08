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
using GLReferences;
using GLReferences.Properties;
using RecordRatings.Clases;
using RecordRatings.Controladores;

namespace RecordRatings.Vistas
{
    public partial class FrmEditEstadoCurso : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string CodigoCurso { get; set; }
        public int Año { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        private Funciones f = new Funciones();

        #endregion

        #region Metodos
        public FrmEditEstadoCurso()
        {
            InitializeComponent();
        }       

        public void Accept() 
        {                          
            Actualizar();
                    
            DialogResult = DialogResult.OK;                           
        }

        private void Actualizar()
        {
            try
            {
               
                CursoAñoElectivo curAe = new CursoAñoElectivo();
                curAe.Curso.CodigoCurso = CodigoCurso;
                curAe.AñoElectivo = Año;
                curAe.Estado = CmbEstado.SelectedIndex;

                if (CtrlCursoAñoElectivo.ActualizarCursoAñoElectivo(curAe) > 0)
                {
                    XtraMessageBox.Show("Curso actualizado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
                
            }
            catch (Exception ex)
            {
                 XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);                
            }
        }
        
        #endregion

        #region Eventos

        #region MovVentana
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();            
        }

        private void LnkLblMinimizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }

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

        #endregion

        private void FrmEditEstadoCurso_Load(object sender, EventArgs e)
        {
            try
            {
                TxtNombre.Text = Nombre;

                if (Estado == "ACTIVO")
                {
                    CmbEstado.SelectedIndex = 1;
                }
                else
                {
                    CmbEstado.SelectedIndex = 0;
                }               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }
           
            TxtNombre.Focus();            
           
        }
       
         #endregion

       



    }
}