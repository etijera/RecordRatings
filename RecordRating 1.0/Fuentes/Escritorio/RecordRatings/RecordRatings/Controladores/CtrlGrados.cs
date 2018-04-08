using RecordRatings.Clases;
using GLReferences;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Controladores
{
    class CtrlGrados
    {
        public static Int32 Insertar(Grado grado)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,grado.Nombre),
                DBHelper.MakeParam("@Numero",SqlDbType.Int,0,grado.Numero)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Grados", dbParametros));
        }

        public static Int32 Actualizar(Grado grado)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,grado.Id),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,grado.Nombre),
                DBHelper.MakeParam("@Numero",SqlDbType.Int,0,grado.Numero)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Grados", dbParametros));
        }

        public static DataSet GetGradoOne(Grado grado)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,grado.Id),               
            };

            return DBHelper.ExecuteDataSet("PA_Grados", dbParametros);
        }


        public static DataSet GetGradoAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL")            
            };

            return DBHelper.ExecuteDataSet("PA_Grados", dbParametros);
        }

        public static Int32 Eliminar(Grado grado)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,grado.Id)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Grados", dbParametros));
        }
    }
}
