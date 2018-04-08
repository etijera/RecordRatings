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
    class CtrlCursos
    {
        public static Int32 Insertar(Curso curso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@CodGrupo",SqlDbType.VarChar,0,curso.Grupo.CodigoGrupo),
                DBHelper.MakeParam("@CodGrado",SqlDbType.VarChar,0,curso.Grado.CodigoGrado),
                DBHelper.MakeParam("@Jornada",SqlDbType.VarChar,0,curso.Jornada),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,curso.Nombre)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Cursos", dbParametros));
        }

        public static Int32 Actualizar(Curso curso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,curso.Id), 
                DBHelper.MakeParam("@CodGrupo",SqlDbType.VarChar,0,curso.Grupo.CodigoGrupo),
                DBHelper.MakeParam("@CodGrado",SqlDbType.VarChar,0,curso.Grado.CodigoGrado),
                DBHelper.MakeParam("@Jornada",SqlDbType.VarChar,0,curso.Jornada),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,curso.Nombre)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Cursos", dbParametros));
        }

        public static DataSet GetCursoOne(Curso curso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,curso.Id),              
            };

            return DBHelper.ExecuteDataSet("PA_Cursos", dbParametros);
        }

        public static DataSet GetCursoOneCod(Curso curso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTCOD"), 
                DBHelper.MakeParam("@CodigoCurso",SqlDbType.VarChar,0,curso.CodigoCurso),              
            };

            return DBHelper.ExecuteDataSet("PA_Cursos", dbParametros);
        }

        public static DataSet GetCursoAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL")            
            };

            return DBHelper.ExecuteDataSet("PA_Cursos", dbParametros);
        }

        public static Int32 Eliminar(Curso curso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,curso.Id),  
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Cursos", dbParametros));
        }
    }
}
