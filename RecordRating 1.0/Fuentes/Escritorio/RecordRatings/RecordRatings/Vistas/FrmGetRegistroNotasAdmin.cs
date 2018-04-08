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
    public partial class FrmGetRegistroNotasAdmin : BasicForm
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
        private string codProfesor = "";
        private string codCurso = "";
        private string codMateria = "";

        #endregion

        #region Metodos
        public FrmGetRegistroNotasAdmin()
        {
            InitializeComponent();
        }

        public bool Validar() 
        {
            bool retorno = true;

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

            return retorno;
        }

        public void Accept() 
        {
            if (Validar())
            {
                FrmRegistrarNotas regisNot = new FrmRegistrarNotas();
                regisNot.Database = Database;
                regisNot.CodProfesor = codProfesor;
                regisNot.NomProfesor = LueProfesor.Text;
                regisNot.CodCurso = codCurso;
                regisNot.NomCurso = LueCurso.Text;
                regisNot.CodPeriodo = LuePeriodo.EditValue.ToString();
                regisNot.NomPeriodo = LuePeriodo.Text;
                regisNot.CodMateria = codMateria;
                regisNot.NomMateria = LueMateria.Text;
                regisNot.Año = Año;
                regisNot.ShowDialog();
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

        private void FrmGetRegistroNotasAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                CursoAñoElectivo curAe = new CursoAñoElectivo();
                curAe.AñoElectivo = Año;

                DataTable dt2 = CtrlCursoAñoElectivo.GetCursoAñoElectivo(curAe).Tables[0];
                LueCurso.Properties.DataSource = dt2;
                LueCurso.Properties.DisplayMember = "Nombre";
                LueCurso.Properties.ValueMember = "CodigoCurso";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1;
                col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
                LueCurso.Properties.Columns.Clear();
                LueCurso.Properties.Columns.Add(col1);
                LueCurso.ItemIndex = -1;

                LueMateria.ItemIndex = -1;
                LueMateria.Enabled = false;
                LueMateria.Properties.DataSource = null;               


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

        private void LueProfesor_EditValueChanged(object sender, EventArgs e)
        {
            if (LueProfesor.EditValue != null) 
            {
                codProfesor = LueProfesor.EditValue.ToString();
            }           
        }               
      
        private void LueMateria_EditValueChanged(object sender, EventArgs e)
        {
            if (LueMateria.EditValue != null)
            {
                LueProfesor.Enabled = true;
                codMateria = LueMateria.EditValue.ToString();
            }

            try
            {               

                RegistroNota regN = new RegistroNota();
                regN.Curso.CodigoCurso = codCurso;
                regN.Materia.CodMateria = codMateria;

                DataTable dt2 = CtrlRegistroNotas.GetProfeMateriasCurso(regN).Tables[0];
                LueProfesor.Properties.DataSource = dt2;
                LueProfesor.Properties.DisplayMember = "Nombre";
                LueProfesor.Properties.ValueMember = "CodProfesor";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1;
                col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
                LueProfesor.Properties.Columns.Clear();
                LueProfesor.Properties.Columns.Add(col1);
                LueProfesor.ItemIndex = 1;


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }

        }

        private void BtnRegistrarNotas_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void LueCurso_EditValueChanged(object sender, EventArgs e)
        {
            if (LueCurso.EditValue != null)
            {
                LueMateria.Enabled = true;
                codCurso = LueCurso.EditValue.ToString();
            }

            try
            {
                RegistroNota regN = new RegistroNota();
                regN.Curso.CodigoCurso = codCurso;

                DataTable dt2 = CtrlRegistroNotas.GetMateriasCursos(regN).Tables[0];
                LueMateria.Properties.DataSource = dt2;
                LueMateria.Properties.DisplayMember = "Nombre";
                LueMateria.Properties.ValueMember = "CodMateria";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1;
                col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
                LueMateria.Properties.Columns.Clear();
                LueMateria.Properties.Columns.Add(col1);
                LueMateria.ItemIndex = -1;
                LueMateria.EditValue = null;

                LueProfesor.ItemIndex = -1;
                LueProfesor.Enabled = false;
                LueProfesor.Properties.DataSource = null;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }
        }


         #endregion


       



    }
}