using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using GLReferences;

namespace GLReferences.Reports
{
    public partial class RptRemiDevoEmpaque : DevExpress.XtraReports.UI.XtraReport
    {
        #region Propiedades

        public string Database { get; set; }
        public bool Desocupado { get; set; }
        public String FechaIni { get; set; }
        public String FechaFin { get; set; }

        #endregion

        #region Metodos

        public RptRemiDevoEmpaque()
        {
            InitializeComponent();
        }

        public void Empresa()
        {

            String cad = String.Format("SELECT	nomempresa,nitempresa,dirempresa,contelefono,logempresa FROM gl_cfg");
            DataSet ds = DataBase.ExecuteQuery(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

            XrlblNombreEmpresa.Text = ds.Tables[0].Rows[0]["nomempresa"].ToString();
            XlrblNitEmpresa.Text = "Nit. " + ds.Tables[0].Rows[0]["nitempresa"].ToString();

        }

        #endregion

        private void xrLabel49_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            Double valorTotal = Convert.ToDouble(e.Value);

            String montoEscrito = Funciones.getInstancia().ConvertirDobleAMontoEnLetras(valorTotal, "PESOS", "CENTAVOS", true);

            e.Text = montoEscrito;
        }
    }
}
