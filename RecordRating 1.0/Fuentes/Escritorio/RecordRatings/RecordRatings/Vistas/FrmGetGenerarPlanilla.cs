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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace RecordRatings.Vistas
{
    public partial class FrmGetGenerarPlanilla : BasicForm
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
        DataTable dtConsultaPlanilla;
        DataTable dtConsultaPeriodos;
        private string codCurso = "";
        private string nomCurso = "";
        private string codPeriodo = "";
        private string nomPeriodo = "";

        #endregion

        #region Metodos
        public FrmGetGenerarPlanilla()
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
           
            return retorno;
        }

        public void Accept() 
        {
            if (Validar())
            {
                GenerarPlanilla();
            }
        }

        public void LlenarDtPlanilla()
        {
            try
            {
                RegistroNota regNot = new RegistroNota();
                regNot.Curso.CodigoCurso = codCurso;
                regNot.AñoElectivo = Año;

                DataSet ds = CtrlRegistroNotas.GetPlanillaXCurso(regNot);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dtConsultaPlanilla = new DataTable();
                    dtConsultaPlanilla = ds.Tables[0].Copy();
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        public void GenerarPlanilla()
        {
            LlenarDtPlanilla();            

            Excel.Application excelAplicacion;
            Excel._Workbook libroTrabajo;
            Excel._Worksheet hojaTrabajo;      

            try
            {
                //Start Excel and get Application object.
                excelAplicacion = new Excel.Application();
                excelAplicacion.Visible = false;                

                //Get a new workbook.
                libroTrabajo = (Excel._Workbook)(excelAplicacion.Workbooks.Open(Path.Combine(Application.StartupPath, "Temp/Excel/Planilla"), Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing));

                for (int j = 0; j < dtConsultaPeriodos.Rows.Count; j++)
                {
                    hojaTrabajo = (Excel._Worksheet)libroTrabajo.Sheets[j+1];
                    
                    hojaTrabajo.Unprotect("cargape");

                    codPeriodo = dtConsultaPeriodos.Rows[j]["CodigoPeriodo"].ToString();
                    nomPeriodo = dtConsultaPeriodos.Rows[j]["Nombre"].ToString();


                    int iniCellCol1 = 8;
                    int colCodAlum = 1;
                    int colPApellido = 3;
                    int colSApellido = 4;
                    int colPNombre = 5;
                    int colSNombre = 6;
                    int colPeriodo = 7;
                    int filPeriodo = 4;
                    int colGrado = 3;
                    int filGrado = 6;

                    for (int i = 0; i < dtConsultaPlanilla.Rows.Count; i++)
                    {
                        string codAlum = dtConsultaPlanilla.Rows[i]["CodigoAlum"].ToString();
                        string pApellido = dtConsultaPlanilla.Rows[i]["PrimerApellido"].ToString();
                        string sApellido = dtConsultaPlanilla.Rows[i]["SegundoApellido"].ToString();
                        string pNombre = dtConsultaPlanilla.Rows[i]["PrimerNombre"].ToString();
                        string sNombre = dtConsultaPlanilla.Rows[i]["SegundoNombre"].ToString();

                        hojaTrabajo.Cells[iniCellCol1, colCodAlum] = codAlum;
                        hojaTrabajo.Cells[iniCellCol1, colPApellido] = pApellido;
                        hojaTrabajo.Cells[iniCellCol1, colSApellido] = sApellido;
                        hojaTrabajo.Cells[iniCellCol1, colPNombre] = pNombre;
                        hojaTrabajo.Cells[iniCellCol1, colSNombre] = sNombre;

                        hojaTrabajo.Cells[filPeriodo, colPeriodo] = "PERIODO : " + codPeriodo + " - " + nomPeriodo  + " - " + TxtAño.Text;
                        hojaTrabajo.Cells[filGrado, colGrado] = "GRADO : " + codCurso + " - " + nomCurso;

                        iniCellCol1++;
                    }

                    hojaTrabajo.Protect("cargape", true); 
                }

                //excelAplicacion.Visible = false;
                //excelAplicacion.UserControl = true;

                string Carpeta = Path.Combine(Application.StartupPath, "Temp\\Excel\\" + TxtAño.Text + "\\");

                if (!Directory.Exists(Carpeta))
                {
                    Directory.CreateDirectory(Carpeta);
                }

                string archivo = Carpeta + "Planillas_Grado_" + nomCurso + "_" + TxtAño.Text + ".xlsx";
                try
                {
                    //Guardad libro
                    libroTrabajo.SaveAs(archivo);

                    //Cerrar el Libro
                    libroTrabajo.Close(false, Missing.Value, Missing.Value);
                    //CErrar aplicacion
                    excelAplicacion.Quit();

                    Process pr = new Process();
                    //Configuramos las opociones iniciales del proceso 
                    pr.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;                                  
                    // Especifique el directorio 
                    pr.StartInfo.WorkingDirectory = Carpeta;
                    // Aqui se introduce el nombre del archivo 
                    pr.StartInfo.FileName = "Planillas_Grado_" + nomCurso + "_" + TxtAño.Text + ".xlsx";
                    // Asegurese de tener creado este archivo 
                    pr.Start(); 

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
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
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

        private void FrmGetImprimirPlanilla_Load(object sender, EventArgs e)
        {
            try
            {
                CursoAñoElectivo curAe = new CursoAñoElectivo();
                curAe.AñoElectivo = Año;

                DataTable dt2 = CtrlCursoAñoElectivo.GetCursoAñoElectivo(curAe).Tables[0];
                   
                //DataTable dt2 = CtrlCursos.GetCursoAll().Tables[0];
                LueCurso.Properties.DataSource = dt2;
                LueCurso.Properties.DisplayMember = "Nombre";
                LueCurso.Properties.ValueMember = "CodigoCurso";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1;
                col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
                LueCurso.Properties.Columns.Clear();
                LueCurso.Properties.Columns.Add(col1);
                LueCurso.ItemIndex = -1;

                dtConsultaPeriodos = CtrlPeriodos.GetPeriodoAll().Tables[0];               
               
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

        private void LueCurso_EditValueChanged(object sender, EventArgs e)
        {
            if (LueCurso.EditValue != null)
            {
                codCurso = LueCurso.EditValue.ToString();
                nomCurso = LueCurso.Text;
            }
        }
       
         #endregion

       
    }
}