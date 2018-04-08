 /***
 * Control      : RangoFecha
 * Proposito    : Permite ingresar un rango de fecha valido
 * Fecha        : Febrero, 2012
 * Fecha Act.   : 
 * Autor        : 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLReferences;


namespace GLUserControls
{
    public partial class RangoFecha : DevExpress.XtraEditors.XtraUserControl
    {

        #region Propiedades

        public bool Vertical { get; set; }
        public Fechas FechaInicial { get; set; }
        public bool JustOne { get; set; }
        public DateTime Fecha { get; set; }
        public bool ValidarAño { get; set; }
        public DateTime FechaInicio
        {
            get
            {
                return TxtFechaIni.DateTime;
            }
            set
            {
                TxtFechaIni.DateTime = value;
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return TxtFechaFin.DateTime;
            }
            set
            {
                TxtFechaFin.DateTime = value;
            }
        }
        public FechasProximas FechaFinal { get; set; }
        public string Inicio
        {
            get
            {
                return fnc.Datetime2String(TxtFechaIni.DateTime);
            }
            set
            {
                string f = string.Format("{2}/{1}/{0}", value.Substring(0, 4), value.Substring(4, 2), value.Substring(6, 2));
                FechaInicio = DateTime.Parse(f);
            }
        }
        public string Fin
        {
            get
            {
                return fnc.Datetime2String(TxtFechaFin.DateTime);
            }
            set
            {
                string f = string.Format("{2}/{1}/{0}", value.Substring(0, 4), value.Substring(4, 2), value.Substring(6, 2));
                FechaFin = DateTime.Parse(f);
            }
        }

        private Funciones fnc = new Funciones();

        #endregion

        #region Metodos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public RangoFecha()
        {
            InitializeComponent();
        }

        public void Edit()
        {
            if (Fecha != null)
                TxtFechaIni.DateTime = Fecha;
        }

        public void DeshabilitarFecha(int Indice)
        {
            if (Indice == 1)
            {
                TxtFechaIni.Enabled = false;
            }

            if (Indice == 2)
            {
                TxtFechaFin.Enabled = false;
            }
        }

        public void HabilitarFecha(int Indice)
        {
            if (Indice == 1)
            {
                TxtFechaIni.Enabled = true;
            }

            if (Indice == 2)
            {
                TxtFechaFin.Enabled = true;
            }
        }

        #endregion

        #region Eventos

        private void RangoFecha_Load(object sender, EventArgs e)
        {
           
            if (Vertical)
            {
                Size = new Size(202, 77);
                LblFechaFin.Location = new Point(6, 55);
                TxtFechaFin.Location = new Point(78, 52);
                labelControl2.Location = new Point(100, 40);
            }

            DateTime hoy = DateTime.Now;
            int año = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            int dia = DateTime.Now.Day;
            switch (FechaInicial)
            {
                case Fechas.Hoy:
                    TxtFechaIni.DateTime = hoy;
                    break;
                case Fechas.Primer_dia_del_Mes:
                    TxtFechaIni.DateTime = new DateTime(año, mes, 01);
                    break;
                case Fechas.Hace_un_Mes:
                    TxtFechaIni.DateTime = new DateTime(año, mes - 1, 01);
                    break;
                case Fechas.Hace_un_Año:
                    TxtFechaIni.DateTime = new DateTime(año - 1, mes, dia);
                    break;
                case Fechas.El_origen_de_los_tiempos:
                    TxtFechaIni.DateTime = new DateTime(1995, 01, 01);
                    break;
                case Fechas.primer_dia_del_año:
                    TxtFechaIni.DateTime = new DateTime(año, 01, 01);
                    break;
                default:
                    TxtFechaIni.DateTime = hoy;
                    break;
            }
            //if (JustOne)
            //{
            //    TxtFechaFin.DateTime = TxtFechaIni.DateTime;
            //    LblFechaIni.Location = new Point(40, 18);
            //    LblFechaIni.Text = "Fecha";
            //    labelControl2.Visible = false;
            //    TxtFechaFin.Visible = false;
            //    LblFechaFin.Visible = false;
            //}
            //else
            //    TxtFechaFin.DateTime = hoy;

            switch (FechaFinal)
            {
                case FechasProximas.Hoy:
                    TxtFechaFin.DateTime = hoy;
                    break;
                case FechasProximas.Al_dia_siguiente:
                    TxtFechaFin.DateTime = new DateTime(año, mes, dia+1);
                    break;
                case FechasProximas.A_la_semana_siguiente:
                    TxtFechaFin.DateTime = new DateTime(año, mes , dia -7);
                    break;
                case FechasProximas.Al_mes_siguiente:
                    TxtFechaFin.DateTime = new DateTime(año , mes + 1 , dia);
                    break;
                case FechasProximas.Al_año_siguiente:
                    TxtFechaFin.DateTime = new DateTime(año + 1, mes, dia);
                    break;
                case FechasProximas.ultimo_dia_del_año:
                    TxtFechaFin.DateTime = new DateTime(año, 12, 31);
                    break;
                default:
                    TxtFechaFin.DateTime = hoy;
                    break;
            }



        }

        private void TxtFechaIni_Leave(object sender, EventArgs e)
        {
            try
            {
                if (JustOne)
                    TxtFechaFin.DateTime = TxtFechaIni.DateTime;

                String fecha = Funciones.getInstancia().RellenarCadenaPorLaIzquierda((fnc.Datetime2String(TxtFechaIni.DateTime)), '0', 8);
                if (fecha == "00010101" || fecha == "01010001")
                {
                    fecha = fnc.Datetime2String(DateTime.Now);
                }
                Inicio = fecha;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        private void TxtFechaFin_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Compare(TxtFechaFin.DateTime, TxtFechaIni.DateTime) < 0)
            {
                XtraMessageBox.Show("La fecha final no puede ser menor que la inical", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtFechaFin.Focus();
                return;
            }

            if (String.IsNullOrEmpty(TxtFechaFin.Text))
            {
                XtraMessageBox.Show("Debe ingresar una fecha", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFechaFin.Focus();
                return;
            }
        }

        private void TxtFechaIni_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(TxtFechaIni.Text))
            {
                XtraMessageBox.Show("Debe ingresar una fecha", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFechaIni.Focus();
                return;
            }
        }

        private void TxtFechaFin_Validated(object sender, EventArgs e)
        {
            if (ValidarAño == true)
            {
                if (TxtFechaFin.DateTime.Year != TxtFechaIni.DateTime.Year)
                {
                    XtraMessageBox.Show("Las fechas deben ser del mismo año", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtFechaFin.Focus();
                    return;
                }
            }
        }

        #endregion

        private void TxtFechaIni_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}
