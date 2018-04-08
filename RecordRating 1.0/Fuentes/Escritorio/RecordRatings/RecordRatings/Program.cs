using RecordRatings.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RecordRatings
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // The following line provides localization for data formats. 
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

            // The following line provides localization for the application's user interface. 
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");

            System.Globalization.CultureInfo before = System.Threading.Thread.CurrentThread.CurrentCulture;
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");//es-CO
                // Proceed with specific code
            }

            finally
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = before;
            }

            FrmCarga carga = new FrmCarga();
            carga.ShowDialog();
            FrmLogin login = new FrmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                XmlDocument myXmlDocument = new XmlDocument();
                XmlNodeList config;   
                string servidor = "";
                string db = "";
                string usuario = "";
                string pass = "";

                myXmlDocument.Load(System.Windows.Forms.Application.StartupPath + @"/RecordRatings.exe.config");
                config = myXmlDocument.GetElementsByTagName("appSettings");
                string cadenaconexion = ((XmlElement)config[0]).GetElementsByTagName("add")[6].Attributes["value"].Value.ToString();
                string[] vector = cadenaconexion.Split(';');

                servidor = vector[0].Split('=')[1];
                db = vector[1].Split('=')[1];
                usuario = vector[2].Split('=')[1];
                pass = vector[3].Split('=')[1];

                FrmPrincipal principal = new FrmPrincipal();
                principal.Año = login.Año;
                principal.NomUsuario = login.NomUsuario;
                principal.CodPeriodo = login.CodPeriodo;
                principal.NomPeriodo = login.NomPeriodo;
                principal.Database = db;

                Application.Run(principal);
            }


            //FrmPrincipal principal = new FrmPrincipal();
            //principal.Año = DateTime.Now.Year;
            //Application.Run(principal);
        }
    }
}
