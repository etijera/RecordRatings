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
    public partial class FrmGetMaterias : BasicForm
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
        public FrmGetMaterias()
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

            if (LueArea.ItemIndex < 0)
            {
                errorP1.SetError(LueArea, "Debe seleccionar un area");
                LueArea.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(LueArea, "");               
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
            LueArea.ItemIndex = -1;
        }

        private void CargarDatos(int id)
        {
            Materia mt = new Materia();
            mt.Id = id;
            DataSet ds = CtrlMaterias.GetMateriaOne(mt);
            DataRow dr = ds.Tables[0].Rows[0];
            
            TxtNombre.Text = dr["Nombre"].ToString();
            LueArea.EditValue = dr["CodArea"].ToString();
        }

        private void InsertarActualizar(string modo)
        {
            try
            {
                if (modo == "INSERT") 
                {
                    Materia materia = new Materia();
                    materia.Nombre = TxtNombre.Text.Trim();
                    materia.Area.Codigo = LueArea.EditValue.ToString();

                    if (CtrlMaterias.Insertar(materia) > 0)
                    {
                         XtraMessageBox.Show("Materia insertada con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {
                    Materia materia = new Materia();
                    materia.Id = Id;
                    materia.Nombre = TxtNombre.Text.Trim();
                    materia.Area.Codigo = LueArea.EditValue.ToString();

                    if (CtrlMaterias.Actualizar(materia) > 0)
                    {
                        XtraMessageBox.Show("Materia actualizada con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
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

        private void FrmGetMaterias_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CtrlAreas.GetAreaAll().Tables[0];

                LueArea.Properties.DataSource = dt;
                LueArea.Properties.DisplayMember = "Nombre";
                LueArea.Properties.ValueMember = "Codigo";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col;
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
                //col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                LueArea.Properties.Columns.Add(col);
                LueArea.ItemIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }
           
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

         #endregion

       



    }
}