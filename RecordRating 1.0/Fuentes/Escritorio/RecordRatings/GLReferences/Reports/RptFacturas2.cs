using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using GLReferences;
using System.Data.SqlClient;

namespace GLReferences.Reports
{
    public partial class RptFacturas2 : DevExpress.XtraReports.UI.XtraReport
    {
        #region Propiedades
        public string Database { get; set; }

        #endregion

        #region Metodos

        public RptFacturas2()
        {
            InitializeComponent();
        }

        public void Empresa()
        {
            SqlParameter[] parametros = new [] { new SqlParameter("@Operacion", "S") };

            DataSet dsDatos = DataBase.ExecuteQuery("PA_DatosEmpresa", "datos", CommandType.StoredProcedure, parametros, ConexionDB.getInstancia().Conexion(Database, null));

            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                String nombre = dsDatos.Tables[0].Rows[0]["Nombre"].ToString();
                String nit = dsDatos.Tables[0].Rows[0]["Nit"].ToString();
                String direccion = dsDatos.Tables[0].Rows[0]["Direccion"].ToString();
                String ciudad = dsDatos.Tables[0].Rows[0]["Ciudad"].ToString();
                String telefono = dsDatos.Tables[0].Rows[0]["Telefono"].ToString();
                String regimen = dsDatos.Tables[0].Rows[0]["Regimen"].ToString();
                String resolucion = dsDatos.Tables[0].Rows[0]["Resolucion"].ToString();
                String observacionFac = dsDatos.Tables[0].Rows[0]["ObservacionFactura"].ToString();

                xrLblTituloE1.Text = nombre;
                xrLblTituloE2.Text = nombre;
                xrLblNit.Text = nit;
                xrLblDir.Text =  ciudad + ' ' + direccion;
                xrLblTel.Text = "TELEFONO(S) " + telefono;
                xrLblRegimen.Text = regimen;
                xrLblResolucion.Text = "RESOLUCION " + resolucion;
                xrLblImpresa.Text = nombre + "  NIT: " + nit;
                XrlblObserFac.Text = observacionFac;
            }

            String cad = String.Format("SELECT logempresa FROM gl_cfg");
            DataSet ds = DataBase.ExecuteQuery(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

            if (ds.Tables[0].Rows.Count > 0)
            {
                xrPictureBox1.ImageUrl = ds.Tables[0].Rows[0]["logempresa"].ToString();
            }
            else
            {
                xrPictureBox1.ImageUrl = "";
            }
        }

        public void SinMarcaAgua()
        {
            Watermark.Text = "";
        }

        #endregion


    }
}
