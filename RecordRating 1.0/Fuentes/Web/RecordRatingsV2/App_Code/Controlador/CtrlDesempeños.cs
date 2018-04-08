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
    class CtrlDesempeños
    {
        public static Int32 Insertar(Desempeño desempeño)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,desempeño.Nombre),
                DBHelper.MakeParam("@NotaMin",SqlDbType.Decimal,0,desempeño.NotaMin),
                DBHelper.MakeParam("@NotaMax",SqlDbType.Decimal,0,desempeño.NotaMax)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Desempeños", dbParametros));
        }

        public static Int32 Actualizar(Desempeño desempeño)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,desempeño.Id),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,desempeño.Nombre),
                DBHelper.MakeParam("@NotaMin",SqlDbType.Decimal,0,desempeño.NotaMin),
                DBHelper.MakeParam("@NotaMax",SqlDbType.Decimal,0,desempeño.NotaMax)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Desempeños", dbParametros));
        }

        public static DataSet GetDesempeñoOne(Desempeño desempeño)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,desempeño.Id),               
            };

            return DBHelper.ExecuteDataSet("PA_Desempeños", dbParametros);
        }


        public static DataSet GetDesempeñoAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL")            
            };

            return DBHelper.ExecuteDataSet("PA_Desempeños", dbParametros);
        }

        public static Int32 Eliminar(Desempeño desempeño)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,desempeño.Id)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Desempeños", dbParametros));
        }
    }
}
