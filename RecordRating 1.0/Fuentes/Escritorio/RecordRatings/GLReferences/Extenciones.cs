using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace GLReferences
{
    public static class Extenciones
    {
        public static string Vector2Cadena(this string x, string caracter, string[] vector)
        {
            string cadena = "";
            for (int i = 0; i < vector.Length; i++)
            {
                if (i == 0)
                    cadena = vector[i];
                else
                    cadena = cadena + caracter + vector[i];
            }

            return cadena;
        }

        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }

        public static float ToFloat(this string str)
        {
            return float.Parse(str);
        }

        public static float ToFloat(this decimal str)
        {
            return float.Parse(str.ToString());
        }


        // Export DataTable into an excel file with field names in the header line
        // - Save excel file without ever making it visible if filepath is given
        // - Don't save excel file, just make it visible if no filepath is given
        //public static void ExportToExcelCont(this DataTable tabla, params string[] PrimerasLineas)
        //{
        //    Excel.Application oXL;
        //    Excel._Workbook oWB;
        //    Excel._Worksheet oSheet;
        //    Excel.Range oRng;

        //    try
        //    {
        //        //Start Excel and get Application object.
        //        oXL = new Excel.Application();

        //        //Get a new workbook.
        //        oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
        //        oSheet = (Excel._Worksheet)oWB.ActiveSheet;
        //        int yI = 3;

        //        oSheet.Cells[1, 1] = "";
        //        oSheet.Cells[2, 1] = "";

        //        foreach (var linea in PrimerasLineas)
        //        {
        //            oSheet.Cells[yI, 1] = linea;
        //            yI++;
        //        }

        //        oSheet.Cells[yI, 1] = "";

        //        oRng = oSheet.get_Range(oSheet.Cells[2, 1], oSheet.Cells[PrimerasLineas.Length + 2, tabla.Columns.Count]);
        //        oRng.MergeCells = true;
        //        oRng.Merge(true);
        //        //oRng.Group(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //        oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        //        oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        //        oRng.Font.Size = 14;
        //        //oRng.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);


        //        yI = yI + 1;

        //        oRng = oSheet.get_Range("D6", "D" + tabla.Rows.Count);
        //        oRng.NumberFormat = "@";

        //        oRng = oSheet.get_Range("G6", "G" + tabla.Rows.Count);
        //        oRng.NumberFormat = "0.00,00";

        //        oRng = oSheet.get_Range("H6", "H" + tabla.Rows.Count);
        //        oRng.NumberFormat = "0.00,00";

        //        int c = tabla.Columns.Count;

        //        foreach (DataColumn item in tabla.Columns)
        //        {
        //            oSheet.Cells[yI, tabla.Columns.IndexOf(item) + 1] = item.ColumnName;
        //        }
        //        string LetraLimite = "ZZ";

        //        oSheet.get_Range("A" + yI, LetraLimite + "1").Font.Bold = true;
        //        //oSheet.get_Range("A" + yI, LetraLimite + "1").Interior.ColorIndex = 3;
        //        oSheet.get_Range("A" + yI, LetraLimite + "1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        //        oSheet.get_Range("A" + yI, LetraLimite + "1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        //        int y = yI;
        //        foreach (DataRow item in tabla.Rows)
        //        {
        //            y++;
        //            for (int i = 1; i <= c; i++)
        //            {
        //                oSheet.Cells[y, i] = item[i - 1];
        //            }
        //        }

        //        oRng = oSheet.get_Range("A1", LetraLimite + "1");
        //        oRng.EntireColumn.AutoFit();

        //        oXL.Visible = true;
        //        oXL.UserControl = true;
        //    }
        //    catch (Exception theException)
        //    {
        //        throw new Exception("No se ha podido exportar el archivo a Excel.", theException);
        //    }
        //}


        //public static void ExportToExcel(this DataTable tabla, params string[] PrimerasLineas)
        //{
        //    Excel.Application oXL;
        //    Excel._Workbook oWB;
        //    Excel._Worksheet oSheet;
        //    Excel.Range oRng;

        //    try
        //    {
        //        //Start Excel and get Application object.
        //        oXL = new Excel.Application();

        //        //Get a new workbook.
        //        oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
        //        oSheet = (Excel._Worksheet)oWB.ActiveSheet;
        //        int yI = 1;

        //        foreach (var linea in PrimerasLineas)
        //        {
        //            oSheet.Cells[yI, 1] = linea;
        //            yI++;
        //        }

        //        yI++;

        //        int c = tabla.Columns.Count;

        //        foreach (DataColumn item in tabla.Columns)
        //        {
        //            oSheet.Cells[yI, tabla.Columns.IndexOf(item) + 1] = item.ColumnName;
        //        }
        //        string LetraLimite = "ZZ";

        //        oSheet.get_Range("A" + yI, LetraLimite + "1").Font.Bold = true;
        //        oSheet.get_Range("A" + yI, LetraLimite + "1").VerticalAlignment =
        //        Excel.XlVAlign.xlVAlignCenter;
        //        oSheet.get_Range("A" + yI, LetraLimite + "1").HorizontalAlignment =
        //        Excel.XlHAlign.xlHAlignLeft;
        //        int y = yI;
        //        foreach (DataRow item in tabla.Rows)
        //        {
        //            y++;
        //            for (int i = 1; i <= c; i++)
        //            {
        //                oSheet.Cells[y, i] = item[i - 1];
        //            }
        //        }

        //        oRng = oSheet.get_Range("A1", LetraLimite + "1");
        //        oRng.EntireColumn.AutoFit();

        //        oXL.Visible = true;
        //        oXL.UserControl = true;
        //    }
        //    catch (Exception theException)
        //    {
        //        throw new Exception("No se ha podido exportar el archivo a Excel: "+theException.ToString(), theException);
        //    }
        //}
 


    }
}
