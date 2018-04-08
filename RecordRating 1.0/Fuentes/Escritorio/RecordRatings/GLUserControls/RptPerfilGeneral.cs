using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using GLReferences;

namespace GLUserControls
{
    public partial class RptPerfilGeneral : DevExpress.XtraReports.UI.XtraReport
    {
        public String Dtbase { get; set; }

        public RptPerfilGeneral()
        {
            InitializeComponent();
        }
        public void Empresa(string nombre, string cabecera)
        {

            String cad = String.Format("SELECT nomempresa,nitempresa,logempresa FROM gl_cfg");
            DataSet ds = DataBase.ExecuteQuery(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Dtbase, null));

            xrLblTitulo.Text = ds.Tables[0].Rows[0][0].ToString();
            xrLblNit.Text = "Nit. " + ds.Tables[0].Rows[0][1].ToString();
            xrPictureBox1.ImageUrl = ds.Tables[0].Rows[0]["logempresa"].ToString();

            xrLblTituloReporte.Text = "Listado de " + nombre;
            xrLblNombre.Text = cabecera.ToUpper();

        }

    }
}
