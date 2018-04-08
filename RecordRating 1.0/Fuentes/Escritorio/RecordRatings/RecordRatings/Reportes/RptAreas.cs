using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using RecordRatings.Controladores;

namespace RecordRatings.Reportes
{
    public partial class RptAreas : DevExpress.XtraReports.UI.XtraReport
    {

        #region Propiedades
        public string Database { get; set; }
        public string Año { get; set; }

        #endregion

        #region Metodos
        public RptAreas()
        {
            InitializeComponent();
        }

        public void Empresa()
        {
            DataSet dsDatos = CtrlInstitucion.GetInstitucionAll();

            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                String nombre = dsDatos.Tables[0].Rows[0]["Nombre"].ToString();
                String nit = dsDatos.Tables[0].Rows[0]["Nit"].ToString();
                String lema = dsDatos.Tables[0].Rows[0]["Lema"].ToString();
                String telefono = dsDatos.Tables[0].Rows[0]["Telefono"].ToString();
                String resolucion = dsDatos.Tables[0].Rows[0]["Resolusion"].ToString();
                String codigoDane = dsDatos.Tables[0].Rows[0]["CodigoDane"].ToString();
                String logo = dsDatos.Tables[0].Rows[0]["Logo"].ToString();
                String director = dsDatos.Tables[0].Rows[0]["Director"].ToString();
                String Secretaria = dsDatos.Tables[0].Rows[0]["Secretaria"].ToString();

                xrLblNombre.Text = nombre;
                xrLblResolucion.Text = "Resolución # " + resolucion;
                xrLblCodNitTel.Text = "Código Dane: " + codigoDane + ". NIT: " + nit + ". Teléfono # " + telefono;
                xrLblLema.Text = lema;
                xrPictureBox1.ImageUrl = logo;
                //xrLlblDirectorGrupo.Text = DirectorGrupo;

                xrLblAñoElectivo.Text = Año.Trim();
            }

          
        }


        #endregion
    }
}
