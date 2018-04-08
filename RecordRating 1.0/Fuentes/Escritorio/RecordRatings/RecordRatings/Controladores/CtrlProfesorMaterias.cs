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
    class CtrlProfesorMaterias
    {
        public static Int32 Insertar(ProfesorMaterias profesorMaterias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,profesorMaterias.Materia.CodMateria),
                DBHelper.MakeParam("@CodigoProfesor",SqlDbType.VarChar,0,profesorMaterias.Profesor.CodigoProfesor)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_ProfesorMaterias", dbParametros));
        }
       
        public static DataSet GetMaterias()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATERIAS")             
            };

            return DBHelper.ExecuteDataSet("PA_ProfesorMaterias", dbParametros);
        }

        public static DataSet GetCursosOne(ProfesorMaterias profesorMaterias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATERIAONE"),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,profesorMaterias.Materia.CodMateria)      
            };

            return DBHelper.ExecuteDataSet("PA_ProfesorMaterias", dbParametros);
        }

        public static DataSet GetProfesorMaterias(ProfesorMaterias profesorMaterias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATERIPROFE"), 
                DBHelper.MakeParam("@CodigoProfesor",SqlDbType.VarChar,0,profesorMaterias.Profesor.CodigoProfesor)              
            };

            return DBHelper.ExecuteDataSet("PA_ProfesorMaterias", dbParametros);

        }

        public static DataSet GetMateNoAsigNadas(ProfesorMaterias profesorMaterias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATPROFENOASIG"), 
                DBHelper.MakeParam("@CodigoProfesor",SqlDbType.VarChar,0,profesorMaterias.Profesor.CodigoProfesor)           
            };

            return DBHelper.ExecuteDataSet("PA_ProfesorMaterias", dbParametros);
        }

        public static DataSet GetMateAsigNadas(ProfesorMaterias profesorMaterias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATPROFEASIG"), 
                DBHelper.MakeParam("@CodigoProfesor",SqlDbType.VarChar,0,profesorMaterias.Profesor.CodigoProfesor)           
            };

            return DBHelper.ExecuteDataSet("PA_ProfesorMaterias", dbParametros);
        }

        public static Int32 Eliminar(ProfesorMaterias profesorMaterias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,profesorMaterias.Materia.CodMateria),
                DBHelper.MakeParam("@CodigoProfesor",SqlDbType.VarChar,0,profesorMaterias.Profesor.CodigoProfesor)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_ProfesorMaterias", dbParametros));
        }

        public static Int32 EliminarTodas(ProfesorMaterias profesorMaterias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DELALL"),
                DBHelper.MakeParam("@CodigoProfesor",SqlDbType.VarChar,0,profesorMaterias.Profesor.CodigoProfesor)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_ProfesorMaterias", dbParametros));
        }

        public static DataSet GetProfesorMateriasOne(ProfesorMaterias profesorMaterias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATERIPROFEONE"), 
                DBHelper.MakeParam("@CodigoProfesor",SqlDbType.VarChar,0,profesorMaterias.Profesor.CodigoProfesor),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,profesorMaterias.Materia.CodMateria)
            };

            return DBHelper.ExecuteDataSet("PA_ProfesorMaterias", dbParametros);
        }

        public static DataSet GetProfesorMateriasRow(ProfesorMaterias profesorMaterias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATERIPROFEROW"), 
                DBHelper.MakeParam("@CodigoProfesor",SqlDbType.VarChar,0,profesorMaterias.Profesor.CodigoProfesor),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,profesorMaterias.Materia.CodMateria)
            };

            return DBHelper.ExecuteDataSet("PA_ProfesorMaterias", dbParametros);
        }

        public static DataSet GetProfesorMat(ProfesorMaterias profesorMaterias)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SPROFMATER"),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,profesorMaterias.Materia.CodMateria)            
            };

            return DBHelper.ExecuteDataSet("PA_ProfesorMaterias", dbParametros);
        }

    }
}
