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
using System.Data.SqlClient;
using GLReferences;
using DevExpress.XtraGrid.Columns;
using RecordRatings.Clases;
using RecordRatings.Controladores;
using GLReferences.Properties;

namespace RecordRatings.Vistas
{
    public partial class FrmListaUsuarios : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Usuario { get; set; }

        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        DataTable dtConsulta = new DataTable();
        DataSet dsConsulta = new DataSet();

        #endregion

        #region Metodos

        public FrmListaUsuarios()
        {
            InitializeComponent();
        }

        public void LlenarDsConsulta()
        {
            try
            {

                DataSet ds = CtrlUsuarios.GetUsuarioAll();

                dtConsulta = ds.Tables[0].Copy();
                dsConsulta.Tables.Clear();
                if (dsConsulta.Tables.Count == 0)
                {
                    dsConsulta.Tables.Add(dtConsulta);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        public void LlenarGridConsulta()
        {
            DgvGeneral.Columns.Clear();

            DataViewManager dvm = new DataViewManager(dsConsulta);
            DataView dvMain = dvm.CreateDataView(dsConsulta.Tables[0]);
            DgvGeneral.OptionsBehavior.AutoPopulateColumns = false;
            GctrlGeneral.DataSource = dvMain;
            string[] captions = new[] { "Id", "IdPersona", "Código", "Nombre Usuario", "Contraseña", "CodTipoUsuario", "Tipo Usuario" };

            GridColumn[] col = new GridColumn[dsConsulta.Tables[0].Columns.Count];
            for (int i = 0; i < dsConsulta.Tables[0].Columns.Count; i++)
            {
                col[i] = DgvGeneral.Columns.AddField(dsConsulta.Tables[0].Columns[i].Caption.Trim());
                col[i].VisibleIndex = i;
                col[i].Caption = captions[i];
                col[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                if (i == 0 || i == 1 || i == 4 || i == 5 || i == 2)
                {
                    col[i].Visible = false;
                }
            }
           
            DgvGeneral.Columns[3].Width = 335;
            DgvGeneral.Columns[6].Width = 135;

            Funciones.getInstancia().Configurar_Grid(DgvGeneral);
            DgvGeneral.OptionsCustomization.AllowSort = true;
            DgvGeneral.OptionsView.ColumnAutoWidth = false;
            DgvGeneral.OptionsFind.AlwaysVisible = true;

        }

        public void Añadir() 
        {
            FrmGetUsuarios usuarios = new FrmGetUsuarios();
            usuarios.Database = Database;
            usuarios.Modo = "N";
            usuarios.ShowDialog();

            if (usuarios.DialogResult == DialogResult.OK) 
            {
                if (!BkgwBuscar.IsBusy)
                {
                    PrgBuscar.Visible = true;
                    BkgwBuscar.RunWorkerAsync();
                }
            }

        }

        public void Editar() 
        {
            if (DgvGeneral.RowCount>0 && DgvGeneral.GetFocusedRow() != null)
            {
                int idGeneral = Convert.ToInt32(DgvGeneral.GetFocusedRowCellValue("Id"));
                int idPerson = Convert.ToInt32(DgvGeneral.GetFocusedRowCellValue("IdPersona"));
                FrmGetUsuarios usuarios = new FrmGetUsuarios();
                usuarios.Database = Database;
                usuarios.Modo = "E";
                usuarios.Id = idGeneral;
                usuarios.IdPersona = idPerson;
                usuarios.ShowDialog();

                if (usuarios.DialogResult == DialogResult.OK)
                {
                    if (!BkgwBuscar.IsBusy)
                    {
                        PrgBuscar.Visible = true;
                        BkgwBuscar.RunWorkerAsync();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un registro.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Eliminar() 
        {
            if (DgvGeneral.RowCount > 0 && DgvGeneral.GetFocusedRow() != null)
            {
                int idGeneral = Convert.ToInt32(DgvGeneral.GetFocusedRowCellValue("Id"));
                string tipoUsuario = DgvGeneral.GetFocusedRowCellValue("CodTipoUsuario").ToString();
                int idPersona = Convert.ToInt32(DgvGeneral.GetFocusedRowCellValue("IdPersona").ToString());

                if (tipoUsuario == "01" || tipoUsuario == "04")
                {

                    Usuario usua= new Usuario();
                    usua.Id = idGeneral;
                    usua.Persona.Id = idPersona;               

                    if (XtraMessageBox.Show("¿Esta seguro que desea eliminar el usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CtrlUsuarios.Eliminar(usua);

                        if (!BkgwBuscar.IsBusy)
                        {
                            PrgBuscar.Visible = true;
                            BkgwBuscar.RunWorkerAsync();
                        }
                    }
                }
                else
                {
                    if (tipoUsuario == "02") 
                    {
                        XtraMessageBox.Show("El usuario que intenta eliminar es un profesor; debe eliminarlo por Perfiles/Profesores.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (tipoUsuario == "03")
                    {
                        XtraMessageBox.Show("El usuario que intenta eliminar es un alumno; debe eliminarlo por Perfiles/Alumnos.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar un registro.", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmListaUsuarios_Load(object sender, EventArgs e)
        {
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
            LlenarGridConsulta();
        }


        #endregion     


    }
}