using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLReferences;
using DevExpress.XtraEditors;

namespace GLUserControls
{
    public partial class FrmShowPerfiles : BasicForm
    {

        private DataSet dsPerfiles;
        private DataTable dtPerfiles;

        public FrmShowPerfiles()
        {
            InitializeComponent();
        }

        public void Añadir()
        {
            FrmAñadirEditarPerfiles frm = new FrmAñadirEditarPerfiles();
            frm.Dbase = null;
            //frm.Perfil = GvGeneral.GetFocusedRowCellValue("Id").ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LlenarGrid();
            }

        }

        public void Editar()
        {
            FrmAñadirEditarPerfiles frm = new FrmAñadirEditarPerfiles();
            frm.Dbase = null;
            frm.Perfil = GvGeneral.GetFocusedRowCellValue("Id").ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LlenarGrid();
            }

        }

        private void LlenarGrid()
        {
            dsPerfiles = new DataSet();
            dtPerfiles = new DataTable();

            DataColumn DtColumn1 = new DataColumn();
            DataColumn DtColumn2 = new DataColumn();

            DtColumn1.ColumnName = "Id";
            DtColumn2.ColumnName = "Titulo";

            dtPerfiles.Columns.Add(DtColumn1);
            dtPerfiles.Columns.Add(DtColumn2);


            foreach (var item in Perfilador.getInstancia().ListarPerfiles())
            {
                dtPerfiles.Rows.Add(item);
            }

            dsPerfiles.Tables.Add(dtPerfiles);

            DataViewManager dvm = new DataViewManager(dsPerfiles);
            DataView dvMain = dvm.CreateDataView(dsPerfiles.Tables[0]);
            GctrlGeneral.DataSource = dvMain;
        }

        private void CambiarUbicacion(string ruta)
        {
            Perfil perfil = null;
            for (int i = 0; i < dsPerfiles.Tables[0].Rows.Count; i++)
            {
                perfil = Perfilador.getInstancia().CargarPerfil(dsPerfiles.Tables[0].Rows[i]["Id"].ToString());

                if (!String.IsNullOrEmpty(perfil.Proyecto))
                {
                    string[] str = perfil.Proyecto.Split('\\');
                    perfil.Proyecto = ruta + '\\' + str[str.Length - 1];

                    Perfilador.getInstancia().ModificarPerfil(perfil);
                }
            }
        }

        private void FrmShowPerfiles_Load(object sender, EventArgs e)
        {

            Funciones.getInstancia().Configurar_Grid(GvGeneral);

            LlenarGrid();
        }

        private void BtnReubicar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog proyecto = new FolderBrowserDialog();
            string dir = null;
            if (proyecto.ShowDialog() == DialogResult.OK)
            {
                dir = proyecto.SelectedPath;
            }

            if (XtraMessageBox.Show("¿Está seguro que desea cambiar la ubicación de los archivos de configuración del perfil?", GLReferences.Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                CambiarUbicacion(dir);
        }

        private void GctrlGeneral_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }

    }
}
