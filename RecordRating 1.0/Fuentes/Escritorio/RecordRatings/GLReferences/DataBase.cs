using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace GLReferences
{
    public class DataBase
    {
        //static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Methods
        
        /// <summary>
        /// Create Command
        /// </summary>
        /// <param name="pTextoComando">CommandText</param>
        /// <param name="Type">CommandType</param>
        /// <returns></returns>
        /// 

        private static SqlCommand CreateCommand(string pTextoComando, CommandType Type)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = pTextoComando;
            Command.CommandType = Type;
            Command.CommandTimeout = 180;
            return Command;
        }

        /// <summary>
        /// Execute Query
        /// </summary>
        /// <param name="pTextoComando">Query</param>
        /// <param name="pTabla">Result Table Name</param>
        /// <param name="Type">Command Type</param>
        /// <returns></returns>
        /// 

        public static DataSet ExecuteQuery(string pTextoComando, string pTabla, CommandType Type, SqlParameter[] QueryParameters, SqlConnection Conn)
        {
            SqlCommand QueryCommand = CreateCommand(pTextoComando, Type);
            QueryCommand.Connection = Conn;
            AddParameters(QueryParameters, QueryCommand);
            DataSet dsDatos = new DataSet();
            try
            {
                if (QueryCommand.Connection.State == ConnectionState.Closed)
                {
                    QueryCommand.Connection.Open();
                }

                SqlDataAdapter daAdapter = new SqlDataAdapter(QueryCommand);
                daAdapter.Fill(dsDatos, pTabla);
                return dsDatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                //log.Fatal(e.Message, e);
            }
            finally
            {
                QueryCommand.Connection.Close();
            }

            return dsDatos;
        }

        /// <summary>
        /// Execute Non Query
        /// </summary>
        /// <param name="pTextoComando">Query</param>
        /// <param name="Type">Command Type</param>
        /// <returns>Result,</returns>
        /// 

        public static bool ExecuteNonQuery(string pTextoComando, CommandType Type, SqlParameter[] QueryParameters, SqlConnection Conn)
        {
            SqlCommand QueryCommand = CreateCommand(pTextoComando, Type);
            QueryCommand.Connection = Conn;//new SqlConnection(ConnectionString);
            AddParameters(QueryParameters, QueryCommand);

            SqlTransaction trTransaccion = null;
            bool result = false;

            try
            {
                if (QueryCommand.Connection.State == ConnectionState.Closed)
                {
                    QueryCommand.Connection.Open();
                }

                //// Se inicia transacción
                trTransaccion = QueryCommand.Connection.BeginTransaction();
                QueryCommand.Transaction = trTransaccion;

                if (QueryCommand.ExecuteNonQuery() >= 0)
                {
                    result = true;
                }
                trTransaccion.Commit();
            }
            catch (Exception e)
            {
                if (trTransaccion != null)
                {
                    trTransaccion.Rollback();
                }
                String ex = e.Message;
                if (ex == "Violation of UNIQUE KEY constraint 'IX_GlFields_1'. Cannot insert duplicate key in object 'dbo.GlFields'.\r\nThe statement has been terminated.")
                {
                    XtraMessageBox.Show("El Campo que intenta añadir ya existe en la tabla", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (ex == "Violation of UNIQUE KEY constraint 'IX_GlTables'. Cannot insert duplicate key in object 'dbo.GlTables'.\r\nThe statement has been terminated.")
                    {
                        XtraMessageBox.Show("La Tabla que intenta añadir ya existe", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show(e.Message, GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                result = true;
            }
            finally
            {
                QueryCommand.Connection.Close();
            }

            return result;
        }

        /// <summary>
        /// Add parameters
        /// </summary>
        /// <param name="QueryParameters">Parameters</param>
        /// <param name="QueryCommand">Command</param>
        /// 

        private static void AddParameters(SqlParameter[] QueryParameters, SqlCommand QueryCommand)
        {
            if (QueryParameters != null)
            {
                foreach (SqlParameter parameter in QueryParameters)
                {
                    QueryCommand.Parameters.Add(parameter.ParameterName, parameter.SqlDbType).Value = parameter.Value;
                }
            }
        }

        public static DataTable GetData(SqlParameter[] par, string PA, string DB)
        {
            DataTable ds = null;
            try
            {
                ds = DataBase.ExecuteQueryDataTable(PA, "datos", CommandType.StoredProcedure, par, ConexionDB.getInstancia().Conexion(DB, null));
            }
            catch
            {
                ds = null;
            }

            return ds;
        }

        public static DataTable ExecuteQueryDataTable(string pTextoComando, string pTabla, CommandType Type, SqlParameter[] QueryParameters, SqlConnection Conn)
        {
            SqlCommand QueryCommand = CreateCommand(pTextoComando, Type);
            QueryCommand.Connection = Conn;
            AddParameters(QueryParameters, QueryCommand);
            DataTable dtDatos = new DataTable();
            try
            {
                if (QueryCommand.Connection.State == ConnectionState.Closed)
                {
                    QueryCommand.Connection.Open();
                }

                SqlDataAdapter daAdapter = new SqlDataAdapter(QueryCommand);
                daAdapter.Fill(dtDatos);
                return dtDatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                //log.Fatal(e.Message, e);
            }
            finally
            {
                QueryCommand.Connection.Close();
            }

            return dtDatos;
        }

        #endregion

    }
}
