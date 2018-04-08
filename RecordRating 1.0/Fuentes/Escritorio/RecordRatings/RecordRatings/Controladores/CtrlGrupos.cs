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
    class CtrlGrupos
    {
        public static Int32 Insertar(Grupo grupos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,grupos.Nombre)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Grupos", dbParametros));
        }

        public static Int32 Actualizar(Grupo grupos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,grupos.Id),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,grupos.Nombre)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Grupos", dbParametros));
        }

        public static DataSet GetGrupoOne(Grupo grupos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,grupos.Id),               
            };

            return DBHelper.ExecuteDataSet("PA_Grupos", dbParametros);
        }


        public static DataSet GetGrupoAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL")            
            };

            return DBHelper.ExecuteDataSet("PA_Grupos", dbParametros);
        }

        public static Int32 Eliminar(Grupo grupos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,grupos.Id)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Grupos", dbParametros));
        }
    }
}
