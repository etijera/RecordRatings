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
    public partial class FrmGetBackup : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }
        public int Id { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        private Funciones f = new Funciones();

        #endregion

        #region Metodos
        public FrmGetBackup()
        {
            InitializeComponent();
        }

        public bool Validar() 
        {
            bool retorno = true;

            if (string.IsNullOrEmpty((TxtUbicacion.Text)))
            {
                errorP1.SetError(TxtUbicacion, "Debe ingresar la ubicación.");
                TxtUbicacion.Focus();
                retorno = false;
            }
            else
            {
                errorP1.SetError(TxtUbicacion, "");
            }           

            return retorno;
        }        

        private void RealizarBackup()
        {
            try
            {
                String ubicacionNombreArchivo = "";
                String nombreDatabase = "";
                String nombreDesc = "";

                ubicacionNombreArchivo = TxtUbicacion.Text + @"\RecorRating_" + (DateTime.Now.Year).ToString() + (DateTime.Now.Day).ToString() + (DateTime.Now.Hour).ToString() + (DateTime.Now.Minute).ToString() + ".bak";
                nombreDatabase = Database;
                nombreDesc = "BackUp de la base de datos " + Resources.AppName;

                DataSet ds = CtrlBackup.RealizarBackup(ubicacionNombreArchivo, nombreDatabase, nombreDesc);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString()=="OK")
                    {
                        XtraMessageBox.Show("Backup realizado con exito.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                    else
                    {
                        XtraMessageBox.Show(ds.Tables[0].Rows[0][0].ToString(), Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
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

        private void FrmGetBackup_Load(object sender, EventArgs e)
        {                       
            BtnUbicacion.Focus();                 
        }

        private void TxtUsuario_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrEmpty((TxtUbicacion.Text))) 
            {
                errorP1.SetError(TxtUbicacion, "Debe ingresar la ubicación.");
                TxtUbicacion.Focus();
            }
            else
            {
                errorP1.SetError(TxtUbicacion, "");
            }
            
        }  
  
        private void BtnUbicacion_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TxtUbicacion.Text = folderBrowserDialog1.SelectedPath;
            }
        }          

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            if (Validar())
            {                                 
                if (!BkgwBuscar.IsBusy)
                {
                    PrgBuscar.Visible = true;
                    BtnBackup.Enabled = false;
                    BtnUbicacion.Enabled = false;
                    BkgwBuscar.RunWorkerAsync();
                }
            } 
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BkgwBuscar_DoWork(object sender, DoWorkEventArgs e)
        {            
            RealizarBackup(); 
        }

        private void BkgwBuscar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PrgBuscar.Visible = false;
            BtnBackup.Enabled = true;
            BtnUbicacion.Enabled = true;

            DialogResult = DialogResult.OK;
        }

         #endregion




       



    }
}