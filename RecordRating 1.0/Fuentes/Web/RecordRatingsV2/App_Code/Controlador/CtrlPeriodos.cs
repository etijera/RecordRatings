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
    class CtrlPeriodos
    {
        public static Int32 Insertar(Periodo periodo)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,periodo.Nombre),
                DBHelper.MakeParam("@Numero",SqlDbType.Int,0,periodo.Numero),
                DBHelper.MakeParam("@Porcentaje",SqlDbType.Int,0,periodo.Porcentaje)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Periodos", dbParametros));
        }

        public static Int32 Actualizar(Periodo periodo)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,periodo.Id),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,periodo.Nombre),
                DBHelper.MakeParam("@Numero",SqlDbType.Int,0,periodo.Numero),
                DBHelper.MakeParam("@Porcentaje",SqlDbType.Int,0,periodo.Porcentaje)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Periodos", dbParametros));
        }

        public static DataSet GetPeriodoOne(Periodo periodo)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,periodo.Id),               
            };

            return DBHelper.ExecuteDataSet("PA_Periodos", dbParametros);
        }

        public static DataSet GetPeriodoOneCod(Periodo periodo)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTCOD"), 
                DBHelper.MakeParam("@CodigoPeriodo",SqlDbType.VarChar,0,periodo.CodigoPeriodo),               
            };

            return DBHelper.ExecuteDataSet("PA_Periodos", dbParametros);
        }

        public static DataSet GetPeriodoAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL")            
            };

            return DBHelper.ExecuteDataSet("PA_Periodos", dbParametros);
        }

        public static Int32 Eliminar(Periodo periodo)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,periodo.Id)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Periodos", dbParametros));
        }
    }
}
