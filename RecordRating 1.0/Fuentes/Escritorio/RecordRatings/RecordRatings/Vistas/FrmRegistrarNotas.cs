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
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection; 

namespace RecordRatings.Vistas
{
    public partial class FrmRegistrarNotas : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public int Año { get; set; }
        public string CodProfesor { get; set; }
        public string CodCurso { get; set; }
        public string CodMateria { get; set; }
        public string CodPeriodo { get; set; }
        public string NomProfesor { get; set; }
        public string NomCurso { get; set; }
        public string NomMateria { get; set; }
        public string NomPeriodo { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        DataTable dtConsulta2;
        DataSet dsConsulta2;
        string modo="INSERT";

        #endregion
        
        #region Metodos
        public FrmRegistrarNotas()
        {
            InitializeComponent();
        }

        public void LlenarDsConsulta()
        {
            try
            {
                RegistroNota regNot = new RegistroNota();
                regNot.Curso.CodigoCurso = CodCurso;
                regNot.Profesor.CodigoProfesor = CodProfesor;
                regNot.Materia.CodMateria = CodMateria;
                regNot.Periodo.CodigoPeriodo = CodPeriodo;
                regNot.AñoElectivo = Año;

                DataSet ds = CtrlRegistroNotas.GetRegistroNotUpd(regNot);

                if (ds.Tables[0].Rows.Count > 0) 
                {
                    
                    modo = "UPDATE";
                    dtConsulta2 = new DataTable();
                    dsConsulta2 = new DataSet();

                    dtConsulta2 = ds.Tables[0].Copy();
                    dsConsulta2.Tables.Clear();
                    if (dsConsulta2.Tables.Count == 0)
                    {
                        dsConsulta2.Tables.Add(dtConsulta2);
                    }
                }
                else
                {
                    
                    modo = "INSERT";
                    DataSet ds1 = CtrlRegistroNotas.GetRegistroNotInsert(regNot);

                    dtConsulta2 = new DataTable();
                    dsConsulta2 = new DataSet();

                    dtConsulta2 = ds1.Tables[0].Copy();
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
           
            string[] captions = new[] { "Código", "Alumno", "CodProfesor", "CodigoCurso", "CodMateria", "CodPeriodo", "Ser y Convivir", "30%",
                                        "Hacer", "30%", "Conocer", "40%", "Saber", "70%", "NotaFinal", "Fallas", "AñoElectivo"};

            GridColumn[] col = new GridColumn[dsConsulta2.Tables[0].Columns.Count];
            for (int i = 0; i < dsConsulta2.Tables[0].Columns.Count; i++)
            {
                col[i] = DgvGeneral.Columns.AddField(dsConsulta2.Tables[0].Columns[i].Caption.Trim());
                col[i].VisibleIndex = i;
                col[i].Caption = captions[i];
                col[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if ( i == 2 || i == 3 || i == 4 || i == 5 || i == 16)
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

            DgvGeneral.Columns[6].ColumnEdit = numerico1;
            DgvGeneral.Columns[7].ColumnEdit = numerico2;
            DgvGeneral.Columns[8].ColumnEdit = numerico1;
            DgvGeneral.Columns[9].ColumnEdit = numerico2;
            DgvGeneral.Columns[10].ColumnEdit = numerico1;
            DgvGeneral.Columns[11].ColumnEdit = numerico2;
            DgvGeneral.Columns[12].ColumnEdit = numerico1;
            DgvGeneral.Columns[13].ColumnEdit = numerico2;
            DgvGeneral.Columns[14].ColumnEdit = numerico2;

            DgvGeneral.Columns[15].ColumnEdit = numerico;

            DgvGeneral.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            Font fuenteNegrita = new Font("Tahoma", 8.25F, FontStyle.Bold);
            DgvGeneral.Columns[6].AppearanceCell.Font = fuenteNegrita;
            DgvGeneral.Columns[8].AppearanceCell.Font = fuenteNegrita;
            DgvGeneral.Columns[10].AppearanceCell.Font = fuenteNegrita;
            DgvGeneral.Columns[12].AppearanceCell.Font = fuenteNegrita;
            DgvGeneral.Columns[14].AppearanceCell.Font = fuenteNegrita;
                      
            DgvGeneral.Columns[0].AppearanceCell.BackColor = Color.FromArgb(0xEA, 0xEA, 0xFD);
            DgvGeneral.Columns[1].AppearanceCell.BackColor = Color.FromArgb(0xF1, 0xD6, 0xE0);
            DgvGeneral.Columns[6].AppearanceCell.BackColor = Color.FromArgb(0xFB, 0xE0, 0xCD);
            DgvGeneral.Columns[7].AppearanceCell.BackColor = Color.FromArgb(0xFB, 0xE0, 0xCD);
            DgvGeneral.Columns[8].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            DgvGeneral.Columns[9].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            DgvGeneral.Columns[10].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            DgvGeneral.Columns[11].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            DgvGeneral.Columns[12].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            DgvGeneral.Columns[13].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            DgvGeneral.Columns[14].AppearanceCell.BackColor = Color.FromArgb(0xCA, 0xE6, 0xCF);
            DgvGeneral.Columns[15].AppearanceCell.BackColor = Color.FromArgb(0xE6, 0xBB, 0xBB);

            DgvGeneral.Columns[0].OptionsColumn.AllowEdit = false;
            DgvGeneral.Columns[1].OptionsColumn.AllowEdit = false;
            DgvGeneral.Columns[7].OptionsColumn.AllowEdit = false;
            DgvGeneral.Columns[9].OptionsColumn.AllowEdit = false;
            DgvGeneral.Columns[11].OptionsColumn.AllowEdit = false;
            DgvGeneral.Columns[12].OptionsColumn.AllowEdit = false;
            DgvGeneral.Columns[13].OptionsColumn.AllowEdit = false;
            DgvGeneral.Columns[14].OptionsColumn.AllowEdit = false;            

            DgvGeneral.Columns[0].Width = 70;
            DgvGeneral.Columns[1].Width = 265;
            DgvGeneral.Columns[6].Width = 95;
            DgvGeneral.Columns[7].Width = 70;
            DgvGeneral.Columns[8].Width = 85;
            DgvGeneral.Columns[9].Width = 70;
            DgvGeneral.Columns[10].Width = 85;
            DgvGeneral.Columns[11].Width = 70;
            DgvGeneral.Columns[12].Width = 85;
            DgvGeneral.Columns[13].Width = 70;
            DgvGeneral.Columns[14].Width = 75;
            DgvGeneral.Columns[15].Width = 60;

            Funciones.getInstancia().Configurar_Grid(DgvGeneral);
            DgvGeneral.OptionsBehavior.Editable = true;
            DgvGeneral.OptionsCustomization.AllowSort = true;
            DgvGeneral.OptionsView.ColumnAutoWidth = false;
        }

        private void Guardar()
        {
            try
            {
                for (int i = 0; i < DgvGeneral.RowCount; i++)
                {
                    string codAlumno = DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["CodigoAlum"]).ToString();
                    decimal nota1 = Convert.ToDecimal(DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["SerConvi"]));
                    decimal porcN1 = Convert.ToDecimal(DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["Nota1"]));
                    decimal nota2 = Convert.ToDecimal(DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["Hacer"]));
                    decimal porcN2 = Convert.ToDecimal(DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["Nota2"]));
                    decimal nota3 = Convert.ToDecimal(DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["Conocer"]));
                    decimal porcN3 = Convert.ToDecimal(DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["Nota3"]));
                    decimal nota4 = Convert.ToDecimal(DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["Saber"]));
                    decimal porcN4 = Convert.ToDecimal(DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["Nota4"]));
                    decimal notaFinal = Convert.ToDecimal(DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["NotaFinal"]));
                    int fallas = Convert.ToInt32(DgvGeneral.GetRowCellValue(i, DgvGeneral.Columns["Fallas"]));

                    RegistroNota regNot = new RegistroNota();
                    regNot.Alumno.CodigoAlum = codAlumno;
                    regNot.Profesor.CodigoProfesor = CodProfesor;
                    regNot.Curso.CodigoCurso = CodCurso;
                    regNot.Materia.CodMateria = CodMateria;
                    regNot.Periodo.CodigoPeriodo = CodPeriodo;
                    regNot.Nota1 = nota1;
                    regNot.PorcN1 = porcN1;
                    regNot.Nota2 = nota2;
                    regNot.PorcN2 = porcN2;
                    regNot.Nota3 = nota3;
                    regNot.PorcN3 = porcN3;
                    regNot.Nota4 = nota4;
                    regNot.PorcN4 = porcN4;
                    regNot.NotaFinal = notaFinal;
                    regNot.Fallas = fallas;
                    regNot.AñoElectivo = Año;

                    if (modo == "INSERT")
                    {
                        CtrlRegistroNotas.Insertar(regNot);
                    }
                    else
                    {
                        CtrlRegistroNotas.Actualizar(regNot);
                    }
                }

                XtraMessageBox.Show("Proceso realizado con exito", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error en el proceso por favor comuniquese con el Admin del programa:\n "+ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RecogerDatosExcel()
        {
            string rutaArchivo = "";
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx";//
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    rutaArchivo = openDialog.FileName;
                }
                else
                {
                    return;
                }
            }
           
            int numHoja = 1;

            switch (CodPeriodo)
            {
                case "02":
                    numHoja = 2;
                    break;

                case "03":
                    numHoja = 3;
                    break;

                case "04":
                    numHoja = 4;
                    break;

                default: numHoja=1;
                    break;
            }

            Excel.Application excelAplicacion;
            Excel._Workbook libroTrabajo;
            Excel._Worksheet hojaTrabajo;

            //Start Excel and get Application object.
            excelAplicacion = new Excel.Application();
            excelAplicacion.Visible = false;

            try
            {                
                //Get a new workbook.
                libroTrabajo = (Excel._Workbook)(excelAplicacion.Workbooks.Open(rutaArchivo, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing));


                hojaTrabajo = (Excel._Worksheet)libroTrabajo.Sheets[numHoja];

                hojaTrabajo.Unprotect("cargape");

                string periodoAño = (string)hojaTrabajo.get_Range("G" + 4, Missing.Value).Text;
                periodoAño = periodoAño.Remove(0, 10);

                string periodo =  (periodoAño.Split('-'))[0].Trim();
                string año =  (periodoAño.Split('-'))[2].Trim();

                if (Año.ToString() != año)
                {
                    XtraMessageBox.Show("La planilla que intenta importar no corresponde al año electivo ("+Año.ToString()+").", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string curso = (string)hojaTrabajo.get_Range("C" + 6, Missing.Value).Text;
                curso = curso.Remove(0, 8);
                string  codCurso = (curso.Split('-'))[0].Trim();

                if (CodCurso != codCurso)
                {
                    XtraMessageBox.Show("La planilla que intenta importar no corresponde al curso seleccionado (" + NomCurso + ").", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string priAlum = (string)hojaTrabajo.get_Range("A" + 8, Missing.Value).Text;

                if (string.IsNullOrEmpty(priAlum) || priAlum.Substring(0, 3) != "ALU" || priAlum.Length != 8)
                {
                    XtraMessageBox.Show("La planilla que intenta importar no posee los códigos de los alumnos.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                               
                for (int i = 8; i < 42; i++)
                {
                    string codAlum = (string)hojaTrabajo.get_Range("A" + i, Missing.Value).Text;
                    if (string.IsNullOrEmpty(codAlum))
                    {
                        break;
                    }

                    int indice = -1;
                    for (int l = 0; l < DgvGeneral.RowCount; l++)
			        {
                        if (DgvGeneral.GetRowCellDisplayText(l, DgvGeneral.Columns["CodigoAlum"]) == codAlum)
                        {
                            indice = l;
                            break;
                        }
			        }

                    if (indice!= -1)
                    {
                        string serConvivir = (string)hojaTrabajo.get_Range("G" + i, Missing.Value).Text;
                        string hacer = (string)hojaTrabajo.get_Range("I" + i, Missing.Value).Text;
                        string conocer = (string)hojaTrabajo.get_Range("K" + i, Missing.Value).Text;
                        string fallas = (string)hojaTrabajo.get_Range("P" + i, Missing.Value).Text;

                        DgvGeneral.SetRowCellValue(indice, DgvGeneral.Columns["SerConvi"], serConvivir);
                        DgvGeneral.SetRowCellValue(indice, DgvGeneral.Columns["Hacer"], hacer);
                        DgvGeneral.SetRowCellValue(indice, DgvGeneral.Columns["Conocer"], conocer);
                        DgvGeneral.SetRowCellValue(indice, DgvGeneral.Columns["Fallas"], fallas);
                    }
                    else
                    {
                        XtraMessageBox.Show("El alumno con codigo ("+ codAlum + "), no existe actualmente en el sistema o no se encuentra activo.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    }                                        
                }

                //Cerrar el Libro
                libroTrabajo.Close(false, Missing.Value, Missing.Value);
                //Cerrar la Aplicación
                excelAplicacion.Quit();
            }
            catch (Exception exc)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, exc.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, exc.Source);

                MessageBox.Show(errorMessage, "Error");
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

        private void FrmRegistrarNotas_Load(object sender, EventArgs e)
        {
            TxtAño.Text = Año.ToString();
            TxtProfesor.Text = NomProfesor;
            TxtPeriodo.Text = NomPeriodo;
            TxtMateria.Text = NomMateria;
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
            if (modo == "INSERT")
            {
                groupControl1.Text = "SIN REGISTRO";
            }
            else
            {
                groupControl1.Text = "ACTUALIZAR REGISTRO";
            }

            PrgBuscar.Visible = false;
            LlenarGridConsulta2();
        }
       
        private void DgvGeneral_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.ToString() != "")
                {                   
                    if (e.Column == DgvGeneral.Columns["SerConvi"])
                    {
                        if (Convert.ToDecimal(e.Value) > 5)
                        {
                            DgvGeneral.SetRowCellValue(e.RowHandle, e.Column, 5);
                        }
                        else
                        {
                            if (Convert.ToDecimal(e.Value) < 0)
                            {
                                DgvGeneral.SetRowCellValue(e.RowHandle, e.Column, Math.Abs(Convert.ToDecimal(e.Value)));
                            }
                        }

                        if (Convert.ToDecimal(e.Value) <= 5 && Convert.ToDecimal(e.Value) >= 0) 
                        {                            
                            decimal nota1 = Decimal.Round(Convert.ToDecimal(e.Value) * Convert.ToDecimal(0.3),1);
                            decimal nota4 = Decimal.Round(Convert.ToDecimal(DgvGeneral.GetRowCellValue(e.RowHandle, DgvGeneral.Columns["Nota4"])),1);
                            decimal notaFinal = Decimal.Round(nota1+nota4,1);

                            DgvGeneral.SetRowCellValue(e.RowHandle, DgvGeneral.Columns["Nota1"], nota1);
                            DgvGeneral.SetRowCellValue(e.RowHandle, DgvGeneral.Columns["NotaFinal"], notaFinal);
                        }
                    }

                    if (e.Column == DgvGeneral.Columns["Hacer"])
                    {
                        if (Convert.ToDecimal(e.Value) > 5)
                        {
                            DgvGeneral.SetRowCellValue(e.RowHandle, e.Column, 5);
                        }
                        else
                        {
                            if (Convert.ToDecimal(e.Value) < 0)
                            {
                                DgvGeneral.SetRowCellValue(e.RowHandle, e.Column, Math.Abs(Convert.ToDecimal(e.Value)));
                            }
                        }
                       

                        if (Convert.ToDecimal(e.Value) <= 5 && Convert.ToDecimal(e.Value) >= 0)
                        {
                            decimal nota2 = Decimal.Round(Convert.ToDecimal(e.Value) * Convert.ToDecimal(0.3),1);
                            decimal nota3 = Decimal.Round(Convert.ToDecimal(DgvGeneral.GetRowCellValue(e.RowHandle, DgvGeneral.Columns["Conocer"])) * Convert.ToDecimal(0.4),1);
                            decimal saber = Decimal.Round((Convert.ToDecimal(e.Value) + Convert.ToDecimal(DgvGeneral.GetRowCellValue(e.RowHandle, DgvGeneral.Columns["Conocer"]))) / 2,1);
                            decimal nota4 = Decimal.Round(nota2 + nota3,1);

                            decimal nota1 =Decimal.Round( Convert.ToDecimal(DgvGeneral.GetRowCellValue(e.RowHandle, DgvGeneral.Columns["Nota1"])),1);
                            decimal notaFinal = Decimal.Round(nota1 + nota4,1);

                            DgvGeneral.SetRowCellValue(e.RowHandle, DgvGeneral.Columns["Nota2"], nota2);
                            DgvGeneral.SetRowCellValue(e.RowHandle, DgvGeneral.Columns["Saber"], saber);
                            DgvGeneral.SetRowCellValue(e.RowHandle, DgvGeneral.Columns["Nota4"], nota4);
                            DgvGeneral.SetRowCellValue(e.RowHandle, DgvGeneral.Columns["NotaFinal"], notaFinal);
                        }
                    }

                    if (e.Column == DgvGeneral.Columns["Conocer"])
                    {
                        if (Convert.ToDecimal(e.Value) > 5)
                        {
                            DgvGeneral.SetRowCellValue(e.RowHandle, e.Column, 5);
                        }
                        else
                        {
                            if (Convert.ToDecimal(e.Value) < 0)
                            {
                                DgvGeneral.SetRowCellValue(e.RowHandle, e.Column, Math.Abs(Convert.ToDecimal(e.Value)));
                            }
                        }


                        if (Convert.ToDecimal(e.Value) <= 5 && Convert.ToDecimal(e.Value) >= 0)
                        {
                            decimal nota2 = Decimal.Round(Convert.ToDecimal(DgvGeneral.GetRowCellValue(e.RowHandle, DgvGeneral.Columns["Hacer"])) * Convert.ToDecimal(0.3),1);
                            decimal nota3 = Decimal.Round(Convert.ToDecimal(e.Value) * Convert.ToDecimal(0.4),1);
                            decimal saber = Decimal.Round((Convert.ToDecimal(e.Value) + Convert.ToDecimal(DgvGeneral.GetRowCellValue(e.RowHandle, DgvGeneral.Columns["Hacer"]))) / 2,1);
                            decimal nota4 = Decimal.Round(nota2 + nota3,1);

                            decimal nota1 = Decimal.Round(Convert.ToDecimal(DgvGeneral.GetRowCellValue(e.RowHandle, DgvGeneral.Columns["Nota1"])),1);
                            decimal notaFinal = Decimal.Round(nota1 + nota4,1);

                            DgvGeneral.SetRowCellValue(e.RowHandle, DgvGeneral.Columns["Nota3"], nota3);
                            DgvGeneral.SetRowCellValue(e.RowHandle, DgvGeneral.Columns["Saber"], saber);
                            DgvGeneral.SetRowCellValue(e.RowHandle, DgvGeneral.Columns["Nota4"], nota4);
                            DgvGeneral.SetRowCellValue(e.RowHandle, DgvGeneral.Columns["NotaFinal"], notaFinal);
                        }
                    }
                }
                else
                {
                    DgvGeneral.SetRowCellValue(e.RowHandle, e.Column, 0);
                }
            }
            else
            {
                DgvGeneral.SetRowCellValue(e.RowHandle, e.Column, 0);
            }
            
        }     

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (DgvGeneral.RowCount > 0)
            {
                if (XtraMessageBox.Show("¿Esta seguro que desea guardar el registro de notas ?",  Resources.AppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (!BkgwGuardar.IsBusy)
                    {
                        GctrlGeneral.Enabled = false;
                        PrgBuscar.Text = "Guardando...";
                        PrgBuscar.EditValue = "Guardando...";
                        PrgBuscar.Visible = true;
                        BkgwGuardar.RunWorkerAsync();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No existen alumnos en este curso para registrarles las notas.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BkgwGuardar_DoWork(object sender, DoWorkEventArgs e)
        {
            Guardar();
        }

        private void BkgwGuardar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            PrgBuscar.Text = "Cargando...";
            PrgBuscar.EditValue = "Cargando...";
            PrgBuscar.Visible = false;
            GctrlGeneral.Enabled = true;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    
        private void BtnCargarExcel_Click(object sender, EventArgs e)
        {
            RecogerDatosExcel();
        }

        #endregion


    }
}