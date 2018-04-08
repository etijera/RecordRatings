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
    public partial class FrmGetCursos : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Modo { get; set; }
        public int Id { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        private Funciones f = new Funciones();

        #endregion

        #region Metodos
        public FrmGetCursos()
        {
            InitializeComponent();
        }

        public bool Validar() 
        {
            bool retorno = true;

            if (string.IsNullOrEmpty((TxtNombre.Text)))
            {
                errorP1.SetError(TxtNombre, "Debe ingresar el nombre.");
                TxtNombre.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtNombre, "");
            }           

            if (LueGrado.ItemIndex < 0)
            {
                errorP1.SetError(LueGrado, "Debe seleccionar un grado");
                LueGrado.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(LueGrado, "");               
            }

            if (LueGrupo.ItemIndex < 0)
            {
                errorP1.SetError(LueGrupo, "Debe seleccionar un grupo");
                LueGrupo.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(LueGrupo, "");
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
            LueGrado.ItemIndex = -1;
            LueGrupo.ItemIndex = -1;
        }

        private void CargarDatos(int id)
        {
            Curso cur = new Curso();
            cur.Id = id;
            DataSet ds = CtrlCursos.GetCursoOne(cur);
            DataRow dr = ds.Tables[0].Rows[0];
            
            TxtNombre.Text = dr["Nombre"].ToString();
            LueGrado.EditValue = dr["CodGrado"].ToString();
            LueGrupo.EditValue = dr["CodGrupo"].ToString();

            if (dr["Jornada"].ToString() == "Mañana")
            {
                CmbJornada.SelectedIndex = 0;
            }
            else
            {
                CmbJornada.SelectedIndex = 1;
            }
        }

        private void InsertarActualizar(string modo)
        {
            try
            {
                if (modo == "INSERT") 
                {
                    Curso curso = new Curso();
                    curso.Nombre = TxtNombre.Text.Trim();
                    curso.Grado.CodigoGrado = LueGrado.EditValue.ToString();
                    curso.Grupo.CodigoGrupo = LueGrupo.EditValue.ToString();
                    curso.Jornada = CmbJornada.Text;

                    if (CtrlCursos.Insertar(curso) > 0)
                    {
                         XtraMessageBox.Show("Curso insertada con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {
                    Curso curso = new Curso();
                    curso.Id = Id;
                    curso.Nombre = TxtNombre.Text.Trim();
                    curso.Grado.CodigoGrado = LueGrado.EditValue.ToString();
                    curso.Grupo.CodigoGrupo = LueGrupo.EditValue.ToString();
                    curso.Jornada = CmbJornada.Text;

                    if (CtrlCursos.Actualizar(curso) > 0)
                    {
                        XtraMessageBox.Show("Curso actualizada con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
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

        private void FrmGetCursos_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = CtrlGrados.GetGradoAll().Tables[0];               

                LueGrado.Properties.DataSource = dt1;
                LueGrado.Properties.DisplayMember = "Nombre";
                LueGrado.Properties.ValueMember = "CodigoGrado";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col;
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);         
                LueGrado.Properties.Columns.Add(col);
                LueGrado.ItemIndex = -1;

                DataTable dt2 = CtrlGrupos.GetGrupoAll().Tables[0];
                LueGrupo.Properties.DataSource = dt2;
                LueGrupo.Properties.DisplayMember = "Nombre";
                LueGrupo.Properties.ValueMember = "CodigoGrupo";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1;
                col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);                
                LueGrupo.Properties.Columns.Add(col);
                LueGrupo.ItemIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }
           
            TxtNombre.Focus();
            if (Modo == "E" && Id > 0) 
            {
                CargarDatos(Id);
            }
           
        }
         
        private void LueGrado_EditValueChanged(object sender, EventArgs e)
        {
            TxtNombre.Text = LueGrado.Text + " " + LueGrupo.Text;
        }
         
        private void LueGrupo_EditValueChanged(object sender, EventArgs e)
        {
            TxtNombre.Text = LueGrado.Text + " " + LueGrupo.Text;
        }

         #endregion

    }
}