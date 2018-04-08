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
using RecordRatings.Controladores;
using DevExpress.XtraGrid.Columns;
using GLReferences;
using RecordRatings.Clases;
using GLReferences.Properties;
using RecordRatings.Reportes;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;

namespace RecordRatings.Vistas
{
    public partial class FrmAsignarMatCursos : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public int Año { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        DataTable dtConsulta = new DataTable();
        DataSet dsConsulta = new DataSet();
        DataTable dtConsulta2Cab;
        DataTable dtConsulta2Det;
        DataSet dsConsulta2;
        private string codCursoSel = "";
        private string nombreCursoSel = "";
        private bool ini = true;
        private string codMateria = "";

        #endregion
        
        #region Metodos
        public FrmAsignarMatCursos()
        {
            InitializeComponent();
        }

        public void LlenarDsConsulta()
        {
            try
            {
                MateriasCurso matCur = new MateriasCurso();
                matCur.AñoElectivo = Año;

                DataSet ds = CtrlMateriasCursos.GetCursosAñoElectivo(matCur);

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

        public void LlenarDsConsulta2(string codigoCur)
        {
            try
            {
                MateriasCurso matC = new MateriasCurso();
                matC.Curso.CodigoCurso = codigoCur;

                DataSet ds = CtrlMateriasCursos.GetMateriasCursos(matC);
                DataSet ds1 = CtrlMateriasCursos.GetMateriasCursosCab(matC);

                dtConsulta2Det = new DataTable();
                dtConsulta2Cab = new DataTable();
                dsConsulta2 = new DataSet();

                dtConsulta2Cab = ds1.Tables[0].Copy();
                dtConsulta2Cab.TableName = "Cabecera"; 
                dtConsulta2Det = ds.Tables[0].Copy();
                dtConsulta2Det.TableName = "Detalle"; 
             
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        public void LlenarGridConsulta()
        {
            DgvCursos.Columns.Clear();            
            DgvCursos.OptionsView.ColumnAutoWidth = false;
            DataViewManager dvm = new DataViewManager(dsConsulta);
            DataView dvMain = dvm.CreateDataView(dsConsulta.Tables[0]);
            DgvCursos.OptionsBehavior.AutoPopulateColumns = false;
            GctrlCursos.DataSource = dvMain;
            string[] captions = new[] {"id", "Código", "Nombre" };

            GridColumn[] col = new GridColumn[dsConsulta.Tables[0].Columns.Count];
            for (int i = 0; i < dsConsulta.Tables[0].Columns.Count; i++)
            {
                col[i] = DgvCursos.Columns.AddField(dsConsulta.Tables[0].Columns[i].Caption.Trim());
                col[i].VisibleIndex = i;
                col[i].Caption = captions[i];
                col[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (i == 0 || i == 1)
                {
                    col[i].Visible = false;
                }
            }
            
            //DgvCursos.Columns[1].Width = 80;
            DgvCursos.Columns[2].Width = 664;
           

            Funciones.getInstancia().Configurar_Grid(DgvCursos);
            DgvCursos.OptionsCustomization.AllowSort = true;
            //DgvCursos.OptionsFind.AlwaysVisible = true;
            DgvCursos.OptionsView.ColumnAutoWidth = false;
        }

        public void LlenarGridConsulta2()
        {
            dsConsulta2.Tables.Clear();

            if (dsConsulta2.Tables.Count == 0)
            {
                dsConsulta2.Tables.Add(dtConsulta2Cab);
                dsConsulta2.Tables.Add(dtConsulta2Det);

                if (dsConsulta2.Relations.Count == 0)
                {
                    DataColumn keyColumn = dsConsulta2.Tables["Cabecera"].Columns["CodArea"];
                    DataColumn foreignKeyColumn = dsConsulta2.Tables["Detalle"].Columns["CodArea"];

                    dsConsulta2.Relations.Add("Relacion", new DataColumn[] { keyColumn }, new DataColumn[] { foreignKeyColumn }, true);
                }
            }

            GctrlMaterias.DataSource = dsConsulta2.Tables["Cabecera"];
            GctrlMaterias.ForceInitialize();
            DgvMaterias.OptionsDetail.AllowExpandEmptyDetails = true;
            DgvMaterias.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            DgvMaterias.OptionsDetail.AllowZoomDetail = true;
            DgvMaterias.OptionsDetail.SmartDetailExpand = true;
            DgvMaterias.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails;

            GctrlMaterias.LevelTree.Nodes.Add("Relacion", DgvDetalle);
            DgvDetalle.SynchronizeClones = false;
            DgvDetalle.ViewCaption = "Materia(s)";


            #region Cabecera

            DgvMaterias.RefreshData();
            DgvMaterias.Columns.Clear();
            DgvMaterias.OptionsView.ColumnAutoWidth = false;
            DgvMaterias.OptionsBehavior.AutoPopulateColumns = false;

            string[] captionsCab = new[] { "CodCurso", "CodArea", "NombreArea", "TotalPorcentaje" };

            GridColumn[] colCab = new GridColumn[dsConsulta2.Tables["Cabecera"].Columns.Count];
            for (int i = 0; i < dsConsulta2.Tables["Cabecera"].Columns.Count; i++)
            {
                colCab[i] = DgvMaterias.Columns.AddField(dsConsulta2.Tables["Cabecera"].Columns[i].Caption.Trim());
                colCab[i].VisibleIndex = i;
                colCab[i].Caption = captionsCab[i];
                colCab[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (i == 0 || i == 1)
                {
                    colCab[i].Visible = false;
                }
            }

            DgvMaterias.Columns[2].Width = 528;
            DgvMaterias.Columns[3].Width = 100;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit numerico = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            numerico.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            numerico.Mask.EditMask = "P0";
            numerico.Mask.UseMaskAsDisplayFormat = true;
            colCab[3].ColumnEdit = numerico;


            Funciones.getInstancia().Configurar_Grid(DgvMaterias);
            //DgvMaterias.OptionsCustomization.AllowSort = true;
            DgvMaterias.OptionsView.ColumnAutoWidth = false;


            #endregion

            #region detalle

            DgvDetalle.RefreshData();
            DgvDetalle.PopulateColumns(dsConsulta2.Tables["Detalle"]);
            DgvDetalle.Columns.Clear();
            DgvDetalle.OptionsBehavior.AutoPopulateColumns = false;

            string[] captions = new[] { "CodCurso", "CodMateria", "Materia", "IHS", "Porc. (%)", "CodProfesor", "Profesor", "CodArea" };

            GridColumn[] col = new GridColumn[dsConsulta2.Tables["Detalle"].Columns.Count];
            for (int i = 0; i < dsConsulta2.Tables["Detalle"].Columns.Count; i++)
            {
                col[i] = DgvDetalle.Columns.AddField(dsConsulta2.Tables["Detalle"].Columns[i].Caption.Trim());
                col[i].VisibleIndex = i;
                col[i].Caption = captions[i];
                col[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (i == 0 || i == 1 || i == 5 || i == 7)
                {
                    col[i].Visible = false;
                }
            }

            DgvDetalle.Columns[2].Width = 240;
            DgvDetalle.Columns[3].Width = 50;
            DgvDetalle.Columns[4].Width = 60;
            DgvDetalle.Columns[6].Width = 245;

            col[4].ColumnEdit = numerico;

            Funciones.getInstancia().Configurar_Grid(DgvDetalle);
            DgvDetalle.OptionsCustomization.AllowSort = true;
            DgvDetalle.OptionsView.ColumnAutoWidth = false;            

            #endregion

        }

        public void Añadir()
        {
            if (DgvCursos.RowCount > 0 && DgvCursos.GetFocusedRow() != null)
            {
                FrmGetMateriasCursos mtC = new FrmGetMateriasCursos();
                mtC.Database = Database;
                mtC.Modo = "N";
                mtC.CodCurso = DgvCursos.GetFocusedRowCellValue(DgvCursos.Columns["CodigoCurso"]).ToString();
                mtC.CodMateria = "";
                mtC.ShowDialog();

                if (mtC.DialogResult == DialogResult.OK)
                {
                    if (!BkgwBuscarMat.IsBusy)
                    {
                        PrgBuscar2.Visible = true;
                        BkgwBuscarMat.RunWorkerAsync();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un curso.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Editar()
        {
            if (codMateria != "")
            {
                FrmGetMateriasCursos mtC = new FrmGetMateriasCursos();
                mtC.Database = Database;
                mtC.Modo = "E";
                mtC.CodCurso = codCursoSel;
                mtC.CodMateria = codMateria;
                mtC.ShowDialog();

                if (mtC.DialogResult == DialogResult.OK)
                {
                    if (!BkgwBuscarMat.IsBusy)
                    {
                        PrgBuscar2.Visible = true;
                        BkgwBuscarMat.RunWorkerAsync();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar una Materia.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Eliminar()
        {
            if (codMateria != "")
            {             

                MateriasCurso mtC = new MateriasCurso();
                mtC.Curso.CodigoCurso = codCursoSel;
                mtC.Materia.CodMateria = codMateria;


                if (XtraMessageBox.Show("¿Esta seguro que desea eliminar la asignación de la materia?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CtrlMateriasCursos.Eliminar(mtC);

                    if (!BkgwBuscarMat.IsBusy)
                    {
                        PrgBuscar2.Visible = true;
                        BkgwBuscarMat.RunWorkerAsync();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un Materia.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Imprimir()
        {
            if (DgvCursos.RowCount > 0 && DgvCursos.GetFocusedRow() != null)
            {
                DataSet dsImprimir = new DataSet();
                dsImprimir.Tables.Add(dtConsulta2Det.Copy());

                //dsImprimir.WriteXmlSchema(System.Windows.Forms.Application.StartupPath + @"/Temp/RptMateriasPorCurso.xsd");
                RptMateriasPorCurso report = new RptMateriasPorCurso();
                report.DataSource = dsImprimir;
                report.Database = Database;
                report.Año = Año.ToString();
                report.NombreCurso = nombreCursoSel;
                report.Empresa();

                ReportPrintTool rpt = new ReportPrintTool(report);
                report.CreateDocument(true);
                rpt.ShowRibbonPreviewDialog();

            }
        }

        #endregion

        #region Eventos

        #region MovVentana
        private void LnkLblMinimizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LnkLblCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
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

        private void FrmAsignarMatCursos_Load(object sender, EventArgs e)
        {
            commonToolBar21.SuperTipAñadir("", "Asignar Nueva", "");
            commonToolBar21.SuperTipEditar("", "Editar Asignación", "");
            commonToolBar21.SuperTipEliminar("", "Eliminar Asignación", "");

            if (!BkgwBuscarCursos.IsBusy)
            {
                PrgBuscar.Visible = true;
                BkgwBuscarCursos.RunWorkerAsync();
            }
        }

        private void BkgwBuscar_DoWork(object sender, DoWorkEventArgs e)
        {
            LlenarDsConsulta();
        }

        private void BkgwBuscar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PrgBuscar.Visible = false;
            LlenarGridConsulta();
             
        }

        private void BkgwBuscarMat_DoWork(object sender, DoWorkEventArgs e)
        {
            LlenarDsConsulta2(codCursoSel);
        }

        private void BkgwBuscarMat_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PrgBuscar2.Visible = false;
            LlenarGridConsulta2();

            if (ini)
            {
                DgvCursos_FocusedRowChanged(sender, null);
                ini = false;
            }
        }      

        private void DgvCursos_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (DgvCursos.Columns.Count > 2 && DgvCursos.RowCount>0)
            {
                codCursoSel = DgvCursos.GetFocusedRowCellValue(DgvCursos.Columns["CodigoCurso"]).ToString();
                nombreCursoSel = DgvCursos.GetFocusedRowCellValue(DgvCursos.Columns["Nombre"]).ToString();
            }

            if (!BkgwBuscarMat.IsBusy)
            {
                PrgBuscar2.Visible = true;
                BkgwBuscarMat.RunWorkerAsync();
            }
        }


        #endregion

        private void DgvMaterias_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (DgvDetalle.Columns.Count > 2 && DgvDetalle.RowCount > 0)
            {
                string codMat = "";
                codMat = DgvDetalle.GetFocusedRowCellValue(DgvDetalle.Columns["CodMateria"]).ToString();
                codMateria = codMat;
            }
        }

        private void DgvDetalle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView dv = (sender as GridView);
            if (DgvDetalle.Columns.Count > 2 && dv.RowCount > 0)
            {
                string codMat = "";
                codMat = dv.GetFocusedRowCellValue(DgvDetalle.Columns["CodMateria"]).ToString();
                codMateria = codMat;
            }
        }

        private void DgvMaterias_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            int valorPorcentaje = 0;

            if (e.RowHandle >= 0 && View.Columns.Count > 3)
            {
                if (View.GetRowCellValue(e.RowHandle, View.Columns["TotalPorcentaje"]) != null)
                {
                    string porcentaje = View.GetRowCellValue(e.RowHandle, View.Columns["TotalPorcentaje"]).ToString();

                    valorPorcentaje = Convert.ToInt32(porcentaje);

                    Color colorceldas = Color.LightCoral;
                    Color colorceldas2 = Color.MediumSeaGreen;

                    if (valorPorcentaje != 100)
                    {
                        if (e.Column.Name == View.Columns["NombreArea"].Name)
                        {
                            e.Appearance.BackColor = colorceldas;
                        }

                        if (e.Column.Name == View.Columns["TotalPorcentaje"].Name)
                        {
                            e.Appearance.BackColor = colorceldas;
                        }
                    }
                    else
                    {
                        e.Appearance.BackColor = colorceldas2;
                    }
                }

            }
        }


    }
}