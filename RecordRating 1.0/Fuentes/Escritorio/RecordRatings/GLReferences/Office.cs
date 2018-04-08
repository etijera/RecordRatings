using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Data;
using System.Windows.Forms;

namespace GLReferences.Office
{
    public class WordHelper
    : IDisposable
    {
        Word.Application wrdApp;
        Word._Document wrdDoc;
        Object oMissing = System.Reflection.Missing.Value;
        Object oFalse = false;
        string tempFileName;
        string tempFileRoute;

        public WordHelper()
        {
            // Create an instance of Word  and make it visible. 
            wrdApp = new Word.Application();
            tempFileName = "Export_" + DateTime.Now.ToString("hms") + ".doc";
            tempFileRoute = Application.StartupPath + @"/temp/" + tempFileName;
        }

        public void CombinarCorrespondencia(string RutaArchivo, DataTable datos)
        {
            if (!System.IO.File.Exists(RutaArchivo))
                throw new Exception("No existe el archivo especificado.\nArchivo no encontrado: " + RutaArchivo);

            // Add a new document. 
            wrdDoc = wrdApp.Documents.Add(RutaArchivo);
            wrdDoc.Select();

            var wrdSelection = wrdApp.Selection;
            var wrdMailMerge = wrdDoc.MailMerge;

            // Create a MailMerge Data file. 
            CreateMailMergeDataFile(datos);

            // Perform mail merge. 
            wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToNewDocument;
            wrdMailMerge.Execute(ref oFalse);

            // Close the original form document. 
            wrdDoc.Saved = true;
            wrdApp.Visible = true;
        }

        private void InsertLines(int LineNum)
        {
            int iCount;

            // Insert "LineNum" blank lines.
            for (iCount = 1; iCount <= LineNum; iCount++)
            {
                wrdApp.Selection.TypeParagraph();
            }
        }

        private void FillDataSource(Word._Document oDoc, DataTable source)
        {
            foreach (DataRow row in source.Rows)
            {
                if (source.Rows[0] != row)
                    oDoc.Tables[1].Rows.Add(oMissing);

                FillRow(oDoc, source.Rows.IndexOf(row) + 2, row.ItemArray);
            }
        }

        private void FillRow(Word._Document oDoc, int Row, params object[] Texts)
        {
            // Insert the data into the specific cell. 
            for (int i = 0; i < Texts.Length; i++)
            {
                oDoc.Tables[1].Cell(Row, i + 1).Range.InsertAfter(Texts[i].ToString());
            }
        }

        private string BuildHeader(DataTable data)
        {
            string r = "";

            foreach (DataColumn c in data.Columns)
            {
                if (c == data.Columns[0])
                    r += (c.ColumnName);
                else
                    r += (", " + c.ColumnName);
            }

            return r;
        }

        private void CreateMailMergeDataFile(DataTable tabla)
        {

            Object oName = tempFileRoute;
            Object oHeader2 = BuildHeader(tabla);

            wrdDoc.MailMerge.CreateDataSource(ref oName, ref oMissing, ref oMissing, ref oHeader2, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            // Open the file to insert data. 
            Word._Document oDataDoc = wrdApp.Documents.Open(ref oName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing );

            // Fill in the data. 
            FillDataSource(oDataDoc, tabla);

            // Save and close the file. 
            oDataDoc.Save();
            oDataDoc.Close(ref oFalse, ref oMissing, ref oMissing);
        }

        public void Dispose()
        {
            wrdDoc.Close(ref oFalse, ref oMissing, ref oMissing);
            // Release References. 
            wrdDoc = null;
            wrdApp = null;

            System.IO.File.Delete(tempFileRoute);
        }

        public static void ShowWordTemplate(string FileName, params GLReferences.KeyValuePair<string, string>[] Marcadores)
        {
            Microsoft.Office.Interop.Word.Document oDoc = null;
            oDoc = oWord.Documents.Add(FileName);

            foreach (var item in Marcadores)
            {
                oDoc.Bookmarks[item.Clave].Range.Text = item.Valor;
            }

            oWord.Visible = true;
            oword = null;
            oDoc.Saved = true;
            oDoc = null;
        }
        static Microsoft.Office.Interop.Word.Application oword = null;
        /// <summary>
        /// </summary>
        static Microsoft.Office.Interop.Word.Application oWord
        {
            get
            {
                if (oword == null)
                {
                    oword = new Microsoft.Office.Interop.Word.Application();
                }
                return oword;
            }
        }
    }
}
