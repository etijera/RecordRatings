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
    class CtrlInstitucion
    {
        public static DataSet GetInstitucionAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECT")            
            };

            return DBHelper.ExecuteDataSet("PA_Institucion", dbParametros);
        }

        public static Int32 Actualizar(Institucion institucion)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {                
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,institucion.Nombre), 
                DBHelper.MakeParam("@Nit",SqlDbType.VarChar,0,institucion.Nit),
                DBHelper.MakeParam("@Direccion",SqlDbType.VarChar,0,institucion.Direccion),
                DBHelper.MakeParam("@Telefono",SqlDbType.VarChar,0,institucion.Telefono),
                DBHelper.MakeParam("@Email",SqlDbType.VarChar,0,institucion.Email),
                DBHelper.MakeParam("@Resolusion",SqlDbType.VarChar,0,institucion.Resolusion),
                DBHelper.MakeParam("@CodigoDane",SqlDbType.VarChar,0,institucion.CodigoDane),
                DBHelper.MakeParam("@Abreviaura",SqlDbType.VarChar,0,institucion.Abreviaura),
                DBHelper.MakeParam("@Lema",SqlDbType.VarChar,0,institucion.Lema),
                DBHelper.MakeParam("@Director",SqlDbType.VarChar,0,institucion.Director),
                DBHelper.MakeParam("@Secretaria",SqlDbType.VarChar,0,institucion.Secretaria),
                DBHelper.MakeParam("@Coordinador",SqlDbType.VarChar,0,institucion.Coordinador),
                DBHelper.MakeParam("@Logo",SqlDbType.VarChar,0,institucion.Logo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Institucion", dbParametros));
        }


    }
}
