﻿using System;
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
    public partial class FrmListaProfesores : BasicForm
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

        #endregion
        
        #region Metodos
        public FrmListaProfesores()
        {
            InitializeComponent();
        }

        public void LlenarDsConsulta()
        {
            try
            {

                DataSet ds = CtrlProfesores.GetProfesorAll();

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
            DgvGeneral.Columns.Clear();

            DgvGeneral.OptionsView.ColumnAutoWidth = false;
            DataViewManager dvm = new DataViewManager(dsConsulta);
            DataView dvMain = dvm.CreateDataView(dsConsulta.Tables[0]);
            DgvGeneral.OptionsBehavior.AutoPopulateColumns = false;
            GctrlGeneral.DataSource = dvMain;
            string[] captions = new[] { "Id", "Código", "Nombre", "Identificación", "Estado", "Dirección", "Email" };

            GridColumn[] col = new GridColumn[dsConsulta.Tables[0].Columns.Count];
            for (int i = 0; i < dsConsulta.Tables[0].Columns.Count; i++)
            {
                col[i] = DgvGeneral.Columns.AddField(dsConsulta.Tables[0].Columns[i].Caption.Trim());
                col[i].VisibleIndex = i;
                col[i].Caption = captions[i];
                col[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (i == 0)
                {
                    col[i].Visible = false;
                }
            }
            
            DgvGeneral.Columns[1].Width = 80;
            DgvGeneral.Columns[2].Width = 200;
            DgvGeneral.Columns[3].Width = 80;
            DgvGeneral.Columns[4].Width = 80;
            DgvGeneral.Columns[5].Width = 200;
            DgvGeneral.Columns[6].Width = 150;

            DgvGeneral.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            DgvGeneral.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            Funciones.getInstancia().Configurar_Grid(DgvGeneral);
            DgvGeneral.OptionsCustomization.AllowSort = true;
            DgvGeneral.OptionsFind.AlwaysVisible = true;
            DgvGeneral.OptionsView.ColumnAutoWidth = false;
        }

        public void Añadir()
        {
            FrmGetProfesores profesores = new FrmGetProfesores();
            profesores.Database = Database;
            profesores.Modo = "N";
            profesores.ShowDialog();

            if (profesores.DialogResult == DialogResult.OK)
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
                FrmGetProfesores profesores = new FrmGetProfesores();
                profesores.Database = Database;
                profesores.Modo = "E";
                profesores.Id = idGeneral;
                profesores.ShowDialog();

                if (profesores.DialogResult == DialogResult.OK)
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
                Profesor profesor = new Profesor();
                profesor.Persona.Id = idGeneral;


                if (XtraMessageBox.Show("Si elimina el profesor se perderan todos los datos y registros de este, ingresados en el sistema.\n ¿Desea continuar?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (XtraMessageBox.Show("¿Esta seguro que desea eliminar el profesor?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CtrlProfesores.Eliminar(profesor);

                        if (!BkgwBuscar.IsBusy)
                        {
                            PrgBuscar.Visible = true;
                            BkgwBuscar.RunWorkerAsync();
                        }
                    } 
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un registro.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Imprimir()
        {
            if (DgvGeneral.RowCount > 0 && DgvGeneral.GetFocusedRow() != null)
            {
                DataSet dsImprimir = dsConsulta;

                //dsImprimir.WriteXmlSchema(System.Windows.Forms.Application.StartupPath + @"/Temp/RptProfesoresAll.xsd");
                RptProfesores report = new RptProfesores();
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

        private void FrmListaProfesores_Load(object sender, EventArgs e)
        {
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