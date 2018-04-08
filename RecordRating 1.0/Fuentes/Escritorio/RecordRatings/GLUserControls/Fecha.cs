 /***
 * Control      : Fecha
 * Proposito    : Permite ingresar una fecha valida
 * Fecha        : Julio, 2012
 * Fecha Act.   : Diciembre, 2012
 * Autor        : 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLReferences;

namespace GLUserControls
{
    public partial class Fecha : UserControl
    {

        #region Propiedades
        public DateTime CampoFecha { get; set; }
        public Fechas FechaInicial { get; set; }
        public string Inicio { get; set; }
        public Size TxtFechaSize
        {
            get
            {
                return TxtFecha.Size;
            }
            set
            {
                if (value != null && value != new Size(0, 0))
                    TxtFecha.Size = value;
            }
        }
        public Size LblFechaSize
        {
            get
            {
                return LblFecha.Size;
            }
            set
            {
                if (value != null && value != new Size(0, 0))
                    LblFecha.Size = value;
            }
        }
        public string TextoLabel
        {
            get { return LblFecha.Text; }
            set { LblFecha.Text = value; }
        }
        public Point TxtFechaLocation
        {
            get
            {
                return TxtFecha.Location;
            }
            set
            {
                if (value != null && value != new Point(0, 0))
                    TxtFecha.Location = value;
                labelControl1.Location = new Point(((Point)value).X + 11, labelControl1.Location.Y);
            }
        }

        public bool ValidarFechaActual { get; set; }
        public bool ValidarPeriodo { get; set; }
        public bool ValidarCierre { get; set; }
        public int MesPeriodo { get; set; }
        public int AñoPeriodo { get; set; }
        public string Database { get; set; }

        private Funciones fnc = new Funciones();

        #endregion

        #region Metodos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Fecha()
        {
            InitializeComponent();
            TxtFechaSize = new Size(189, 20);
            LblFechaSize = new Size(100, 20);
        }

        public void Edit()
        {
            if (CampoFecha != null)
                TxtFecha.DateTime = CampoFecha;
        }

        public void setlabel(string titulo)
        {
            LblFecha.Text = titulo.Trim();
        }

        public bool Validar()
        {
            bool retorno = true;

            if (ValidarFechaActual)
            {
                if (TxtFecha.DateTime.Date < DateTime.Now.Date)
                {
                    XtraMessageBox.Show("La  fecha seleccionada no puede ser menor que la fecha actual.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtFecha.Focus();
                    return false;
                }
                else
                {
                    retorno = true;
                }
            }

            if (ValidarPeriodo)
            {
                if (MesPeriodo != TxtFecha.DateTime.Month || AñoPeriodo != TxtFecha.DateTime.Year)
                {
                    String mes = Funciones.getInstancia().Numero2Mes(MesPeriodo);
                    XtraMessageBox.Show("El documento que intenta crear no corresponde al periodo que se esta trabajando (" + mes + " de " + AñoPeriodo + "). Por favor verifique.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtFecha.Focus();
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
                    TxtFecha.Focus();
                    return false;
                }
            }

            return retorno;
        }

        #endregion

        #region Eventos

        private void Fecha_Load(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            int año = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            int dia = DateTime.Now.Day;

            switch (FechaInicial)
            {
                case Fechas.Hoy:
                    TxtFecha.DateTime = hoy;
                    break;
                case Fechas.Primer_dia_del_Mes:
                    TxtFecha.DateTime = new DateTime(año, mes, 01);
                    break;
                case Fechas.Hace_un_Mes:
                    TxtFecha.DateTime = new DateTime(año, mes - 1, 01);
                    break;
                case Fechas.Hace_un_Año:
                    TxtFecha.DateTime = new DateTime(año - 1, mes, dia);
                    break;
                case Fechas.El_origen_de_los_tiempos:
                    TxtFecha.DateTime = new DateTime(1995, 01, 01);
                    break;
                default:
                    TxtFecha.DateTime = hoy;
                    break;
            }

            Inicio = fnc.Datetime2String(TxtFecha.DateTime);
            CampoFecha = TxtFecha.DateTime;

        }

        private void TxtFecha_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(TxtFecha.Text))
            {
                XtraMessageBox.Show("Debe ingresar una fecha", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFecha.Focus();
                return;
            }
            else
            {
                Inicio = fnc.Datetime2String(TxtFecha.DateTime);
                CampoFecha = TxtFecha.DateTime;
            }
        }

        

        #endregion

        private void TxtFecha_Validated(object sender, EventArgs e)
        {
            if (Validar())
            {
                Inicio = fnc.Datetime2String(TxtFecha.DateTime);
                CampoFecha = TxtFecha.DateTime;
            }
        }

    }
}
