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
    public partial class FrmGetAlumnos : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Modo { get; set; }
        public int Id { get; set; }
        public int Año { get; set; }

        #endregion

        #region Variables

        bool clickeado = true;
        Point formPosition;
        Boolean mouseAction;
        string CodAlumno = "";
        private Funciones f = new Funciones();

        #endregion

        #region Metodos

        public FrmGetAlumnos()
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

        public bool ValidarUsu()
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

        private bool ConsultarUsuario()
        {
            string user = "";
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


        public void Accept()
        {
            if (Modo != "E")
            {
                if (ValidarPersona())
                {
                    if (ConsultarIdentificacion())
                    {
                        if (ValidarUsu())
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
                if (ValidarPersona())
                {                                
                    if (ConsultarIdentificacion())
                    {                                                
                        InsertarActualizar("UPDATE");
                       
                        DialogResult = DialogResult.OK;                        
                    }                    
                }
            }
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
                if (TxtIdentificacion.Text.Trim() == identifi && idPersona != Id) 
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
            TxtPrNombre.Text = "";
            TxtSegNombre.Text = "";
            TxtPrApellido.Text = "";
            TxtSegApellido.Text = "";
            TxtIdentificacion.Text = "";
            TxtCarnet.Text = "";
            TxtDireccion.Text = "";
            TxtEmail.Text = "";
            TxtTelefono.Text = "";
        }

        private void InsertarActualizar(string modo)
        {
            try
            {
                if (modo == "INSERT")
                {                   
                    Alumno alumno = new Alumno();
                    alumno.Persona.Nombre = TxtNombre.Text.Trim();
                    alumno.Persona.PrimerNombre = TxtPrNombre.Text.Trim();
                    alumno.Persona.SegundoNombre = TxtSegNombre.Text.Trim();
                    alumno.Persona.PrimerApellido = TxtPrApellido.Text.Trim();
                    alumno.Persona.SegundoApellido = TxtSegApellido.Text.Trim();
                    alumno.Persona.Identificacion = TxtIdentificacion.Text.Trim();

                    if (String.IsNullOrEmpty(TxtCarnet.Text))
                    {
                        alumno.Carnet = TxtIdentificacion.Text.Trim();
                    }
                    else
                    {
                        alumno.Carnet = TxtCarnet.Text.Trim();
                    }
                    
                    alumno.Persona.Direccion = TxtDireccion.Text.Trim();
                    alumno.Persona.Telefono = TxtTelefono.Text.Trim();
                    alumno.Persona.Email = TxtEmail.Text.Trim(); 
                    alumno.Persona.Sexo = (CmbSexo.SelectedIndex == 0 ? "M" : "F");

                    string est = "I";

                    if (CmbEstado.SelectedIndex == 1) 
                    {
                        est = "A";
                    }
                    else
                    {
                        if (CmbEstado.SelectedIndex == 2) 
                        {
                            est = "S";
                        }
                        else
                        {
                            if (CmbEstado.SelectedIndex == 3)
                            {
                                est = "E";
                            }
                            else
                            {
                                if (CmbEstado.SelectedIndex == 4)
                                {
                                    est = "R";
                                }
                            }
                        }
                    }
                    
                    alumno.Estado = est;

                    alumno.Usuario.Nombre = TxtUsuario.Text.Trim();
                    alumno.Usuario.Contrasenia = TxtPass2.Text.Trim();
                    alumno.Usuario.TipoUsuario.Codigo = LueTipoUsuario.EditValue.ToString();

                    DataSet dsIn = CtrlAlumnos.Insertar(alumno);
                    if (dsIn.Tables[0].Rows.Count > 0)
                    {
                        CodAlumno = dsIn.Tables[0].Rows[0]["CodAlumno"].ToString();

                        CursoAlumno cuAl = new CursoAlumno();
                        cuAl.Alumno.CodigoAlum = CodAlumno;
                        cuAl.AñoElectivo = Año;

                        if (LueCurso.EditValue != null)
                        {
                            cuAl.Curso.CodigoCurso = LueCurso.EditValue.ToString();

                            CtrlCursoAlumnos.ActualizarCurso(cuAl);
                        }

                        XtraMessageBox.Show("Alumno insertado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {                                        
                    Alumno alumno = new Alumno();
                    alumno.Persona.Id = Id;
                    alumno.Persona.Nombre = TxtNombre.Text.Trim();
                    alumno.Persona.PrimerNombre = TxtPrNombre.Text.Trim();
                    alumno.Persona.SegundoNombre = TxtSegNombre.Text.Trim();
                    alumno.Persona.PrimerApellido = TxtPrApellido.Text.Trim();
                    alumno.Persona.SegundoApellido = TxtSegApellido.Text.Trim();
                    alumno.Persona.Identificacion = TxtIdentificacion.Text.Trim();
                    if (String.IsNullOrEmpty(TxtCarnet.Text))
                    {
                        alumno.Carnet = TxtIdentificacion.Text.Trim();
                    }
                    else
                    {
                        alumno.Carnet = TxtCarnet.Text.Trim();
                    }

                    string est = "I";

                    if (CmbEstado.SelectedIndex == 1)
                    {
                        est = "A";
                    }
                    else
                    {
                        if (CmbEstado.SelectedIndex == 2)
                        {
                            est = "S";
                        }
                        else
                        {
                            if (CmbEstado.SelectedIndex == 3)
                            {
                                est = "E";
                            }
                            else
                            {
                                if (CmbEstado.SelectedIndex == 4)
                                {
                                    est = "R";
                                }
                            }
                        }
                    }

                    alumno.Estado = est;

                    alumno.Persona.Direccion = TxtDireccion.Text.Trim();
                    alumno.Persona.Telefono = TxtTelefono.Text.Trim();
                    alumno.Persona.Email = TxtEmail.Text.Trim();
                    alumno.Persona.Sexo = (CmbSexo.SelectedIndex == 0 ? "M" : "F");

                    DataSet dsIn = CtrlAlumnos.Actualizar(alumno);
                    if (dsIn.Tables[0].Rows.Count > 0)
                    {
                        CodAlumno = dsIn.Tables[0].Rows[0]["CodAlumno"].ToString();

                        CursoAlumno cuAl = new CursoAlumno();
                        cuAl.Alumno.CodigoAlum = CodAlumno;
                        cuAl.AñoElectivo = Año;

                        if (LueCurso.EditValue != null) 
                        { 
                            cuAl.Curso.CodigoCurso = LueCurso.EditValue.ToString();

                            CtrlCursoAlumnos.ActualizarCurso(cuAl);
                        }

                        XtraMessageBox.Show("Alumno actualizado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        private void CargarDatos(int id)
        {
            Alumno al = new Alumno();
            al.Persona.Id = id;
            DataSet ds = CtrlAlumnos.GetAlumnoOne(al);
            DataRow dr = ds.Tables[0].Rows[0];

            CodAlumno = dr["CodigoAlum"].ToString();
            TxtNombre.Text = dr["Nombre"].ToString();
            TxtPrNombre.Text = dr["PrimerNombre"].ToString();
            TxtSegNombre.Text = dr["SegundoNombre"].ToString();
            TxtPrApellido.Text = dr["PrimerApellido"].ToString();
            TxtSegApellido.Text = dr["SegundoApellido"].ToString();
            TxtIdentificacion.Text = dr["Identificacion"].ToString();
            TxtCarnet.Text = dr["Carnet"].ToString();
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
            
            if (dr["Estado"].ToString() == "I")
            {
                CmbEstado.SelectedIndex = 0;               
            }
            else
            {
                if (dr["Estado"].ToString() == "A")
                {
                    CmbEstado.SelectedIndex = 1; 
                }
                else
                {
                    if (dr["Estado"].ToString() == "S")
                    {
                        CmbEstado.SelectedIndex = 2; 
                    }
                    else
                    {
                        if (dr["Estado"].ToString() == "E")
                        {
                            CmbEstado.SelectedIndex = 3;
                        }
                        else
                        {
                            if (dr["Estado"].ToString() == "R")
                            {
                                CmbEstado.SelectedIndex = 4;
                            }
                        }
                    }
                }
            }

            CargarCurso();
        }

        public void CargarCurso() 
        {
            CursoAlumno cuAl = new CursoAlumno();
            cuAl.Alumno.CodigoAlum = CodAlumno;
            cuAl.AñoElectivo = Año;
            DataSet ds = CtrlCursoAlumnos.GetCursoAlumnosOne(cuAl);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                LueCurso.EditValue = dr["CodigoCurso"].ToString();
            }
        }

        #endregion

        #region Eventos

        #region MovVentana       

        private void LnkLblCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void FrmGetAlumnos_Load(object sender, EventArgs e)
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
                LueTipoUsuario.EditValue = "03";
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }

            CursoAñoElectivo curAe = new CursoAñoElectivo();
            curAe.AñoElectivo = Año;

            DataTable dt2 = CtrlCursoAñoElectivo.GetCursoAñoElectivo(curAe).Tables[0];
            LueCurso.Properties.DataSource = dt2;
            LueCurso.Properties.DisplayMember = "Nombre";
            LueCurso.Properties.ValueMember = "CodigoCurso";

            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1;
            col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
            LueCurso.Properties.Columns.Add(col1);
            LueCurso.ItemIndex = -1;
            

            TxtPrNombre.Focus();
            if (Modo == "E" && Id > 0)
            {
                CargarDatos(Id);
                panel3.Visible = false;
                acceptCancel1.Location = new Point(229, 337);
                this.Size = new Size(631, 382);
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

        #endregion


    }
}