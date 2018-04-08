using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GLReferences;
using DevExpress.XtraEditors;

namespace GLUserControls
{
    public partial class FrmGetFecha : BasicForm
    {
        #region Propiedades

        public String Database { get; set; }
        public String FechaInicio { get; set; }
        public String FechaFin { get; set; }

        #endregion

        #region Metodos

        public FrmGetFecha()
        {
            InitializeComponent();
        }

        public void Accept()
        {

            FechaInicio = rangoFecha1.Inicio;
            FechaFin = rangoFecha1.Fin;

            DialogResult = DialogResult.OK;
        }

        public void DeshabilitarFecha(int Indice)
        {
            rangoFecha1.DeshabilitarFecha(Indice);
        }
        #endregion

        private void FrmGetFecha_Load(object sender, EventArgs e)
        {
            try
            {
                rangoFecha1.FechaInicio = Convert.ToDateTime((FechaInicio == "" ? DateTime.Now.ToString() : (FechaInicio.Length == 8 ? Funciones.getInstancia().FormatoFecha(FechaInicio) : FechaInicio)));//Funciones.getInstancia().FormatoFecha()
                rangoFecha1.FechaFin = Convert.ToDateTime((FechaFin == "" ? DateTime.Now.ToString() : (FechaFin.Length == 8 ? Funciones.getInstancia().FormatoFecha(FechaFin) : FechaFin)));//Funciones.getInstancia().FormatoFecha()
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }
    }
}
