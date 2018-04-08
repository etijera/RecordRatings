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
    public partial class FrmGetProfesorMaterias : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Modo { get; set; }
        public string CodProfesor { get; set; }
        public string CodMateria { get; set; }
        public string NombreProfe { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        private Funciones f = new Funciones();

        #endregion

        #region Metodos
        public FrmGetProfesorMaterias()
        {
            InitializeComponent();
        }

        public bool Validar() 
        {
            bool retorno = true;                    

            if (LueMateria.ItemIndex < 0)
            {
                errorP1.SetError(LueMateria, "Debe seleccionar una materia");
                LueMateria.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(LueMateria, "");               
            }                   

            return retorno;
        }

        public void Accept() 
        {
            if (Validar())
            {
                CodMateria = LueMateria.EditValue.ToString();                  

                DialogResult = DialogResult.OK;                
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

        private void FrmGetProfesorMaterias_Load(object sender, EventArgs e)
        {
            try
            {
                TxtNombreProfe.Text = NombreProfe;

                ProfesorMaterias prMat = new ProfesorMaterias();
                prMat.Profesor.CodigoProfesor = CodProfesor;
                DataTable dt1 = new DataTable();

                dt1 = CtrlProfesorMaterias.GetMateNoAsigNadas(prMat).Tables[0];                            

                LueMateria.Properties.DataSource = dt1;
                LueMateria.Properties.DisplayMember = "Nombre";
                LueMateria.Properties.ValueMember = "CodMateria";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col;
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);         
                LueMateria.Properties.Columns.Add(col);
                LueMateria.ItemIndex = -1;
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }           
           
           
        }                

         #endregion

    }
}