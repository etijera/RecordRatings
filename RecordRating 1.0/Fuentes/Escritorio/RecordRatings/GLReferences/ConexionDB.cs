using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data;
using DevExpress.XtraEditors;

namespace GLReferences
{
    public class ConexionDB
    {
        private static ConexionDB conexionDB;
        private SqlConnection conexion;
        private Configuration appconfig;
        private ConnectionStringSettings connStringSettings;
        private string con;
        private string database;

        /// <summary>
        /// Singleton de la clase ConexionDB
        /// </summary>
        /// <returns>ConexionDB</returns>
        public static ConexionDB getInstancia()
        {
            if (conexionDB == null)
            {
                conexionDB = new ConexionDB();
            }
            return conexionDB;
        }

        public SqlConnection ConexionProp
        {
            get
            {
                return conexion;
            }
        }


        /// <summary>
        /// Devuelve la cadena de conexion esperado
        /// </summary>
        /// <param name="cstrName">Nombre de la cadena de conexion. Por defecto el mismo nombre de la BD, 
        /// si es null se conecta por la primera cadena de conexion disponible </param>
        /// <param name="conn">La cadena de conexion en caso de que exista en el app.config</param>
        /// <returns>La conexion a la BD</returns>
        public SqlConnection Conexion(string cstrName, string conn)
        {
            database = cstrName;
            con = conn;
            //if (!String.IsNullOrEmpty(database) && String.IsNullOrEmpty(con))
            //    Conectar(database);
            //else
            Conectar();
            return conexion;
        }

        /// <summary>
        /// Se usa para conectar a una cadena de conexion, nueva o existente en el app.config
        /// </summary>
        /// <param name="cstrName">Nombre de la cadena de conexion, Por defecto el mismo nombre de la BD</param>
        /// <param name="conn">La cadena de conexion, en caso de que no exista en el app.config</param>
        //private void Conectar(string cstrName)
        //{
        //    try
        //    {
        //        appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //        conexion = new SqlConnection(GetAppConfigConString(cstrName));
        //        conexion.Open();
        //    }
        //    catch (Exception)
        //    {
        //        AddAppConfigConString(cstrName);
        //        conexion.Open();
        //    }
        //}

        /// <summary>
        /// Se usa para conectar a la primera cadena de conexion existente en el app.config
        /// </summary>
        private void Conectar()
        {
            //appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //int length = appconfig.ConnectionStrings.ConnectionStrings.Count - 1;
            //if (length >= 1)
            //{
            conexion = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            conexion.Open();
            //}
            //else
            //{
            //    AddAppConfigConString(database, con);
            //}
        }

        /// <summary>
        /// Metodo para acceder al App.Config y obtener la primera cadena de conexión
        /// </summary>
        /// <returns>Cadena de conexión guardada en el app.config</returns>
        //private List<string> GetAppConfigConString()
        //{
        //    appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    int length = appconfig.ConnectionStrings.ConnectionStrings.Count - 1;
        //    List<string> listaConString = new List<string>();
        //    for (int i = 1; i <= length; i += 1)
        //    {
        //        listaConString.Add(appconfig.ConnectionStrings.ConnectionStrings[i].ConnectionString);
        //    }
        //    return listaConString;
        //}

        /// <summary>
        /// Metodo para acceder al App.Config y obtener a la cadena de conexión. Por defecto el mismo nombre de la BD
        /// </summary>
        /// <param name="cstrName">Nombre de la cadena de conexión. Por defecto el mismo nombre de la BD</param>
        /// <returns>Cadena de conexión guardada en el app.config</returns>
        public string GetAppConfigConString(string cstrName)
        {
            //appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //connStringSettings = ConfigurationManager.AppSettings.Get("connectionString");
            //if (connStringSettings == null)
            //    return null;
            //else
            return ConfigurationManager.AppSettings.Get("connectionString");
        }

        /// <summary>
        /// Metodo para acceder al App.Config y Modificar o Adicionar una cadena de conexión (Por defecto "DefConString")
        /// </summary>
        /// <param name="cstrName">Nombre de la cadena de conexión. Por defecto el mismo nombre de la BD</param>
        /// <param name="connectionString">Cadena de conexión</param>
        public void SetAppConfigConString(string cstrName, string connectionString)
        {
            appconfig.ConnectionStrings.ConnectionStrings[cstrName].ConnectionString = connectionString;
            appconfig.Save();
        }

        //public void AddAppConfigConString(string db)
        //{

        //    String connectionString;
        //    connectionString = appconfig.ConnectionStrings.ConnectionStrings[1].ConnectionString;
        //    string[] str = connectionString.Split(';');
        //    str[1] = "Initial Catalog=" + db;
        //    string cad = "";
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        cad += str[i] + ';';
        //    }

        //    if (String.IsNullOrEmpty(GetAppConfigConString(db)))
        //    {
        //        appconfig.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(db, cad));
        //        appconfig.Save();
        //    }
        //    else
        //        SetAppConfigConString(db, cad);
        //}

        /// <summary>
        /// Se usa para agregar una nueva cadena de conexion en el app.config
        /// </summary>
        /// <param name="cstrName">Nombre de la cadena de conexion. Por defecto el mismo nombre de la BD</param>
        /// <param name="connectionString">La cadena de conexion</param>
        //public void AddAppConfigConString(string cstrName, string connectionString)
        //{
        //    appconfig.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(cstrName, connectionString));
        //    appconfig.Save();
        //}

    }
}
