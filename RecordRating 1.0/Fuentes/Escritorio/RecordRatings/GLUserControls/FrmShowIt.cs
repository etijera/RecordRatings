 /***
 * Formulario   : FrmShowIt
 * Proposito    : Visualiza una ventana la cual permite realizar las siguientes funciones:
 *                Listar, Realizar busquedas, Adicionar, Editar, Eliminar, Imprimir, Exportar a Excel
 *                y Documentar
 * Fecha        : Febrero, 2012
 * Fecha Act.   :
 * Autor        : 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLReferences;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraBars;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Alerter;
using GLReferences.Properties;
using DevExpress.XtraReports.UI;

namespace GLUserControls
{
    public partial class FrmShowIt : BasicForm
    {
        #region Propiedades
        /// <summary>
        /// Obtiene o establece el perfil con el cual se configura el ShowIt
        /// </summary>
        public Perfil PerfilShow { get; set; }
        /// <summary>
        /// Obtiene o establece el nombre de la Base de datos a la cual debe conectarse
        /// </summary>
        public String database { get; set; }
        /// <summary>
        /// Obtiene o establece el Id de la fila seleccionada en la cuadricula que visualiza SowIt
        /// </summary>
        public String Seleccion { get; set; }
        /// <summary>
        /// Obtiene o establece la condición de filtro al hacer busquedas
        /// </summary>
        public String Filtro { get; set; }
        /// <summary>
        /// Obtiene o establece un valor booleano para indicar si ShowIt se llama desde un menú o desde un TxtLbl
        /// </summary>
        public bool DesdeMenu { get; set; }
        /// <summary>
        /// Obtiene o establece indicador para colocar o no, ceros a la izquierda
        /// </summary>
        public bool PonerCeros { get; set; }
        public String Relacion { get; set; }
        public String Complemento { get; set; }

        public String DescripcionSeleccion { get; set; }
        public String IdentificacionSeleccion { get; set; }
        public OrdenarPor Ordenar { get; set; }
        public String ComplementoFiltro { get; set; }

        public String OpcionGet { get; set; }

        public bool OpGet { get; set; }

        public String Usuario { get; set; }

        public bool PasarUsuario { get; set; }

        #endregion

        #region  Variables 
        /// <summary>
        /// DataSet para alojar el resultado de la consulta que permite listar datos en ShowIt
        /// </summary>
        private DataSet dsGeneral = new DataSet();
        private String campoOrden;
        private bool permisoAdicionar = false;
        private bool permisoEliminar = false;
        private bool permisoEditar = false;
        private bool permisoImprimir = false;

        #endregion

        #region Metodos

        /// <summary>FrmShowIt()
        /// Constructor de la clase
        /// </summary>
        public FrmShowIt()
        {
            InitializeComponent();
            DesdeMenu = false;
        }

        /// <summary>
        /// Oculta el botón Adicionar
        /// </summary>
        public void OcultarBtnAñadir()
        {
            toolBarShowit1.VerAñadir = BarItemVisibility.Never;
        }

        /// <summary>
        /// Oculta el botón Editar
        /// </summary>
        public void OcultarBtnEditar()
        {
            toolBarShowit1.VerEditar = BarItemVisibility.Never;
        }

        /// <summary>
        /// oculta el botón Eliminar
        /// </summary>
        public void OcultarBtnEliminar()
        {
            toolBarShowit1.VerEliminar = BarItemVisibility.Never;
        }

        /// <summary>
        /// Oculta el botón Imprimir
        /// </summary>
        public void OcultarBtnImprimir()
        {
            toolBarShowit1.VerImprimir = BarItemVisibility.Never;
        }

        /// <summary>
        /// Oculta el botón Guardar
        /// </summary>
        public void OcultarBtnGuardar()
        {
            toolBarShowit1.VerGuardar = BarItemVisibility.Never;
        }

        /// <summary>
        /// Oculta el botón Excel
        /// </summary>
        public void OcultarBtnExcel()
        {
            toolBarShowit1.VerExcel = BarItemVisibility.Never;
        }

        /// <summary>
        /// Oculta todos los botones
        /// </summary>
        public void OcultarTodo()
        {
            OcultarBtnAñadir();
            OcultarBtnEditar();
            OcultarBtnEliminar();
            OcultarBtnImprimir();
            OcultarBtnGuardar();
            OcultarBtnExcel();
        }

        /// <summary>
        /// Deshabilita todos los botones
        /// </summary>
        public void DesHabilitarTodo()
        {
            DesHabilitarBtnAñadir();
            DesHabilitarBtnEditar();
            DesHabilitarBtnEliminar();
            DesHabilitarBtnImprimir();
            DesHabilitarBtnGuardar();
            DesHabilitarBtnExcel();
        }

        /// <summary>
        /// Deshabilita el botón Adicionar
        /// </summary>
        public void DesHabilitarBtnAñadir()
        {
            toolBarShowit1.HabilitarAñadir = false;
        }

        /// <summary>
        /// Deshabilita el botón Editar
        /// </summary>
        public void DesHabilitarBtnEditar()
        {
            toolBarShowit1.HabilitarEditar = false;
        }

        /// <summary>
        /// Deshabilita el botón Eliminar
        /// </summary>
        public void DesHabilitarBtnEliminar()
        {
            toolBarShowit1.HabilitarEliminar = false;
        }

        /// <summary>
        /// Deshabilita el botón Imprimir
        /// </summary>
        public void DesHabilitarBtnImprimir()
        {
            toolBarShowit1.HabilitarImprimir = false;
        }

        /// <summary>
        /// Deshabilita el botón Guardar
        /// </summary>
        public void DesHabilitarBtnGuardar()
        {
            toolBarShowit1.HabilitarGuardar = false;
        }

        /// <summary>
        /// Deshabilita el botón Excel
        /// </summary>
        public void DesHabilitarBtnExcel()
        {
            toolBarShowit1.HabilitarExcel = false;
        }
        //
        public void ConsultarPermisos()
        {
            SqlParameter[] parametro = new [] { new SqlParameter("@Usuario", Usuario ?? "") };

            DataTable dtPermisos = DataBase.ExecuteQueryDataTable("PA_Permisos", "datos", CommandType.StoredProcedure, parametro, ConexionDB.getInstancia().Conexion(database, null));

            if (dtPermisos.Rows.Count > 0)
            {
                permisoAdicionar = (bool)(dtPermisos.Rows[0]["Adicionar"]);
                permisoEditar = (bool)(dtPermisos.Rows[0]["Editar"]);
                permisoEliminar = (bool)(dtPermisos.Rows[0]["Eliminar"]);
                permisoImprimir = (bool)(dtPermisos.Rows[0]["Imprimir"]);
            }

            //toolBarShowit1.HabilitarAñadir = permisoAdicionar;
            //toolBarShowit1.HabilitarEditar = permisoEditar;
            //toolBarShowit1.HabilitarEliminar = permisoEliminar;
            //toolBarShowit1.HabilitarImprimir = permisoImprimir;

        }

        /// <summary>
        /// Método para llamar al formulario de Adición
        /// </summary>
        public void Añadir()
        {
            if (permisoAdicionar)
            {
                object o = null;
                try
                {
                    Assembly myDllAssembly = Assembly.LoadFile(@"" + PerfilShow.Proyecto);
                    Type t = myDllAssembly.GetType(PerfilShow.Formulario);

                    if (t != null)
                        o = Activator.CreateInstance(t);
                    else
                        o = Assembly.GetEntryAssembly().CreateInstance(PerfilShow.Formulario);

                    PropertyInfo desdeShow = o.GetType().GetProperty("DesdeMenu");
                    desdeShow.SetValue(o, DesdeMenu, null);

                    PropertyInfo modo = o.GetType().GetProperty("Modo");
                    modo.SetValue(o, "N", null);

                    if (OpGet)
                    {
                        PropertyInfo Get = o.GetType().GetProperty("OpcionGet");
                        Get.SetValue(o, OpcionGet, null);
                    }

                    PropertyInfo perfil = o.GetType().GetProperty("PerfilAct");
                    perfil.SetValue(o, PerfilShow, null);

                    PropertyInfo db = o.GetType().GetProperty("Database");
                    db.SetValue(o, database, null);

                    if (PasarUsuario)
                    {
                        PropertyInfo Get = o.GetType().GetProperty("Usuario");
                        Get.SetValue(o, Usuario, null);
                    }

                    if (PerfilShow.Formulario.Equals("GLUserControls.FrmGetCodeName"))
                    {
                        PropertyInfo ponerCeros = o.GetType().GetProperty("PonerCeros");
                        ponerCeros.SetValue(o, PonerCeros, null);
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                string camp = "";
                camp = PerfilShow.Llave + "," + camp.Vector2Cadena(",", PerfilShow.Campos).Replace(PerfilShow.Llave + ",", "");
                String cad = String.Format("SELECT DISTINCT TOP(1) {0} FROM {1} {2} WHERE delmrk = 1 {3} ORDER BY {4} DESC", camp, PerfilShow.Tabla, Relacion, Complemento, PerfilShow.Llave);
                DataTable dt = DataBase.ExecuteQueryDataTable(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(database, null));
                DataSet dsUlt = new DataSet();
                dsUlt.Tables.Add(dt);

                XtraForm frm = (XtraForm)o;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK && DesdeMenu)
                {                           
                    Seleccion = frm.GetType().GetProperty("ID").GetValue(frm, null).ToString();
                    int resto = 0;

                    if (dsUlt.Tables[0].Rows.Count != 0)
                        resto = Convert.ToInt32(Seleccion) - Convert.ToInt32(dsUlt.Tables[0].Rows[0][PerfilShow.Llave]);
                    else
                        resto = Convert.ToInt32(Seleccion) - 0;

                    cad = String.Format("SELECT TOP({0}) {1} FROM {2} {3} WHERE delmrk = 1 {4} ORDER BY {5} DESC", resto, camp, PerfilShow.Tabla, Relacion, Complemento, PerfilShow.Llave);
                    DataTable dt1 = DataBase.ExecuteQueryDataTable(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(database, null));
                    dsGeneral.Tables.Clear();
                    dsGeneral.Tables.Add(dt1);

                    LlenarGrilla();
                }

                if (frm.DialogResult == DialogResult.OK && !DesdeMenu)
                {
                    Seleccion = frm.GetType().GetProperty("ID").GetValue(frm, null).ToString();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
            {
                XtraMessageBox.Show("El usuario " + Usuario + " no tiene permiso para realizar esta operación.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Método para llamar al formulario de Edición
        /// </summary>
        public void Editar()
        {
            if (permisoEditar)
            {
                System.Reflection.Assembly myDllAssembly = System.Reflection.Assembly.LoadFile(@"" + PerfilShow.Proyecto);
                Type t = myDllAssembly.GetType(PerfilShow.Formulario);

                object o = Activator.CreateInstance(t);

                if (GvGeneral.GetFocusedDataSourceRowIndex() > -1)
                {
                    try
                    {
                        int hver = GvGeneral.GetFocusedDataSourceRowIndex();
                        Seleccion = dsGeneral.Tables[0].Rows[GvGeneral.GetFocusedDataSourceRowIndex()][PerfilShow.Llave].ToString();
                        //DescripcionSeleccion = dsGeneral.Tables[0].Rows[GvGeneral.GetFocusedDataSourceRowIndex()][PerfilShow.CampoNombre].ToString();
                        //IdentificacionSeleccion = dsGeneral.Tables[0].Rows[GvGeneral.GetFocusedDataSourceRowIndex()][PerfilShow.CampoCodigo].ToString();


                        PropertyInfo desdeShow = o.GetType().GetProperty("DesdeMenu");
                        desdeShow.SetValue(o, DesdeMenu, null);

                        PropertyInfo modo = o.GetType().GetProperty("Modo");
                        modo.SetValue(o, "E", null);

                        if (OpGet)
                        {
                            PropertyInfo Get = o.GetType().GetProperty("OpcionGet");
                            Get.SetValue(o, OpcionGet, null);
                        }

                        PropertyInfo perfil = o.GetType().GetProperty("PerfilAct");
                        perfil.SetValue(o, PerfilShow, null);

                        PropertyInfo codigo = o.GetType().GetProperty("ID");
                        codigo.SetValue(o, Seleccion, null);

                        PropertyInfo db = o.GetType().GetProperty("Database");
                        db.SetValue(o, database, null);

                        if (PasarUsuario)
                        {
                            PropertyInfo Get = o.GetType().GetProperty("Usuario");
                            Get.SetValue(o, Usuario, null);
                        }

                        if (PerfilShow.Formulario.Equals("GLUserControls.FrmGetCodeName"))
                        {
                            PropertyInfo ponerCeros = o.GetType().GetProperty("PonerCeros");
                            ponerCeros.SetValue(o, PonerCeros, null);
                        }

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    XtraForm frm = (XtraForm)o;
                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK && DesdeMenu)
                    {
                        LlenarDataSet();
                        LlenarGrilla();
                    }

                    if (frm.DialogResult == DialogResult.OK && !DesdeMenu)
                    {
                        Seleccion = frm.GetType().GetProperty("ID").GetValue(frm, null).ToString();
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
                else
                    XtraMessageBox.Show("Debe seleccionar un registro", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            else
            {
                XtraMessageBox.Show("El usuario " + Usuario + " no tiene permiso para realizar esta operación.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Método para eliminar el registro seleccionado
        /// </summary>
        public void Eliminar()
        {
            if (permisoEliminar)
            {
                try
                {

                    if (GvGeneral.GetFocusedDataSourceRowIndex() > -1)
                    {
                        if (XtraMessageBox.Show("¿Esta seguro que desea anular el registro ?", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Seleccion = dsGeneral.Tables[0].Rows[GvGeneral.GetFocusedDataSourceRowIndex()][PerfilShow.Llave].ToString();

                            String sql = String.Format("UPDATE {0} SET delmrk = 0 WHERE {1} = '{2}'", PerfilShow.Tabla, PerfilShow.Llave, Seleccion);

                            bool IsDone = DataBase.ExecuteNonQuery(sql, CommandType.Text, null, ConexionDB.getInstancia().Conexion(database, null));

                            if (IsDone)
                            {
                                //AlertInfo info = new AlertInfo(Resources.SystemMessage, "Registro Eliminado Satisfactoriamente", Resources.Check);
                                //alertControl1.Show(this, info);
                                LlenarDataSet();
                                LlenarGrilla();
                            }
                        }
                    }
                    else
                        XtraMessageBox.Show("Debe seleccionar un registro", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                }
                catch (Exception t)
                {
                    XtraMessageBox.Show(t.Message);
                }
            }
            else
            {
                XtraMessageBox.Show("El usuario " + Usuario + " no tiene permiso para realizar esta operación.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Método para imprimir
        /// </summary>
        public void Imprimir()
        {
            if (permisoImprimir)
            {
                if (PerfilShow.Formulario.Equals("GLUserControls.FrmGetCodeName") || PerfilShow.Formulario.Equals("GLUserControls.FrmGetName"))
                {
                    try
                    {
                        string camp = "";

                        if (PerfilShow.Llave != PerfilShow.CampoCodigo)
                        {
                            camp = "DISTINCT " + PerfilShow.Llave + "," + PerfilShow.CampoCodigo + "," + camp.Vector2Cadena(",", PerfilShow.Campos);
                        }
                        else
                        {
                            camp = "DISTINCT " + PerfilShow.Llave + "," + camp.Vector2Cadena(",", PerfilShow.Campos);
                        }

                        String cad = String.Format("SELECT {0} FROM {1} {2} WHERE delmrk = 1 {3} ", camp, PerfilShow.Tabla, Relacion, Complemento);
                        DataTable dt = DataBase.ExecuteQueryDataTable(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(database, null));
                        DataSet dsRpt = new DataSet();
                        dsRpt.Tables.Add(dt);

                        dsRpt.Tables[0].Columns[PerfilShow.CampoCodigo].ColumnName = "codigo";
                        dsRpt.Tables[0].Columns[PerfilShow.CampoNombre].ColumnName = "nombre";
                        int posicion = 0;
                        for (int i = 0; i < PerfilShow.CamposId.Length; i++)
                        {
                            if (PerfilShow.CamposId[i] == PerfilShow.CampoNombre)
                            {
                                posicion = i;
                            }
                        }
                        //Convert.ToInt32(PerfilShow.Visibles [dsRpt.Tables[0].Columns[PerfilShow.CampoNombre].Ordinal])
                        string cabecera = PerfilShow.Cabeceras[posicion];

                        RptPerfilGeneral report = new RptPerfilGeneral();
                        report.DataSource = dsRpt;
                        report.Dtbase = database;
                        report.Empresa(PerfilShow.Titulo, cabecera);

                        report.ShowPreview();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    System.Reflection.Assembly myDllAssembly = System.Reflection.Assembly.LoadFile(@"" + PerfilShow.Proyecto);
                    Type t = myDllAssembly.GetType(PerfilShow.Reporte);

                    object o = Activator.CreateInstance(t);

                    PropertyInfo db = o.GetType().GetProperty("Database");
                    db.SetValue(o, database, null);

                    o.GetType().GetMethod("Consulta").Invoke(o, null);
                    o.GetType().GetMethod("Empresa").Invoke(o, null);

                    XtraReport rpt = (XtraReport)o;
                    rpt.ShowPreview();

                }
            }
            else
            {
                XtraMessageBox.Show("El usuario " + Usuario + " no tiene permiso para realizar esta operación.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Guardar()
        {

        }

        public void Excel()
        {

        }

        /// <summary>
        /// Método para cargar los datos a listar en un DataSet
        /// </summary>
        public void LlenarDataSet()
        {
            string condicion = "";

            if (!String.IsNullOrEmpty(Filtro))
            {
                condicion = "(";
                for (int i = 0; i < PerfilShow.CamposId.Length; i++)
                {
                    condicion = condicion + PerfilShow.CamposId[i] + " LIKE '%" + Filtro.ToUpper() + "%'";
                    if (i != PerfilShow.CamposId.Length - 1)
                        condicion = condicion + " OR ";
                }

                if (!String.IsNullOrEmpty(ComplementoFiltro))
                {
                    condicion = condicion + " OR " + ComplementoFiltro;
                }
            }

            if (!String.IsNullOrEmpty(condicion))
                condicion = condicion + ") AND";

            string camp = "";
            camp = "DISTINCT " + PerfilShow.Llave + "," + camp.Vector2Cadena(",", PerfilShow.Campos);
            String cad = String.Format("SELECT {0} FROM {1} {2} WHERE {3} delmrk = 1 {4} ORDER BY {5} ", camp, PerfilShow.Tabla, Relacion, condicion, Complemento, campoOrden);
            DataTable dt  = DataBase.ExecuteQueryDataTable(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(database, null));
            dsGeneral.Tables.Clear();
            dsGeneral.Tables.Add(dt);
        }

        /// <summary>
        /// Método para llenar la cuadricula donde se visualizan los registros
        /// </summary>
        public void LlenarGrilla()
        {
            GvGeneral.Columns.Clear();
            GvGeneral.OptionsView.ColumnAutoWidth = false;
            DataViewManager dvm = new DataViewManager(dsGeneral);
            DataView dvMain = dvm.CreateDataView(dsGeneral.Tables[0]);

            GridColumn[] col = new GridColumn[PerfilShow.Visibles.Length];
            int index = 0;
            for (int i = 0; i < PerfilShow.Visibles.Length; i++)
            {

                index = Convert.ToInt32(PerfilShow.Indices[i]);
                col[index] = GvGeneral.Columns.AddField(dsGeneral.Tables[0].Columns[PerfilShow.CamposId[i]].Caption);
                col[index].VisibleIndex = index;
                //col[index].BestFit();
                col[index].Width = PerfilShow.Tamaños[i].ToInt();
                col[index].Caption = PerfilShow.Cabeceras[i];
                col[index].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            GctrlGeneral.DataSource = dvMain;
            if (GvGeneral.RowCount > 0)
            {
                GvGeneral.Focus();
                GvGeneral.SelectRow(0);
            }
        }

        public void TamañoVentana(int x, int y)
        {
            this.Size = new Size(x, y);
        }
        #endregion

        #region Eventos

        private void FrmShowIt_Load(object sender, EventArgs e)
        {
            this.Text = PerfilShow.Titulo;
            GvGeneral.Columns.Clear();

            GvGeneral.OptionsBehavior.AutoPopulateColumns = false;
            GvGeneral.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            GvGeneral.OptionsBehavior.AllowAddRows    = DevExpress.Utils.DefaultBoolean.False;
            GvGeneral.OptionsBehavior.Editable        = false;

            GvGeneral.OptionsFilter.AllowFilterEditor        = false;
            GvGeneral.OptionsFilter.AllowColumnMRUFilterList = false;
            GvGeneral.OptionsFilter.AllowMRUFilterList       = false;
            GvGeneral.OptionsFilter.MRUFilterListPopupCount  = 0;
            GvGeneral.OptionsFilter.MRUFilterListCount       = 0;
            GvGeneral.OptionsFilter.MRUColumnFilterListCount = 0;

            GvGeneral.OptionsCustomization.AllowGroup = false;
            GvGeneral.OptionsCustomization.AllowQuickHideColumns = false;
            GvGeneral.OptionsCustomization.AllowFilter = false;

            GvGeneral.OptionsView.EnableAppearanceOddRow = true;
            GvGeneral.OptionsView.ShowGroupPanel         = false;
            GvGeneral.OptionsHint.ShowColumnHeaderHints  = false;
            GvGeneral.OptionsView.ShowIndicator          = true;
            GvGeneral.OptionsView.ShowFilterPanelMode    = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;

            GvGeneral.OptionsMenu.EnableColumnMenu = false;

            GvGeneral.ScrollStyle          = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            GvGeneral.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;


            switch (Ordenar)
            {
                case OrdenarPor.CampoNombre :
                    campoOrden = PerfilShow.Tabla + "." + PerfilShow.CampoNombre;
                    break;

                case OrdenarPor.CampoCodigo:
                    campoOrden = PerfilShow.Tabla + "." + PerfilShow.CampoCodigo;
                    break;

                case OrdenarPor.CampoId:
                    campoOrden = PerfilShow.Tabla + "." + PerfilShow.Llave;
                    break;

                default:
                    campoOrden = PerfilShow.Tabla + "." + PerfilShow.CampoNombre;
                    break;
            }

            if (!String.IsNullOrEmpty(Filtro))
            {
                LlenarDataSet();
                LlenarGrilla();
                SendKeys.Send("{tab}");
                SendKeys.Send("{tab}");
            }

            if (GvGeneral.RowCount == 0)
            {
                TxtBuscar.Focus();
            }

            ConsultarPermisos();
        }

        private void GctrlGeneral_DoubleClick(object sender, EventArgs e)
        {
            SendKeys.Send("{Enter}");
        }

        private void GctrlGeneral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !DesdeMenu)
            {
                if (GvGeneral.GetFocusedDataSourceRowIndex() > -1)
                {
                    Seleccion = dsGeneral.Tables[0].Rows[GvGeneral.GetFocusedDataSourceRowIndex()][PerfilShow.Llave].ToString();
                    DescripcionSeleccion = dsGeneral.Tables[0].Rows[GvGeneral.GetFocusedDataSourceRowIndex()][PerfilShow.CampoNombre].ToString();
                    IdentificacionSeleccion = dsGeneral.Tables[0].Rows[GvGeneral.GetFocusedDataSourceRowIndex()][PerfilShow.CampoCodigo].ToString();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !BkgwBuscar.IsBusy)
            {
                PrgBuscar.Visible = true;
                Filtro = TxtBuscar.Text;
                BkgwBuscar.RunWorkerAsync();
            }

            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            PrgBuscar.Visible = true;
            Filtro = TxtBuscar.Text;
            BkgwBuscar.RunWorkerAsync();
        }

        private void BkgwBuscar_DoWork(object sender, DoWorkEventArgs e)
        {
            LlenarDataSet();
        }

        private void BkgwBuscar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PrgBuscar.Visible = false;
            LlenarGrilla();
        }

        private void FrmShowIt_FormClosing(object sender, FormClosingEventArgs e)
        {
            BkgwBuscar.CancelAsync();
        }

        private void FrmShowIt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                if (toolBarShowit1.HabilitarAñadir == true && toolBarShowit1.VerAñadir == BarItemVisibility.Always)
                {
                    Añadir();
                }
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R)
            {
                if (toolBarShowit1.HabilitarEliminar == true && toolBarShowit1.VerEliminar == BarItemVisibility.Always)
                {
                    Eliminar();
                }
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.P)
            {
                if (toolBarShowit1.HabilitarImprimir == true && toolBarShowit1.VerImprimir == BarItemVisibility.Always)
                {
                    Imprimir();
                }
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.E)
            {
                if (toolBarShowit1.HabilitarEditar == true && toolBarShowit1.VerEditar == BarItemVisibility.Always)
                {
                    Editar();
                }
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.G)
            {
                if (toolBarShowit1.HabilitarGuardar == true && toolBarShowit1.VerGuardar == BarItemVisibility.Always)
                {
                    Guardar();
                }
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.L)
            {
                if (toolBarShowit1.HabilitarExcel == true && toolBarShowit1.VerExcel == BarItemVisibility.Always)
                {
                    Excel();
                }
            }
        }

        #endregion

    }
}
