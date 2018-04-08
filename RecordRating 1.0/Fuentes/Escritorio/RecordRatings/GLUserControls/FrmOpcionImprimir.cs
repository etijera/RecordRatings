using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace GLUserControls
{
    public partial class FrmOpcionImprimir : BasicForm
    {
        #region Propiedades

        public RadioGroupItem[] Items { get; set; }
        public int Indice { get; set; }

        #endregion

        #region Metodos

        public FrmOpcionImprimir()
        {
            InitializeComponent();
        }

        public void InicializarItems()
        {
            radioGroupImprimir.Properties.Items.AddRange(Items);

        }

        public void Accept()
        {
            Indice = radioGroupImprimir.SelectedIndex;
            DialogResult = DialogResult.OK;
        }

        #endregion
        #region Eventos

        private void FrmOpcionImprimir_Load(object sender, EventArgs e)
        {
            InicializarItems();
        }

        #endregion


    }
}
