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
using RecordRatings.Reportes;
using DevExpress.XtraReports.UI;

namespace RecordRatings.Vistas
{
    public partial class FrmImprimirBoletin : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Modo { get; set; }
        public int Año { get; set; }
        public string CodPeriodo { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        DataSet dsImprimir = new DataSet();

        #endregion

        #region Metodos
        public FrmImprimirBoletin()
        {
            InitializeComponent();
        }

        public bool Validar() 
        {
            bool retorno = true;
            
            if (LueCurso.ItemIndex < 0)
            {
                errorP1.SetError(LueCurso, "Debe seleccionar un curso");
                LueCurso.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(LueCurso, "");
            }

            if (LuePeriodo.ItemIndex < 0)
            {
                errorP1.SetError(LuePeriodo, "Debe seleccionar un periodo");
                LuePeriodo.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(LuePeriodo, "");
            }                             

            return retorno;
        }

        public void Accept() 
        {
            if (Validar())
            {
                dsImprimir = new DataSet();
                RegistroNota regNot = new RegistroNota();
                regNot.Curso.CodigoCurso = LueCurso.EditValue.ToString();
                regNot.Periodo.CodigoPeriodo = LuePeriodo.EditValue.ToString();
                regNot.AñoElectivo = Año;

                DataTable dtCabecera = CtrlRegistroNotas.GetBoletinesPorCursoCab(regNot).Tables[0].Copy();
                dtCabecera.TableName = "Cabecera";
                DataTable dtDetalles = CtrlRegistroNotas.GetBoletinesPorCursoDet2(regNot).Tables[0].Copy();
                dtDetalles.TableName = "Detalle";              

                dsImprimir.Tables.Add(dtCabecera);
                dsImprimir.Tables.Add(dtDetalles);

                DataColumn[] keyColumn = new DataColumn[] { dsImprimir.Tables["Cabecera"].Columns["CodigoAlum"]};
                DataColumn[] foreignKeyColumn = new DataColumn[] { dsImprimir.Tables["Detalle"].Columns["CodigoAlum"] };
                dsImprimir.Relations.Add("Relacion", keyColumn, foreignKeyColumn);


                //dsImprimir.WriteXmlSchema(System.Windows.Forms.Application.StartupPath + @"/Temp/RptBoletines2.xsd");
                RptBoletin report = new RptBoletin();
                report.DataSource = dsImprimir;
                report.Database = Database;
                report.Año = Año.ToString();
                report.CodPeriodo = LuePeriodo.EditValue.ToString();
                report.CodCurso = LueCurso.EditValue.ToString();
                report.Empresa();

                ReportPrintTool rpt = new ReportPrintTool(report);
                report.CreateDocument(true);
                rpt.ShowRibbonPreviewDialog();
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

        private void FrmImprimirBoletin_Load(object sender, EventArgs e)
        {
            try
            {                
                DataTable dt2 = CtrlCursos.GetCursoAll().Tables[0];
                LueCurso.Properties.DataSource = dt2;
                LueCurso.Properties.DisplayMember = "Nombre";
                LueCurso.Properties.ValueMember = "CodigoCurso";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1;
                col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
                LueCurso.Properties.Columns.Clear();
                LueCurso.Properties.Columns.Add(col1);
                LueCurso.ItemIndex = -1;                

                DataTable dt3 = CtrlPeriodos.GetPeriodoAll().Tables[0];
                LuePeriodo.Properties.DataSource = dt3;
                LuePeriodo.Properties.DisplayMember = "Nombre";
                LuePeriodo.Properties.ValueMember = "CodigoPeriodo";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col2;
                col2 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
                LuePeriodo.Properties.Columns.Add(col2);
                LuePeriodo.ItemIndex = -1;

                LuePeriodo.EditValue = CodPeriodo;
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }

            TxtAño.Text = Año.ToString();
                      
        } 

        private void BtnRegistrarNotas_Click(object sender, EventArgs e)
        {
            Accept();
        }

         #endregion



    }
}