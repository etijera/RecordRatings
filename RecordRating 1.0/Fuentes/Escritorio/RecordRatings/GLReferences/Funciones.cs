using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;
using DevExpress.XtraGrid.Views.Layout;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Data.OleDb;
using System.Data.Odbc;
using GLReferences.Reports;
using DevExpress.XtraPrinting;
using GlRereferences.Reports;
using DevExpress.XtraPrintingLinks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using DevExpress.XtraGrid;

namespace GLReferences
{
    public class Funciones
    {
        public static List<string> Digitos = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        int contador = 0;
        String code = "";
        bool invalid = false;
        private static Funciones funciones;

        public static int MaxLength(Perfil p, string Database)
        {
            String cad = String.Format("SELECT CHARACTER_MAXIMUM_LENGTH FROM information_schema.columns WHERE table_name = '{0}' AND COLUMN_NAME='{1}'", p.Tabla, p.CampoCodigo);
            DataSet ds = DataBase.ExecuteQuery(cad, "tamaño", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));
            int maxl = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            return maxl;
        }

        public static Funciones getInstancia()
        {
            if (funciones == null)
            {
                funciones = new Funciones();
            }
            return funciones;
        }

        /// <summary>
        /// Enumerados que definen los tipos de
        /// intervalos de tiempo posibles.
        /// </summary>
        public enum DateInterval
        {
            Day,
            DayOfYear,
            Hour,
            Minute,
            Month,
            Quarter,
            Second,
            Weekday,
            WeekOfYear,
            Year
        }

        public static void RunFile(string filePath)
        {
            Process.Start("explorer.exe", filePath);
        }

        public static string ToMoneyString(double val)
        {
            return "$ " + val.ToString("N");
        }

        public DataSet ObtenerConfiguracionGeneral(SqlConnection conn)
        {
            return DataBase.ExecuteQuery("PA_ObtenerConfiguracionGeneral", "Data", CommandType.StoredProcedure, null, conn);
        }

        public DataSet GetTipoUsurios(SqlConnection Conn)
        {
            string sql = "SELECT * FROM TipoUsuarios WHERE delmrk = '1' order by Codigo";
            return DataBase.ExecuteQuery(sql, "datos", CommandType.Text, null, Conn);
        }        

        public DataSet GetUsuarios(SqlConnection Conn)
        {
            string sql = "SELECT * FROM Usuarios WHERE delmrk = '1'";
            return DataBase.ExecuteQuery(sql, "datos", CommandType.Text, null, Conn);
        }

        public DataSet GetPersonas(SqlConnection Conn)
        {
            string sql = "SELECT * FROM Personas WHERE delmrk = '1'";
            return DataBase.ExecuteQuery(sql, "datos", CommandType.Text, null, Conn);
        }

        public DataSet ValidarUsuario(string user, string pass, SqlConnection Conn)
        {
            string sql = "SELECT * FROM Usuarios WHERE delmrk = '1' AND Nombre = @usuario AND Contrasenia = @clave";
            SqlParameter[] parameters = { new SqlParameter("@usuario", user), new SqlParameter("@clave", pass) };
            return DataBase.ExecuteQuery(sql, "datos", CommandType.Text, parameters, Conn);
        }

        public DataSet GetMenu(SqlConnection Conn)
        {
            string sql = "SELECT * FROM accglmenu ORDER BY Codigo";
            return DataBase.ExecuteQuery(sql, "datos", CommandType.Text, null, Conn);
        }

        public DataSet GetTables(SqlConnection Conn)
        {
            string sql = "SELECT	sysobjects.NAME AS TABLA , sysobjects.Id as Id FROM	sysobjects  WHERE	sysobjects.xtype = 'U' OR  sysobjects.xtype = 'V' ORDER BY sysobjects.NAME ";
            return DataBase.ExecuteQuery(sql, "tablas", CommandType.Text, null, Conn);
        }

        public DataSet GetCampos(SqlConnection Conn, String Tabla)
        {
            string sql = "select name as NAME from syscolumns where id = '" + Tabla + "' ";
            return DataBase.ExecuteQuery(sql, "campos", CommandType.Text, null, Conn);
        }

        public String GetNextCode(String table, String keyColumn, SqlConnection Conn,string codeColumn="")
        {
            string sql = "SELECT count (*) FROM " + table;
            if (contador == 0)
            {
                contador = Convert.ToInt32(DataBase.ExecuteQuery(sql, "datos", CommandType.Text, null, Conn).Tables[0].Rows[0][0]);
                contador += 1; 
            }

            code = contador.ToString().PadLeft(4, Convert.ToChar("0"));

            if (String.IsNullOrEmpty(codeColumn))
            {
                sql = String.Format("select * from {0} where {1} = '{2}'", table, keyColumn, code);
            }
            else
            {
                sql = String.Format("select * from {0} where {1} = '{2}' OR {3} = '{4}'", table, keyColumn, code,codeColumn,code);
            }
            
            DataTable dt = DataBase.ExecuteQuery(sql, "datos", CommandType.Text, null, Conn).Tables[0];

            if (dt.Rows.Count > 0)
            {
                contador += 1;
                GetNextCode(table, keyColumn, Conn,codeColumn);
            }

            return code;

        }

        public DataSet GetCamposFecha(SqlConnection Conn, String Tabla)
        {
            string sql = "SELECT SC.NAME FROM sys.objects as SO INNER JOIN sys.columns as SC ON SO.OBJECT_ID = SC.OBJECT_ID WHERE SO.TYPE ='U' AND SO.name='" + Tabla + "' AND  SC.SYSTEM_TYPE_ID='61' ";
            return DataBase.ExecuteQuery(sql, "campos", CommandType.Text, null, Conn);
        }
        private static DateTime? _SQLNullDateTime = null;
        public static DateTime SQLNullDateTime
        {
            get
            {
                if (_SQLNullDateTime == null)
                {
                    var d = new DateTime(1900, 1, 1);
                    _SQLNullDateTime = d;
                }
                return _SQLNullDateTime.Value;
            }
        }

        public String Datetime2String(DateTime fecha)
        {
            string mes = fecha.Month.ToString();
            if (mes.Length == 1)
            {
                mes = '0' + mes;
            }
            string dia = fecha.Day.ToString();
            if (dia.Length == 1)
            {
                dia = '0' + dia;
            }
            return fecha.Year.ToString() + mes + dia;
        }

        /// <summary>FormatoFecha(String f)
        /// Permite darle formato de fecha(dd/mm/aa), a un una cadena de 8 numeros.
        /// </summary>
        /// <param name="f">En este parametro se recibe la cadena a la cual queremos darle formato</param>
        /// <returns>Retorna la cadena con formato fecha(dd/mm/aa)</returns>
        public String FormatoFecha(String f)
        {
            if (f != "")
            {
                String a;
                String m;
                String d;
                String fe = "";
                int g = f.Length;
                a = f.Substring(0, 4);
                m = f.Substring(4, 2);
                d = f.Substring(6, 2);
                fe = d + "/" + m + "/" + a;
                return fe;
            }
            else
            {

                String fe;

                fe = DateTime.Today.ToString();

                return fe;
            }
        }

        public string RellenarCadenaPorLaIzquierda(string cadena, char relleno, int tamanio)
        {
            string cadenaRellenada = cadena;

            while (cadenaRellenada.Length < tamanio)
            {
                cadenaRellenada = relleno + cadenaRellenada;
            }
            return cadenaRellenada;
        }

        public string ConvertirDobleAMontoEnLetras(double cantidad, string moneda, string postfijoMontoEnLetras, bool postfijo = false)
        {
            string res;
            string dec = "";
            string dec1 = "";
            Int64 entero;
            int decimales;

            entero = Convert.ToInt64(Math.Truncate(cantidad));
            decimales = Convert.ToInt32(Math.Round((cantidad - entero) * 100, 2));
            dec = " CON " + RellenarCadenaPorLaIzquierda(decimales.ToString(), '0', 2) + "/100";
            dec1 = " CON " + NumToText(decimales);
            res = NumToText(Convert.ToDouble(entero)) + " " + moneda.ToUpper().Trim();
            if (postfijo)
            {
                res = NumToText(Convert.ToDouble(entero)) + " " + moneda.ToUpper().Trim() + dec1 + " " + postfijoMontoEnLetras.ToUpper().Trim();
            }
            return res;
        }

        public string NumToText(double value)
        {
            string Num2Text = "";

            value = Math.Truncate(value);

            if (value == 0)
                Num2Text = "CERO";

            else
                if (value == 1)
                    Num2Text = "UNO";

                else
                    if (value == 2)
                        Num2Text = "DOS";

                    else
                        if (value == 3)
                            Num2Text = "TRES";

                        else
                            if (value == 4)
                                Num2Text = "CUATRO";

                            else
                                if (value == 5)
                                    Num2Text = "CINCO";

                                else
                                    if (value == 6)
                                        Num2Text = "SEIS";

                                    else
                                        if (value == 7)
                                            Num2Text = "SIETE";

                                        else
                                            if (value == 8)
                                                Num2Text = "OCHO";

                                            else
                                                if (value == 9)
                                                    Num2Text = "NUEVE";

                                                else
                                                    if (value == 10)
                                                        Num2Text = "DIEZ";

                                                    else
                                                        if (value == 11)
                                                            Num2Text = "ONCE";

                                                        else
                                                            if (value == 12)
                                                                Num2Text = "DOCE";

                                                            else
                                                                if (value == 13)
                                                                    Num2Text = "TRECE";

                                                                else
                                                                    if (value == 14)
                                                                        Num2Text = "CATORCE";

                                                                    else
                                                                        if (value == 15)
                                                                            Num2Text = "QUINCE";

                                                                        else
                                                                            if (value < 20)
                                                                                Num2Text = "DIECI" + NumToText(value - 10);

                                                                            else
                                                                                if (value == 20)
                                                                                    Num2Text = "VEINTE";

                                                                                else
                                                                                    if (value < 30)
                                                                                    {
                                                                                        string segundaCifra;
                                                                                        if ((value % 20).Equals(1))
                                                                                        {
                                                                                            segundaCifra = "UN";
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            segundaCifra = NumToText(value % 20);
                                                                                        }
                                                                                        Num2Text = "VEINTI" + segundaCifra;
                                                                                    }

                                                                                    else
                                                                                        if (value == 30)
                                                                                            Num2Text = "TREINTA";

                                                                                        else
                                                                                            if (value == 40)
                                                                                                Num2Text = "CUARENTA";

                                                                                            else
                                                                                                if (value == 50)
                                                                                                    Num2Text = "CINCUENTA";

                                                                                                else
                                                                                                    if (value == 60)
                                                                                                        Num2Text = "SESENTA";

                                                                                                    else
                                                                                                        if (value == 70)
                                                                                                            Num2Text = "SETENTA";

                                                                                                        else
                                                                                                            if (value == 80)
                                                                                                                Num2Text = "OCHENTA";

                                                                                                            else
                                                                                                                if (value == 90)
                                                                                                                    Num2Text = "NOVENTA";

                                                                                                                else
                                                                                                                    if (value < 100)
                                                                                                                    {
                                                                                                                        string segundaCifra;
                                                                                                                        if ((value % 10).Equals(1))
                                                                                                                        {
                                                                                                                            segundaCifra = "UN";
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            segundaCifra = NumToText(value % 10);
                                                                                                                        }
                                                                                                                        Num2Text = NumToText(Math.Truncate(value / 10) * 10) + " Y " + segundaCifra;
                                                                                                                    }

                                                                                                                    else
                                                                                                                        if (value == 100)
                                                                                                                            Num2Text = "CIEN";

                                                                                                                        else
                                                                                                                            if (value < 200)
                                                                                                                                Num2Text = "CIENTO " + NumToText(value - 100);

                                                                                                                            else
                                                                                                                                if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800))
                                                                                                                                    Num2Text = NumToText(Math.Truncate(value / 100)) + "CIENTOS";

                                                                                                                                else
                                                                                                                                    if (value == 500)
                                                                                                                                        Num2Text = "QUINIENTOS";

                                                                                                                                    else
                                                                                                                                        if (value == 700)
                                                                                                                                            Num2Text = "SETECIENTOS";

                                                                                                                                        else
                                                                                                                                            if (value == 900)
                                                                                                                                                Num2Text = "NOVECIENTOS";

                                                                                                                                            else
                                                                                                                                                if (value < 1000)
                                                                                                                                                    Num2Text = NumToText(Math.Truncate(value / 100) * 100) + " " + NumToText(value % 100);

                                                                                                                                                else
                                                                                                                                                    if (value == 1000)
                                                                                                                                                        Num2Text = "MIL";

                                                                                                                                                    else
                                                                                                                                                        if (value < 2000)
                                                                                                                                                            Num2Text = "MIL " + NumToText(value % 1000);

                                                                                                                                                        else
                                                                                                                                                            if (value < 1000000)
                                                                                                                                                            {
                                                                                                                                                                Num2Text = NumToText(Math.Truncate(value / 1000)) + " MIL";
                                                                                                                                                                if ((value % 1000) > 0)
                                                                                                                                                                {
                                                                                                                                                                    Num2Text = Num2Text + " " + NumToText(value % 1000);
                                                                                                                                                                }
                                                                                                                                                            }

                                                                                                                                                            else
                                                                                                                                                                if (value == 1000000)
                                                                                                                                                                    Num2Text = "UN MILLON";

                                                                                                                                                                else
                                                                                                                                                                    if (value < 2000000)
                                                                                                                                                                        Num2Text = "UN MILLON " + NumToText(value % 1000000);

                                                                                                                                                                    else
                                                                                                                                                                        if (value < 1000000000000)
                                                                                                                                                                        {
                                                                                                                                                                            Num2Text = NumToText(Math.Truncate(value / 1000000)) + " MILLONES ";
                                                                                                                                                                            if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                                                                                                                                                                            {
                                                                                                                                                                                Num2Text = Num2Text + " " + NumToText(value - Math.Truncate(value / 1000000) * 1000000);
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                        else
                                                                                                                                                                            if (value == 1000000000000)
                                                                                                                                                                            {
                                                                                                                                                                                Num2Text = "UN BILLON";
                                                                                                                                                                            }
                                                                                                                                                                            else
                                                                                                                                                                                if (value < 2000000000000)
                                                                                                                                                                                {
                                                                                                                                                                                    Num2Text = "UN BILLON " + NumToText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                                                                                                                                                                                }
                                                                                                                                                                                else
                                                                                                                                                                                {
                                                                                                                                                                                    Num2Text = NumToText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                                                                                                                                                                                    if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                                                                                                                                                                                    {
                                                                                                                                                                                        Num2Text = Num2Text + " " + NumToText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                                                                                                                                                                                    }
                                                                                                                                                                                }
            return Num2Text;
        }

        public double Redondear(double valor, double divisor)
        {
            double redondeado = 0;
            double restante;
            double faltante;
            if (valor < (divisor / 2))
            {
                redondeado = 0;
            }
            if (valor < divisor)
            {
                redondeado = divisor;
            }
            if (valor % divisor > 0)
            {
                faltante = valor % divisor;
                restante = (faltante - divisor);
                if (restante < 0)
                {
                    restante = restante * (-1);
                }

                if (faltante >= (divisor / 2))
                {
                    redondeado = valor + restante;
                }
                else
                {
                    redondeado = valor - faltante;
                }
            }

            if (valor % divisor <= 0)
            {
                redondeado = valor;
            }

            return redondeado;
        }

        public string Numero2Mes(int mes)
        {

            switch (mes)
            {
                case 1:
                    return "Enero";
                case 2:
                    return "Febrero";
                case 3:
                    return "Marzo";
                case 4:
                    return "Abril";
                case 5:
                    return "Mayo";
                case 6:
                    return "Junio";
                case 7:
                    return "Julio";
                case 8:
                    return "Agosto";
                case 9:
                    return "Septiembre";
                case 10:
                    return "Octubre";
                case 11:
                    return "Noviembre";
                case 12:
                    return "Diciembre";

                default:
                    return String.Empty;
            }

        }

        public int Mes2Numero(String mes)
        {

            switch (mes.ToUpper())
            {
                case "ENERO":
                    return 1;
                case "FEBRERO":
                    return 2;
                case "MARZO":
                    return 3;
                case "ABRIL":
                    return 4;
                case "MAYO":
                    return 5;
                case "JUNIO":
                    return 6;
                case "JULIO":
                    return 7;
                case "AGOSTO":
                    return 8;
                case "SEPTIEMBRE":
                    return 9;
                case "OCTUBRE":
                    return 10;
                case "NOVIEMBRE":
                    return 11;
                case "DICIEMBRE":
                    return 12;

                default:
                    return 1;
            }

        }

        public void Configurar_Grid(GridView DgvGrilla)
        {
            DgvGrilla.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            DgvGrilla.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            DgvGrilla.OptionsBehavior.Editable = false;
            DgvGrilla.OptionsBehavior.AllowIncrementalSearch = true;

            DgvGrilla.OptionsFilter.AllowFilterEditor = false;
            DgvGrilla.OptionsFilter.AllowColumnMRUFilterList = false;
            DgvGrilla.OptionsFilter.AllowMRUFilterList = false;
            DgvGrilla.OptionsFilter.MRUFilterListPopupCount = 0;
            DgvGrilla.OptionsFilter.MRUFilterListCount = 0;
            DgvGrilla.OptionsFilter.MRUColumnFilterListCount = 0;

            DgvGrilla.OptionsCustomization.AllowGroup = false;
            DgvGrilla.OptionsCustomization.AllowQuickHideColumns = false;
            DgvGrilla.OptionsCustomization.AllowFilter = false;

            DgvGrilla.OptionsView.ColumnAutoWidth = true;
            DgvGrilla.OptionsView.RowAutoHeight = true;
            DgvGrilla.OptionsView.EnableAppearanceOddRow = true;
            DgvGrilla.OptionsView.ShowAutoFilterRow = false;
            DgvGrilla.OptionsView.ShowGroupPanel = false;
            DgvGrilla.OptionsHint.ShowColumnHeaderHints = false;
            DgvGrilla.OptionsView.ShowIndicator = true;
            DgvGrilla.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;

            DgvGrilla.OptionsFind.AllowFindPanel = true;
            DgvGrilla.OptionsFind.FindFilterColumns = "*";
            DgvGrilla.OptionsFind.FindMode = FindMode.Always;

            DgvGrilla.OptionsMenu.EnableColumnMenu = false;

        }

        public void Configurar_LayoutView(LayoutView LyvGrilla)
        {

            LyvGrilla.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            LyvGrilla.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            LyvGrilla.OptionsBehavior.Editable = false;

            LyvGrilla.OptionsFilter.AllowFilterEditor = false;
            LyvGrilla.OptionsFilter.AllowColumnMRUFilterList = false;
            LyvGrilla.OptionsFilter.AllowMRUFilterList = false;
            LyvGrilla.OptionsFilter.MRUFilterListPopupCount = 0;
            LyvGrilla.OptionsFilter.MRUFilterListCount = 0;
            LyvGrilla.OptionsFilter.MRUColumnFilterListCount = 0;

            //LyvGrilla.OptionsCustomization.AllowGroup = false;

            //LyvGrilla.OptionsCustomization.AllowQuickHideColumns = false;
            LyvGrilla.OptionsCustomization.AllowFilter = false;

            // LyvGrilla.OptionsView.ColumnAutoWidth = true;
            //LyvGrilla.OptionsView.RowAutoHeight = true;
            // LyvGrilla.OptionsView.EnableAppearanceOddRow = true;
            // LyvGrilla.OptionsView.ShowAutoFilterRow = false;
            // LyvGrilla.OptionsView.ShowGroupPanel = false;
            //LyvGrilla.OptionsHint.ShowColumnHeaderHints = false;
            //LyvGrilla.OptionsView.ShowIndicator = true;
            LyvGrilla.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;

            LyvGrilla.OptionsFind.AllowFindPanel = true;
            LyvGrilla.OptionsFind.FindFilterColumns = "*";
            LyvGrilla.OptionsFind.FindMode = FindMode.Always;

            //LyvGrilla.OptionsMenu.EnableColumnMenu = false;

        }

        /// <summary>ExportarExcelDataTable(System.Data.DataTable dt, string RutaExcel)
        /// Exporta datos de una tabla a Excel
        /// </summary>
        /// <param name="dt">Objeto que contiene las filas a exportar</param>
        /// <param name="RutaExcel">Ruta y nombre de archivo a exportar</param>
        //public void ExportarExcelDataTable(System.Data.DataTable dt, string RutaExcel)
        //{
        //    // Crea un objeto Excel y un libro
        //    Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
        //    Microsoft.Office.Interop.Excel.Workbook libroTrabajo = excel.Application.Workbooks.Add(true);
        //    excel.Cells.NumberFormat = "@";

        //    // Adicionar las columnas de encabezado
        //    int columna = 0;

        //    foreach (DataColumn c in dt.Columns)
        //    {
        //        columna++;
        //        excel.Cells[1, columna] = c.ColumnName;
        //    }

        //    int fila = 0;
        //    foreach (DataRow r in dt.Rows)
        //    {
        //        fila++;

        //        columna = 0;
        //        foreach (DataColumn c in dt.Columns)
        //        {
        //            columna++;
        //            excel.Cells[fila + 1, columna] = r[c.ColumnName];
        //        }
        //    }

        //    object missing = System.Reflection.Missing.Value;

        //    libroTrabajo.SaveAs(RutaExcel, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel5);

        //    excel.Quit();
        //}
        //// ==== Fin ExportarExcelDataTable() ====

        //public void ExportarExcelDataSetMD(DataSet ds, string RutaExcel, string tituloRpt, string colIndice, string colForanea)
        //{
        //    // Crea un objeto Excel y un libro
        //    Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
        //    Microsoft.Office.Interop.Excel.Workbook libroTrabajo = excel.Application.Workbooks.Add(true);
        //    excel.Cells.NumberFormat = "@";//#.##
        //    Microsoft.Office.Interop.Excel.Range chartRange;
        //    Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
        //    xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)libroTrabajo.Worksheets.get_Item(1); 

        //    // Adicionar las columnas de encabezado
        //    DataTable dtCab = ds.Tables[0];
        //    DataTable dtDet = ds.Relations[0].ChildTable;
            
        //    //Titulo
        //    excel.Cells[1, 1] = tituloRpt;
        //    excel.Cells[1, 9] = DateTime.Now.ToLongDateString(); 

        //    chartRange = xlWorksheet.get_Range("a1", "z1 ");
        //    chartRange.Font.Bold = true;
        //    chartRange.Font.Size = 16;

        //    int columnaCab = 0;
        //    int columnaDet = 0;

        //    //Primeras Collumnas Cabecera
        //    foreach (DataColumn c in dtCab.Columns)
        //    {
        //        columnaCab++;
        //        excel.Cells[5, columnaCab] = c.ColumnName;
        //        chartRange = xlWorksheet.get_Range("a5", "z1 ");
        //        chartRange.Font.Bold = true;
        //        chartRange.Font.Size = 12;
        //    }

        //    int filaCabecera = 5;

        //    foreach (DataRow r in dtCab.Rows)
        //    {
        //        filaCabecera=filaCabecera+1;
                

        //        columnaCab = 0;
        //        //Agrega Fila Cabecera
        //        foreach (DataColumn c in dtCab.Columns)
        //        {
        //            columnaCab++;
        //            excel.Cells[filaCabecera, columnaCab] = r[c.ColumnName];
        //        }
        //        filaCabecera = filaCabecera +1;

        //        string idP = r[colIndice].ToString();
        //        columnaDet = 1;
        //        excel.Cells[filaCabecera, 2] = "DETALLES";
        //        chartRange = xlWorksheet.get_Range("b" + filaCabecera, "b" + filaCabecera);
        //        chartRange.Font.Bold = true;
        //        chartRange.Font.Size = 12;

        //        filaCabecera++;
        //        //Agrega captions Filas detalles
        //        foreach (DataColumn c in dtDet.Columns)
        //        {
        //            if (c.ColumnName != colForanea)
        //            {
        //                columnaDet++;
        //                excel.Cells[filaCabecera, columnaDet] = c.ColumnName;

        //                chartRange = xlWorksheet.get_Range("a"+filaCabecera, "z"+filaCabecera);
        //                chartRange.Font.Bold = true;
        //                chartRange.Font.Size = 12;
        //            }                    
        //        }

        //        filaCabecera++;
        //        //Agregar filas detalles
        //        foreach (DataRow rDet in dtDet.Rows)
        //        {
        //            if (idP == rDet[colForanea].ToString())
        //            {
        //                columnaDet = 1;
        //                foreach (DataColumn c in dtDet.Columns)
        //                {
        //                    if (c.ColumnName != colForanea)
        //                    {
        //                        columnaDet++;
        //                        excel.Cells[filaCabecera, columnaDet] = rDet[c.ColumnName];
        //                    }
        //                }
        //                filaCabecera++;
        //            }
                    
        //        }

        //        filaCabecera = filaCabecera + 1;
        //        columnaCab = 0;
        //        foreach (DataColumn c in dtCab.Columns)
        //        {
        //            columnaCab++;
        //            excel.Cells[filaCabecera, columnaCab] = c.ColumnName;

        //            chartRange = xlWorksheet.get_Range("a" + filaCabecera, "z" + filaCabecera);
        //            chartRange.Font.Bold = true;
        //            chartRange.Font.Size = 12;
        //        }
                
        //    }

        //    object missing = System.Reflection.Missing.Value;

        //    libroTrabajo.SaveAs(RutaExcel, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel5);

        //    excel.Quit();
        //}

        public String LeerCiudadDesdeTxt(String ruta)
        {
            String line;
            String Ciudad = "";
            String espacio1;
            String espacio2;
            try
            {
                StreamReader sr = new StreamReader(ruta);

                if (sr.ReadLine() == null)
                {
                    return Ciudad;
                }
                line = sr.ReadLine().Trim();

                while (line != null)
                {
                    if (line.Substring(0, 1) == "I")
                    {
                        espacio1 = line.Substring(1, line.Length - 1).Trim();
                        espacio2 = espacio1.Substring(1, espacio1.Length - 1).Trim();
                        Ciudad = espacio2.Substring(0, espacio2.Length).Trim();
                        break;
                    }

                    line = sr.ReadLine();
                    if (line != null)
                    {
                        line = line.Trim();
                    }

                }

                sr.Close();
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Exception: " + e.Message);
            }
            return Ciudad;
        }

        public String ObtenerCiudad()
        {
            return System.Configuration.ConfigurationManager.AppSettings["Ciudad"].ToString();

        }

        public String ObtenerTipoReporte()
        {
            return System.Configuration.ConfigurationManager.AppSettings["TipoReporte"].ToString();
        }

        /// <summary>
        /// Devuelve un valor Long que especifica el número de
        /// intervalos de tiempo entre dos valores Date.
        /// </summary>
        /// <param name="interval">Obligatorio. Valor de enumeración
        /// DateInterval o expresión String que representa el intervalo
        /// de tiempo que se desea utilizar como unidad de diferencia
        /// entre Date1 y Date2. </param>
        /// <param name="date1">Obligatorio. Date. Primer valor de
        /// fecha u hora que se desea utilizar en el cálculo. </param>
        /// <param name="date2">Obligatorio. Date. Segundo valor de
        /// fecha u hora que se desea utilizar en el cálculo. </param>
        /// <returns></returns>
        public long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
        {
            long rs = 0;
            TimeSpan diff = date2.Subtract(date1);
            switch (interval)
            {
                case DateInterval.Day:
                case DateInterval.DayOfYear:
                    rs = (long)diff.TotalDays;
                    break;
                case DateInterval.Hour:
                    rs = (long)diff.TotalHours;
                    break;
                case DateInterval.Minute:
                    rs = (long)diff.TotalMinutes;
                    break;
                case DateInterval.Month:
                    rs = (date2.Month - date1.Month) + (12 * Funciones.getInstancia().DateDiff(DateInterval.Year, date1, date2));
                    break;
                case DateInterval.Quarter:
                    rs = (long)Math.Ceiling((double)(Funciones.getInstancia().DateDiff(DateInterval.Month, date1, date2) / 3.0));
                    break;
                case DateInterval.Second:
                    rs = (long)diff.TotalSeconds;
                    break;
                case DateInterval.Weekday:
                case DateInterval.WeekOfYear:
                    rs = (long)(diff.TotalDays / 7);
                    break;
                case DateInterval.Year:
                    rs = date2.Year - date1.Year;
                    break;
            }//switch
            return rs;
        }//DateDiff
        public static string GetRGBFrom(Color val)
        {
            string r = "";

            r = string.Format("{0},{1},{2}", val.R, val.G, val.B);

            return r;
        }

        public static Color GetRGBFrom(string val)
        {
            var c = val.Split(',');
            return Color.FromArgb(
            byte.Parse(c[0]),
            byte.Parse(c[1]),
            byte.Parse(c[2])
            );
        }

        public bool IsEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper, RegexOptions.None);
            }
            catch (Exception)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        public String FormatearValorDecimal(String valor)
        {
            string valor1 = valor.Replace(".", "");
            string retorno = valor1.Replace(",", ".");
            return retorno;
        }

        public DateTime PeriodoADateTime(String periodo, Char separador)
        {
            DateTime fecha;

            int mes = Mes2Numero(periodo.Split(separador)[0]);
            int año = Convert.ToInt32(periodo.Split(separador)[1]);

            fecha = new DateTime(año, mes, 1);

            return fecha;
        }

        public bool Auxiliar(string codigoPuc)
        {
            bool r = false;
            if (!String.IsNullOrEmpty(codigoPuc))
            {
                if (codigoPuc.Length > 6)
                {
                    r = true;
                }
                else
                {
                    r = false;
                    XtraMessageBox.Show("El código debe ser un auxiliar", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return r;
        }

        public decimal calcularBultos(String codigoArticulo, decimal cantidad, SqlConnection cConx, String cMode)
        {
            decimal cantidadRes = 0;

            if (cMode == "B")
            {
                if (cantidad > 0)
                {
                    SqlParameter[] par = new [] { new SqlParameter("@CodArti", codigoArticulo) };
                    DataSet dsFactorB = DataBase.ExecuteQuery("proc_LoadFactorBultos", "factor", CommandType.StoredProcedure, par, cConx);

                    if (dsFactorB.Tables[0].Rows.Count != 0)
                    {
                        if (Convert.ToDecimal(dsFactorB.Tables[0].Rows[0][0]) > 0)
                        {
                            cantidadRes = cantidad / Convert.ToDecimal(dsFactorB.Tables[0].Rows[0][0]);
                            cantidadRes = Decimal.Round(cantidadRes);
                        }

                    }
                }
            }
            else
            {
                if (cantidad > 0)
                {
                    SqlParameter[] par = new [] { new SqlParameter("@CodArti", codigoArticulo) };
                    DataSet dsFactorB = DataBase.ExecuteQuery("proc_LoadFactorBultos", "factor", CommandType.StoredProcedure, par, cConx);

                    if (dsFactorB.Tables[0].Rows.Count != 0)
                    {
                        if (Convert.ToDecimal(dsFactorB.Tables[0].Rows[0][0]) > 0)
                        {
                            cantidadRes = cantidad * Convert.ToDecimal(dsFactorB.Tables[0].Rows[0][0]);
                            cantidadRes = Decimal.Round(cantidadRes);
                        }

                    }
                }
            }


            return cantidadRes;
        }


        public void CombinarCorrespondencia1()
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "Heading 1";
            oPara1.Range.Font.Bold = 1;
            oPara1.Format.SpaceAfter = 24; //24 pt spacing after paragraph.
            oPara1.Range.InsertParagraphAfter();

            //Insert a paragraph at the end of the document.
            Word.Paragraph oPara2;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara2.Range.Text = "Heading 2";
            oPara2.Format.SpaceAfter = 6;
            oPara2.Range.InsertParagraphAfter();

            //Insert another paragraph.
            Word.Paragraph oPara3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara3.Range.Text = "This is a sentence of normal text. Now here is a table:";
            oPara3.Range.Font.Bold = 0;
            oPara3.Format.SpaceAfter = 24;
            oPara3.Range.InsertParagraphAfter();

            //Insert a 3 x 5 table, fill it with data, and make the first row
            //bold and italic.
            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 3, 5, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            int r;
            int c;
            string strText;
            for (r = 1; r <= 3; r++)
                for (c = 1; c <= 5; c++)
                {
                    strText = "r" + r + "c" + c;
                    oTable.Cell(r, c).Range.Text = strText;
                }
            oTable.Rows[1].Range.Font.Bold = 1;
            oTable.Rows[1].Range.Font.Italic = 1;

            //Add some text after the table.
            Word.Paragraph oPara4;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara4.Range.InsertParagraphBefore();
            oPara4.Range.Text = "And here's another table:";
            oPara4.Format.SpaceAfter = 24;
            oPara4.Range.InsertParagraphAfter();

            //Insert a 5 x 2 table, fill it with data, and change the column widths.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 5, 2, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            for (r = 1; r <= 5; r++)
                for (c = 1; c <= 2; c++)
                {
                    strText = "r" + r + "c" + c;
                    oTable.Cell(r, c).Range.Text = strText;
                }
            oTable.Columns[1].Width = oWord.InchesToPoints(2); //Change width of columns 1 & 2
            oTable.Columns[2].Width = oWord.InchesToPoints(3);

            //Keep inserting text. When you get to 7 inches from top of the
            //document, insert a hard page break.
            object oPos;
            double dPos = oWord.InchesToPoints(7);
            oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range.InsertParagraphAfter();
            do
            {
                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                wrdRng.ParagraphFormat.SpaceAfter = 6;
                wrdRng.InsertAfter("A line of text");
                wrdRng.InsertParagraphAfter();
                oPos = wrdRng.get_Information
                (Word.WdInformation.wdVerticalPositionRelativeToPage);
            }
            while (dPos >= Convert.ToDouble(oPos));
            object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
            object oPageBreak = Word.WdBreakType.wdPageBreak;
            wrdRng.Collapse(ref oCollapseEnd);
            wrdRng.InsertBreak(ref oPageBreak);
            wrdRng.Collapse(ref oCollapseEnd);
            wrdRng.InsertAfter("We're now on page 2. Here's my chart:");
            wrdRng.InsertParagraphAfter();

            //Insert a chart.
            Word.InlineShape oShape;
            object oClassType = "MSGraph.Chart.8";
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oShape = wrdRng.InlineShapes.AddOLEObject(ref oClassType, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing);

            //Demonstrate use of late bound oChart and oChartApp objects to
            //manipulate the chart object with MSGraph.
            object oChart;
            object oChartApp;
            oChart = oShape.OLEFormat.Object;
            oChartApp = oChart.GetType().InvokeMember("Application",
            BindingFlags.GetProperty, null, oChart, null);

            //Change the chart type to Line.
            object[] Parameters = new Object[1];
            Parameters[0] = 4; //xlLine = 4
            oChart.GetType().InvokeMember("ChartType", BindingFlags.SetProperty,
            null, oChart, Parameters);

            //Update the chart image and quit MSGraph.
            oChartApp.GetType().InvokeMember("Update",
            BindingFlags.InvokeMethod, null, oChartApp, null);
            oChartApp.GetType().InvokeMember("Quit",
            BindingFlags.InvokeMethod, null, oChartApp, null);
            //... If desired, you can proceed from here using the Microsoft Graph 
            //Object model on the oChart and oChartApp objects to make additional
            //changes to the chart.

            //Set the width of the chart.
            oShape.Width = oWord.InchesToPoints(6.25f);
            oShape.Height = oWord.InchesToPoints(3.57f);

            //Add text after the chart.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("THE END.");
        }

        Word.Application wrdApp;
        Word._Document wrdDoc;
        Object oMissing = System.Reflection.Missing.Value;
        Object oFalse = false;

        private void InsertLines(int LineNum)
        {
            int iCount;

            // Insert "LineNum" blank lines.	
            for (iCount = 1; iCount <= LineNum; iCount++)
            {
                wrdApp.Selection.TypeParagraph();
            }
        }

        private void FillRow(Word._Document oDoc, int Row, string Text1,
        string Text2, string Text3, string Text4)
        {
            // Insert the data into the specific cell.
            oDoc.Tables[1].Cell(Row, 1).Range.InsertAfter(Text1);
            //oDoc.Tables[1].Cell(Row, 2).Range.InsertAfter(Text2);
            //oDoc.Tables[1].Cell(Row, 3).Range.InsertAfter(Text3);
            //oDoc.Tables[1].Cell(Row, 4).Range.InsertAfter(Text4);
        }

        private void CreateMailMergeDataFile(DataTable customers)
        {
            Word._Document oDataDoc;
            int iCount;

            Object oName = "E:\\DataDoc.doc";
            Object oHeader = "FirstName";//, LastName, Address, CityStateZip
            wrdDoc.MailMerge.CreateDataSource(ref oName, ref oMissing,
            ref oMissing, ref oHeader, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing);

            // Open the file to insert data.
            oDataDoc = wrdApp.Documents.Open(ref oName, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing /*, ref oMissing */);

            for (iCount = 1; iCount <= 2; iCount++)
            {
                oDataDoc.Tables[1].Rows.Add(ref oMissing);
            }
            int i = 2;

            for (int j = 0; j < customers.Rows.Count; j++)
            {
                FillRow(oDataDoc, j, customers.Rows[j][0].ToString(), customers.Rows[j][1].ToString(), "4567 Main Street", "Buffalo, NY  98052");
            }

            // Save and close the file.
            oDataDoc.Save();
            oDataDoc.Close(ref oFalse, ref oMissing, ref oMissing);
        }

        public string GetExcelConnectionString(string archivoExcel)
        {
            string provider = "Microsoft.Jet.OLEDB.4.0";
            string extendedProperties = "Excel 8.0";
            string headDataRow = "Yes";
            string intermixed = "0";

            string resultad = string.Format("Provider={0};Data Source={1};Extended Properties='{2};HDR={3};IMEX={4}';", provider, archivoExcel, extendedProperties, headDataRow, intermixed);

            return resultad;
        }

        public DataSet LeeDBF(String consulta, String direccionTabla, String user = "", String password = "")
        {
            DataSet ds = new DataSet();
            try
            {
                //String conexionDBF = "Driver={Microsoft Visual FoxPro Driver};Provider=Microsoft.Jet.OLEDB.4.0; SourceType=DBF;SourceDB={" + direccionTabla + "};";
                String conexionDBF = String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=dBase IV; User ID={1}; Password={2}", direccionTabla, user, password);
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = conexionDBF;
                con.Open();

                OleDbDataAdapter da = new OleDbDataAdapter(consulta, con);
                da.Fill(ds);

                con.Close();
                con.Dispose();

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }

            return ds;
        }

        public void CombinarCorrespondencia()
        {
            DataTable dt = new DataTable();
            DataColumn col1 = new DataColumn("Nombre");
            DataColumn col2 = new DataColumn("Titulo");

            dt.Columns.Add(col1);
            dt.Columns.Add(col2);

            dt.Rows.Add(new String[] { "STEVE" });//, "STEVE" 
            dt.Rows.Add(new String[] { "CARLOS" });//, "CARLOS"

            Word.Selection wrdSelection;
            Word.MailMerge wrdMailMerge;
            Word.MailMergeFields wrdMergeFields;
            Word.Table wrdTable;
            string StrToAdd;

            // Create an instance of Word  and make it visible.
            wrdApp = new Word.Application();
            wrdApp.Visible = true;

            // Add a new document.
            wrdDoc = wrdApp.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);
            wrdDoc.Select();

            wrdSelection = wrdApp.Selection;
            wrdMailMerge = wrdDoc.MailMerge;

            // Create a MailMerge Data file.
            CreateMailMergeDataFile(dt);

            // Create a string and insert it into the document.
            StrToAdd = "State University\r\nElectrical Engineering Department";
            wrdSelection.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wrdSelection.TypeText(StrToAdd);

            InsertLines(4);

            // Insert merge data.
            wrdSelection.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphLeft;
            wrdMergeFields = wrdMailMerge.Fields;
            wrdMergeFields.Add(wrdSelection.Range, "FirstName");
            wrdSelection.TypeText(" ");
            //wrdMergeFields.Add(wrdSelection.Range, "LastName");
            //wrdSelection.TypeParagraph();

            //wrdMergeFields.Add(wrdSelection.Range, "Address");
            //wrdSelection.TypeParagraph();
            //wrdMergeFields.Add(wrdSelection.Range, "CityStateZip");

            InsertLines(2);

            // Right justify the line and insert a date field
            // with the current date.
            wrdSelection.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphRight;

            Object objDate = "dddd, MMMM dd, yyyy";
            wrdSelection.InsertDateTime(ref objDate, ref oFalse, ref oMissing,
            ref oMissing, ref oMissing);

            InsertLines(2);

            // Justify the rest of the document.
            wrdSelection.ParagraphFormat.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphJustify;

            wrdSelection.TypeText("Dear ");
            wrdMergeFields.Add(wrdSelection.Range, "FirstName");
            wrdSelection.TypeText(",");
            InsertLines(2);

            // Create a string and insert it into the document.
            StrToAdd = "Thank you for your recent request for next " +
            "semester's class schedule for the Electrical " +
            "Engineering Department. Enclosed with this " +
            "letter is a booklet containing all the classes " +
            "offered next semester at State University.  " +
            "Several new classes will be offered in the " +
            "Electrical Engineering Department next semester.  " +
            "These classes are listed below.";
            wrdSelection.TypeText(StrToAdd);

            InsertLines(2);

            // Insert a new table with 9 rows and 4 columns.
            wrdTable = wrdDoc.Tables.Add(wrdSelection.Range, 9, 4,
            ref oMissing, ref oMissing);
            // Set the column widths.
            wrdTable.Columns[1].SetWidth(51, Word.WdRulerStyle.wdAdjustNone);
            wrdTable.Columns[2].SetWidth(170, Word.WdRulerStyle.wdAdjustNone);
            wrdTable.Columns[3].SetWidth(100, Word.WdRulerStyle.wdAdjustNone);
            wrdTable.Columns[4].SetWidth(111, Word.WdRulerStyle.wdAdjustNone);
            // Set the shading on the first row to light gray.
            wrdTable.Rows[1].Cells.Shading.BackgroundPatternColorIndex =
            Word.WdColorIndex.wdGray25;
            // Bold the first row.
            wrdTable.Rows[1].Range.Bold = 1;
            // Center the text in Cell (1,1).
            wrdTable.Cell(1, 1).Range.Paragraphs.Alignment =
            Word.WdParagraphAlignment.wdAlignParagraphCenter;

            // Fill each row of the table with data.
            FillRow(wrdDoc, 1, "Class Number", "Class Name",
            "Class Time", "Instructor");
            FillRow(wrdDoc, 2, "EE220", "Introduction to Electronics II",
            "1:00-2:00 M,W,F", "Dr. Jensen");
            FillRow(wrdDoc, 3, "EE230", "Electromagnetic Field Theory I",
            "10:00-11:30 T,T", "Dr. Crump");
            FillRow(wrdDoc, 4, "EE300", "Feedback Control Systems",
            "9:00-10:00 M,W,F", "Dr. Murdy");
            FillRow(wrdDoc, 5, "EE325", "Advanced Digital Design",
            "9:00-10:30 T,T", "Dr. Alley");
            FillRow(wrdDoc, 6, "EE350", "Advanced Communication Systems",
            "9:00-10:30 T,T", "Dr. Taylor");
            FillRow(wrdDoc, 7, "EE400", "Advanced Microwave Theory",
            "1:00-2:30 T,T", "Dr. Lee");
            FillRow(wrdDoc, 8, "EE450", "Plasma Theory",
            "1:00-2:00 M,W,F", "Dr. Davis");
            FillRow(wrdDoc, 9, "EE500", "Principles of VLSI Design",
            "3:00-4:00 M,W,F", "Dr. Ellison");

            // Go to the end of the document.
            Object oConst1 = Word.WdGoToItem.wdGoToLine;
            Object oConst2 = Word.WdGoToDirection.wdGoToLast;
            wrdApp.Selection.GoTo(ref oConst1, ref oConst2, ref oMissing, ref oMissing);
            InsertLines(2);

            // Create a string and insert it into the document.
            StrToAdd = "For additional information regarding the " +
            "Department of Electrical Engineering, " +
            "you can visit our Web site at ";
            wrdSelection.TypeText(StrToAdd);
            // Insert a hyperlink to the Web page.
            Object oAddress = "http://www.ee.stateu.tld";
            Object oRange = wrdSelection.Range;
            wrdSelection.Hyperlinks.Add(oRange, ref oAddress, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing);
            // Create a string and insert it into the document
            StrToAdd = ".  Thank you for your interest in the classes " +
            "offered in the Department of Electrical " +
            "Engineering.  If you have any other questions, " +
            "please feel free to give us a call at " +
            "555-1212.\r\n\r\n" +
            "Sincerely,\r\n\r\n" +
            "Kathryn M. Hinsch\r\n" +
            "Department of Electrical Engineering \r\n";
            wrdSelection.TypeText(StrToAdd);

            // Perform mail merge.
            wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToNewDocument;
            wrdMailMerge.Execute(ref oFalse);

            // Close the original form document.
            wrdDoc.Saved = true;
            wrdDoc.Close(ref oFalse, ref oMissing, ref oMissing);


            // Release References.
            wrdSelection = null;
            wrdMailMerge = null;
            wrdMergeFields = null;
            wrdDoc = null;
            wrdApp = null;

            // Clean up temp file.
            System.IO.File.Delete("E:\\DataDoc.doc");
        }

        public void StartProcess(string path)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = path;
                process.Start();
                process.WaitForInputIdle();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public String GetConcecutivo(String Database, String TipoDoc, String mensaje, string Tipo)
        {
            string sql = "select dbo.GetConsecutivo('" + TipoDoc + "'," + Tipo + ")";
            DataTable dtConsecutivo = DataBase.ExecuteQueryDataTable(sql, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

            String conse = "";

            if (dtConsecutivo.Rows.Count > 0)
            {
                conse = dtConsecutivo.Rows[0][0].ToString();

            }
            else
            {
                if (String.IsNullOrEmpty(mensaje))
                {
                    mensaje = "Debe configurar la fuente de las notas contables";
                }
                MessageBox.Show(mensaje, GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return conse;
        }

        public String GetFuente(String Database, String TipoDoc, String mensaje)
        {
            string sql = "select docfte from tipodocumento where doccod = '" + TipoDoc + "'";
            DataTable dtFuente = DataBase.ExecuteQueryDataTable(sql, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

            String conse = "";

            if (dtFuente.Rows.Count > 0)
            {
                conse = dtFuente.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show(mensaje, GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return conse;
        }

        //public void ImprimirNota(String Database, String Documento, String Fuente)
        //{
        //    SqlParameter[] parametros = new [] { new SqlParameter("@Documento", Documento) //
        //    , 
        //    new SqlParameter("@Fuente", Fuente) };//

        //    DataSet dsContable = DataBase.ExecuteQuery("Proc_Imprimir_Nota", "Cabecera", CommandType.StoredProcedure, parametros, ConexionDB.getInstancia().Conexion(Database, null));
        //    if (dsContable.Tables.Count == 0)
        //    {
        //        MessageBox.Show("Datos no encontrados, verifique los datos por favor...!", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //    RptNotaContableSt report = new RptNotaContableSt();
        //    report.Database = Database;
        //    report.DataSource = dsContable;
        //    report.ShowPreviewDialog();
        //}

        //public void ImprimirRemiDevoEmpaque(String Database, String Id)
        //{
        //    SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@Operacion", "P"),
        //    new SqlParameter("@Id", Id) };
        //    DataSet dsimprimir = DataBase.ExecuteQuery("PA_RemisionDevolucionEmpaque", "Datos", CommandType.StoredProcedure, parametros, ConexionDB.getInstancia().Conexion(Database, null));

        //    //dsimprimir.WriteXmlSchema(System.Windows.Forms.Application.StartupPath + @"/Temp/DsRemisionDevolucionEmpaque.xsd");

        //    RptRemiDevoEmpaque Report = new RptRemiDevoEmpaque();
        //    Report.DataSource = dsimprimir;
        //    Report.Database = Database;
        //    Report.Empresa();
        //    //Show the print preview. 
        //    PrintingSystemBase ps = Report.PrintingSystem;

        //    Report.ShowRibbonPreview();

        //    ps.ExecCommand(PrintingSystemCommand.Scale, new object[] { 1 });
        //}

        //public void ImprimirFactura(String Database, String Documento)
        //{
        //    DataTable dtCabeceraFac = new DataTable();
        //    DataTable dtDetallesFac = new DataTable();
        //    DataSet dsImprimir = new DataSet();
        //    try
        //    {
        //        dtDetallesFac.Rows.Clear();
        //        dtCabeceraFac.Rows.Clear();
        //        String numeroFactura = Documento;
        //        SqlParameter[] parametros3 = new [] { new SqlParameter("@Operacion", "PC"), new SqlParameter("@NumeroFactura", numeroFactura) };
        //        DataTable dtCabFac = DataBase.ExecuteQueryDataTable("PA_ViewCMIVentas", "Cabecera", CommandType.StoredProcedure, parametros3, ConexionDB.getInstancia().Conexion(Database, null));
        //        dtCabFac.TableName = "Cabecera";

        //        if (dtCabeceraFac.Columns.Count == 0)
        //        {
        //            dtCabeceraFac = dtCabFac.Clone();
        //        }

        //        if (dtCabFac.Rows.Count > 0)
        //        {
        //            for (int j = 0; j < dtCabFac.Rows.Count; j++)
        //            {
        //                dtCabeceraFac.Rows.Add(dtCabFac.Rows[j].ItemArray);
        //            }
        //        }

        //        SqlParameter[] parametros4 = new [] { new SqlParameter("@Operacion", "PD"), new SqlParameter("@NumeroFactura", numeroFactura) };
        //        DataTable dtDetFac = DataBase.ExecuteQueryDataTable("PA_ViewCMIVentas", "Detalles", CommandType.StoredProcedure, parametros4, ConexionDB.getInstancia().Conexion(Database, null));
        //        dtDetFac.TableName = "Detalles";
        //        if (dtDetallesFac.Columns.Count == 0)
        //        {
        //            dtDetallesFac = dtDetFac.Clone();
        //        }

        //        if (dtDetFac.Rows.Count > 0)
        //        {
        //            for (int j = 0; j < dtDetFac.Rows.Count; j++)
        //            {
        //                dtDetallesFac.Rows.Add(dtDetFac.Rows[j].ItemArray);
        //            }
        //        }

        //        if (dsImprimir.Tables.Count == 0 && dtDetFac.Rows.Count > 0)
        //        {
        //            dsImprimir.Tables.Add(dtCabeceraFac);
        //            dsImprimir.Tables.Add(dtDetallesFac);

        //            DataColumn keyColumn = dsImprimir.Tables["Cabecera"].Columns["NumeroFac"];
        //            DataColumn foreignKeyColumn = dsImprimir.Tables["Detalles"].Columns["NumeroFac"];
        //            dsImprimir.Relations.Add("Relacion", keyColumn, foreignKeyColumn);

        //            string tipoImpre = null;
        //            SqlParameter[] paramTipo = new [] { new SqlParameter("@Operacion", "tipofacturacredito"), new SqlParameter("@NumeroFactura", numeroFactura) };
        //            DataTable DtTipo = DataBase.ExecuteQueryDataTable("PA_ViewCMIVentas", "tipofacturacredito", CommandType.StoredProcedure, paramTipo, ConexionDB.getInstancia().Conexion(Database, null));
        //            if (DtTipo.Rows.Count > 0)
        //            {
        //                tipoImpre = DtTipo.Rows[0][0].ToString();
        //                if (tipoImpre == "1")
        //                {
        //                    RptFacturas report = new RptFacturas();
        //                    report.DataSource = dsImprimir;
        //                    report.Database = Database;
        //                    report.Empresa();
        //                    report.SinMarcaAgua();
        //                    //report.ShowPreview();
        //                    PrintingSystemBase ps = report.PrintingSystem;

        //                    report.ShowRibbonPreview();

        //                    ps.ExecCommand(PrintingSystemCommand.Scale, new object[] { 1 });
        //                }
        //                if (tipoImpre == "2")
        //                {
        //                    RptFacturasMedio report = new RptFacturasMedio();////RptFacturas Tamaño Medio
        //                    report.DataSource = dsImprimir;
        //                    report.Database = Database;
        //                    report.Empresa();
        //                    report.SinMarcaAgua();
        //                    //report.ShowPreview();
        //                    PrintingSystemBase ps = report.PrintingSystem;

        //                    report.ShowRibbonPreview();

        //                    ps.ExecCommand(PrintingSystemCommand.Scale, new object[] { 1 });
        //                }

        //            }
        //            else
        //            {
        //                XtraMessageBox.Show("Debe seleccionar el tipo de pagina de la factura.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            }
        //        }
        //        else
        //        {
        //            XtraMessageBox.Show("No se puede imprimir la factura.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(" " + ex, GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //public void ImprimirFactura(String Database, DataSet Dsimprimir, bool OcultarMarcaAgua = false)
        //{
        //    try
        //    {
        //        string tipoImpre = null;
        //        SqlParameter[] paramTipo = new [] { new SqlParameter("@Operacion", "tipofacturacredito") };
        //        DataTable DtTipo = DataBase.ExecuteQueryDataTable("PA_ViewCMIVentas", "tipofacturacredito", CommandType.StoredProcedure, paramTipo, ConexionDB.getInstancia().Conexion(Database, null));
        //        if (DtTipo.Rows.Count > 0)
        //        {
        //            tipoImpre = DtTipo.Rows[0][0].ToString();
        //            if (tipoImpre == "1")
        //            {
        //                RptFacturas2 report = new RptFacturas2();
        //                report.DataSource = Dsimprimir;
        //                report.Database = Database;
        //                report.Empresa();
        //                if (OcultarMarcaAgua)
        //                {
        //                    report.SinMarcaAgua();
        //                }
        //                //report.ShowPreview();
        //                PrintingSystemBase ps = report.PrintingSystem;

        //                report.ShowRibbonPreview();

        //                ps.ExecCommand(PrintingSystemCommand.Scale, new object[] { 1 });
        //            }
        //            if (tipoImpre == "2")
        //            {
        //                RptFacturasMedio report = new RptFacturasMedio();////RptFacturas Tamaño Medio
        //                report.DataSource = Dsimprimir;
        //                report.Database = Database;
        //                report.Empresa();
        //                if (!OcultarMarcaAgua)
        //                {
        //                    report.SinMarcaAgua();
        //                }
        //                //report.ShowPreview();
        //                PrintingSystemBase ps = report.PrintingSystem;

        //                report.ShowRibbonPreview();

        //                ps.ExecCommand(PrintingSystemCommand.Scale, new object[] { 1 });
        //            }
        //        }
        //        else
        //        {
        //            XtraMessageBox.Show("Debe seleccionar el tipo de pagina de la factura.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        XtraMessageBox.Show(" " + ex, GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public string ConvertFirstLetterToUpper(string strWord)
        {
            try
            {
                string[] arrWords = strWord.Split(' ');
                string strTemp2 = string.Empty;

                if (arrWords.Length > 1) //Existe mas de una palabra, Ej ANA MARIA
                {
                    foreach (string strTemp in arrWords)
                    {
                        strTemp2 += strTemp.Substring(0, 1).ToUpper() + strTemp.Substring(1).ToLower() + " ";
                    }
                }
                else
                {
                    strTemp2 = arrWords[0].Substring(0, 1).ToUpper() + arrWords[0].Substring(1).ToLower() + " ";
                }

                return strTemp2.Substring(0, strTemp2.Length - 1);
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
                return strWord;
            }
        }

        //public void ImprimirFacturaTemporal(String Database, String Documento)
        //{
        //    DataTable dtCabeceraFac = new DataTable();
        //    DataTable dtDetallesFac = new DataTable();
        //    DataSet dsImprimir = new DataSet();
        //    try
        //    {
        //        dtDetallesFac.Rows.Clear();
        //        dtCabeceraFac.Rows.Clear();
        //        String numeroFactura = Documento;
        //        SqlParameter[] parametros3 = new[] { new SqlParameter("@Operacion", "PCTMP"), new SqlParameter("@NumeroFactura", numeroFactura) };
        //        DataTable dtCabFac = DataBase.ExecuteQueryDataTable("PA_ImbCargarCanon", "Cabecera", CommandType.StoredProcedure, parametros3, ConexionDB.getInstancia().Conexion(Database, null));
        //        dtCabFac.TableName = "Cabecera";

        //        if (dtCabeceraFac.Columns.Count == 0)
        //        {
        //            dtCabeceraFac = dtCabFac.Clone();
        //        }

        //        if (dtCabFac.Rows.Count > 0)
        //        {
        //            for (int j = 0; j < dtCabFac.Rows.Count; j++)
        //            {
        //                dtCabeceraFac.Rows.Add(dtCabFac.Rows[j].ItemArray);
        //            }
        //        }

        //        SqlParameter[] parametros4 = new[] { new SqlParameter("@Operacion", "PDTMP"), new SqlParameter("@NumeroFactura", numeroFactura) };
        //        DataTable dtDetFac = DataBase.ExecuteQueryDataTable("PA_ImbCargarCanon", "Detalles", CommandType.StoredProcedure, parametros4, ConexionDB.getInstancia().Conexion(Database, null));
        //        dtDetFac.TableName = "Detalles";
        //        if (dtDetallesFac.Columns.Count == 0)
        //        {
        //            dtDetallesFac = dtDetFac.Clone();
        //        }

        //        if (dtDetFac.Rows.Count > 0)
        //        {
        //            for (int j = 0; j < dtDetFac.Rows.Count; j++)
        //            {
        //                dtDetallesFac.Rows.Add(dtDetFac.Rows[j].ItemArray);
        //            }
        //        }

        //        if (dsImprimir.Tables.Count == 0 && dtDetFac.Rows.Count > 0)
        //        {
        //            dsImprimir.Tables.Add(dtCabeceraFac);
        //            dsImprimir.Tables.Add(dtDetallesFac);

        //            DataColumn keyColumn = dsImprimir.Tables["Cabecera"].Columns["NumeroFac"];
        //            DataColumn foreignKeyColumn = dsImprimir.Tables["Detalles"].Columns["NumeroFac"];
        //            dsImprimir.Relations.Add("Relacion", keyColumn, foreignKeyColumn);

        //            string tipoImpre = null;
        //            SqlParameter[] paramTipo = new[] { new SqlParameter("@Operacion", "tipofacturacredito"), new SqlParameter("@NumeroFactura", numeroFactura) };
        //            DataTable DtTipo = DataBase.ExecuteQueryDataTable("PA_ImbCargarCanon", "tipofacturacredito", CommandType.StoredProcedure, paramTipo, ConexionDB.getInstancia().Conexion(Database, null));
        //            if (DtTipo.Rows.Count > 0)
        //            {
        //                tipoImpre = DtTipo.Rows[0][0].ToString();
        //                if (tipoImpre == "1")
        //                {
        //                    RptFacturas report = new RptFacturas();
        //                    report.DataSource = dsImprimir;
        //                    report.Database = Database;
        //                    report.Empresa();
        //                    //report.SinMarcaAgua();
        //                    //report.ShowPreview();
        //                    PrintingSystemBase ps = report.PrintingSystem;

        //                    report.ShowRibbonPreview();

        //                    ps.ExecCommand(PrintingSystemCommand.Scale, new object[] { 1 });
        //                }
        //                if (tipoImpre == "2")
        //                {
        //                    RptFacturasMedio report = new RptFacturasMedio();////RptFacturas Tamaño Medio
        //                    report.DataSource = dsImprimir;
        //                    report.Database = Database;
        //                    report.Empresa();
        //                    //report.SinMarcaAgua();
        //                    //report.ShowPreview();
        //                    PrintingSystemBase ps = report.PrintingSystem;

        //                    report.ShowRibbonPreview();

        //                    ps.ExecCommand(PrintingSystemCommand.Scale, new object[] { 1 });
        //                }

        //            }
        //            else
        //            {
        //                XtraMessageBox.Show("Debe seleccionar el tipo de pagina de la factura.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            }
        //        }
        //        else
        //        {
        //            XtraMessageBox.Show("No se puede imprimir la factura.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(" " + ex, GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        /*****************************************************************************************/
        /*Funciones Desarrolladas para calcular valores IVA en el CMI de Cotizaciones
                 Desarrollado Por: Jorge Luis Sierra Vergara.
                 */
        /****************************************************************************************/

        public Double DevolverValorIva(double valor_unitario, double cantidad, double tarifa, double descuento , string Databasee)
        {
            return (DevolverUnitarioSinIva(valor_unitario, tarifa, descuento, Databasee) * (tarifa / 100)) * cantidad;
        }

        public Double DevolverValorTotal(double valor_unitario, double cantidad, double valorIva, double tarifa, double descuento, string database)
        {
            double subtotal = DevolverUnitarioSinIva(valor_unitario, tarifa, descuento, database) * cantidad;
            double total = subtotal + valorIva;
            return total;
        }

        public Double DevolverValorSubTotal(double valor_unitario, double tarifa, double cantidad , double descuento, string Databasee)
        {
            Double subtotal = 0;
            return subtotal = DevolverUnitarioSinIva(valor_unitario, tarifa, descuento, Databasee) * cantidad ;
        }

        public Double DevolverUnitarioSinIva(double valor_unitario, double tarifa, double descuento, string Databasee)
        {
            double baseCalculo = 0;
            double valorDescuento = 0;
            double nuevoPrecio = 0;

            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@Operacion", "GCONFINV") };
            DataTable dt = DataBase.ExecuteQueryDataTable("PA_CotizacionesIM", "Cabecera", CommandType.StoredProcedure, parametros, ConexionDB.getInstancia().Conexion(Databasee, null));
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][3].ToString().Equals("1"))
                {
                    baseCalculo    = (valor_unitario / (1 + (tarifa / 100)));
                    valorDescuento = baseCalculo * (descuento / 100);
                    nuevoPrecio    = baseCalculo - valorDescuento;

                }
                else
                {
                    baseCalculo    = valor_unitario;
                    valorDescuento = baseCalculo * (descuento / 100);
                    nuevoPrecio    = baseCalculo - valorDescuento;
                }

                return nuevoPrecio;
            }
            else
            {
                return 0;
            }
        }

        public bool ValidarIvaPorcentaje(double tariva, int  tartip, int glmodalidad  , String Database)
        {
            SqlParameter[] parametros = new SqlParameter[] {
            new SqlParameter("@Operacion", "IVA_POR"),
            new SqlParameter("@Tariva", tariva),
            new SqlParameter("@TarTip", tartip),
            new SqlParameter("@GlModalidad", glmodalidad)
            };

            DataTable dtPorIva = DataBase.ExecuteQueryDataTable("PA_CotizacionesIM", "Cabecera", CommandType.StoredProcedure, parametros, ConexionDB.getInstancia().Conexion(Database, null));
            if (dtPorIva.Rows.Count > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public String GetName(String Database, String Tabla, String Campo, String Condicion)
        {
            // String where = (String.IsNullOrEmpty(Condicion) == true) ?  "where " + Condicion:"";
            string sql = "";
            if (String.IsNullOrEmpty(Condicion))
            {
                sql = String.Format("select {0} from {1}", Campo, Tabla);
            }
            else
            {
                sql = String.Format("select {0} from {1} Where {2} ", Campo, Tabla, Condicion);
            }
            DataTable dtDato = DataBase.ExecuteQueryDataTable(sql, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

            String vDato = "";

            if (dtDato.Rows.Count > 0)
            {
                vDato = dtDato.Rows[0][0].ToString();
            }
            return vDato;
        }

        public String getConsecutivo_Fuente(String glCodigoFuente, String dataBase)
        {
            String retorno = "";

            String cadSQl = "SELECT dbo.getConsecutivo_con_Fuente('" + glCodigoFuente + "') AS ftecon";

            DataSet dsConsecutivo = DataBase.ExecuteQuery(cadSQl, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(dataBase, null));

            if (dsConsecutivo.Tables[0].Rows.Count > 0)
            {
                retorno = " " + (dsConsecutivo.Tables[0].Rows[0]["ftecon"]).ToString();
            }
            return retorno.ToString();
        }



        public bool ValidarFecha(DateTime fecha, int MesPeriodo, int AñoPeriodo, String dataBase)
        {
            bool retorno = true;


            String sql = "SELECT ccest FROM accglccmes WHERE ccMes ='" + MesPeriodo + "' AND ccAño ='" + AñoPeriodo + "'";

            DataSet dsPeriodo = DataBase.ExecuteQuery(sql, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(dataBase, null));

            bool cierre = false;
            if (dsPeriodo.Tables[0].Rows.Count > 0)
            {
                cierre = Convert.ToBoolean(dsPeriodo.Tables[0].Rows[0]["ccest"]);
            }

            if (cierre)
            {
                XtraMessageBox.Show("Error, el período está cerrado. Por favor verifique.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                retorno = false;
            }

            if (MesPeriodo != fecha.Month || AñoPeriodo != fecha.Year)
            {
                String mes = Funciones.getInstancia().Numero2Mes(MesPeriodo);
                XtraMessageBox.Show("El documento que intenta crear no corresponde al periodo que se esta trabajando (" + mes + " " + AñoPeriodo + "). Por favor verifique.", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                retorno = false;
            }

            return retorno;
        }

        public string SumaRestaHoras(int h1, int m1, int h2, int m2, string operacion = "+")
        {
            string horaResultado = "";

            int sumH = 0;
            int sumM = 0;

            if (operacion == "+")
            {
                sumH = h1 + h2;
                sumM = m1 + m2;

                if (sumM >= 60)
                {
                    sumM = sumM - 60;
                    sumH = sumH + 1;
                }
            }

            if (operacion == "-")
            {
                sumH = h1 - h2;
                sumM = m1 - m2;

                if (sumM < 0)
                {
                    sumM = sumM + 60;
                    sumH = sumH - 1;
                }
            }

            string h = RellenarCadenaPorLaIzquierda(sumH.ToString(), '0', 2);
            string m = RellenarCadenaPorLaIzquierda(sumM.ToString(), '0', 2);

            horaResultado = h + ":" + m;
            return horaResultado;
        }

        public string DiferenciaHoras(DateTime fechaHoraIni,DateTime fechaHoraFin) 
        {
            string horaRetorno = "";

            TimeSpan Span = fechaHoraFin.Subtract(fechaHoraIni);
            if (Span.Days>0)
            {
                int totalHoras = Span.Days*24+Span.Hours;
                horaRetorno = RellenarCadenaPorLaIzquierda(totalHoras.ToString(), '0', 2) + ":" + RellenarCadenaPorLaIzquierda(Span.Minutes.ToString(), '0', 2);
            }
            else
            {
                horaRetorno = RellenarCadenaPorLaIzquierda(Span.Hours.ToString(), '0', 2) + ":" + RellenarCadenaPorLaIzquierda(Span.Minutes.ToString(), '0', 2);

            }
            return horaRetorno;
        }

        public string HoraMilitar(string hora)
        {
            hora = hora.Replace(":", "");
            string horaRetorno = "";

            if (hora.Contains("m"))
            {
                if (hora.ToLower().Contains("a.m") || hora.ToLower().Contains("am") || hora.ToLower().Contains("a m"))
                {
                    if (hora.Substring(0, 2) == "12")
                    {
                        horaRetorno = "00" + hora.Substring(2, 2);
                    }
                    else
                    {
                        horaRetorno = hora.Substring(0, 2) + hora.Substring(2, 2);
                    }
                }

                if (hora.ToLower().Contains("p.m") || hora.ToLower().Contains("pm") || hora.ToLower().Contains("p m"))
                {
                    if (hora.Substring(0, 2) == "12")
                    {
                        horaRetorno = hora;
                    }
                    else
                    {
                        horaRetorno = (Convert.ToInt32(hora.Substring(0, 2)) + 12).ToString() + hora.Substring(2, 2);
                    }
                }
            }
            else
            {
                horaRetorno = hora;
            }

            return horaRetorno;
        }

        public int UltimoDiaMes(int año,int mes) 
        {            
            int ultimoDia = 28;
            DateTime fecha = new DateTime(año, mes, ultimoDia);

            while (fecha.Month == mes)
            {
                ultimoDia = fecha.Day;
                fecha = fecha.AddDays(1);
            }
            
            return ultimoDia;        
        }

        public string SumarRestarHorasStr(string hora1, string hora2,string operacion="+") 
        {
            string retorno = "";

            int xhora1 = Convert.ToDateTime(hora1).Hour,
                xminutos1 = Convert.ToDateTime(hora1).Minute,
                xhora2 = Convert.ToDateTime(hora2).Hour,
                xminutos2 = Convert.ToDateTime(hora2).Minute;

            retorno = SumaRestaHoras(xhora2, xminutos2, xhora1, xminutos1,operacion);
            return retorno;
        }

        public String DatetimeCompleteHora(DateTime fecha)
        {
            string mes = fecha.Month.ToString();
            if (mes.Length == 1)
            {
                mes = '0' + mes;
            }
            string dia = fecha.Day.ToString();
            if (dia.Length == 1)
            {
                dia = '0' + dia;
            }

            string hora = fecha.Hour.ToString();
            if (hora.Length == 1)
            {
                hora = '0' + hora;
            }

            string minutos = fecha.Minute.ToString();
            if (minutos.Length == 1)
            {
                minutos = '0' + minutos;
            }

            string segudos = fecha.Second.ToString();
            if (segudos.Length == 1)
            {
                segudos = '0' + segudos;
            }
            return fecha.Year.ToString() + mes + dia + " " + hora + ":" + minutos + ":" + segudos;
        }

        //private void DisplayQuarterlySales(Excel._Worksheet oWS)
        //{
        //    Excel._Workbook oWB;
        //    Excel.Series oSeries;
        //    Excel.Range oResizeRange;
        //    Excel._Chart oChart;
        //    String sMsg;
        //    int iNumQtrs;

        //    //Determine how many quarters to display data for.
        //    for (iNumQtrs = 4; iNumQtrs >= 2; iNumQtrs--)
        //    {
        //        sMsg = "Enter sales data for ";
        //        sMsg = String.Concat(sMsg, iNumQtrs);
        //        sMsg = String.Concat(sMsg, " quarter(s)?");

        //        DialogResult iRet = MessageBox.Show(sMsg, "Quarterly Sales?",
        //            MessageBoxButtons.YesNo);
        //        if (iRet == DialogResult.Yes)
        //            break;
        //    }

        //    sMsg = "Displaying data for ";
        //    sMsg = String.Concat(sMsg, iNumQtrs);
        //    sMsg = String.Concat(sMsg, " quarter(s).");

        //    MessageBox.Show(sMsg, "Quarterly Sales");

        //    //Starting at E1, fill headers for the number of columns selected.
        //    oResizeRange = oWS.get_Range("E1", "E1").get_Resize(Missing.Value, iNumQtrs);
        //    oResizeRange.Formula = "=\"Q\" & COLUMN()-4 & CHAR(10) & \"Sales\"";

        //    //Change the Orientation and WrapText properties for the headers.
        //    oResizeRange.Orientation = 38;
        //    oResizeRange.WrapText = true;

        //    //Fill the interior color of the headers.
        //    oResizeRange.Interior.ColorIndex = 36;

        //    //Fill the columns with a formula and apply a number format.
        //    oResizeRange = oWS.get_Range("E2", "E6").get_Resize(Missing.Value, iNumQtrs);
        //    oResizeRange.Formula = "=RAND()*100";
        //    oResizeRange.NumberFormat = "$0.00";

        //    //Apply borders to the Sales data and headers.
        //    oResizeRange = oWS.get_Range("E1", "E6").get_Resize(Missing.Value, iNumQtrs);
        //    oResizeRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

        //    //Add a Totals formula for the sales data and apply a border.
        //    oResizeRange = oWS.get_Range("E8", "E8").get_Resize(Missing.Value, iNumQtrs);
        //    oResizeRange.Formula = "=SUM(E2:E6)";
        //    oResizeRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle
        //        = Excel.XlLineStyle.xlDouble;
        //    oResizeRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).Weight
        //        = Excel.XlBorderWeight.xlThick;

        //    //Add a Chart for the selected data.
        //    oWB = (Excel._Workbook)oWS.Parent;
        //    oChart = (Excel._Chart)oWB.Charts.Add(Missing.Value, Missing.Value,
        //        Missing.Value, Missing.Value);

        //    //Use the ChartWizard to create a new chart from the selected data.
        //    oResizeRange = oWS.get_Range("E2:E6", Missing.Value).get_Resize(
        //        Missing.Value, iNumQtrs);
        //    oChart.ChartWizard(oResizeRange, Excel.XlChartType.xl3DColumn, Missing.Value,
        //        Excel.XlRowCol.xlColumns, Missing.Value, Missing.Value, Missing.Value,
        //        Missing.Value, Missing.Value, Missing.Value, Missing.Value);
        //    oSeries = (Excel.Series)oChart.SeriesCollection(1);
        //    oSeries.XValues = oWS.get_Range("A2", "A6");
        //    for (int iRet = 1; iRet <= iNumQtrs; iRet++)
        //    {
        //        oSeries = (Excel.Series)oChart.SeriesCollection(iRet);
        //        String seriesName;
        //        seriesName = "=\"Q";
        //        seriesName = String.Concat(seriesName, iRet);
        //        seriesName = String.Concat(seriesName, "\"");
        //        oSeries.Name = seriesName;
        //    }

        //    oChart.Location(Excel.XlChartLocation.xlLocationAsObject, oWS.Name);

        //    //Move the chart so as not to cover your data.
        //    oResizeRange = (Excel.Range)oWS.Rows.get_Item(10, Missing.Value);
        //    oWS.Shapes.Item("Chart 1").Top = (float)(double)oResizeRange.Top;
        //    oResizeRange = (Excel.Range)oWS.Columns.get_Item(2, Missing.Value);
        //    oWS.Shapes.Item("Chart 1").Left = (float)(double)oResizeRange.Left;
        //}

        private void ExportaFormatos(GridView dgv)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            dgv.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            dgv.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            dgv.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            dgv.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            dgv.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            dgv.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportarExcelMultiplesPag(GridControl gCtrl)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (.xlsx)|*.xlsx";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var printingSystem = new PrintingSystemBase();
                    var compositeLink = new CompositeLinkBase();
                    compositeLink.PrintingSystemBase = printingSystem;

                    var link1 = new PrintableComponentLinkBase();
                    link1.Component = gCtrl;
                    var link2 = new PrintableComponentLinkBase();
                    link2.Component = gCtrl;

                    compositeLink.Links.Add(link1);
                    compositeLink.Links.Add(link2);

                    var options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.SingleFilePageByPage;

                    compositeLink.CreatePageForEachLink();
                    compositeLink.ExportToXlsx(saveDialog.FileName, options);
                }
            }
        }
        

       
    }
}
