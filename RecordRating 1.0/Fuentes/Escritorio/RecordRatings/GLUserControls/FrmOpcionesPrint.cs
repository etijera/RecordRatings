using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLUserControls;

namespace GLUserControls
{
    public partial class FrmOpcionesPrint : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public String[] Opciones { get; set; }
        public int IndiceSelccionado { get; set; }

        #endregion

        #region Metodos

        public FrmOpcionesPrint()
        {
            InitializeComponent();
        }

        public void Imprimir()
        {
            if (CmbOpcionesPrint.SelectedIndex != -1)
            {
                IndiceSelccionado = CmbOpcionesPrint.SelectedIndex;
                DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("Debe seleccionar una opcion", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region eventos 

        private void FrmOpcionesPrint_Load(object sender, EventArgs e)
        {
            CmbOpcionesPrint.Properties.Items.AddRange(Opciones);
        }

        #endregion
    }
}
