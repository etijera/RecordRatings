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
using RecordRatings.Clases;
using RecordRatings.Controladores;
using GLReferences.Properties;

namespace RecordRatings.Vistas
{
    public partial class FrmInstitucion : BasicForm
    {

        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        string imageUrl = "";

        #endregion

        #region Metodos

        public FrmInstitucion()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {            
            DataSet ds = CtrlInstitucion.GetInstitucionAll();
            DataRow dr = ds.Tables[0].Rows[0];

            TxtNombre.Text = dr["Nombre"].ToString();
            TxtAbreviatura.Text = dr["Abreviaura"].ToString();
            TxtNit.Text = dr["Nit"].ToString();
            TxtLema.Text = dr["Lema"].ToString();
            TxtDireccion.Text = dr["Direccion"].ToString();
            TxtEmail.Text = dr["Email"].ToString();     
            TxtTelefono.Text = dr["Telefono"].ToString();
            TxtResolucion.Text = dr["Resolusion"].ToString(); 
            TxtDirector.Text = dr["Director"].ToString();
            TxtCodDane.Text = dr["CodigoDane"].ToString();

            try
            {
                PicEdit1.Image = (dr["Logo"].ToString() != "") ? Image.FromFile(dr["Logo"].ToString()) : null;
                imageUrl = dr["Logo"].ToString();

            }
            catch (Exception ex)
            {
                 XtraMessageBox.Show("No se encontro la imagen: " + dr["Logo"].ToString(), Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);                
            }

            TxtCoordinador.Text = dr["Coordinador"].ToString();
            TxtSecretaria.Text = dr["Secretaria"].ToString();
     
        }

        public void Accept()
        {                        
            ActualizarInformacion();                
            DialogResult = DialogResult.OK;
                        
        }

        private void ActualizarInformacion()
        {          
            Institucion institucion = new Institucion();
            institucion.Nombre = TxtNombre.Text.Trim();
            institucion.Nit = TxtNit.Text.Trim();
            institucion.Direccion = TxtDireccion.Text.Trim();
            institucion.Telefono = TxtTelefono.Text.Trim();
            institucion.Email = TxtEmail.Text.Trim();
            institucion.Resolusion = TxtResolucion.Text.Trim();
            institucion.CodigoDane = TxtCodDane.Text.Trim();
            institucion.Abreviaura = TxtAbreviatura.Text.Trim();
            institucion.Lema = TxtLema.Text.Trim();
            institucion.Director = TxtDirector.Text.Trim();
            institucion.Secretaria = TxtSecretaria.Text.Trim();
            institucion.Coordinador = TxtCoordinador.Text.Trim();
            institucion.Logo = imageUrl;            

            if (CtrlInstitucion.Actualizar(institucion) > 0)
            {
                XtraMessageBox.Show("Información actualizada con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
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

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PicEdit1.Image = Image.FromFile(openFileDialog1.FileName);
                imageUrl = openFileDialog1.FileName;
            }
        }

        private void FrmInstitucion_Load(object sender, EventArgs e)
        {
            TxtNombre.Focus();
            CargarDatos();
        }


        #endregion

    }
}