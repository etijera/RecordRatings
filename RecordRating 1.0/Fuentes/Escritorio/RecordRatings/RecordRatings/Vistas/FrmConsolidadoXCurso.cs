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

namespace RecordRatings.Vistas
{
    public partial class FrmConsolidadoXCurso : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public int Año { get; set; }
        public string CodCurso { get; set; }
        public string CodPeriodo { get; set; }
        public string NomCurso { get; set; }
        public string NomPeriodo { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        DataTable dtConsulta2;
        DataSet dsConsulta2;

        #endregion
        
        #region Metodos
        public FrmConsolidadoXCurso()
        {
            InitializeComponent();
        }

        public void LlenarDsConsulta()
        {
            try
            {
                RegistroNota regNot = new RegistroNota();          
                regNot.Curso.CodigoCurso = CodCurso;    
                regNot.Periodo.CodigoPeriodo = CodPeriodo;
                regNot.AñoElectivo = Año;

                DataSet ds = CtrlRegistroNotas.GetConsolidadoXCurso(regNot);

                if (ds.Tables[0].Rows.Count > 0) 
                {
                    
                    dtConsulta2 = new DataTable();
                    dsConsulta2 = new DataSet();

                    dtConsulta2 = ds.Tables[0].Copy();
                    dsConsulta2.Tables.Clear();
                    if (dsConsulta2.Tables.Count == 0)
                    {
                        dsConsulta2.Tables.Add(dtConsulta2);
                    }
                }                
                
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        public void LlenarGridConsulta2()
        {
            DgvGeneral.Columns.Clear();
            DgvGeneral.OptionsView.ColumnAutoWidth = false;
            DataViewManager dvm = new DataViewManager(dsConsulta2);
            DataView dvMain = dvm.CreateDataView(dsConsulta2.Tables[0]);
            DgvGeneral.OptionsBehavior.AutoPopulateColumns = true;
            GctrlGeneral.DataSource = dvMain;            

            DgvGeneral.Columns[0].Visible = false;
            DgvGeneral.Columns[1].BestFit();

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit numerico2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();            
            numerico2.Mask.EditMask = "n";
            numerico2.Mask.UseMaskAsDisplayFormat = true;
            numerico2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            for (int i = 2; i < DgvGeneral.Columns.Count-1; i++)
            {
                DgvGeneral.Columns[i].ColumnEdit = numerico2;
                DgvGeneral.Columns[i].BestFit();
            }            

            Font fuenteNegrita = new Font("Tahoma", 8.25F, FontStyle.Bold);
            DgvGeneral.Columns[1].AppearanceCell.Font = fuenteNegrita;                

            Funciones.getInstancia().Configurar_Grid(DgvGeneral);
            DgvGeneral.OptionsBehavior.Editable = false;
            DgvGeneral.OptionsCustomization.AllowSort = false;
            DgvGeneral.OptionsView.ColumnAutoWidth = false;
            DgvGeneral.OptionsCustomization.AllowGroup = true;
            DgvGeneral.OptionsView.ShowGroupPanel = false;           
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

        private void FrmConsolidadoXCurso_Load(object sender, EventArgs e)
        {
            TxtAño.Text = Año.ToString();
            TxtPeriodo.Text = NomPeriodo;
            TxtCurso.Text = NomCurso;


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
            if (dsConsulta2.Tables[0].Rows.Count > 0) 
            {
                LlenarGridConsulta2();
            }           
        }
                          
        #endregion



    }
}