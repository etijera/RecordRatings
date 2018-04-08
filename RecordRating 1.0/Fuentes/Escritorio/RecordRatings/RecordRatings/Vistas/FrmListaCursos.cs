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
    public partial class FrmListaCursos : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Modo { get; set; }
        public int Año { get; set; }
        public string CodigoCurso { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        DataTable dtConsulta = new DataTable();
        DataSet dsConsulta = new DataSet();

        #endregion
        
        #region Metodos
        public FrmListaCursos()
        {
            InitializeComponent();
        }

        public void LlenarDsConsulta()
        {
            try
            {

                DataSet ds;

                if (Modo != "CURSOS_NOASIG")
                {
                    ds = CtrlCursos.GetCursoAll();

                    dtConsulta = ds.Tables[0].Copy();
                    dsConsulta.Tables.Clear();
                    if (dsConsulta.Tables.Count == 0)
                    {
                        dsConsulta.Tables.Add(dtConsulta);
                    }
                }
                else
                {
                    CursoAñoElectivo curAe = new CursoAñoElectivo();
                    curAe.AñoElectivo = Año;
                    ds = CtrlCursoAñoElectivo.GetCursoAñoElectivoNoAsigNados(curAe);

                    dtConsulta = ds.Tables[0].Copy();
                    dsConsulta.Tables.Clear();
                    if (dsConsulta.Tables.Count == 0)
                    {
                        dsConsulta.Tables.Add(dtConsulta);
                    }
                }
                
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        public void LlenarGridConsulta()
        {
            DgvGeneral.Columns.Clear();            
            DgvGeneral.OptionsView.ColumnAutoWidth = false;
            DataViewManager dvm = new DataViewManager(dsConsulta);
            DataView dvMain = dvm.CreateDataView(dsConsulta.Tables[0]);
            DgvGeneral.OptionsBehavior.AutoPopulateColumns = false;
            GctrlGeneral.DataSource = dvMain;
            string[] captions;

            if (Modo != "CURSOS_NOASIG")
            {
                captions = new[] { "Id", "Código", "Nombre", "CodGrupo", "CodGrado", "Jornada" };
            }
            else
            {
                captions = new[] { "Id", "Código", "Nombre" };
            }
           

            GridColumn[] col = new GridColumn[dsConsulta.Tables[0].Columns.Count];
            for (int i = 0; i < dsConsulta.Tables[0].Columns.Count; i++)
            {
                col[i] = DgvGeneral.Columns.AddField(dsConsulta.Tables[0].Columns[i].Caption.Trim());
                col[i].VisibleIndex = i;
                col[i].Caption = captions[i];
                col[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (Modo != "CURSOS_NOASIG")
                {
                    if (i == 0 || i == 1 || i == 3 || i == 4)
                    {
                        col[i].Visible = false;
                    }
                }
                else
                {
                    if (i == 0 || i == 1)
                    {
                        col[i].Visible = false;
                    }
                }
            }
            
            //DgvGeneral.Columns[1].Width = 80;
            if (Modo != "CURSOS_NOASIG")
            {
                DgvGeneral.Columns[2].Width = 378;
                DgvGeneral.Columns[5].Width = 105;
            }
            else
            {
                DgvGeneral.Columns[2].Width = 480;
            }
           

            Funciones.getInstancia().Configurar_Grid(DgvGeneral);
            DgvGeneral.OptionsCustomization.AllowSort = true;
            DgvGeneral.OptionsFind.AlwaysVisible = true;
            DgvGeneral.OptionsView.ColumnAutoWidth = false;
        }

        public void Añadir()
        {
            FrmGetCursos cusros = new FrmGetCursos();
            cusros.Database = Database;
            cusros.Modo = "N";
            cusros.ShowDialog();

            if (cusros.DialogResult == DialogResult.OK)
            {
                if (!BkgwBuscar.IsBusy)
                {
                    PrgBuscar.Visible = true;
                    BkgwBuscar.RunWorkerAsync();
                }
            }
        }

        public void Editar()
        {
            if (DgvGeneral.RowCount > 0 && DgvGeneral.GetFocusedRow() != null)
            {
                int idGeneral = Convert.ToInt32(DgvGeneral.GetFocusedRowCellValue("Id"));
                FrmGetCursos cursos = new FrmGetCursos();
                cursos.Database = Database;
                cursos.Modo = "E";
                cursos.Id = idGeneral;
                cursos.ShowDialog();

                if (cursos.DialogResult == DialogResult.OK)
                {
                    if (!BkgwBuscar.IsBusy)
                    {
                        PrgBuscar.Visible = true;
                        BkgwBuscar.RunWorkerAsync();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un registro.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Eliminar()
        {
            if (DgvGeneral.RowCount > 0 && DgvGeneral.GetFocusedRow() != null)
            {
                int idGeneral = Convert.ToInt32(DgvGeneral.GetFocusedRowCellValue("Id"));
                Curso curso = new Curso();
                curso.Id = idGeneral;


                if (XtraMessageBox.Show("¿Esta seguro que desea eliminar el curso?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CtrlCursos.Eliminar(curso);

                    if (!BkgwBuscar.IsBusy)
                    {
                        PrgBuscar.Visible = true;
                        BkgwBuscar.RunWorkerAsync();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un registro.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Accept()
        {
            if (DgvGeneral.RowCount > 0 && DgvGeneral.GetFocusedRow() != null)
            {
                CodigoCurso = DgvGeneral.GetFocusedRowCellDisplayText(DgvGeneral.Columns["CodigoCurso"]);
                DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un curso.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Imprimir()
        {
            if (DgvGeneral.RowCount > 0 && DgvGeneral.GetFocusedRow() != null)
            {
                DataSet dsImprimir = dsConsulta;

                //dsImprimir.WriteXmlSchema(System.Windows.Forms.Application.StartupPath + @"/Temp/RptCursosAll.xsd");
                RptCursos report = new RptCursos();
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

        private void FrmListaCursos_Load(object sender, EventArgs e)
        {
            if (Modo != "CURSOS_NOASIG")
            {
                this.Size = new Size(518, 359);
                acceptCancel1.Visible = false;
            }
            else
            {
                panelControl1.Visible = false;
                groupControl1.Location = new Point(5, 34);
                this.Size = new Size(518, 368);
                acceptCancel1.Location = new Point(173, 322);
            }

            if (!BkgwBuscar.IsBusy)
            {
                PrgBuscar.Visible = true;
                BkgwBuscar.RunWorkerAsync();
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

        #endregion


    }
}