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
    public partial class FrmGetFechaOne : BasicForm
    {
        #region Propiedades

        public String Database { get; set; }
        public String Fecha { get; set; }
        public String Titulo { get; set; }
        public DateTime FechaDate { get; set; }
        public bool ValidarFechaActual { get; set; }
        public bool ValidarPeriodo { get; set; }
        public bool ValidarCierre { get; set; }
        public int MesPeriodo { get; set; }
        public int AñoPeriodo { get; set; }

        #endregion

        #region Metodos

        public FrmGetFechaOne()
        {
            InitializeComponent();
            fecha1.FechaInicial = GLReferences.Fechas.Hoy;
        }

        public void Accept()
        {
            if (Validar())
            {
                Fecha = fecha1.Inicio;
                FechaDate = fecha1.CampoFecha;

                DialogResult = DialogResult.OK;
            }
        }

        public bool Validar()
        {
            bool retorno = true;

            if (ValidarFechaActual)
            {
                if (fecha1.CampoFecha.Date < DateTime.Now.Date)
                {
                    XtraMessageBox.Show("La  fecha seleccionada no puede ser menor que la fecha actual.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fecha1.Focus();
                    return false;
                }
                else
                {
                    retorno = true;
                }
            }

            if (ValidarPeriodo)
            {
                if (MesPeriodo != fecha1.CampoFecha.Month || AñoPeriodo != fecha1.CampoFecha.Year)
                {
                    String mes = Funciones.getInstancia().Numero2Mes(MesPeriodo);
                    XtraMessageBox.Show("El documento que intenta crear no corresponde al periodo que se esta trabajando (" + mes + " de " + AñoPeriodo + "). Por favor verifique.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fecha1.Focus();
                    return false;
                }
            }

            if (ValidarCierre)
            {
                String sql = "SELECT ccest FROM accglccmes WHERE ccMes ='" + MesPeriodo + "' AND ccAño ='" + AñoPeriodo + "'";

                DataSet ds = DataBase.ExecuteQuery(sql, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

                bool cierre = false;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cierre = Convert.ToBoolean(ds.Tables[0].Rows[0]["ccest"]);
                }

                if (cierre)
                {
                    String mes = Funciones.getInstancia().Numero2Mes(MesPeriodo);
                    XtraMessageBox.Show("Error, el período (" + mes + " de " + AñoPeriodo + ") está cerrado. Por favor verifique.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fecha1.Focus();
                    return false;
                }
            }

            return retorno;
        }


        #endregion

        #region Eventos

        private void FrmGetFechaOne_Load(object sender, EventArgs e)
        {
            this.Text = Titulo;
            if (MesPeriodo == 0)
            {
                MesPeriodo = fecha1.CampoFecha.Month;
            }

            if (AñoPeriodo == 0)
            {
                AñoPeriodo = fecha1.CampoFecha.Year;
            }
            fecha1.Focus();

        }

        #endregion
    }
}
