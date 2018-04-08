using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using GLReferences;

namespace GLReferences.Reports
{
    public partial class RptReciboCaja2 : DevExpress.XtraReports.UI.XtraReport
    {
        #region

        public string Database { get; set; }
        public String Fecha { get; set; }

        #endregion

        #region Metodos

        public RptReciboCaja2()
        {
            InitializeComponent();
        }

        public void Empresa()
        {
            String cad = String.Format("SELECT nomempresa,nitempresa,conciudad FROM gl_cfg");
            DataSet ds = DataBase.ExecuteQuery(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

            xrLblTitulo.Text = ds.Tables[0].Rows[0]["nomempresa"].ToString();
            xrLblNit.Text = "Nit. " + ds.Tables[0].Rows[0]["nitempresa"].ToString();
            XrLblCiudad.Text = ds.Tables[0].Rows[0]["conciudad"].ToString() + ", " + Fecha; ;

        }

        #endregion

        /*private void xrLabel26_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(XrlblEfectivo.Text))
            {
                XrlblFechaCheque.Text = "";
            }
        }

        private void XrlblEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(XrlblEfectivo.Text))
            {
                XrlblFechaCheque.Text = "";
            }
        }*/

    }
}
