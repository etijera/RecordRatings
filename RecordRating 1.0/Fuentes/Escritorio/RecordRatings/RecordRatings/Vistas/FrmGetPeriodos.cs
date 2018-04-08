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
    public partial class FrmGetPeriodos : BasicForm
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
        public FrmGetPeriodos()
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

            if (string.IsNullOrEmpty((TxtNumero.Text)))
            {
                errorP1.SetError(TxtNumero, "Debe ingresar el número.");
                TxtNumero.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtNumero, "");
            }

            if (string.IsNullOrEmpty((TxtPorcentaje.Text)))
            {
                errorP1.SetError(TxtPorcentaje, "Debe ingresar el porcentaje.");
                TxtPorcentaje.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtPorcentaje, "");
            } 

            return retorno;
        }

        public void Accept() 
        {
            if (Validar())
            {
                //if (ConsultarUsuario())
                //{
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
                //}
            }
        }

        //private bool ConsultarUsuario()
        //{
        //    string user="";
        //    bool retorno = true;
            
        //    if (Modo != "E")
        //    {
        //        Usuario us = new Usuario();
        //        us.Nombre = TxtNombre.Text.Trim();
        //        DataSet ds = CtrlUsuarios.GetUsuarioName(us);                   
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            user = ds.Tables[0].Rows[0]["Nombre"].ToString();
        //        }

        //        if (TxtNombre.Text == user)
        //        {

        //            retorno = false;
        //            XtraMessageBox.Show("El nombre de usuario ya existe.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        //            TxtNombre.Focus();

        //        }
        //    }

        //    return retorno;
        //}

        private void LimpiarVentana()
        {
            TxtNombre.Text = "";   
            TxtNumero.Text = "";    
            TxtPorcentaje.Text = "0";        
        }

        private void CargarDatos(int id)
        {
            Periodo pr = new Periodo();
            pr.Id = id;
            DataSet ds = CtrlPeriodos.GetPeriodoOne(pr);
            DataRow dr = ds.Tables[0].Rows[0];
            
            TxtNombre.Text = dr["Nombre"].ToString();
            TxtNumero.Text = dr["Numero"].ToString();
            TxtPorcentaje.Text = dr["Porcentaje"].ToString();
           
        }

        private void InsertarActualizar(string modo)
        {
            try
            {
                if (modo == "INSERT") 
                {
                    Periodo periodo = new Periodo();
                    periodo.Nombre = TxtNombre.Text.Trim();
                    periodo.Numero = Convert.ToInt32(TxtNumero.Text.Trim());
                    periodo.Porcentaje = Convert.ToInt32(TxtPorcentaje.EditValue);                   

                    if (CtrlPeriodos.Insertar(periodo) > 0)
                    {
                         XtraMessageBox.Show("Periodo insertado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {
                    Periodo periodo = new Periodo();
                    periodo.Id = Id;
                    periodo.Nombre = TxtNombre.Text.Trim();
                    periodo.Numero = Convert.ToInt32(TxtNumero.Text.Trim());
                    periodo.Porcentaje = Convert.ToInt32(TxtPorcentaje.EditValue);    

                    if (CtrlPeriodos.Actualizar(periodo) > 0)
                    {
                        XtraMessageBox.Show("Periodo actualizado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
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

        private void FrmGetPeriodos_Load(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty((TxtNumero.Text)))
            {
                errorP1.SetError(TxtNumero, "Debe ingresar el número.");
                TxtNumero.Focus();
            }
            else
            {
                errorP1.SetError(TxtNumero, "");
            }
        }  

        private void TxtPorcentaje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((TxtPorcentaje.Text)))
            {
                errorP1.SetError(TxtPorcentaje, "Debe ingresar el porcentaje.");
                TxtPorcentaje.Focus();
            }
            else
            {
                errorP1.SetError(TxtPorcentaje, "");
            }
        }
          

         #endregion


       



    }
}