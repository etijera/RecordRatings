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

namespace RecordRatings.Vistas
{
    public partial class FrmCursoAñoElectivo : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public int Año { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        DataTable dtConsulta = new DataTable();
        DataSet dsConsulta = new DataSet();

        #endregion
        
        #region Metodos
        public FrmCursoAñoElectivo()
        {
            InitializeComponent();
        }

        public void LlenarDsConsulta()
        {
            try
            {
                CursoAñoElectivo curAe = new CursoAñoElectivo();
                curAe.AñoElectivo = Año;
                DataSet ds = CtrlCursoAñoElectivo.GetCursoAñoElectivo(curAe);

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

        public void LlenarGridConsulta()
        {
            DgvCursos.Columns.Clear();            
            DgvCursos.OptionsView.ColumnAutoWidth = false;
            DataViewManager dvm = new DataViewManager(dsConsulta);
            DataView dvMain = dvm.CreateDataView(dsConsulta.Tables[0]);
            DgvCursos.OptionsBehavior.AutoPopulateColumns = false;
            GctrlCursos.DataSource = dvMain;
            string[] captions = new[] {"id", "Código", "Nombre","Estado" };

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
                        
            DgvCursos.Columns[2].Width = 400;
            DgvCursos.Columns[3].Width = 80;
           

            Funciones.getInstancia().Configurar_Grid(DgvCursos);
            DgvCursos.OptionsCustomization.AllowSort = true;
            //DgvCursos.OptionsFind.AlwaysVisible = true;
            DgvCursos.OptionsView.ColumnAutoWidth = false;
        }

        public void Añadir()
        {

            FrmListaCursos mtC = new FrmListaCursos();
            mtC.Database = Database;
            mtC.Modo = "CURSOS_NOASIG";
            mtC.Año = Año;
            mtC.ShowDialog();

            if (mtC.DialogResult == DialogResult.OK)
            {
                CursoAñoElectivo curAe = new CursoAñoElectivo();
                curAe.Curso.CodigoCurso = mtC.CodigoCurso;
                curAe.AñoElectivo = Año;

                CtrlCursoAñoElectivo.Insertar(curAe);

                if (!BkgwBuscarCursos.IsBusy)
                {
                    PrgBuscar2.Visible = true;
                    BkgwBuscarCursos.RunWorkerAsync();
                }
            }
            
           
        }

        public void Editar()
        {
            if (DgvCursos.RowCount > 0 && DgvCursos.GetFocusedRow() != null)
            {
                string codCurso, nombre, estado = "";
   
                codCurso = DgvCursos.GetFocusedRowCellValue(DgvCursos.Columns["CodigoCurso"]).ToString();
                nombre = DgvCursos.GetFocusedRowCellValue(DgvCursos.Columns["Nombre"]).ToString();
                estado = DgvCursos.GetFocusedRowCellValue(DgvCursos.Columns["Estado"]).ToString();

                FrmEditEstadoCurso editEc = new FrmEditEstadoCurso();
                editEc.Database = Database;
                editEc.CodigoCurso = codCurso;
                editEc.Nombre = nombre;
                editEc.Estado = estado;
                editEc.Año = Año;
                editEc.ShowDialog();

                if (editEc.DialogResult == DialogResult.OK)
                {
                    if (!BkgwBuscarCursos.IsBusy)
                    {
                        PrgBuscar2.Visible = true;
                        BkgwBuscarCursos.RunWorkerAsync();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un curso.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Eliminar()
        {
            if (DgvCursos.RowCount > 0 && DgvCursos.GetFocusedRow() != null)
            {
                string codCurso = "";
                codCurso = DgvCursos.GetFocusedRowCellValue(DgvCursos.Columns["CodigoCurso"]).ToString();

                CursoAñoElectivo curAe = new CursoAñoElectivo();
                curAe.Curso.CodigoCurso = codCurso;
                curAe.AñoElectivo = Año;


                if (XtraMessageBox.Show("¿Esta seguro que desea eliminar la asignación del curso?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CtrlCursoAñoElectivo.Eliminar(curAe);

                    if (!BkgwBuscarCursos.IsBusy)
                    {
                        PrgBuscar2.Visible = true;
                        BkgwBuscarCursos.RunWorkerAsync();
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
                DataSet dsImprimir = dsConsulta;

                //dsImprimir.WriteXmlSchema(System.Windows.Forms.Application.StartupPath + @"/Temp/RptCursosPorAño.xsd");
                RptCursosPorAño report = new RptCursosPorAño();
                report.DataSource = dsImprimir;
                report.Database = Database;
                report.Año = Año.ToString();
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

        private void FrmCursoAñoElectivo_Load(object sender, EventArgs e)
        {
            commonToolBar21.SuperTipAñadir("", "Asignar Nuevo", "");
            commonToolBar21.SuperTipEditar("", "Editar Asignación", "");
            commonToolBar21.SuperTipEliminar("", "Eliminar Asignación", "");

            TxtAñoElectivo.Text = Año.ToString();

            if (!BkgwBuscarCursos.IsBusy)
            {
                PrgBuscar2.Visible = true;
                BkgwBuscarCursos.RunWorkerAsync();
            }

        }

        private void BkgwBuscar_DoWork(object sender, DoWorkEventArgs e)
        {
            LlenarDsConsulta();
        }

        private void BkgwBuscar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PrgBuscar2.Visible = false;
            LlenarGridConsulta();           
                        
        }                

        #endregion


    }
}