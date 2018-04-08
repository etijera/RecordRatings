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
    class CtrlRegistroNotas
    {
        public static DataSet Insertar(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@CodAlumno",SqlDbType.VarChar,0,registroNota.Alumno.CodigoAlum),
                DBHelper.MakeParam("@CodProfesor",SqlDbType.VarChar,0,registroNota.Profesor.CodigoProfesor),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,registroNota.Materia.CodMateria),
                DBHelper.MakeParam("@CodPeriodo",SqlDbType.VarChar,0,registroNota.Periodo.CodigoPeriodo),
                DBHelper.MakeParam("@Nota1",SqlDbType.Decimal,0,registroNota.Nota1),
                DBHelper.MakeParam("@PorcN1",SqlDbType.Decimal,0,registroNota.PorcN1),
                DBHelper.MakeParam("@Nota2",SqlDbType.Decimal,0,registroNota.Nota2),
                DBHelper.MakeParam("@PorcN2",SqlDbType.Decimal,0,registroNota.PorcN2),
                DBHelper.MakeParam("@Nota3",SqlDbType.Decimal,0,registroNota.Nota3),
                DBHelper.MakeParam("@PorcN3",SqlDbType.Decimal,0,registroNota.PorcN3),
                DBHelper.MakeParam("@Nota4",SqlDbType.Decimal,0,registroNota.Nota4),
                DBHelper.MakeParam("@PorcN4",SqlDbType.Decimal,0,registroNota.PorcN4),
                DBHelper.MakeParam("@NotaFinal",SqlDbType.Decimal,0,registroNota.NotaFinal),
                DBHelper.MakeParam("@Fallas",SqlDbType.Int,0,registroNota.Fallas),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,registroNota.AñoElectivo)
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);
        }

        public static Int32 Actualizar(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@CodAlumno",SqlDbType.VarChar,0,registroNota.Alumno.CodigoAlum),
                DBHelper.MakeParam("@CodProfesor",SqlDbType.VarChar,0,registroNota.Profesor.CodigoProfesor),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,registroNota.Materia.CodMateria),
                DBHelper.MakeParam("@CodPeriodo",SqlDbType.VarChar,0,registroNota.Periodo.CodigoPeriodo),
                DBHelper.MakeParam("@Nota1",SqlDbType.Decimal,0,registroNota.Nota1),
                DBHelper.MakeParam("@PorcN1",SqlDbType.Decimal,0,registroNota.PorcN1),
                DBHelper.MakeParam("@Nota2",SqlDbType.Decimal,0,registroNota.Nota2),
                DBHelper.MakeParam("@PorcN2",SqlDbType.Decimal,0,registroNota.PorcN2),
                DBHelper.MakeParam("@Nota3",SqlDbType.Decimal,0,registroNota.Nota3),
                DBHelper.MakeParam("@PorcN3",SqlDbType.Decimal,0,registroNota.PorcN3),
                DBHelper.MakeParam("@Nota4",SqlDbType.Decimal,0,registroNota.Nota4),
                DBHelper.MakeParam("@PorcN4",SqlDbType.Decimal,0,registroNota.PorcN4),
                DBHelper.MakeParam("@NotaFinal",SqlDbType.Decimal,0,registroNota.NotaFinal),
                DBHelper.MakeParam("@Fallas",SqlDbType.Int,0,registroNota.Fallas),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,registroNota.AñoElectivo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_RegistroNotas", dbParametros));
        }
       
        public static DataSet GetCursosProfe(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SCURPROF") ,
                DBHelper.MakeParam("@CodProfesor",SqlDbType.VarChar,0,registroNota.Profesor.CodigoProfesor)
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);
        }

        public static DataSet GetCursosProfeAñoElectivo(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SCURPROF_AE"),
                DBHelper.MakeParam("@CodProfesor",SqlDbType.VarChar,0,registroNota.Profesor.CodigoProfesor),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,registroNota.AñoElectivo)
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);
        }

        public static DataSet GetMateriasCursosProfe(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATCURPROF"), 
                DBHelper.MakeParam("@CodProfesor",SqlDbType.VarChar,0,registroNota.Profesor.CodigoProfesor),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),               
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);

        }

        public static DataSet GetRegistroNotUpd(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTUPD"),
                DBHelper.MakeParam("@CodProfesor",SqlDbType.VarChar,0,registroNota.Profesor.CodigoProfesor),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,registroNota.Materia.CodMateria),
                DBHelper.MakeParam("@CodPeriodo",SqlDbType.VarChar,0,registroNota.Periodo.CodigoPeriodo),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,registroNota.AñoElectivo)
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);
        }

        public static DataSet GetRegistroNotInsert(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTINSERT"),
                DBHelper.MakeParam("@CodProfesor",SqlDbType.VarChar,0,registroNota.Profesor.CodigoProfesor),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,registroNota.Materia.CodMateria),
                DBHelper.MakeParam("@CodPeriodo",SqlDbType.VarChar,0,registroNota.Periodo.CodigoPeriodo),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,registroNota.AñoElectivo)
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);
        }

        public static DataSet GetBoletinesPorCursoCab(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SBOLEXCURCAB"),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodPeriodo",SqlDbType.VarChar,0,registroNota.Periodo.CodigoPeriodo),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,registroNota.AñoElectivo)
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);
        }

        public static DataSet GetPlanillaXCurso(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTPLANILLA"),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,registroNota.AñoElectivo)
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);
        }

        public static DataSet GetBoletinesPorCursoDet2(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SBOLEXCURDET2"),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodPeriodo",SqlDbType.VarChar,0,registroNota.Periodo.CodigoPeriodo),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,registroNota.AñoElectivo)
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);
        }

        public static DataSet GetMateriasCursos(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SMATCURSOS"), 
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),               
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);

        }

        public static DataSet GetProfeMateriasCurso(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SPROFMATECURSO"), 
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodMateria",SqlDbType.VarChar,0,registroNota.Materia.CodMateria)            
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);

        }

        public static DataSet GetConsultarNotas(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELNOTAALUM"),
                DBHelper.MakeParam("@CodAlumno",SqlDbType.VarChar,0,registroNota.Alumno.CodigoAlum),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,registroNota.AñoElectivo)
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);
        }

        public static DataSet GetConsolidadoXCurso(RegistroNota registroNota)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELCONSOXCUR"),
                DBHelper.MakeParam("@CodCurso",SqlDbType.VarChar,0,registroNota.Curso.CodigoCurso),
                DBHelper.MakeParam("@CodPeriodo",SqlDbType.VarChar,0,registroNota.Periodo.CodigoPeriodo),
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,registroNota.AñoElectivo)
            };

            return DBHelper.ExecuteDataSet("PA_RegistroNotas", dbParametros);
        }

    }
}
