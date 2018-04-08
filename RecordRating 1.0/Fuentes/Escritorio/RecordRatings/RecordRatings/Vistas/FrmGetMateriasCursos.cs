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

namespace RecordRatings.Vistas
{
    public partial class FrmGetMateriasCursos : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Modo { get; set; }
        public string CodCurso { get; set; }
        public string CodMateria { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        private Funciones f = new Funciones();
        string codMateria;
        string codArea;

        #endregion

        #region Metodos
        public FrmGetMateriasCursos()
        {
            InitializeComponent();
        }

        public bool Validar() 
        {
            bool retorno = true;                    

            if (LueMateria.ItemIndex < 0)
            {
                errorP1.SetError(LueMateria, "Debe seleccionar una materia");
                LueMateria.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(LueMateria, "");               
            }

            if (LueProfesor.ItemIndex < 0)
            {
                errorP1.SetError(LueProfesor, "Debe seleccionar un profesor");
                LueProfesor.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(LueProfesor, "");
            }

            if (TxtIhs.EditValue == null || TxtIhs.EditValue.ToString() == "") 
            {
                errorP1.SetError(TxtIhs, "Debe seleccionar un profesor");
                TxtIhs.Focus();
                retorno = false;
            }
            else
            {
                if (Convert.ToInt32(TxtIhs.EditValue) == 0) 
                {
                    errorP1.SetError(TxtIhs, "Debe seleccionar un profesor");
                    TxtIhs.Focus();
                    retorno = false;
                }
                else
                {
                    errorP1.SetError(TxtIhs, "");   
                }
            }

            return retorno;
        }

        public void Accept() 
        {
            if (Validar())
            {               
                    if (Modo != "E")
                    {
                        InsertarActualizar("INSERT");
                        LimpiarVentana();
                    }
                    else
                    {
                        InsertarActualizar("UPDATE");
                    }

                    DialogResult = DialogResult.OK;                
            }
        }        

        private void LimpiarVentana()
        {
            TxtNombre.Text = "";
            LueMateria.ItemIndex = -1;
            LueProfesor.ItemIndex = -1;
            TxtIhs.EditValue = 0;
        }

        private void CargarDatos(string modo)
        {
            if (modo == "E")
            {
                MateriasCurso mtC = new MateriasCurso();
                mtC.Curso.CodigoCurso = CodCurso;
                mtC.Materia.CodMateria = CodMateria;
                DataSet ds = CtrlMateriasCursos.GetMateriasCursosOne(mtC);
                DataRow dr = ds.Tables[0].Rows[0];

                TxtNombre.Text = dr["NombreCurso"].ToString();
                LueProfesor.EditValue = dr["CodProfesor"].ToString();
                LueMateria.EditValue = dr["CodMateria"].ToString();
                TxtIhs.EditValue = Convert.ToInt32(dr["IHS"]);
                TxtPorcentaje.EditValue = Convert.ToInt32(dr["Porcentaje"]);
                
            }
            else
            {
                MateriasCurso mtC = new MateriasCurso();
                mtC.Curso.CodigoCurso = CodCurso;
                DataSet ds = CtrlMateriasCursos.GetCursosOne(mtC);
                DataRow dr = ds.Tables[0].Rows[0];

                TxtNombre.Text = dr["NombreCurso"].ToString();
            }
          
        }

        private void InsertarActualizar(string modo)
        {
            try
            {
                if (modo == "INSERT") 
                {
                    MateriasCurso mtC = new MateriasCurso();
                    mtC.Curso.CodigoCurso = CodCurso;
                    mtC.Materia.CodMateria = LueMateria.EditValue.ToString();
                    mtC.Profesor.CodigoProfesor = LueProfesor.EditValue.ToString();
                    mtC.IHS = Convert.ToInt32(TxtIhs.EditValue);
                    mtC.Area.Codigo = codArea;
                    mtC.Porcentaje = Convert.ToInt32(TxtPorcentaje.EditValue);

                    if (CtrlMateriasCursos.Insertar(mtC) > 0)
                    {
                         XtraMessageBox.Show("Materia asignada con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {
                    MateriasCurso mtC = new MateriasCurso();
                    mtC.Curso.CodigoCurso = CodCurso;
                    mtC.Materia.CodMateria = LueMateria.EditValue.ToString();
                    mtC.Profesor.CodigoProfesor = LueProfesor.EditValue.ToString();
                    mtC.IHS = Convert.ToInt32(TxtIhs.EditValue);
                    mtC.Porcentaje = Convert.ToInt32(TxtPorcentaje.EditValue);

                    if (CtrlMateriasCursos.Actualizar(mtC) > 0)
                    {
                        XtraMessageBox.Show("Materia asignada con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }
            }
            catch (Exception ex)
            {
                 XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);                
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

        private void FrmGetMateriasCursos_Load(object sender, EventArgs e)
        {
            try
            {
                MateriasCurso mtC = new MateriasCurso();
                mtC.Curso.CodigoCurso = CodCurso;
                DataTable dt1 = new DataTable();
                if (Modo != "E") 
                {
                    dt1 = CtrlMateriasCursos.GetMateNoAsigNadas(mtC).Tables[0];
                }
                else
                {
                    dt1 = CtrlMateriasCursos.GetMateAsigNadas(mtC).Tables[0];
                    LueMateria.Enabled = false;
                }             

                LueMateria.Properties.DataSource = dt1;
                LueMateria.Properties.DisplayMember = "Nombre";
                LueMateria.Properties.ValueMember = "CodMateria";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col;
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);         
                LueMateria.Properties.Columns.Add(col);
                LueMateria.ItemIndex = -1;               

                CargarDatos(Modo);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }
           
            TxtNombre.Focus();
           
           
        }                

        private void LueMateria_EditValueChanged(object sender, EventArgs e)
        {
            if (LueMateria.EditValue != null) 
            {
                LueProfesor.Enabled = true;
                codMateria = LueMateria.EditValue.ToString();

                Materia mat = new Materia();
                mat.CodMateria = codMateria;
                DataSet ds = CtrlMaterias.GetMateriaOneCod(mat);
                TxtNombreArea.Text = ds.Tables[0].Rows[0]["NombreArea"].ToString();
                codArea = ds.Tables[0].Rows[0]["CodArea"].ToString();

               try
               {
                    ProfesorMaterias prMat = new ProfesorMaterias();
                    prMat.Materia.CodMateria = codMateria;

                    DataTable dt2 = CtrlProfesorMaterias.GetProfesorMat(prMat).Tables[0];
                    LueProfesor.Properties.DataSource = dt2;
                    LueProfesor.Properties.DisplayMember = "Nombre";
                    LueProfesor.Properties.ValueMember = "CodigoProfesor";

                    DevExpress.XtraEditors.Controls.LookUpColumnInfo col1;
                    col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
                    LueProfesor.Properties.Columns.Clear();
                    LueProfesor.Properties.Columns.Add(col1);
                    LueProfesor.ItemIndex = -1;
                   

                }
                 catch (Exception ex)
                 {
                     XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                     return;
                 }
            }

        }

         #endregion
            
    }
}