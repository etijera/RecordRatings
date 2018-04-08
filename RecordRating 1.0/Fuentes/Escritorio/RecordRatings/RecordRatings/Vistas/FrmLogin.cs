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
using RecordRatings.Controladores;
using Settings;

namespace RecordRatings.Vistas
{
    public partial class FrmLogin : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string NomUsuario { get; set; }
        public string CodPeriodo { get; set; }
        public string NomPeriodo { get; set; }
        public int Año { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;

        #endregion

        #region Metodos
        public FrmLogin()
        {
            InitializeComponent();
        }

        public bool Validar() 
        {
            bool retorno = true;

            if (string.IsNullOrEmpty((TxtUsuario.Text)))
            {
                errorP1.SetError(TxtUsuario, "Debe ingresar el usuario.");
                TxtUsuario.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtUsuario, "");
            }

            if (string.IsNullOrEmpty((TxtPassword.Text)))
            {
                errorP1.SetError(TxtPassword, "Debe ingresar la contraseña.");
                TxtPassword.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtPassword, "");
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

        public bool ValidarLogin() 
        {
            string user = TxtUsuario.Text.Trim();
            string pass = TxtPassword.Text.Trim();
            bool retorno = false;

            DataSet ds = Funciones.getInstancia().ValidarUsuario(user,pass,ConexionDB.getInstancia().Conexion(null, null));
            
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                    XtraMessageBox.Show("Usuario y/o contraseña incorrectos.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    TxtUsuario.Focus();
                }
            }
            else
            {
                retorno = false;
                XtraMessageBox.Show("La base de datos configurada no tiene la estructura necesaria para iniciar sesión. Por favor verifique los ajustes de conexión o comuníquese con el administrador del sistema.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                BtnAjustes.Focus();
            }

            return retorno;
        }

        public void Entrar() 
        {
            if (Validar())
            {
                if (ValidarLogin())
                {
                    CodPeriodo = LuePeriodo.EditValue.ToString();
                    Año = Convert.ToInt32(CmbAño.SelectedItem);
                    NomUsuario = TxtUsuario.Text.Trim();
                    NomPeriodo = LuePeriodo.Text;

                    DialogResult = DialogResult.OK;
                }
            }
        }
        #endregion

        #region Eventos
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void PtbEntrar_MouseEnter(object sender, EventArgs e)
        {
            PtbEntrar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void PtbEntrar_MouseLeave(object sender, EventArgs e)
        {
            PtbEntrar.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void PtbEntrar_Click(object sender, EventArgs e)
        {
            Entrar();
        }

        private void LnkLblMinimizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Entrar();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            DataSet ds = CtrlPeriodos.GetPeriodoAll();

            if (ds.Tables.Count>0)
            {
                DataTable dt3 = ds.Tables[0];
                LuePeriodo.Properties.DataSource = dt3;
                LuePeriodo.Properties.DisplayMember = "Nombre";
                LuePeriodo.Properties.ValueMember = "CodigoPeriodo";

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col2;
                col2 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 100);
                LuePeriodo.Properties.Columns.Add(col2);
                LuePeriodo.ItemIndex = -1; 
            }

            int[] años = new int[20];
            int añoActual =  DateTime.Now.Year;
            int inicioCombo = añoActual - 10;

            for (int i = 0; i < años.Length; i++)
            {
                años[i] = inicioCombo;
                inicioCombo = inicioCombo + 1;
            }

            CmbAño.Properties.Items.AddRange(años);
            CmbAño.SelectedItem = añoActual;
        }

        private void CmbAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Entrar();
            }
        }

        private void LuePeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                Entrar();
            }
        }

        private void BtnAjustes_Click(object sender, EventArgs e)
        {
            FrmConfigurar config = new FrmConfigurar();
            config.ShowDialog();
        }

        #endregion


    }
}