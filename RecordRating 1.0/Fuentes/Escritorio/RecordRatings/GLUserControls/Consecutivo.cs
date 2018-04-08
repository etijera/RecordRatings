using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLReferences;

namespace GLUserControls
{
    public partial class Consecutivo : DevExpress.XtraEditors.XtraUserControl
    {
        #region Propiedades

        public String Database { get; set; }
        public String Tabla { get; set; }
        public int Tamaño { get; set; }
        public Size LblConsecutivoSize { get; set; }
        public Font LblFont { get; set; }
        public Color BorderColor { get; set; }

        #endregion

        #region Variables

        Font f;
        Color c;

        #endregion

        /// <summary>Constructor
        /// Constructor de la clase
        /// </summary>
        public Consecutivo()
        {
            InitializeComponent();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cantidad"></param>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public String Numero(int cantidad, String cadena)
        {
            int largo = cadena.Length;

            UInt32 num = Convert.ToUInt32(cadena);
            String salida = Convert.ToString(num + 1);

            for (int i = largo; i < cantidad; i++)
            {
                salida = "0" + salida;
            }
            if (salida.Length > cantidad)
            {
                salida = salida.Substring(1, 6);
            }
            return salida;

        }

        public void Obtener()
        {
            String r = String.Format("SELECT prenro FROM " + Tabla + " ");

            DataSet ds1 = DataBase.ExecuteQuery(r, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));
            int o = ds1.Tables[0].Rows.Count;
            LblConsecutivo.Text = Numero(Tamaño, Convert.ToString(o));

        }

        private void Consecutivo_Load(object sender, EventArgs e)
        {
            Size s = new Size(0, 0);
            if (LblConsecutivoSize == s)
            {
                LblConsecutivo.Size = new Size(121, 25);
            }
            else
            {
                LblConsecutivo.Size = LblConsecutivoSize;
            }

            if (LblFont == null)
            {
                f = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            }
            else
            {
                f = LblFont;
            }

            if (BorderColor == null)
            {
                c = System.Drawing.Color.LightSlateGray;
            }
            else
            {
                c = BorderColor;
            }

            LblConsecutivo.Font = f;
            LblConsecutivo.Appearance.BorderColor = c;
        }
    }
}
