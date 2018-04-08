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
    public partial class FrmConsultarNotas : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public int Año { get; set; }
        public string CodAlumno { get; set; }
        public string CodCurso { get; set; }
        public string CodMateria { get; set; }
        public string CodPeriodo { get; set; }
        public string NomAlumno { get; set; }
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
        public FrmConsultarNotas()
        {
            InitializeComponent();
        }

        public void LlenarDsConsulta()
        {
            try
            {
                RegistroNota regNot = new RegistroNota();          
                regNot.Alumno.CodigoAlum = CodAlumno;
                regNot.AñoElectivo = Año;

                DataSet ds = CtrlRegistroNotas.GetConsultarNotas(regNot);

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
            DgvGeneral.OptionsBehavior.AutoPopulateColumns = false;
            GctrlGeneral.DataSource = dvMain;

            string[] captions = new[] { "CodArea", "Area", "CodMateria", "Materia", "Nota P1", "Porc. P1",  "Nota P2", "Porc. P2",
                                         "Nota P3", "Porc. P3",  "Nota P4", "Porc. P4", "Acumulado", "Fallas"};

            GridColumn[] col = new GridColumn[dsConsulta2.Tables[0].Columns.Count];
            for (int i = 0; i < dsConsulta2.Tables[0].Columns.Count; i++)
            {
                col[i] = DgvGeneral.Columns.AddField(dsConsulta2.Tables[0].Columns[i].Caption.Trim());
                col[i].VisibleIndex = i;
                col[i].Caption = captions[i];
                col[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (i == 0 || i == 2 )
                {
                    col[i].Visible = false;
                }
            }

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit numerico = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            //numerico.ReadOnly = true;
            numerico.Mask.EditMask = "n0";
            numerico.Mask.UseMaskAsDisplayFormat = true;
            numerico.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit numerico1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            //numerico2.ReadOnly = true;
            numerico1.Mask.EditMask = "n1";
            numerico1.Mask.UseMaskAsDisplayFormat = true;
            numerico1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit numerico2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            //numerico2.ReadOnly = true;
            numerico2.Mask.EditMask = "n";
            numerico2.Mask.UseMaskAsDisplayFormat = true;
            numerico2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            DgvGeneral.Columns[4].ColumnEdit = numerico2;
            DgvGeneral.Columns[5].ColumnEdit = numerico2;
            DgvGeneral.Columns[6].ColumnEdit = numerico2;
            DgvGeneral.Columns[7].ColumnEdit = numerico2;
            DgvGeneral.Columns[8].ColumnEdit = numerico2;
            DgvGeneral.Columns[9].ColumnEdit = numerico2;
            DgvGeneral.Columns[10].ColumnEdit = numerico2;
            DgvGeneral.Columns[11].ColumnEdit = numerico2;
            DgvGeneral.Columns[12].ColumnEdit = numerico2;


            DgvGeneral.Columns[13].ColumnEdit = numerico;


            //DgvGeneral.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            Font fuenteNegrita = new Font("Tahoma", 8.25F, FontStyle.Bold);
            DgvGeneral.Columns[1].AppearanceCell.Font = fuenteNegrita;
            //DgvGeneral.Columns[4].AppearanceCell.Font = fuenteNegrita;
            //DgvGeneral.Columns[5].AppearanceCell.Font = fuenteNegrita;
            //DgvGeneral.Columns[6].AppearanceCell.Font = fuenteNegrita;
            //DgvGeneral.Columns[7].AppearanceCell.Font = fuenteNegrita;
            //DgvGeneral.Columns[8].AppearanceCell.Font = fuenteNegrita;
            //DgvGeneral.Columns[9].AppearanceCell.Font = fuenteNegrita;
            //DgvGeneral.Columns[10].AppearanceCell.Font = fuenteNegrita;
            //DgvGeneral.Columns[11].AppearanceCell.Font = fuenteNegrita;
            DgvGeneral.Columns[12].AppearanceCell.Font = fuenteNegrita;
            DgvGeneral.Columns[13].AppearanceCell.Font = fuenteNegrita;



            DgvGeneral.Columns[4].AppearanceCell.BackColor = Color.FromArgb(0xFE, 0xF0, 0xE7);
            DgvGeneral.Columns[5].AppearanceCell.BackColor = Color.FromArgb(0xFC, 0xED, 0xE3);
            DgvGeneral.Columns[6].AppearanceCell.BackColor = Color.FromArgb(0xE2, 0xFA, 0xE7);
            DgvGeneral.Columns[7].AppearanceCell.BackColor = Color.FromArgb(0xDD, 0xF6, 0xE2);
            DgvGeneral.Columns[8].AppearanceCell.BackColor = Color.FromArgb(0xF9, 0xE3, 0xFA);
            DgvGeneral.Columns[9].AppearanceCell.BackColor = Color.FromArgb(0xF2, 0xDD, 0xF6);
            DgvGeneral.Columns[10].AppearanceCell.BackColor = Color.FromArgb(0xEA, 0xEA, 0xFD);
            DgvGeneral.Columns[11].AppearanceCell.BackColor = Color.FromArgb(0xE1, 0xE1, 0xFF);
            DgvGeneral.Columns[12].AppearanceCell.BackColor = Color.FromArgb(0xBF, 0xD4, 0xEF);
            DgvGeneral.Columns[13].AppearanceCell.BackColor = Color.FromArgb(0xF8, 0xC6, 0xC6);

            //DgvGeneral.Columns[10].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            //DgvGeneral.Columns[11].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            //DgvGeneral.Columns[12].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            //DgvGeneral.Columns[13].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            //DgvGeneral.Columns[14].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            //DgvGeneral.Columns[15].AppearanceCell.BackColor = Color.FromArgb(0xE6, 0xBB, 0xBB);             

            DgvGeneral.Columns[0].Width = 70;
            DgvGeneral.Columns[1].Width = 365;
            DgvGeneral.Columns[2].Width = 70;
            DgvGeneral.Columns[3].Width = 365;

            DgvGeneral.Columns[4].Width = 75;
            DgvGeneral.Columns[5].Width = 75;
            DgvGeneral.Columns[6].Width = 75;
            DgvGeneral.Columns[7].Width = 75;
            DgvGeneral.Columns[8].Width = 75;
            DgvGeneral.Columns[9].Width = 75;
            DgvGeneral.Columns[10].Width = 75;
            DgvGeneral.Columns[11].Width = 75;
            DgvGeneral.Columns[12].Width = 75;

            DgvGeneral.Columns[13].Width = 60;

            Funciones.getInstancia().Configurar_Grid(DgvGeneral);
            DgvGeneral.OptionsBehavior.Editable = false;
            DgvGeneral.OptionsCustomization.AllowSort = false;
            DgvGeneral.OptionsView.ColumnAutoWidth = false;

            DgvGeneral.OptionsCustomization.AllowGroup = true;

            DgvGeneral.OptionsView.ShowGroupPanel = false;

            DgvGeneral.Columns["NombreArea"].GroupIndex = 0;
            DgvGeneral.ExpandAllGroups();
           
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

        private void FrmConsultarNotas_Load(object sender, EventArgs e)
        {
            TxtAño.Text = Año.ToString();
            TxtAlumno.Text = NomAlumno;
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
            LlenarGridConsulta2();
        }
                          
        #endregion



    }
}