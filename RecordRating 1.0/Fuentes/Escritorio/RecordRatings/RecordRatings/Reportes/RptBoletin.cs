using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using RecordRatings.Controladores;
using RecordRatings.Clases;

namespace RecordRatings.Reportes
{
    public partial class RptBoletin : DevExpress.XtraReports.UI.XtraReport
    {
        #region Propiedades
        public string Database { get; set; }
        public string Año { get; set; }
        public string DirectorGrupo { get; set; }
        public string CodPeriodo { get; set; }
        public string CodCurso { get; set; }

        #endregion

        #region Variables

        decimal suma = 0;
        decimal count = 0;

        #endregion


        #region Metodos
        public RptBoletin()
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

                xrLblDirector.Text = director;
                xrLblSecretaria.Text = Secretaria;
                //xrLlblDirectorGrupo.Text = DirectorGrupo;

                xrLblAñoElectivo.Text = Año.Trim();
            }

            Curso cur = new Curso();
            cur.CodigoCurso = CodCurso;
            DataSet dsDatos1 = CtrlCursos.GetCursoOneCod(cur);

            string jornada = dsDatos1.Tables[0].Rows[0]["Jornada"].ToString();
            xrLblJornada.Text = jornada.ToUpper();

            Periodo per = new Periodo();
            per.CodigoPeriodo = CodPeriodo;
            DataSet dsDatos2 = CtrlPeriodos.GetPeriodoOneCod(per);

            string periodo = dsDatos2.Tables[0].Rows[0]["Numero"].ToString();
            string porcPeriodo = dsDatos2.Tables[0].Rows[0]["Porcentaje"].ToString();
            xrLblPEriodo.Text = periodo + "°,     " + porcPeriodo + " %";
        }

        #endregion

        private void xrLabel53_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            suma = Convert.ToDecimal(e.Value);

            decimal promedio = Decimal.Round(suma / count);

        }

        private void xrLabel54_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            count = Convert.ToDecimal(e.Value);

            
        }
    }
}
