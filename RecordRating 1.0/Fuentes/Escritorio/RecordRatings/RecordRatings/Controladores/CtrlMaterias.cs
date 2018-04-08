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
    class CtrlMaterias
    {
        public static Int32 Insertar(Materia materias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@CodArea",SqlDbType.VarChar,0,materias.Area.Codigo),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,materias.CodMateria),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,materias.Nombre)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Materias", dbParametros));
        }

        public static Int32 Actualizar(Materia materias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,materias.Id), 
                DBHelper.MakeParam("@CodArea",SqlDbType.VarChar,0,materias.Area.Codigo),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,materias.CodMateria),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,materias.Nombre)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Materias", dbParametros));
        }

        public static DataSet GetMateriaOne(Materia materias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,materias.Id),               
            };

            return DBHelper.ExecuteDataSet("PA_Materias", dbParametros);
        }

        public static DataSet GetMateriaOneCod(Materia materias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTCOD"), 
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,materias.CodMateria),               
            };

            return DBHelper.ExecuteDataSet("PA_Materias", dbParametros);
        }

        public static DataSet GetAreaName(Materia materias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTNAME"), 
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,materias.Nombre),               
            };

            return DBHelper.ExecuteDataSet("PA_Materias", dbParametros);

        }

        public static DataSet GetAreaAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL")            
            };

            return DBHelper.ExecuteDataSet("PA_Materias", dbParametros);
        }

        public static Int32 Eliminar(Materia materias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,materias.Id)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Materias", dbParametros));
        }
    }
}
