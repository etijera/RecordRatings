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
    public partial class FrmGetDesempeños : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Modo { get; set; }
        public int Id { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        private Funciones f = new Funciones();

        #endregion

        #region Metodos
        public FrmGetDesempeños()
        {
            InitializeComponent();
        }

        public bool Validar() 
        {
            bool retorno = true;

            if (string.IsNullOrEmpty((TxtNombre.Text)))
            {
                errorP1.SetError(TxtNombre, "Debe ingresar el nombre.");
                TxtNombre.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtNombre, "");
            }

            if (string.IsNullOrEmpty((TxtNotaMin.Text)))
            {
                errorP1.SetError(TxtNotaMin, "Debe ingresar la nota minima.");
                TxtNotaMin.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtNotaMin, "");
            }   

            if (string.IsNullOrEmpty((TxtNotaMax.Text)))
            {
                errorP1.SetError(TxtNotaMax, "Debe ingresar la nota maxima.");
                TxtNotaMax.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtNotaMax, "");
            }         

            return retorno;
        }

        public void Accept() 
        {
            if (Validar())
            {              
                if (Modo != "E")
                {
                    InsertarActualizar("INSERT");
                    LimpiarVentana();
                }
                else
                {
                    InsertarActualizar("UPDATE");
                }

                DialogResult = DialogResult.OK;                
            }
        }
       

        private void LimpiarVentana()
        {
            TxtNombre.Text = "";   
            TxtNotaMin.Text = "0";   
            TxtNotaMax.Text = "0";           
        }

        private void CargarDatos(int id)
        {
            Desempeño dsmp = new Desempeño();
            dsmp.Id = id;
            DataSet ds = CtrlDesempeños.GetDesempeñoOne(dsmp);
            DataRow dr = ds.Tables[0].Rows[0];
            
            TxtNombre.Text = dr["Nombre"].ToString();
            TxtNotaMin.Text = dr["NotaMin"].ToString();
            TxtNotaMax.Text = dr["NotaMax"].ToString();
           
        }

        private void InsertarActualizar(string modo)
        {
            try
            {
                if (modo == "INSERT") 
                {
                    Desempeño dsmp = new Desempeño();
                    dsmp.Nombre = TxtNombre.Text.Trim();
                    dsmp.NotaMin = Convert.ToDecimal(TxtNotaMin.Text.Trim());
                    dsmp.NotaMax = Convert.ToDecimal(TxtNotaMax.Text.Trim());                 

                    if (CtrlDesempeños.Insertar(dsmp) > 0)
                    {
                         XtraMessageBox.Show("Desempeño insertado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {
                    Desempeño dsmp = new Desempeño();
                    dsmp.Id = Id;
                    dsmp.Nombre = TxtNombre.Text.Trim();
                    dsmp.NotaMin = Convert.ToDecimal(TxtNotaMin.Text.Trim());
                    dsmp.NotaMax = Convert.ToDecimal(TxtNotaMax.Text.Trim()); 

                    if (CtrlDesempeños.Actualizar(dsmp) > 0)
                    {
                        XtraMessageBox.Show("Desempeño actualizado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
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

        private void FrmGetDesempeños_Load(object sender, EventArgs e)
        {                       
            TxtNombre.Focus();
            if (Modo == "E" && Id > 0) 
            {
               CargarDatos(Id);
            }           
        }

        private void TxtUsuario_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrEmpty((TxtNombre.Text))) 
            {
                errorP1.SetError(TxtNombre, "Debe ingresar el nombre.");
                TxtNombre.Focus();
            }
            else
            {
                errorP1.SetError(TxtNombre, "");
            }
            
        }  

        private void TxtNumero_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((TxtNotaMin.Text)))
            {
                errorP1.SetError(TxtNotaMin, "Debe ingresar la nota minima.");
                TxtNotaMin.Focus();
            }
            else
            {
                errorP1.SetError(TxtNotaMin, "");
            }
        }         

        private void TxtNotaMax_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((TxtNotaMax.Text)))
            {
                errorP1.SetError(TxtNotaMax, "Debe ingresar la nota maxima.");
                TxtNotaMax.Focus();
            }
            else
            {
                errorP1.SetError(TxtNotaMax, "");
            }
        }

         #endregion



       



    }
}