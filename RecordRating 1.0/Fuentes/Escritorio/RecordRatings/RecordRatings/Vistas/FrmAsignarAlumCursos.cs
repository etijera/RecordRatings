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
    public partial class FrmAsignarAlumCursos : BasicForm
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
        DataTable dtConsulta2;
        DataSet dsConsulta2;
        private string codCursoSel = "";
        private string nombreCursoSel = "";
        private bool ini = true;

        #endregion
        
        #region Metodos
        public FrmAsignarAlumCursos()
        {
            InitializeComponent();
        }

        public void LlenarDsConsulta()
        {
            try
            {
                CursoAlumno curAl = new CursoAlumno();
                curAl.AñoElectivo = Año;
                DataSet ds = CtrlCursoAlumnos.GetCursosAñoElectivo(curAl);

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
                CursoAlumno cuAl = new CursoAlumno();
                cuAl.Curso.CodigoCurso = codigoCur;
                cuAl.AñoElectivo = Año;

                DataSet ds = CtrlCursoAlumnos.GetCursoAlumnos(cuAl);

                dtConsulta2 = new DataTable();
                dsConsulta2 = new DataSet();

                dtConsulta2 = ds.Tables[0].Copy();
                dsConsulta2.Tables.Clear();
                if (dsConsulta2.Tables.Count == 0)
                {
                    dsConsulta2.Tables.Add(dtConsulta2);
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
            DgvCursos.Columns[2].Width = 275;
           

            Funciones.getInstancia().Configurar_Grid(DgvCursos);
            DgvCursos.OptionsCustomization.AllowSort = true;
            //DgvCursos.OptionsFind.AlwaysVisible = true;
            DgvCursos.OptionsView.ColumnAutoWidth = false;
        }
       
        public void LlenarGridConsulta2()
        {
            DgvAlumnos.Columns.Clear();
            DgvAlumnos.OptionsView.ColumnAutoWidth = false;
            DataViewManager dvm = new DataViewManager(dsConsulta2);
            DataView dvMain = dvm.CreateDataView(dsConsulta2.Tables[0]);
            DgvAlumnos.OptionsBehavior.AutoPopulateColumns = false;
            GctrlAlumnos.DataSource = dvMain;
            string[] captions = new[] { "CodCurso", "CodigoAlum", "Alumno", "Carnet", "AñoElectivo" };

            GridColumn[] col = new GridColumn[dsConsulta2.Tables[0].Columns.Count];
            for (int i = 0; i < dsConsulta2.Tables[0].Columns.Count; i++)
            {
                col[i] = DgvAlumnos.Columns.AddField(dsConsulta2.Tables[0].Columns[i].Caption.Trim());
                col[i].VisibleIndex = i;
                col[i].Caption = captions[i];
                col[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (i == 0 || i == 1 || i == 4)
                {
                    col[i].Visible = false;
                }
            }

            DgvAlumnos.Columns[2].Width = 250;
            DgvAlumnos.Columns[3].Width = 100;

            Funciones.getInstancia().Configurar_Grid(DgvAlumnos);
            DgvAlumnos.OptionsCustomization.AllowSort = true;
            //DgvMaterias.OptionsFind.AlwaysVisible = true;
            DgvAlumnos.OptionsView.ColumnAutoWidth = false;
        }

        public void Añadir()
        {
            if (DgvCursos.RowCount > 0 && DgvCursos.GetFocusedRow() != null)
            {
                FrmListaAlumnos lisAlum = new FrmListaAlumnos();
                lisAlum.Database = Database;
                lisAlum.Modo = "GET";
                lisAlum.Año = Año;
                lisAlum.ShowDialog();

                if (lisAlum.DialogResult == DialogResult.OK)
                {
                    CursoAlumno cuA = new CursoAlumno();
                    cuA.Curso.CodigoCurso = codCursoSel;
                    cuA.Alumno.CodigoAlum = lisAlum.CodigoAlumno;
                    cuA.AñoElectivo = Año;

                    CtrlCursoAlumnos.Insertar(cuA);

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

        public void Eliminar()
        {
            if (DgvAlumnos.RowCount > 0 && DgvAlumnos.GetFocusedRow() != null)
            {
                string codAlum = "";
                codAlum = DgvAlumnos.GetFocusedRowCellValue(DgvAlumnos.Columns["CodigoAlum"]).ToString();

                CursoAlumno cuAl = new CursoAlumno();
                cuAl.Curso.CodigoCurso = codCursoSel;
                cuAl.Alumno.CodigoAlum = codAlum;
                cuAl.AñoElectivo = Año;


                if (XtraMessageBox.Show("¿Esta seguro que desea eliminar el alumno del curso?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CtrlCursoAlumnos.Eliminar(cuAl);

                    if (!BkgwBuscarMat.IsBusy)
                    {
                        PrgBuscar2.Visible = true;
                        BkgwBuscarMat.RunWorkerAsync();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un alumno.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Imprimir()
        {
            if (DgvCursos.RowCount > 0 && DgvCursos.GetFocusedRow() != null)
            {
                DataSet dsImprimir = dsConsulta2;

                ////dsImprimir.WriteXmlSchema(System.Windows.Forms.Application.StartupPath + @"/Temp/RptAlumnosPorCurso.xsd");
                RptAlumnosPorCurso report = new RptAlumnosPorCurso();
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

        private void FrmAsignarAlumCursos_Load(object sender, EventArgs e)
        {

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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Añadir();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        #endregion


    }
}