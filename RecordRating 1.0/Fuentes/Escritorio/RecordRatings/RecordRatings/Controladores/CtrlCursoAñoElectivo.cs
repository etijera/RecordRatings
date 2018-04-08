using GLReferences;
using RecordRatings.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Controladores
{
    class CtrlCursoAñoElectivo
    {
        public static Int32 Insertar(CursoAñoElectivo cursoAñoElectivo)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@CodigoCurso",SqlDbType.VarChar,0,cursoAñoElectivo.Curso.CodigoCurso),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAñoElectivo.AñoElectivo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_CursoAñoElectivo", dbParametros));
        }

        public static Int32 ActualizarCursoAñoElectivo(CursoAñoElectivo cursoAñoElectivo)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATECUR_AE"),
                DBHelper.MakeParam("@CodigoCurso",SqlDbType.VarChar,0,cursoAñoElectivo.Curso.CodigoCurso),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAñoElectivo.AñoElectivo),
                DBHelper.MakeParam("@Estado",SqlDbType.Int,0,cursoAñoElectivo.Estado)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_CursoAñoElectivo", dbParametros));
        }

        public static DataSet GetCursoAñoElectivo(CursoAñoElectivo cursoAñoElectivo)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SCURSOS_AE"), 
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAñoElectivo.AñoElectivo)            
            };

            return DBHelper.ExecuteDataSet("PA_CursoAñoElectivo", dbParametros);
        }

        public static DataSet GetCursoAñoElectivoNoAsigNados(CursoAñoElectivo cursoAñoElectivo)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SCURSOS_NOASIG") , 
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAñoElectivo.AñoElectivo),           
            };

            return DBHelper.ExecuteDataSet("PA_CursoAñoElectivo", dbParametros);
        }

        public static Int32 Eliminar(CursoAñoElectivo cursoAñoElectivo)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@CodigoCurso",SqlDbType.VarChar,0,cursoAñoElectivo.Curso.CodigoCurso),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,cursoAñoElectivo.AñoElectivo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_CursoAñoElectivo", dbParametros));
        }
    }
}
