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
using System.Data.Sql;
using System.Xml;
using System.Data.SqlClient;
using GLUserControls;

namespace Settings
{
    public partial class FrmConfigurar : BasicForm
    {
        #region Propiedades
        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        DataTable dtInstancias = new DataTable();
        XmlDocument myXmlDocument = new XmlDocument();
        XmlNodeList config;       

        #endregion

        #region Metodos

        public FrmConfigurar()
        {
            InitializeComponent();
        }

        private void BuscarInstancias()
        {            
            // Retrieve the enumerator instance and then the data.
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable dt1 = instance.GetDataSources();

            dtInstancias = dt1.Copy();
        }

        public void LeerConfiguracionActual()
        {
            string servidor = "";
            string db = "";
            string usuario = "";
            string pass = "";

            myXmlDocument.Load(System.Windows.Forms.Application.StartupPath + @"/RecordRatings.exe.config");
            config = myXmlDocument.GetElementsByTagName("appSettings");
            //XmlNodeList listaValidacion = ((XmlElement)config[0]).GetElementsByTagName("connectionString");
            string cadenaconexion = ((XmlElement)config[0]).GetElementsByTagName("add")[6].Attributes["value"].Value.ToString();
            string[] vector = cadenaconexion.Split(';');

            servidor = vector[0].Split('=')[1];
            db = vector[1].Split('=')[1];
            usuario = vector[2].Split('=')[1];
            pass = vector[3].Split('=')[1];

            int iRowItem = 0;

            for (int i = 0; i < CmbInstancia.Properties.Items.Count; i++)
            {
                if (servidor == CmbInstancia.Properties.Items[i].ToString())
                {
                    iRowItem = i;
                    break;
                }
            }

            if (CmbInstancia.Properties.Items.Count>0)
            {
                CmbInstancia.SelectedIndex = iRowItem;
            }
            else
            {
                CmbInstancia.SelectedIndex = -1;
            }

            TxtBaseDatos.Text = db;
            TxtUsuario.Text = usuario;
            TxtPass.Text = pass;
            
        }

        private void LlenarComboInstancias()
        {
            string nombreInstancia = "";
            string nombreServidor = "";
            string nombreCompleto = "";

            for (int i = 0; i < dtInstancias.Rows.Count; i++)
            {
                nombreServidor = (dtInstancias.Rows[i]["ServerName"].ToString());
                nombreInstancia = (dtInstancias.Rows[i]["InstanceName"].ToString());

                nombreCompleto = nombreServidor + (string.IsNullOrEmpty(nombreInstancia) ? "" : @"\" + nombreInstancia);
                CmbInstancia.Properties.Items.Add(nombreCompleto);
            }

            if (CmbInstancia.Properties.Items.Count > 0)
            {
                CmbInstancia.SelectedIndex = 0;
            }
        }

        public void Accept() 
        {
            if (Validar())
            {
                ActualizarConfig(ArmarCadenaConexion());
                XtraMessageBox.Show("Recuerde que debe reiniciar para que los cambios surtan efecto.", "RecordRatings 1.0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }            
        }

        public void ActualizarConfig(string cadenaConexion)
        {                        
            ((XmlElement)config[0]).GetElementsByTagName("add")[6].Attributes["value"].Value = cadenaConexion;
            myXmlDocument.Save(System.Windows.Forms.Application.StartupPath + @"/RecordRatings.exe.config");
        }

        public string ArmarCadenaConexion()
        {
            string nuevaCadena = "";
            string servidor = "";
            string db = "";
            string usuario = "";
            string pass = "";
           
            servidor = "Data Source=" + CmbInstancia.Text + "; ";
            db = "Initial Catalog=" + TxtBaseDatos.Text + "; ";
            usuario = "user=" + TxtUsuario.Text + "; ";
            pass = "password=" + TxtPass.Text;

            nuevaCadena = servidor + db + usuario + pass;

            return nuevaCadena;
        }

        public bool Validar() 
        {
            bool retorno = true;

            if (string.IsNullOrEmpty((CmbInstancia.Text)))
            {
                errorP1.SetError(CmbInstancia, "Debe ingresar la instancia.");
                CmbInstancia.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(CmbInstancia, "");
            }

            if (string.IsNullOrEmpty((TxtBaseDatos.Text)))
            {
                errorP1.SetError(TxtBaseDatos, "Debe ingresar la base de datos.");
                TxtBaseDatos.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtBaseDatos, "");
            }

            if (string.IsNullOrEmpty((TxtPass.Text)))
            {
                errorP1.SetError(TxtPass, "Debe ingresar la contraseña.");
                TxtPass.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtPass, "");
            }

            return retorno;
        }


        #endregion

        #region Eventos


        #region MovVentana

        private void LnkLblCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void FrmConfigurar_Load(object sender, EventArgs e)
        {
            if (!BkgwBuscar.IsBusy)
            {
                PrgBuscar.Visible = true;
                panel1.Enabled = false;
                acceptCancel1.HabilitarAceptar  = false;
                BkgwBuscar.RunWorkerAsync();
            }
            
        }

        private void LnkLblCerrar_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void LnkLblMinimizar_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BkgwBuscar_DoWork(object sender, DoWorkEventArgs e)
        {
            BuscarInstancias();
        }

        private void BkgwBuscar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LlenarComboInstancias();
            PrgBuscar.Visible = false; 
            panel1.Enabled = true;
            acceptCancel1.HabilitarAceptar = true;

            LeerConfiguracionActual();
        }

        private void BtnNombre_Click(object sender, EventArgs e)
        {            
            if (Validar())
            {
                string msj = "";
                try
                {

                    SqlConnection cn = new SqlConnection(ArmarCadenaConexion());
                    cn.Open();

                    if (cn.State == ConnectionState.Open)
                    {
                        msj = "Parametros de conexión correctos.";
                        cn.Close();
                    }
                    else
                    {
                        msj = "Parametros de conexión incorrectos.";
                    }

                    XtraMessageBox.Show(msj, "RecordRatings 1.0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
                catch (Exception ex)
                {
                    msj = "Parametros de conexión incorrectos. ERROR: " + ex.Message;
                    XtraMessageBox.Show(msj, "RecordRatings 1.0", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                } 
            }
        }

        #endregion

    }
}