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
using DevExpress.XtraGrid.Columns;

namespace RecordRatings.Vistas
{
    public partial class FrmGetProfesores : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Modo { get; set; }
        public int Id { get; set; }

        #endregion

        #region Variables

        bool clickeado = true;
        Point formPosition;
        Boolean mouseAction;
        string codProfesor;
        DataSet dsConsulta = new DataSet();
        DataTable dtConsulta = new DataTable();
        private Funciones f = new Funciones();

        #endregion

        #region Metodos

        public FrmGetProfesores()
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

            Profesor pf = new Profesor();
            pf.Persona.Identificacion = TxtIdentificacion.Text.Trim();

            DataSet ds = CtrlProfesores.GetPersonaIdentificacion(pf);
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
                    Profesor profesor = new Profesor();
                    profesor.Persona.Nombre = TxtNombre.Text.Trim();
                    profesor.Persona.PrimerNombre = TxtPrNombre.Text.Trim();
                    profesor.Persona.SegundoNombre = TxtSegNombre.Text.Trim();
                    profesor.Persona.PrimerApellido = TxtPrApellido.Text.Trim();
                    profesor.Persona.SegundoApellido = TxtSegApellido.Text.Trim();
                    profesor.Persona.Identificacion = TxtIdentificacion.Text.Trim();
                    profesor.Persona.Direccion = TxtDireccion.Text.Trim();
                    profesor.Persona.Telefono = TxtTelefono.Text.Trim();
                    profesor.Persona.Email = TxtEmail.Text.Trim();
                    profesor.Persona.Sexo = (CmbSexo.SelectedIndex == 0 ? "M" : "F");

                    string est = "I";

                    if (CmbEstado.SelectedIndex == 1)
                    {
                        est = "A";
                    }
                    else
                    {                       
                        if (CmbEstado.SelectedIndex == 2)
                        {
                            est = "R";
                        }
                         
                    }
                    profesor.Estado = est;

                    profesor.Usuario.Nombre = TxtUsuario.Text.Trim();
                    profesor.Usuario.Contrasenia = TxtPass2.Text.Trim();
                    profesor.Usuario.TipoUsuario.Codigo = LueTipoUsuario.EditValue.ToString();

                    DataTable insert = CtrlProfesores.Insertar(profesor).Tables[0];

                    if (insert.Rows.Count > 0)
                    {
                        codProfesor = insert.Rows[0]["CodProfesor"].ToString();
                        InsertarMaterias();

                        XtraMessageBox.Show("Profesor insertado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {
                    Profesor profesor = new Profesor();
                    profesor.Persona.Id = Id;
                    profesor.Persona.Nombre = TxtNombre.Text.Trim();
                    profesor.Persona.PrimerNombre = TxtPrNombre.Text.Trim();
                    profesor.Persona.SegundoNombre = TxtSegNombre.Text.Trim();
                    profesor.Persona.PrimerApellido = TxtPrApellido.Text.Trim();
                    profesor.Persona.SegundoApellido = TxtSegApellido.Text.Trim();
                    profesor.Persona.Identificacion = TxtIdentificacion.Text.Trim();                   
                    profesor.Persona.Direccion = TxtDireccion.Text.Trim();
                    profesor.Persona.Telefono = TxtTelefono.Text.Trim();
                    profesor.Persona.Email = TxtEmail.Text.Trim();
                    profesor.Persona.Sexo = (CmbSexo.SelectedIndex == 0 ? "M" : "F");

                    string est = "I";

                    if (CmbEstado.SelectedIndex == 1)
                    {
                        est = "A";
                    }
                    else
                    {
                        if (CmbEstado.SelectedIndex == 2)
                        {
                            est = "R";
                        }

                    }
                    profesor.Estado = est;

                    if (CtrlProfesores.Actualizar(profesor) > 0)
                    {
                        EliminarMaterias();
                        InsertarMaterias();
                        XtraMessageBox.Show("Profesor actualizado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        public void InsertarMaterias() 
        {
            for (int i = 0; i < DgvMaterias.RowCount; i++)
            {
                string codMateria = DgvMaterias.GetRowCellValue(i, DgvMaterias.Columns["CodMateria"]).ToString();

                ProfesorMaterias prM = new ProfesorMaterias();
                prM.Materia.CodMateria = codMateria;
                prM.Profesor.CodigoProfesor = codProfesor;

                CtrlProfesorMaterias.Insertar(prM);
            }
        }

        public void EliminarMaterias() 
        {
            ProfesorMaterias prM = new ProfesorMaterias();
            prM.Profesor.CodigoProfesor = codProfesor;

            CtrlProfesorMaterias.EliminarTodas(prM);
        }

        private void CargarDatos(int id)
        {
            Profesor pf = new Profesor();
            pf.Persona.Id = id;
            DataSet ds = CtrlProfesores.GetProfesorOne(pf);
            DataRow dr = ds.Tables[0].Rows[0];

            codProfesor = dr["CodigoProfesor"].ToString();
            TxtNombre.Text = dr["Nombre"].ToString();
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
                    if (dr["Estado"].ToString() == "R")
                    {
                        CmbEstado.SelectedIndex = 4;
                    }                   
                }
            }

            if (!BkgwBuscarMat.IsBusy)
            {
                PrgBuscar2.Visible = true;
                BkgwBuscarMat.RunWorkerAsync();
            }   
        }

        private void LlenarDsConsulta(string codProfesor)
        {
            try
            {
                ProfesorMaterias profMat = new ProfesorMaterias();
                profMat.Profesor.CodigoProfesor = codProfesor;

                DataSet ds = CtrlProfesorMaterias.GetProfesorMaterias(profMat);

                dtConsulta = new DataTable();
                dsConsulta = new DataSet();

                dtConsulta = ds.Tables[0].Copy();
                dsConsulta.Tables.Clear();
                if (dsConsulta.Tables.Count == 0)
                {
                    dsConsulta.Tables.Add(dtConsulta);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LlenarGridConsulta()
        {
            DgvMaterias.Columns.Clear();
            DgvMaterias.OptionsView.ColumnAutoWidth = false;
            DataViewManager dvm = new DataViewManager(dsConsulta);
            DataView dvMain = dvm.CreateDataView(dsConsulta.Tables[0]);
            DgvMaterias.OptionsBehavior.AutoPopulateColumns = false;
            GctrlMaterias.DataSource = dvMain;
            string[] captions = new[] { "CodigoProfesor","Area", "CodMateria", "Materia" };

            GridColumn[] col = new GridColumn[dsConsulta.Tables[0].Columns.Count];
            for (int i = 0; i < dsConsulta.Tables[0].Columns.Count; i++)
            {
                col[i] = DgvMaterias.Columns.AddField(dsConsulta.Tables[0].Columns[i].Caption.Trim());
                col[i].VisibleIndex = i;
                col[i].Caption = captions[i];
                col[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (i == 0 || i == 2 )
                {
                    col[i].Visible = false;
                }
            }

            DgvMaterias.Columns[1].Width = 300;
            DgvMaterias.Columns[3].Width = 255;


            Funciones.getInstancia().Configurar_Grid(DgvMaterias);
            DgvMaterias.OptionsCustomization.AllowSort = true;
            //DgvMaterias.OptionsFind.AlwaysVisible = true;
            DgvMaterias.OptionsView.ColumnAutoWidth = false;
        }

        public void Añadir() 
        {
           
            FrmGetProfesorMaterias prMat = new FrmGetProfesorMaterias();
            prMat.CodMateria = DgvMaterias.GetFocusedRowCellDisplayText(DgvMaterias.Columns["CodigoProfesor"]);
            prMat.NombreProfe = TxtNombre.Text;
            prMat.CodProfesor = codProfesor;
            prMat.ShowDialog();

            if (prMat.DialogResult == System.Windows.Forms.DialogResult.OK) 
            {
                if (ValidarAddMat(prMat.CodMateria))
                { 
                    ProfesorMaterias prMa = new ProfesorMaterias();
                    prMa.Profesor.CodigoProfesor = prMat.CodProfesor;
                    prMa.Materia.CodMateria = prMat.CodMateria;

                    DataRow dr = CtrlProfesorMaterias.GetProfesorMateriasRow(prMa).Tables[0].Rows[0];
                    dtConsulta.Rows.Add(dr.ItemArray);
                    DgvMaterias.RefreshData();
                }

            }
            
        }

        private bool ValidarAddMat(string cMat)
        {
            bool retorno = true;

            for (int i = 0; i < DgvMaterias.RowCount; i++)
            {
                string codM = DgvMaterias.GetRowCellDisplayText(i, DgvMaterias.Columns["CodMateria"]);

                if (cMat == codM)
                {
                    retorno = false;
                }
            }

            return retorno;
        }

        public void Eliminar() 
        {
            if (DgvMaterias.RowCount > 0 && DgvMaterias.GetFocusedRow() != null) 
            {
                if (XtraMessageBox.Show("¿Esta seguro que desea eliminar la asignación de la materia?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DgvMaterias.DeleteRow(DgvMaterias.FocusedRowHandle);
                    DgvMaterias.RefreshData();
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar una materia.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmGetProfesores_Load(object sender, EventArgs e)
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
                LueTipoUsuario.EditValue = "02";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }

            TxtPrNombre.Focus();
            if (Modo == "E" && Id > 0)
            {
                CargarDatos(Id);
                panel3.Visible = false;
                panelControl1.Location = new Point(18, 288);
                GctrlMaterias.Location = new Point(18, 317);
                acceptCancel1.Location = new Point(219, 469);
                PrgBuscar2.Location = new Point(198, 376);
                this.Size = new Size(610, 515);
            }
            else
            {
                codProfesor = "";
                if (!BkgwBuscarMat.IsBusy)
                {
                    PrgBuscar2.Visible = true;
                    BkgwBuscarMat.RunWorkerAsync();
                }   
            }                    

            TxtPrNombre.Focus();
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

        private void BkgwBuscarMat_DoWork(object sender, DoWorkEventArgs e)
        {
            LlenarDsConsulta(codProfesor);
        }

        private void BkgwBuscarMat_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PrgBuscar2.Visible = false;
            LlenarGridConsulta();            
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