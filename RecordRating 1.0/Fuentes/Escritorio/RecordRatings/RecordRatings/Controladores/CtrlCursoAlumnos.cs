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
    class CtrlCursoAlumnos
    {
        public static Int32 Insertar(CursoAlumno cursoAlumnos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@CodigoAlum",SqlDbType.VarChar,0,cursoAlumnos.Alumno.CodigoAlum),
                DBHelper.MakeParam("@CodigoCurso",SqlDbType.VarChar,0,cursoAlumnos.Curso.CodigoCurso),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAlumnos.AñoElectivo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_CursoAlumnos", dbParametros));
        }

        public static Int32 ActualizarCurso(CursoAlumno cursoAlumnos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATECUR"),
                DBHelper.MakeParam("@CodigoAlum",SqlDbType.VarChar,0,cursoAlumnos.Alumno.CodigoAlum),
                DBHelper.MakeParam("@CodigoCurso",SqlDbType.VarChar,0,cursoAlumnos.Curso.CodigoCurso),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAlumnos.AñoElectivo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_CursoAlumnos", dbParametros));
        }

        public static DataSet GetCursos()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SCURSOS")             
            };

            return DBHelper.ExecuteDataSet("PA_CursoAlumnos", dbParametros);
        }

        public static DataSet GetCursosAñoElectivo(CursoAlumno cursoAlumnos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SCURSOS_AE"),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAlumnos.AñoElectivo)         
            };

            return DBHelper.ExecuteDataSet("PA_CursoAlumnos", dbParametros);
        }

        public static DataSet GetCursoAlumnos(CursoAlumno cursoAlumnos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SALUMCURSOS"),
                DBHelper.MakeParam("@CodigoCurso",SqlDbType.VarChar,0,cursoAlumnos.Curso.CodigoCurso),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAlumnos.AñoElectivo)               
            };

            return DBHelper.ExecuteDataSet("PA_CursoAlumnos", dbParametros);

        }
        public static DataSet GetCursoAlumnosOne(CursoAlumno cursoAlumnos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SALUMCURSOONE"),
                DBHelper.MakeParam("@CodigoAlum",SqlDbType.VarChar,0,cursoAlumnos.Alumno.CodigoAlum),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAlumnos.AñoElectivo)               
            };

            return DBHelper.ExecuteDataSet("PA_CursoAlumnos", dbParametros);

        }
       

        public static DataSet GetAlumnosNoAsigNados(CursoAlumno cursoAlumnos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SALUNOASIG") , 
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAlumnos.AñoElectivo),           
            };

            return DBHelper.ExecuteDataSet("PA_CursoAlumnos", dbParametros);
        }

        public static Int32 Eliminar(CursoAlumno cursoAlumnos)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@CodigoAlum",SqlDbType.VarChar,0,cursoAlumnos.Alumno.CodigoAlum),
                DBHelper.MakeParam("@CodigoCurso",SqlDbType.VarChar,0,cursoAlumnos.Curso.CodigoCurso),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAlumnos.AñoElectivo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_CursoAlumnos", dbParametros));
        }
     
    }
}
