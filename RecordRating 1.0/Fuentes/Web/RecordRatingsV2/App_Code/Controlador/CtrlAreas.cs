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
    class CtrlAreas
    {
        public static Int32 Insertar(Area area)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,area.Nombre)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Areas", dbParametros));
        }

        public static Int32 Actualizar(Area area)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,area.Id),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,area.Nombre)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Areas", dbParametros));
        }

        public static DataSet GetAreaOne(Area area)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,area.Id),               
            };

            return DBHelper.ExecuteDataSet("PA_Areas", dbParametros);
        }


        public static DataSet GetAreaAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL")            
            };

            return DBHelper.ExecuteDataSet("PA_Areas", dbParametros);
        }

        public static Int32 Eliminar(Area area)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,area.Id)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Areas", dbParametros));
        }
    }
}
