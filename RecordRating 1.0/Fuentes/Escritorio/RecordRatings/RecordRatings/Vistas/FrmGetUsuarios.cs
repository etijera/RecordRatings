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
    public partial class FrmGetUsuarios : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Modo { get; set; }
        public int Id { get; set; }
        public int IdPersona { get; set; }

        #endregion

        #region Variables

        bool clickeado = true;
        Point formPosition;
        Boolean mouseAction;
        private Funciones f = new Funciones();
        int idPersona;

        #endregion

        #region Metodos
        public FrmGetUsuarios()
        {
            InitializeComponent();
        }
        public bool ValidarPersona()
        {
            bool retorno = true;

            if (string.IsNullOrEmpty((TxtPrNombre.Text)))
            {
                errorP1.SetError(TxtPrNombre, "Debe ingresar el primer nombre.");
                TxtPrNombre.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtPrNombre, "");
            }

            if (string.IsNullOrEmpty((TxtPrApellido.Text)))
            {
                errorP1.SetError(TxtPrApellido, "Debe ingresar el primer apellido.");
                TxtPrApellido.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtPrApellido, "");
            }

            if (string.IsNullOrEmpty((TxtIdentificacion.Text)))
            {
                errorP1.SetError(TxtIdentificacion, "Debe ingresar la identificación.");
                TxtIdentificacion.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtIdentificacion, "");
            }
           

            return retorno;
        }
        public bool Validar() 
        {
            bool retorno = true;
          

            if (string.IsNullOrEmpty((TxtUsuario.Text)))
            {
                errorP1.SetError(TxtUsuario, "Debe ingresar el usuario.");
                TxtUsuario.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtUsuario, "");
            }

            if (string.IsNullOrEmpty((TxtPass1.Text)))
            {
                errorP1.SetError(TxtPass1, "Debe ingresar la contraseña.");
                TxtPass1.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtPass1, "");
            }

            if (string.IsNullOrEmpty((TxtPass2.Text)))
            {
                errorP1.SetError(TxtPass2, "Debe confirmar la contraseña.");
                TxtPass2.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtPass2, "");

                if (TxtPass1.Text != TxtPass2.Text)
                {
                    errorP1.SetError(TxtPass2, "Las contraseñas no coinciden.");
                    TxtPass2.Focus();
                    retorno = false;
                }
                else
                {
                    errorP1.SetError(TxtPass2, "");
                }
            }

            if (LueTipoUsuario.ItemIndex < 0)
            {
                errorP1.SetError(LueTipoUsuario, "Debe seleccionar un tipo de ususario.");
                LueTipoUsuario.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(LueTipoUsuario, "");               
            }

            return retorno;
        }

        public void Accept() 
        {
            if (Modo != "E") 
            {
                if (ValidarPersona()) 
                {
                    if (ConsultarIdentificacion())
                    {
                        if (Validar())
                        {
                            if (ConsultarUsuario())
                            {
                                InsertarActualizar("INSERT");
                                LimpiarVentana();

                                DialogResult = DialogResult.OK;
                            }
                        }
                    }
                }
            }
            else
            {
                if (LueTipoUsuario.EditValue.ToString() != "01")
                {
                    if (Validar())
                    {
                        if (ConsultarUsuario())
                        {
                            InsertarActualizar("UPDATE");

                            DialogResult = DialogResult.OK;
                        }
                    }
                }
                else
                {
                    if (ValidarPersona())
                    {
                        if (ConsultarIdentificacion())
                        {
                            if (Validar())
                            {
                                if (ConsultarUsuario())
                                {
                                    InsertarActualizar("UPDATE");

                                    DialogResult = DialogResult.OK;
                                }
                            }
                        }
                    }
                }
            }
           
        }

        private bool ConsultarUsuario()
        {
            string user="";
            bool retorno = true;
            
            if (Modo != "E")
            {
                Usuario us = new Usuario();
                us.Nombre = TxtUsuario.Text.Trim();
                DataSet ds = CtrlUsuarios.GetUsuarioName(us);                   
                if (ds.Tables[0].Rows.Count > 0)
                {
                    user = ds.Tables[0].Rows[0]["Nombre"].ToString();
                }

                if (TxtUsuario.Text == user)
                {

                    retorno = false;
                    XtraMessageBox.Show("El nombre de usuario ya existe.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    TxtUsuario.Focus();

                }
            }

            return retorno;
        }

        private bool ConsultarIdentificacion()
        {
            string identifi = "";
            int idPersona = 0;
            bool retorno = true;

            Alumno al = new Alumno();
            al.Persona.Identificacion = TxtIdentificacion.Text.Trim();

            DataSet ds = CtrlAlumnos.GetPersonaIdentificacion(al);
            if (ds.Tables[0].Rows.Count > 0)
            {
                identifi = ds.Tables[0].Rows[0]["Identificacion"].ToString();
                idPersona = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
            }

            if (Modo != "E")
            {
                if (TxtIdentificacion.Text.Trim() == identifi)
                {
                    retorno = false;
                    XtraMessageBox.Show("Ya existe una persona con esa identificación.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    TxtIdentificacion.Focus();

                }
            }
            else
            {
                if (TxtIdentificacion.Text.Trim() == identifi && idPersona != IdPersona)
                {
                    retorno = false;
                    XtraMessageBox.Show("Ya existe una persona con esa identificación.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    TxtIdentificacion.Focus();
                }
            }

            return retorno;
        }


        private void LimpiarVentana()
        {
            TxtUsuario.Text = "";
            TxtPass1.Text = "";
            TxtPass2.Text = "";
            LueTipoUsuario.ItemIndex = -1;
        }

        private void CargarDatos(int id)
        {
            Usuario us = new Usuario();
            us.Id = id;
            DataSet ds = CtrlUsuarios.GetUsuarioOne(us);
            DataRow dr = ds.Tables[0].Rows[0];
            
            TxtUsuario.Text = dr["Nombre"].ToString();
            TxtPass1.Text = dr["Contrasenia"].ToString();
            TxtPass2.Text = dr["Contrasenia"].ToString();
            LueTipoUsuario.EditValue = dr["CodTipoUsuario"].ToString();

            if (LueTipoUsuario.EditValue.ToString() == "01") 
            {

                idPersona = Convert.ToInt32(dr["IdPersona"]);
                TxtNombre.Text = dr["NombrePersona"].ToString();
                TxtPrNombre.Text = dr["PrimerNombre"].ToString();
                TxtSegNombre.Text = dr["SegundoNombre"].ToString();
                TxtPrApellido.Text = dr["PrimerApellido"].ToString();
                TxtSegApellido.Text = dr["SegundoApellido"].ToString();
                TxtIdentificacion.Text = dr["Identificacion"].ToString();
                TxtDireccion.Text = dr["Direccion"].ToString();
                TxtEmail.Text = dr["Email"].ToString();
                TxtTelefono.Text = dr["Telefono"].ToString();
                if (dr["Sexo"].ToString() == "M")
                {
                    CmbSexo.SelectedIndex = 0;
                }
                else
                {
                    CmbSexo.SelectedIndex = 1;
                }
            }

        }

        private void InsertarActualizar(string modo)
        {
            try
            {
                if (LueTipoUsuario.EditValue.ToString() == "01") 
                {
                    InsertarUsuarioBasico(modo);
                }
                else
                {
                    if (LueTipoUsuario.EditValue.ToString() == "02") 
                    {
                        InsertarUsuarioProfe(modo);
                    }
                    else
                    {
                        if (LueTipoUsuario.EditValue.ToString() == "03") 
                        {
                            InsertarUsuarioAlumno(modo);
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                 XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);                
            }
        }

        public void InsertarUsuarioBasico(string modo) 
        {
            if (modo == "INSERT")
            {
                Usuario usuario = new Usuario();

                usuario.Persona.Nombre = TxtNombre.Text.Trim();
                usuario.Persona.PrimerNombre = TxtPrNombre.Text.Trim();
                usuario.Persona.SegundoNombre = TxtSegNombre.Text.Trim();
                usuario.Persona.PrimerApellido = TxtPrApellido.Text.Trim();
                usuario.Persona.SegundoApellido = TxtSegApellido.Text.Trim();
                usuario.Persona.Identificacion = TxtIdentificacion.Text.Trim();
                usuario.Persona.Direccion = TxtDireccion.Text.Trim();
                usuario.Persona.Telefono = TxtTelefono.Text.Trim();
                usuario.Persona.Email = TxtEmail.Text.Trim();
                usuario.Persona.Sexo = (CmbSexo.SelectedIndex == 0 ? "M" : "F");
                
                usuario.Nombre = TxtUsuario.Text.Trim();
                usuario.Contrasenia = TxtPass2.Text.Trim();
                usuario.TipoUsuario.Codigo = LueTipoUsuario.EditValue.ToString();

                if (CtrlUsuarios.InsertarBasico(usuario) > 0)
                {
                    XtraMessageBox.Show("Usuario insertado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
            }
            else
            {
                Usuario usuario = new Usuario();

                usuario.Persona.Id = idPersona;
                usuario.Persona.Nombre = TxtNombre.Text.Trim();
                usuario.Persona.PrimerNombre = TxtPrNombre.Text.Trim();
                usuario.Persona.SegundoNombre = TxtSegNombre.Text.Trim();
                usuario.Persona.PrimerApellido = TxtPrApellido.Text.Trim();
                usuario.Persona.SegundoApellido = TxtSegApellido.Text.Trim();
                usuario.Persona.Identificacion = TxtIdentificacion.Text.Trim();
                usuario.Persona.Direccion = TxtDireccion.Text.Trim();
                usuario.Persona.Telefono = TxtTelefono.Text.Trim();
                usuario.Persona.Email = TxtEmail.Text.Trim();
                usuario.Persona.Sexo = (CmbSexo.SelectedIndex == 0 ? "M" : "F");

                usuario.Id = Id;
                usuario.Nombre = TxtUsuario.Text.Trim();
                usuario.Contrasenia = TxtPass2.Text.Trim();
                usuario.TipoUsuario.Codigo = LueTipoUsuario.EditValue.ToString();

                if (CtrlUsuarios.Actualizar(usuario) > 0)
                {
                    XtraMessageBox.Show("Usuario actualizado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
            }
        }

        public void InsertarUsuarioProfe(string modo) 
        {
            if (modo == "INSERT")
            {
                Usuario usuario = new Usuario();

                usuario.Persona.Nombre = TxtNombre.Text.Trim();
                usuario.Persona.PrimerNombre = TxtPrNombre.Text.Trim();
                usuario.Persona.SegundoNombre = TxtSegNombre.Text.Trim();
                usuario.Persona.PrimerApellido = TxtPrApellido.Text.Trim();
                usuario.Persona.SegundoApellido = TxtSegApellido.Text.Trim();
                usuario.Persona.Identificacion = TxtIdentificacion.Text.Trim();
                usuario.Persona.Direccion = TxtDireccion.Text.Trim();
                usuario.Persona.Telefono = TxtTelefono.Text.Trim();
                usuario.Persona.Email = TxtEmail.Text.Trim();
                usuario.Persona.Sexo = (CmbSexo.SelectedIndex == 0 ? "M" : "F");

                usuario.Nombre = TxtUsuario.Text.Trim();
                usuario.Contrasenia = TxtPass2.Text.Trim();
                usuario.TipoUsuario.Codigo = LueTipoUsuario.EditValue.ToString();

                if (CtrlUsuarios.InsertarProfe(usuario) > 0)
                {
                    XtraMessageBox.Show("Usuario insertado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
            }
            else
            {
                Usuario usuario = new Usuario();

                usuario.Persona.Id = -1;

                usuario.Id = Id;
                usuario.Nombre = TxtUsuario.Text.Trim();
                usuario.Contrasenia = TxtPass2.Text.Trim();
                usuario.TipoUsuario.Codigo = LueTipoUsuario.EditValue.ToString();

                if (CtrlUsuarios.Actualizar(usuario) > 0)
                {
                    XtraMessageBox.Show("Usuario actualizado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
            }

        }

        public void InsertarUsuarioAlumno(string modo)
        {
            if (modo == "INSERT")
            {
                Usuario usuario = new Usuario();

                usuario.Persona.Nombre = TxtNombre.Text.Trim();
                usuario.Persona.PrimerNombre = TxtPrNombre.Text.Trim();
                usuario.Persona.SegundoNombre = TxtSegNombre.Text.Trim();
                usuario.Persona.PrimerApellido = TxtPrApellido.Text.Trim();
                usuario.Persona.SegundoApellido = TxtSegApellido.Text.Trim();
                usuario.Persona.Identificacion = TxtIdentificacion.Text.Trim();
                usuario.Persona.Direccion = TxtDireccion.Text.Trim();
                usuario.Persona.Telefono = TxtTelefono.Text.Trim();
                usuario.Persona.Email = TxtEmail.Text.Trim();
                usuario.Persona.Sexo = (CmbSexo.SelectedIndex == 0 ? "M" : "F");

                usuario.Nombre = TxtUsuario.Text.Trim();
                usuario.Contrasenia = TxtPass2.Text.Trim();
                usuario.TipoUsuario.Codigo = LueTipoUsuario.EditValue.ToString();

                if (CtrlUsuarios.InsertarAlumno(usuario) > 0)
                {
                    XtraMessageBox.Show("Usuario insertado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
            }
            else
            {
                Usuario usuario = new Usuario();

                usuario.Persona.Id = -1;

                usuario.Id = Id;
                usuario.Nombre = TxtUsuario.Text.Trim();
                usuario.Contrasenia = TxtPass2.Text.Trim();
                usuario.TipoUsuario.Codigo = LueTipoUsuario.EditValue.ToString();

                if (CtrlUsuarios.Actualizar(usuario) > 0)
                {
                    XtraMessageBox.Show("Usuario actualizado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
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

        private void GetUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = f.GetTipoUsurios(ConexionDB.getInstancia().Conexion(null, null)).Tables[0];

                LueTipoUsuario.Properties.DataSource = dt;
                LueTipoUsuario.Properties.DisplayMember = "Nombre";
                LueTipoUsuario.Properties.ValueMember = "Codigo";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col;
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
                //col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                LueTipoUsuario.Properties.Columns.Add(col);
                LueTipoUsuario.ItemIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }
           
            TxtUsuario.Focus();
            if (Modo == "E" && Id > 0) 
            {
                CargarDatos(Id);
                LueTipoUsuario.Enabled = false;
                TxtUsuario.Enabled = false;

                if (LueTipoUsuario.EditValue.ToString() != "01") 
                { 
                    TxtPass1.Focus();
                    panel3.Visible = false;

                    panel1.Location = new Point(16, 40);
                    acceptCancel1.Location = new Point(216, 166);
                    this.Size = new Size(604, 216);
                }
            }


           
        }

        private void TxtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (TxtUsuario.Text.Trim().Length > 0) 
            { 
                if (TxtUsuario.Text.Trim().Contains(" "))
                {                   
                    errorP1.SetError(TxtUsuario, "El usuario no debe contener espcios en blanco.");
                    TxtUsuario.Focus();
                }
                else
                {
                    errorP1.SetError(TxtUsuario, "");
                }
            }
            else
            {
                if (string.IsNullOrEmpty((TxtUsuario.Text))) 
                {
                    errorP1.SetError(TxtUsuario, "Debe ingresar el usuario.");
                    TxtUsuario.Focus();
                }
                else
                {
                    errorP1.SetError(TxtUsuario, "");
                }
            }
        }
       
        private void TxtPass2_Validating(object sender, CancelEventArgs e)
        {
            if (TxtPass1.Text != TxtPass2.Text)
            {
                errorP1.SetError(TxtPass1, "Las contraseñas no coinciden.");
                TxtPass1.Focus();
            }
            else
            {
                errorP1.SetError(TxtPass1, "");
            }
        }

        private void TxtPass2_TextChanged(object sender, EventArgs e)
        {
            if (TxtPass2.Text.Trim().Length > 0)
            {
                if (TxtPass1.Text != TxtPass2.Text)
                {
                    errorP1.SetError(TxtPass2, "Las contraseñas no coinciden.");
                    TxtPass2.Focus();
                }
                else
                {
                    errorP1.SetError(TxtPass2, "");
                }
            }
        }

        private void BtnNombre_Click(object sender, EventArgs e)
        {
            if (clickeado)
            {
                TxtNombre.Text = String.Format("{0} {1} {2} {3}", TxtPrApellido.Text.Trim(), TxtSegApellido.Text.Trim(), TxtPrNombre.Text.Trim(), TxtSegNombre.Text.Trim());
                clickeado = false;
            }
            else
            {
                TxtNombre.Text = String.Format("{0} {1} {2} {3}", TxtPrNombre.Text.Trim(), TxtSegNombre.Text.Trim(), TxtPrApellido.Text.Trim(), TxtSegApellido.Text.Trim());
                clickeado = true;
            }
        }

        private void TxtPrNombre_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((TxtPrNombre.Text)))
            {
                errorP1.SetError(TxtPrNombre, "Debe ingresar el primer nombre.");
                TxtPrNombre.Focus();
            }
            else
            {
                errorP1.SetError(TxtPrNombre, "");
            }
        }

        private void TxtSegNombre_TextChanged(object sender, EventArgs e)
        {
            if (clickeado)
            {
                TxtNombre.Text = String.Format("{0} {1} {2} {3}", TxtPrNombre.Text.Trim(), TxtSegNombre.Text.Trim(), TxtPrApellido.Text.Trim(), TxtSegApellido.Text.Trim());

            }
            else
            {
                TxtNombre.Text = String.Format("{0} {1} {2} {3}", TxtPrApellido.Text.Trim(), TxtSegApellido.Text.Trim(), TxtPrNombre.Text.Trim(), TxtSegNombre.Text.Trim());

            }
        }

        private void TxtPrApellido_TextChanged(object sender, EventArgs e)
        {
            if (clickeado)
            {
                TxtNombre.Text = String.Format("{0} {1} {2} {3}", TxtPrNombre.Text.Trim(), TxtSegNombre.Text.Trim(), TxtPrApellido.Text.Trim(), TxtSegApellido.Text.Trim());

            }
            else
            {
                TxtNombre.Text = String.Format("{0} {1} {2} {3}", TxtPrApellido.Text.Trim(), TxtSegApellido.Text.Trim(), TxtPrNombre.Text.Trim(), TxtSegNombre.Text.Trim());

            }
        }

        private void TxtPrApellido_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((TxtPrApellido.Text)))
            {
                errorP1.SetError(TxtPrApellido, "Debe ingresar el primer apellido.");
                TxtPrApellido.Focus();
            }
            else
            {
                errorP1.SetError(TxtPrApellido, "");
            }
        }

        private void TxtSegApellido_TextChanged(object sender, EventArgs e)
        {
            if (clickeado)
            {
                TxtNombre.Text = String.Format("{0} {1} {2} {3}", TxtPrNombre.Text.Trim(), TxtSegNombre.Text.Trim(), TxtPrApellido.Text.Trim(), TxtSegApellido.Text.Trim());

            }
            else
            {
                TxtNombre.Text = String.Format("{0} {1} {2} {3}", TxtPrApellido.Text.Trim(), TxtSegApellido.Text.Trim(), TxtPrNombre.Text.Trim(), TxtSegNombre.Text.Trim());

            }
        }

        private void TxtIdentificacion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((TxtIdentificacion.Text)))
            {
                errorP1.SetError(TxtIdentificacion, "Debe ingresar la identificación.");
                TxtIdentificacion.Focus();
            }
            else
            {
                errorP1.SetError(TxtIdentificacion, "");
            }
        }

        private void TxtPrNombre_TextChanged(object sender, EventArgs e)
        {
            if (clickeado)
            {
                TxtNombre.Text = String.Format("{0} {1} {2} {3}", TxtPrNombre.Text.Trim(), TxtSegNombre.Text.Trim(), TxtPrApellido.Text.Trim(), TxtSegApellido.Text.Trim());

            }
            else
            {
                TxtNombre.Text = String.Format("{0} {1} {2} {3}", TxtPrApellido.Text.Trim(), TxtSegApellido.Text.Trim(), TxtPrNombre.Text.Trim(), TxtSegNombre.Text.Trim());

            }
        }




        #endregion


    }
}