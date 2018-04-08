using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLReferences;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace GLUserControls
{
    public partial class FrmAñadirEditarPerfiles : BasicForm
    {
        #region Propiedades 

        public String Perfil { get; set; }
        public String Dbase { get; set; }
 
        #endregion

        #region Variables

        private DataSet dsTablas, dsCampoPrincipal, dsCamposFecha, dsCampoCodigo, dsCampoNombre;
        private DataSet dsGrillaCampos=new DataSet();
        private DataTable dtGrillaCampos = new DataTable();
        private DataSet dsGrillaCamposVisibles = new DataSet();
        private DataTable dtTablas, dtCampoPrincipal, dtCamposFecha, dtCampoCodigo, dtCampoNombre;
        private DataTable dtGrillaCamposVisibles = new DataTable();
        private String tabla = "";
        private String campoPcpal = "";
        private String campoCodigo = "";
        private String campoNombre = "";
        private String campoFecha = "";
        private String[] vCampos;
        private String[] vVisibles;
        private String[] vCabeceras;
        private String[] vTamaños;
        private String[] vIndexes;
        private String[] vCampoId;

        #endregion

        #region Metodos
      
        /// <summary> Constructor
        /// Constructor de la clase
        /// </summary>
        public FrmAñadirEditarPerfiles()
        {
            InitializeComponent();
            acceptCancel1.AcceptButtonText = "Guardar";
            acceptCancel1.Maceptar = "Guardar";
            TxtLblDatosD.Size = new Size(298, 26);
        }

        /// <summary> LlenarGrid(DataSet d)
        /// Permite llenar la grilla con un Dataset
        /// </summary>
        /// <param name="d">En este parametro se recibe el Dataset con que se va a llenar la grilla DgvCampos </param>
        public void LlenarGridCampos(DataSet d)
        {
               if (d!=null)
                {
                    DgvCampos.Columns.Clear();
                    DataViewManager dvm = new DataViewManager(d);
                    DataView dvMain = dvm.CreateDataView(d.Tables[0]);

                    DgvCampos.OptionsBehavior.AutoPopulateColumns = false;
                    GcrtlCampos.DataSource = dvMain;

                    GridColumn[] col = new GridColumn[d.Tables[0].Columns.Count];

                    string[] captions = new[] { "Campo", "Agregar", "Visible"};

                    for (int i = 0; i < d.Tables[0].Columns.Count; i++)
                    {
                        col[i] = DgvCampos.Columns.AddField(d.Tables[0].Columns[i].Caption.Trim());
                        col[i].VisibleIndex = i;
                        col[i].Caption = captions[i];
                        col[i].FieldName = captions[i];
                    }

                    DgvCampos.Columns["Campo"].Width = 504;
                    DgvCampos.Columns["Agregar"].Width = 48;
                    DgvCampos.Columns["Visible"].Width = 47;
                    DevExpress.XtraEditors.Repository.RepositoryItemTextEdit memo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    memo.ReadOnly = true;
                    DgvCampos.Columns[0].ColumnEdit = memo;
                    DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit memo1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                    memo1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
                    DgvCampos.Columns[1].ColumnEdit = memo1;
                    DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit memo2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                    DgvCampos.Columns[2].ColumnEdit = memo2;
                }

                DgvCampos.OptionsBehavior.AutoPopulateColumns = false;
                DgvCampos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                DgvCampos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                DgvCampos.OptionsView.ColumnAutoWidth = false;
                DgvCampos.OptionsFilter.AllowFilterEditor = false;
                DgvCampos.OptionsFilter.AllowColumnMRUFilterList = false;
                DgvCampos.OptionsFilter.AllowMRUFilterList = false;
                DgvCampos.OptionsFilter.MRUFilterListPopupCount = 0;
                DgvCampos.OptionsFilter.MRUFilterListCount = 0;
                DgvCampos.OptionsFilter.MRUColumnFilterListCount = 0;
                DgvCampos.OptionsView.EnableAppearanceOddRow = true;
                DgvCampos.OptionsView.ShowAutoFilterRow = false;
                DgvCampos.OptionsView.ShowGroupPanel = false;
                DgvCampos.OptionsHint.ShowColumnHeaderHints = false;
                DgvCampos.OptionsView.ShowIndicator = true;
                DgvCampos.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;
                DgvCampos.OptionsCustomization.AllowQuickHideColumns = false;
                DgvCampos.OptionsCustomization.AllowFilter = false;
                DgvCampos.OptionsMenu.EnableColumnMenu = false;
                DgvCampos.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
                DgvCampos.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
        }

        /// <summary>LlenarGrid2(DataSet d)
        /// Permite llenar la grilla con un Dataset
        /// </summary>
        /// <param name="d"></param>En este parametro se recibe el Dataset con que se va a llenar la grilla DgvCamposVisibles
        public void LlenarGridCamposVisibles(DataSet d)
        {
            if (d != null)
            {
                DgvCamposVisibles.Columns.Clear();
                DataViewManager dvm = new DataViewManager(d);
                DataView dvMain = dvm.CreateDataView(d.Tables[0]);
                DgvCamposVisibles.OptionsBehavior.AutoPopulateColumns = false;
                GctrlCamposVisibles.DataSource = dvMain;
                GridColumn[] col = new GridColumn[d.Tables[0].Columns.Count];
                string[] captions = new[] { "CampoId", "Cabecera", "Tamaño", "Índice" };

                for (int i = 0; i < d.Tables[0].Columns.Count; i++)
                {
                    col[i] = DgvCamposVisibles.Columns.AddField(d.Tables[0].Columns[i].Caption.Trim());
                    col[i].VisibleIndex = i;
                    col[i].Caption = captions[i];
                    col[i].FieldName = captions[i];
                    if (i==0)
                    {
                        col[i].Visible = false;
                    }
                }

                DevExpress.XtraEditors.Repository.RepositoryItemTextEdit memo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                memo.ReadOnly = false;
                DgvCamposVisibles.Columns[1].ColumnEdit = memo;
                DevExpress.XtraEditors.Repository.RepositoryItemTextEdit memo2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                memo2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                memo2.Mask.EditMask = "d";
                memo2.Mask.UseMaskAsDisplayFormat = false;
                //memo2.NullText = "100";
                memo2.Mask.UseMaskAsDisplayFormat = true;
                memo2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                memo2.Appearance.Options.UseTextOptions = true;
                DgvCamposVisibles.Columns[2].ColumnEdit = memo2;
                DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit memo3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();  
                memo3.NullText = "0";
                memo3.Mask.EditMask = "d";
                memo3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                memo3.MinValue = 0;
                
                if (d.Tables[0].Rows.Count!=1)
                {
                   memo3.MaxValue = (d.Tables[0].Rows.Count) - 1;
                   memo3.ReadOnly = false;
                }
                else
                {
                    if (d.Tables[0].Rows.Count == 1)
                        memo3.MaxValue = (d.Tables[0].Rows.Count);
                        memo3.ReadOnly = true;
                        d.Tables[0].Rows[0][3] = "0";
                }
                
                DgvCamposVisibles.Columns[3].ColumnEdit = memo3;
            }
            else
            {
                GctrlCamposVisibles.DataSource = null;
            }

            DgvCamposVisibles.OptionsBehavior.AutoPopulateColumns = false;
            DgvCamposVisibles.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            DgvCamposVisibles.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            DgvCamposVisibles.OptionsView.ColumnAutoWidth = false;
            DgvCamposVisibles.OptionsFilter.AllowFilterEditor = false;
            DgvCamposVisibles.OptionsFilter.AllowColumnMRUFilterList = false;
            DgvCamposVisibles.OptionsFilter.AllowMRUFilterList = false;
            DgvCamposVisibles.OptionsFilter.MRUFilterListPopupCount = 0;
            DgvCamposVisibles.OptionsFilter.MRUFilterListCount = 0;
            DgvCamposVisibles.OptionsFilter.MRUColumnFilterListCount = 0;
            DgvCamposVisibles.OptionsView.EnableAppearanceOddRow = true;
            DgvCamposVisibles.OptionsView.ShowAutoFilterRow = false;
            DgvCamposVisibles.OptionsView.ShowGroupPanel = false;
            DgvCamposVisibles.OptionsHint.ShowColumnHeaderHints = false;
            DgvCamposVisibles.OptionsView.ShowIndicator = true;
            DgvCamposVisibles.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;
            DgvCamposVisibles.OptionsCustomization.AllowQuickHideColumns = false;
            DgvCamposVisibles.OptionsCustomization.AllowFilter = false;
            DgvCamposVisibles.OptionsMenu.EnableColumnMenu = false;
            DgvCamposVisibles.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            DgvCamposVisibles.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
        }

        /// <summary>Viajar()
        /// Permite realizar las acciones añadir y modificar.
        /// Este metodo es llamado desde el metodo Guardar.
        /// </summary>
        public void Viajar()
        {
            Perfil perfil = new Perfil();

            try
            {
                int tamañoCampos = 0;
                int tamañoVisibles = 0;
                for (int i = 0; i < dtGrillaCampos.Rows.Count; i++)
                {
                    if ((bool)dtGrillaCampos.Rows[i]["Agregar"]) 
                        tamañoCampos++; 
                    if ((bool)dtGrillaCampos.Rows[i]["Visible"])
                        tamañoVisibles++; 
                }

                perfil.Campos = new string[tamañoCampos];
                for (int i = 0, j = 0; i < dtGrillaCampos.Rows.Count; i++)
                {
                    if ((bool)dtGrillaCampos.Rows[i]["Agregar"])
                    {
                        perfil.Campos[j] = dtGrillaCampos.Rows[i][0].ToString();
                        j++;
                    }
                }

                perfil.Visibles = new string[tamañoVisibles];
                for (int i = 0, j = 0; i < dtGrillaCampos.Rows.Count; i++)
                {
                    if ((bool)dtGrillaCampos.Rows[i]["Visible"])
                    {
                        perfil.Visibles[j] = dtGrillaCampos.Rows[i][0].ToString();
                        j++;
                    }
                }

                perfil.CamposId = new string[dtGrillaCamposVisibles.Rows.Count];
                for (int i = 0; i < dtGrillaCamposVisibles.Rows.Count; i++)
                {
                        perfil.CamposId[i] = dtGrillaCamposVisibles.Rows[i][0].ToString();

                }

                perfil.Cabeceras = new string[dtGrillaCamposVisibles.Rows.Count];
                for (int i = 0; i < dtGrillaCamposVisibles.Rows.Count; i++)
                {
                        perfil.Cabeceras[i] = dtGrillaCamposVisibles.Rows[i]["Cabecera"].ToString();
                }

                perfil.Tamaños = new string[dtGrillaCamposVisibles.Rows.Count];
                for (int i = 0; i < dtGrillaCamposVisibles.Rows.Count; i++)
                {
                        perfil.Tamaños[i] = dtGrillaCamposVisibles.Rows[i]["Tamaño"].ToString();
                }

                perfil.Indices = new string[dtGrillaCamposVisibles.Rows.Count];
                for (int i = 0; i < dtGrillaCamposVisibles.Rows.Count; i++)
                {
                    perfil.Indices[i] = dtGrillaCamposVisibles.Rows[i]["Indice"].ToString();
                }

                perfil.Tabla = LueOrigenD.Text;
                perfil.Formulario = TxtFrmGet.Text;
                perfil.Proyecto = TxtProyecto.Text;
                perfil.Titulo = TxtTitulo.Text;
                perfil.Llave = LueCampoPrincipal.Text;
                perfil.CampoNombre = LueCampoNombre.Text;
                perfil.CampoCodigo = LueCampoCodigo.Text;

                if (LueCampoFecha.Text == "[Vacío]")
                    perfil.CampoFecha = "";
                else
                    perfil.CampoFecha = LueCampoFecha.Text;

                perfil.UtilizarReportes = ChkUtilizarR.Checked.ToString();
                if (String.IsNullOrEmpty(TxtLblDatosD.Codigo))
                {
                    perfil.DatosDetalle = "";
                }
                else
                {
                perfil.DatosDetalle = TxtLblDatosD.Codigo;
                }

                perfil.Descripcion = TxtDescripcion.Text;
                perfil.Subtitulo = TxtSubtitulo.Text;
                perfil.ColumnaEstatica =TxtColumnaE.Text;
                perfil.Id = TxtNomPerfil.Text;
                perfil.Reporte = TxtReporte.Text;

                Perfilador p= new Perfilador();
                bool existe=p.BuscarPerfil(TxtNomPerfil.Text);           
                if (existe == true)
                {
                    if (TxtNomPerfil.Enabled==false)
                    {       
                        new Perfilador().ModificarPerfil(perfil);
                        XtraMessageBox.Show("El perfil fue editado satisfactoriamente", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (DialogResult.Yes== XtraMessageBox.Show("Ya existe un perfil llamado " + TxtNomPerfil.Text + "; ¿Desea reemplazarlo?", GLReferences.Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            new Perfilador().ModificarPerfil(perfil);
                            XtraMessageBox.Show("El perfil fue reemplazado satisfactoriamente", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }                      
                    }                   
                }
                else
                {
                    new Perfilador().InsertarPerfil(perfil);
                    XtraMessageBox.Show("El perfil fue añadido satisfactoriamente", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception y)
            {
                XtraMessageBox.Show(y.Message);
            }
        }

        /// <summary>Guardar()
        /// Este metodo se ejecuta cuando se presiona el boton Guardar.
        /// Permite hacer validaciones antes de ejecutar el metodo Viajar()
        /// </summary>
        public void Guardar()
        {
            if (String.IsNullOrEmpty(TxtNomPerfil.Text))
            {
                XtraMessageBox.Show("Nombre perfil no puede quedar vacío", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                  TxtNomPerfil.Focus();
            }

            if (String.IsNullOrEmpty(TxtFrmGet.Text) && !String.IsNullOrEmpty(TxtNomPerfil.Text))
            {
                XtraMessageBox.Show("Formulario Get no puede quedar vacío", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFrmGet.Focus();
            }

            if (String.IsNullOrEmpty(TxtProyecto.Text) && !String.IsNullOrEmpty(TxtFrmGet.Text))
            {
                XtraMessageBox.Show("Proyecto no puede quedar vacío", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProyecto.Focus();
            }

            if (String.IsNullOrEmpty(TxtTitulo.Text) && !String.IsNullOrEmpty(TxtProyecto.Text))
            {
                XtraMessageBox.Show("Título no puede quedar vacío", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtTitulo.Focus();
            }

            if (LueOrigenD.Text == "[Vacío]" && !String.IsNullOrEmpty(TxtTitulo.Text) 
                && !String.IsNullOrEmpty(TxtNomPerfil.Text) && !String.IsNullOrEmpty(TxtFrmGet.Text))
            {
                XtraMessageBox.Show("Debe seleccionar el origen de  los datos", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LueOrigenD.Focus();
            }

            if (String.IsNullOrEmpty(LueCampoPrincipal.Text) && !String.IsNullOrEmpty(TxtTitulo.Text))
            {
                XtraMessageBox.Show("Debe seleccionar el campo principal", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LueCampoPrincipal.Focus();
            }

            bool viajar = false;
            int parar = 0;
            if (dtGrillaCamposVisibles.Rows.Count!=0)
            {
                for (int i = 0; i < dtGrillaCamposVisibles.Rows.Count; i++)
                {
                    String indc = dtGrillaCamposVisibles.Rows[i][3].ToString();
                    if (parar == 1)
                        {
                            break;
                        }
                        for (int j = 0; j < dtGrillaCamposVisibles.Rows.Count; j++)
                        {
                            if (indc == dtGrillaCamposVisibles.Rows[j][3].ToString()&& j!=i)
                            {
                                XtraMessageBox.Show("El indice no se puede repetir", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                viajar = false;
                                parar = 1;
                                break;
                            }
                            else
                            {
                                viajar = true;
                            }
                        }
                }
            }
            else
            {
                viajar = true;
            }
       
            if (viajar && !String.IsNullOrEmpty(TxtTitulo.Text) && !String.IsNullOrEmpty(LueCampoPrincipal.Text) 
               && !String.IsNullOrEmpty(TxtFrmGet.Text) &&!String.IsNullOrEmpty(TxtProyecto.Text)&& !String.IsNullOrEmpty(TxtNomPerfil.Text)&& LueOrigenD.Text != "[Vacío]")
            {
                Viajar(); 
            }          
        }

        /// <summary>LlenarTablas(String tabla)
        /// Permite inicializar el LookUpEdit (LueOrigenD), con las tablas que pertenecen a la Base de Datos.
        /// Si el parametro (tabla), es diferente de ""; se inicializa el LookUpEdit (LueOrigenD), y se selecciona el nombre de la tabla que viene en el parametro (tabla)
        /// </summary>
        /// <param name="tabla">En este parametro se recibe el nombre de la tabla que se desea selecionar en el LookUpEdit (LueOrigenD) </param>
        public void LlenarTablas(String tabla)
        {   
            Funciones f=new Funciones();
            dsTablas = f.GetTables(ConexionDB.getInstancia().Conexion(Dbase,null));
            dtTablas = dsTablas.Tables[0];

            try
            {
                LueOrigenD.Properties.DataSource = dtTablas;
                LueOrigenD.Properties.DisplayMember = "TABLA";
                LueOrigenD.Properties.ValueMember = "TABLA";
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col;
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TABLA", 10, "Tablas");
                col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                LueOrigenD.Properties.Columns.Add(col);

                var col2 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", 10, "Tablas");
                col2.Visible = false;
                LueOrigenD.Properties.Columns.Add(col2);

                if (!String.IsNullOrEmpty(tabla))
                {
                    LueOrigenD.EditValue = tabla;
                }
                else
                {
                    LueOrigenD.ItemIndex = -1;
                } 
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>LlenarCampos(String campo)
        /// Permite inicializar el LookUpEdit (LueCampoPrincipal), con los campos que pertenecen a la tabla seleccionada.
        /// Si el parametro (campo), es diferente de ""; se inicializa el LookUpEdit (LueCampoPrincipal), y se selecciona el nombre del campo que viene en el parametro (campo)
        /// </summary>
        /// <param name="campo">En este parametro se recibe el nombre del campo que se desea seleccionar en el LookUpEdit (LueCampoPrincipal) </param>
        public void LlenarCampoPrincipal(String campo)
        {
            string SourceId = null;
            foreach (DataRow item in dtTablas.Rows)
            {
                if (item["TABLA"].ToString().Equals(LueOrigenD.Text))
                {
                    SourceId = item["Id"].ToString();
                }
            }

            if (string.IsNullOrEmpty(SourceId))
            {
                throw new Exception("Ha ocurrido un error");
            }

            LueCampoPrincipal.Text = "";
            Funciones f = new Funciones();
            dsCampoPrincipal = f.GetCampos(ConexionDB.getInstancia().Conexion(Dbase, null), SourceId);
            dtCampoPrincipal = dsCampoPrincipal.Tables[0];

            try
            {
                LueCampoPrincipal.Properties.Columns.Clear();
                LueCampoPrincipal.Properties.DataSource = dtCampoPrincipal;
                LueCampoPrincipal.Properties.DisplayMember = "NAME";
                LueCampoPrincipal.Properties.ValueMember = "NAME";

                var col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 10, "Campos");
                LueCampoPrincipal.Properties.Columns.Add(col);
                if (!string.IsNullOrEmpty(campo))
                {
                    LueCampoPrincipal.EditValue = campo;
                }
                else
                {
                    LueCampoPrincipal.ItemIndex = 1;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>LlenarCampoCodigo(String campo)
        /// Permite inicializar el LookUpEdit (LueCampoNombre), con los campos que pertenecen a la tabla seleccionada.
        /// Si el parametro (campo), es diferente de ""; se inicializa el LookUpEdit (LueCampoNombre), y se selecciona el nombre del campo que viene en el parametro (campo)
        /// </summary>
        /// <param name="campo">En este parametro se recibe el nombre del campo que se desea seleccionar en el LookUpEdit (LueCampoNombre) </param>
        public void LlenarCampoNombre(String campo)
        {

            string SourceId = null;
            foreach (DataRow item in dtTablas.Rows)
            {
                if (item["TABLA"].ToString().Equals(LueOrigenD.Text))
                {
                    SourceId = item["Id"].ToString();
                }
            }

            if (string.IsNullOrEmpty(SourceId))
            {
                throw new Exception("Ha ocurrido un error");
            }

            LueCampoNombre.Text = "";
            Funciones f1 = new Funciones();
            dsCampoNombre = f1.GetCampos(ConexionDB.getInstancia().Conexion(Dbase, null), SourceId);
            dtCampoNombre = dsCampoNombre.Tables[0];

            try
            {
                LueCampoNombre.Properties.Columns.Clear();
                LueCampoNombre.Properties.DataSource = dtCampoNombre;
                LueCampoNombre.Properties.DisplayMember = "NAME";
                LueCampoNombre.Properties.ValueMember = "NAME";
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col;
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 10, "Campos");
                LueCampoNombre.Properties.Columns.Add(col);
                if (!String.IsNullOrEmpty(campo))
                {
                    LueCampoNombre.EditValue = campo;
                }
                else
                {
                    LueCampoPrincipal.ItemIndex = 1;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>LlenarCampoNombre(String campo)
        /// Permite inicializar el LookUpEdit (LueCampoCodigo), con los campos que pertenecen a la tabla seleccionada.
        /// Si el parametro (campo), es diferente de ""; se inicializa el LookUpEdit (LueCampoCodigo), y se selecciona el nombre del campo que viene en el parametro (campo)
        /// </summary>
        /// <param name="campo">En este parametro se recibe el nombre del campo que se desea seleccionar en el LookUpEdit (LueCampoCodigo) </param>
        public void LlenarCampoCodigo(String campo)
        {

            string SourceId = null;
            foreach (DataRow item in dtTablas.Rows)
            {
                if (item["TABLA"].ToString().Equals(LueOrigenD.Text))
                {
                    SourceId = item["Id"].ToString();
                }
            }

            if (string.IsNullOrEmpty(SourceId))
            {
                throw new Exception("Ha ocurrido un error");
            }


            LueCampoCodigo.Text = "";
            Funciones f1 = new Funciones();
            dsCampoCodigo = f1.GetCampos(ConexionDB.getInstancia().Conexion(Dbase, null), SourceId);
            dtCampoCodigo = dsCampoCodigo.Tables[0];

            try
            {
                LueCampoCodigo.Properties.Columns.Clear();
                LueCampoCodigo.Properties.DataSource = dtCampoCodigo;
                LueCampoCodigo.Properties.DisplayMember = "NAME";
                LueCampoCodigo.Properties.ValueMember = "NAME";
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col;
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 10, "Campos");
                LueCampoCodigo.Properties.Columns.Add(col);
                if (!String.IsNullOrEmpty(campo))
                {
                    LueCampoCodigo.EditValue = campo;
                }
                else
                {
                    LueCampoCodigo.ItemIndex = -1;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>LlenarCampoFecha(String campo)
        /// Permite inicializar el LookUpEdit (LueCampoFecha), con los campos de tipo fecha que pertenecen a la tabla seleccionada.
        /// Si el parametro (campo), es diferente de ""; se inicializa el LookUpEdit (LueCampoFecha), y se selecciona el nombre del campo que viene en el parametro (campo)
        /// </summary>
        /// <param name="campo">En este parametro se recibe el nombre del campo que se desea seleccionar en el LookUpEdit (LueCampoFecha)</param>
        public void LlenarCampoFecha(String campo)
        {
            string SourceId = null;
            foreach (DataRow item in dtTablas.Rows)
            {
                if (item["TABLA"].ToString().Equals(LueOrigenD.Text))
                {
                    SourceId = item["Id"].ToString();
                }
            }

            if (string.IsNullOrEmpty(SourceId))
            {
                throw new Exception("Ha ocurrido un error");
            }


            LueCampoFecha.Text = "";
            Funciones f = new Funciones();
            dsCamposFecha = f.GetCamposFecha(ConexionDB.getInstancia().Conexion(Dbase, null), SourceId);
            dtCamposFecha = dsCamposFecha.Tables[0];

            try
            {
                LueCampoFecha.Properties.Columns.Clear();
                LueCampoFecha.Properties.DataSource = dtCamposFecha;
                LueCampoFecha.Properties.DisplayMember = "NAME";
                LueCampoFecha.Properties.ValueMember = "NAME";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col;
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 10, "Campos Fecha");
                LueCampoFecha.Properties.Columns.Add(col);
                if (!String.IsNullOrEmpty(campo))
                {
                    LueCampoFecha.EditValue = campo;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary> Agregado(GridView view, int row)
        /// Permite verificar si el valor de la celda compuesta por row seleccionado  y por la columna "Agregar", es "true" o "false".
        /// </summary>
        /// <param name="view">En este parametro se recibe el objeto de la grilla, en la cual se va a verficar el valor de la celda </param>
        /// <param name="row">En este parametro se recibe  el indice del row seleccionado</param>
        /// <returns></returns>
        private bool Agregado(GridView view, int row)
        {
            GridColumn col = view.Columns["Agregar"];
            bool val = Convert.ToBoolean(view.GetRowCellValue(row, col));
            return val;
        }

        /// <summary>LlenarDtCamposVisibles()
        /// Permite llenar el DataTable (dtCamposVisibles), el cual es agregado al DataSet dsCamposVisibles
        /// </summary>
        public void LlenarDtCamposVisibles()
        {
            DataColumn ColCampoId = new DataColumn("CampoId");
            ColCampoId.DataType = System.Type.GetType("System.String");
            ColCampoId.Caption = "CampoId";

            DataColumn ColCabecera = new DataColumn("Cabecera");
            ColCabecera.DataType = System.Type.GetType("System.String");
            ColCabecera.Caption = "Cabecera";

            DataColumn ColTamaño = new DataColumn("Tamaño");
            ColTamaño.DataType = System.Type.GetType("System.String");
            ColTamaño.Caption = "Tamaño";
            ColTamaño.DefaultValue = "100";

            DataColumn ColIndice = new DataColumn("Indice");
            ColTamaño.DataType = System.Type.GetType("System.String");
            ColTamaño.Caption = "Índice";

            dtGrillaCamposVisibles.Columns.Add(ColCampoId);
            dtGrillaCamposVisibles.Columns.Add(ColCabecera);
            dtGrillaCamposVisibles.Columns.Add(ColTamaño);
            dtGrillaCamposVisibles.Columns.Add(ColIndice);

            if (vCampoId!=null)
            {
                if (vCampoId[0]!="")
                {

                for (int i = 0; i < vCampoId.Length; i++)
                {
                    dtGrillaCamposVisibles.Rows.Add(new String[] { vCampoId[i], vCabeceras[i], vTamaños[i], vIndexes[i]});
                } 
                   
                }
            }
        }

        /// <summary>LlenarDsCamposVisibles()
        /// Permite llenar el DataSet (dsCamposVisibles), el cual es agregado a la grilla DgvCamposVisibles
        /// </summary>
        public void LlenarDsCamposVisibles()
        {
            if (vCampos != null || dtGrillaCamposVisibles.Rows.Count != 0)
            {
                if (dsGrillaCamposVisibles.Tables.Count == 0)
                {
                    dsGrillaCamposVisibles.Tables.Add(dtGrillaCamposVisibles);
                }

                if (dtGrillaCamposVisibles.Columns.Count == 0)
                {
                    LlenarDtCamposVisibles();
                }
                LlenarGridCamposVisibles(dsGrillaCamposVisibles);
            }
            else
            {
                LlenarGridCamposVisibles(null);
            }
        }

        #endregion

        #region Eventos

        private void LueOrigenD_TextChanged(object sender, EventArgs e)
        {
            if (LueOrigenD.Text != "[Vacío]")
            {
                LlenarCampoPrincipal(campoPcpal);
                LlenarCampoCodigo(campoCodigo);
                LlenarCampoNombre(campoNombre);
                LlenarCampoFecha(campoFecha);
                dtGrillaCampos = dtCampoPrincipal.Copy();

                DataColumn ColAgregar = new DataColumn("Agregar");
                ColAgregar.DataType = System.Type.GetType("System.Boolean");
                ColAgregar.Caption = "Agregar";
                ColAgregar.DefaultValue = false;
                
                DataColumn ColVisible = new DataColumn("Visible");
                ColVisible.DataType = System.Type.GetType("System.Boolean");
                ColVisible.Caption = "Visible";
                ColVisible.DefaultValue = false;

                dtGrillaCampos.Columns.Add(ColAgregar);
                dtGrillaCampos.Columns.Add(ColVisible);
                dsGrillaCampos.Tables.Clear();

                if (vCampos!=null && vVisibles!=null)
                {
                    foreach (var item in vCampos)
                    {
                        for (int i = 0; i < dtGrillaCampos.Rows.Count; i++)
                        {
                            if (item==dtGrillaCampos.Rows[i][0].ToString())
                            {
                                dtGrillaCampos.Rows[i][1] = true;
                            }
                        }
                    }

                    foreach (var item in vVisibles)
                    {
                        for (int i = 0; i < dtGrillaCampos.Rows.Count; i++)
                        {
                            if (item == dtGrillaCampos.Rows[i][0].ToString())
                            {
                                dtGrillaCampos.Rows[i][2] = true;                                
                            }
                        }
                    }
                }

                dsGrillaCampos.Tables.Add(dtGrillaCampos);
                LlenarGridCampos(dsGrillaCampos);
                dsGrillaCamposVisibles.Clear();
                //
                vCampos = null;
                vVisibles = null;
                //
            }
        }

        private void FrmAñadirEditarPerfiles_Load(object sender, EventArgs e)
        {
            DataSet dsEditar = new DataSet();        
            if (!String.IsNullOrEmpty(Perfil))
            {
                Perfil perfilEditar = Perfilador.getInstancia().CargarPerfil(Perfil);

                if (perfilEditar != null)
                {
                    TxtNomPerfil.Text = perfilEditar.Id;
                    TxtNomPerfil.Enabled = false;
                    TxtTitulo.Text = perfilEditar.Titulo;
                    TxtFrmGet.Text = perfilEditar.Formulario;
                    string[] ruta = perfilEditar.Proyecto.Split('\\');
                    TxtProyecto.Text = "\\" + ruta[ruta.Length - 1];
                    tabla = perfilEditar.Tabla;
                    campoPcpal = perfilEditar.Llave;
                    campoCodigo = perfilEditar.CampoCodigo;
                    campoNombre = perfilEditar.CampoNombre;

                    campoFecha = perfilEditar.CampoFecha;
                    ChkUtilizarR.Checked =Convert.ToBoolean(perfilEditar.UtilizarReportes);
                    TxtLblDatosD.Codigo = perfilEditar.DatosDetalle;
                    TxtDescripcion.Text = perfilEditar.Descripcion;

                    TxtSubtitulo.Text = perfilEditar.Subtitulo;
                    TxtColumnaE.Text = perfilEditar.ColumnaEstatica.ToString();
                    TxtReporte.Text = perfilEditar.Reporte;
                       
                    vCampos = perfilEditar.Campos;
                    vVisibles = perfilEditar.Visibles;

                    vCampoId = perfilEditar.CamposId;
                    vCabeceras = perfilEditar.Cabeceras;
                    vTamaños = perfilEditar.Tamaños;
                    vIndexes = perfilEditar.Indices;
                }
                else
                {
                    XtraMessageBox.Show("El perfil "+Perfil+" no existe", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Cancel;
                }

              LlenarTablas(tabla);
              LlenarDtCamposVisibles();
              LlenarDsCamposVisibles();
            }
            else
            {
                tabla = "";
                campoPcpal = null;
                campoFecha = null;
                LlenarGridCampos(null);
                LlenarTablas(null);
                LlenarDtCamposVisibles();
            }         
        }

        private void GvCampos_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DgvCampos.PostEditor();
            bool estado = (bool)(DgvCampos.GetRowCellValue(DgvCampos.FocusedRowHandle, DgvCampos.Columns["Visible"]));
            
            if (DgvCampos.FocusedColumn.FieldName == "Visible")
            {
                if (vCampoId!=null)
                {
                     if (estado == false)
                    {
                         String cmpo=DgvCampos.GetRowCellValue(DgvCampos.FocusedRowHandle, DgvCampos.Columns["Campo"]).ToString();
                         String indx=Convert.ToString(dtGrillaCamposVisibles.Rows.Count);
                         dtGrillaCamposVisibles.Rows.Add(new String[] { cmpo, cmpo, "100",indx});
                    }
                    else
                    {
                        String cmpo=DgvCampos.GetRowCellValue(DgvCampos.FocusedRowHandle, DgvCampos.Columns["Campo"]).ToString();
                         for (int i = 0; i < DgvCamposVisibles.RowCount; i++)
			             {
                             if (DgvCamposVisibles.GetRowCellDisplayText(i,"CampoId")==cmpo)
                             {
                                 dtGrillaCamposVisibles.Rows.RemoveAt(i);
                                 for (int j = 0; j < DgvCamposVisibles.RowCount; j++)
			                        {
                                        if (Convert.ToInt32(dtGrillaCamposVisibles.Rows[j][3]) > dtGrillaCamposVisibles.Rows.Count-1)
	                                    {
                                            dtGrillaCamposVisibles.Rows[j][3] =Convert.ToString(dtGrillaCamposVisibles.Rows.Count - 1);
	                                    }
			                        }
                                 break;
                             }
			             }                        
                    }
                }
                else
                {
                    if (estado == false)
                    {
                        String cmpo = DgvCampos.GetRowCellValue(DgvCampos.FocusedRowHandle, DgvCampos.Columns["Campo"]).ToString();
                        String indx = Convert.ToString(dtGrillaCamposVisibles.Rows.Count);
                        dtGrillaCamposVisibles.Rows.Add(new String[] { cmpo, cmpo, "100", indx });
                    }
                    else
                    {
                        String cmpo = DgvCampos.GetRowCellValue(DgvCampos.FocusedRowHandle, DgvCampos.Columns["Campo"]).ToString();
                        for (int i = 0; i < DgvCamposVisibles.RowCount; i++)
                        {
                            if (DgvCamposVisibles.GetRowCellDisplayText(i, "CampoId") == cmpo)
                            {
                                dtGrillaCamposVisibles.Rows.RemoveAt(i);
                                for (int j = 0; j < DgvCamposVisibles.RowCount; j++)
                                {
                                    if (Convert.ToInt32(dtGrillaCamposVisibles.Rows[j][3]) > dtGrillaCamposVisibles.Rows.Count - 1)
                                    {
                                        dtGrillaCamposVisibles.Rows[j][3] = Convert.ToString(dtGrillaCamposVisibles.Rows.Count - 1);
                                    }

                                }
                                break;
                            }
                        }   
                    }
                }  
            }

            if (DgvCampos.FocusedColumn.FieldName == "Agregar" && (bool)DgvCampos.GetDataRow(DgvCampos.FocusedRowHandle)[DgvCampos.FocusedColumn.FieldName])
            {
                DgvCampos.SetRowCellValue(DgvCampos.FocusedRowHandle, DgvCampos.Columns["Visible"], false);
                if (vCampoId != null || dtGrillaCamposVisibles.Rows.Count != 0)
                {
                    String cmpo = DgvCampos.GetRowCellValue(DgvCampos.FocusedRowHandle, DgvCampos.Columns["Campo"]).ToString();
                    for (int i = 0; i < DgvCamposVisibles.RowCount; i++)
                    {
                        if (DgvCamposVisibles.GetRowCellDisplayText(i, "CampoId") == cmpo)
                        {
                            dtGrillaCamposVisibles.Rows.RemoveAt(i);
                            for (int j = 0; j < DgvCamposVisibles.RowCount; j++)
                            {
                                if (Convert.ToInt32(dtGrillaCamposVisibles.Rows[j][3]) > dtGrillaCamposVisibles.Rows.Count - 1)
                                {
                                    dtGrillaCamposVisibles.Rows[j][3] = Convert.ToString(dtGrillaCamposVisibles.Rows.Count - 1);
                                }
                            }
                            break;
                        }
                    }    
                }
            }
        }

        private void GvCampos_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Visible" && !Agregado(view, view.FocusedRowHandle))
            {
                view.SetFocusedValue(false);
                e.Cancel = true;
            }
        }

        private void XtcGeneral_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page == xtraTabPage2)
            {
                LlenarDsCamposVisibles();
            }
        }

        private void DgvCamposVisibles_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DgvCamposVisibles.PostEditor();

            if (DgvCamposVisibles.FocusedColumn.FieldName == "Tamaño")
            {
                String v=DgvCamposVisibles.GetRowCellValue(DgvCamposVisibles.FocusedRowHandle, DgvCamposVisibles.Columns[2]).ToString();
                if (String.IsNullOrEmpty(v))
                {
                    v="0";
                }
                int t = Convert.ToInt32(v);
                
                if (t<=0)
                {
                   // XtraMessageBox.Show("El tamaño debe ser mayor que 0", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtGrillaCamposVisibles.Rows[DgvCamposVisibles.FocusedRowHandle][2].ToString();
                    DgvCamposVisibles.SetRowCellValue(DgvCamposVisibles.FocusedRowHandle, DgvCamposVisibles.Columns[2], "100");  
                }
            }
        }

        private void BtnProyecto_Click(object sender, EventArgs e)
        {
            OpenFileDialog proyecto = new OpenFileDialog();
            
            proyecto.Filter = "Archivos DLL(*.dll)|*.dll";
            proyecto.InitialDirectory = Application.StartupPath;

            if (proyecto.ShowDialog() == DialogResult.OK)
            {
                string dir = @"\" + proyecto.SafeFileName;
                TxtProyecto.Text = dir;
            }
        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil();

            try
            {
                int tamañoCampos = 0;
                int tamañoVisibles = 0;
                for (int i = 0; i < dtGrillaCampos.Rows.Count; i++)
                {
                    if ((bool)dtGrillaCampos.Rows[i]["Agregar"])
                        tamañoCampos++;
                    if ((bool)dtGrillaCampos.Rows[i]["Visible"])
                        tamañoVisibles++;
                }

                perfil.Campos = new string[tamañoCampos];
                for (int i = 0, j = 0; i < dtGrillaCampos.Rows.Count; i++)
                {
                    if ((bool)dtGrillaCampos.Rows[i]["Agregar"])
                    {
                        perfil.Campos[j] = dtGrillaCampos.Rows[i][0].ToString();
                        j++;
                    }
                }

                perfil.Visibles = new string[tamañoVisibles];
                for (int i = 0, j = 0; i < dtGrillaCampos.Rows.Count; i++)
                {
                    if ((bool)dtGrillaCampos.Rows[i]["Visible"])
                    {
                        perfil.Visibles[j] = dtGrillaCampos.Rows[i][0].ToString();
                        j++;
                    }
                }

                perfil.CamposId = new string[dtGrillaCamposVisibles.Rows.Count];
                for (int i = 0; i < dtGrillaCamposVisibles.Rows.Count; i++)
                {
                    perfil.CamposId[i] = dtGrillaCamposVisibles.Rows[i][0].ToString();

                }

                perfil.Cabeceras = new string[dtGrillaCamposVisibles.Rows.Count];
                for (int i = 0; i < dtGrillaCamposVisibles.Rows.Count; i++)
                {
                    perfil.Cabeceras[i] = dtGrillaCamposVisibles.Rows[i]["Cabecera"].ToString();
                }

                perfil.Tamaños = new string[dtGrillaCamposVisibles.Rows.Count];
                for (int i = 0; i < dtGrillaCamposVisibles.Rows.Count; i++)
                {
                    perfil.Tamaños[i] = dtGrillaCamposVisibles.Rows[i]["Tamaño"].ToString();
                }

                perfil.Indices = new string[dtGrillaCamposVisibles.Rows.Count];
                for (int i = 0; i < dtGrillaCamposVisibles.Rows.Count; i++)
                {
                    perfil.Indices[i] = dtGrillaCamposVisibles.Rows[i]["Indice"].ToString();
                }

                perfil.Tabla = LueOrigenD.Text;
                perfil.Formulario = TxtFrmGet.Text;
                perfil.Proyecto = TxtProyecto.Text;
                perfil.Titulo = TxtTitulo.Text;
                perfil.Llave = LueCampoPrincipal.Text;
                perfil.CampoNombre = LueCampoNombre.Text;
                perfil.CampoCodigo = LueCampoCodigo.Text;

                if (LueCampoFecha.Text == "[Vacío]")
                    perfil.CampoFecha = "";
                else
                    perfil.CampoFecha = LueCampoFecha.Text;

                perfil.UtilizarReportes = ChkUtilizarR.Checked.ToString();
                if (String.IsNullOrEmpty(TxtLblDatosD.Codigo))
                {
                    perfil.DatosDetalle = "";
                }
                else
                {
                    perfil.DatosDetalle = TxtLblDatosD.Codigo;
                }

                perfil.Descripcion = TxtDescripcion.Text;
                perfil.Subtitulo = TxtSubtitulo.Text;
                perfil.ColumnaEstatica = TxtColumnaE.Text;
                perfil.Id = TxtNomPerfil.Text;
                perfil.Reporte = TxtReporte.Text;
            }catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            FrmShowIt Formulario = new FrmShowIt();
            Formulario.PerfilShow = perfil;
            Formulario.database = Dbase;
            Formulario.Filtro = "";
            Formulario.DesHabilitarTodo();
            Formulario.ShowDialog();


        }
    }
}
