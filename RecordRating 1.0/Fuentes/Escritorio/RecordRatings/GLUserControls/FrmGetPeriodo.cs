using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using GLReferences;

namespace GLUserControls
{
    public partial class FrmGetPeriodo : BasicForm
    {
        #region Propiedades

        public String Database { get; set; }
        public String Fecha { get; set; }
        public String Titulo { get; set; }
        public DateTime FechaDate { get; set; }

        #endregion

        #region Metodos

        public FrmGetPeriodo()
        {
            InitializeComponent();
            TxtFecha.DateTime = DateTime.Now;
        }

        public void Accept()
        {
            Fecha = Funciones.getInstancia().Datetime2String(TxtFecha.DateTime);
            FechaDate = TxtFecha.DateTime;

            DialogResult = DialogResult.OK;
        }

        #endregion

        #region Eventos

        private void FrmGetFechaOne_Load(object sender, EventArgs e)
        {
            this.Text = Titulo;
            TxtFecha.Focus();
        }

        #endregion
    }
}
