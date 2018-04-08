using Modelo;
using Referencias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    class CtrlNiveles
    {
        public static Int32 Insertar(Nivel nivel)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,nivel.Nombre)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Niveles", dbParametros));
        }

        public static Int32 Actualizar(Nivel nivel)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,nivel.Id),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,nivel.Nombre)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Niveles", dbParametros));
        }

        public static DataSet GetAreaOne(Nivel nivel)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,nivel.Id),               
            };

            return DBHelper.ExecuteDataSet("PA_Niveles", dbParametros);
        }


        public static DataSet GetAreaAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL")            
            };

            return DBHelper.ExecuteDataSet("PA_Niveles", dbParametros);
        }

        public static Int32 Eliminar(Nivel nivel)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,nivel.Id)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Niveles", dbParametros));
        }
    }
}
