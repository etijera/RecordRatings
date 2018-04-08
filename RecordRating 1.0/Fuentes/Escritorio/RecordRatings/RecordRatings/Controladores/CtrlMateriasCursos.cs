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
    class CtrlMateriasCursos
    {
        public static Int32 Insertar(MateriasCurso materiasCurso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,materiasCurso.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,materiasCurso.Materia.CodMateria),
                DBHelper.MakeParam("@IHS",SqlDbType.Int,0,materiasCurso.IHS),
                DBHelper.MakeParam("@CodProfesor",SqlDbType.VarChar,0,materiasCurso.Profesor.CodigoProfesor),
                DBHelper.MakeParam("@Porcentaje",SqlDbType.Int,0,materiasCurso.Porcentaje),
                DBHelper.MakeParam("@CodArea",SqlDbType.VarChar,0,materiasCurso.Area.Codigo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_MateriasCursos", dbParametros));
        }

        public static Int32 Actualizar(MateriasCurso materiasCurso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,materiasCurso.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,materiasCurso.Materia.CodMateria),
                DBHelper.MakeParam("@IHS",SqlDbType.Int,0,materiasCurso.IHS),
                DBHelper.MakeParam("@CodProfesor",SqlDbType.VarChar,0,materiasCurso.Profesor.CodigoProfesor),
                DBHelper.MakeParam("@Porcentaje",SqlDbType.Int,0,materiasCurso.Porcentaje)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_MateriasCursos", dbParametros));
        }

        public static DataSet GetCursos()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SCURSOS")             
            };

            return DBHelper.ExecuteDataSet("PA_MateriasCursos", dbParametros);
        }

        public static DataSet GetCursosAñoElectivo(MateriasCurso materiasCurso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SCURSOS_AE"),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,materiasCurso.AñoElectivo)          
            };

            return DBHelper.ExecuteDataSet("PA_MateriasCursos", dbParametros);
        }

        public static DataSet GetCursosOne(MateriasCurso materiasCurso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SCURSOONE")  ,
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,materiasCurso.Curso.CodigoCurso)            
            };

            return DBHelper.ExecuteDataSet("PA_MateriasCursos", dbParametros);
        }

        public static DataSet GetMateriasCursos(MateriasCurso materiasCurso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATCURSOS"), 
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,materiasCurso.Curso.CodigoCurso),               
            };

            return DBHelper.ExecuteDataSet("PA_MateriasCursos", dbParametros);

        }
        public static DataSet GetMateriasCursosCab(MateriasCurso materiasCurso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATCURSOSCAB"), 
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,materiasCurso.Curso.CodigoCurso),               
            };

            return DBHelper.ExecuteDataSet("PA_MateriasCursos", dbParametros);

        }

        public static DataSet GetMateNoAsigNadas(MateriasCurso materiasCurso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATNOASIG") , 
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,materiasCurso.Curso.CodigoCurso),           
            };

            return DBHelper.ExecuteDataSet("PA_MateriasCursos", dbParametros);
        }

        public static DataSet GetMateAsigNadas(MateriasCurso materiasCurso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATASIG") , 
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,materiasCurso.Curso.CodigoCurso),           
            };

            return DBHelper.ExecuteDataSet("PA_MateriasCursos", dbParametros);
        }

        public static Int32 Eliminar(MateriasCurso materiasCurso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,materiasCurso.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,materiasCurso.Materia.CodMateria)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_MateriasCursos", dbParametros));
        }
        public static DataSet GetMateriasCursosOne(MateriasCurso materiasCurso)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATCURONE"),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,materiasCurso.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,materiasCurso.Materia.CodMateria)
            };

            return DBHelper.ExecuteDataSet("PA_MateriasCursos", dbParametros);
        }
    }
}
