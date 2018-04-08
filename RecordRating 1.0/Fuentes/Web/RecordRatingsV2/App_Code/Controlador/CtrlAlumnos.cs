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
    class CtrlAlumnos
    {
        public static DataSet Insertar(Alumno alumno)
        {           
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,alumno.Persona.Nombre),
                DBHelper.MakeParam("@PrimerNombre",SqlDbType.VarChar,0,alumno.Persona.PrimerNombre),
                DBHelper.MakeParam("@SegundoNombre",SqlDbType.VarChar,0,alumno.Persona.SegundoNombre),
                DBHelper.MakeParam("@PrimerApellido",SqlDbType.VarChar,0,alumno.Persona.PrimerApellido),
                DBHelper.MakeParam("@SegundoApellido",SqlDbType.VarChar,0,alumno.Persona.SegundoApellido),
                DBHelper.MakeParam("@Identificacion",SqlDbType.VarChar,0,alumno.Persona.Identificacion),
                DBHelper.MakeParam("@Carnet",SqlDbType.VarChar,0,alumno.Carnet),
                DBHelper.MakeParam("@Direccion",SqlDbType.VarChar,0,alumno.Persona.Direccion),
                DBHelper.MakeParam("@Telefono",SqlDbType.VarChar,0,alumno.Persona.Telefono),
                DBHelper.MakeParam("@Email",SqlDbType.VarChar,0,alumno.Persona.Email),
                DBHelper.MakeParam("@Sexo",SqlDbType.VarChar,0,alumno.Persona.Sexo),
                DBHelper.MakeParam("@NombreUsuario",SqlDbType.VarChar,0,alumno.Usuario.Nombre),
                DBHelper.MakeParam("@Contrasenia",SqlDbType.VarChar,0,alumno.Usuario.Contrasenia),
                DBHelper.MakeParam("@CodTipoUsuario",SqlDbType.VarChar,0,alumno.Usuario.TipoUsuario.Codigo),
                DBHelper.MakeParam("@Estado",SqlDbType.VarChar,0,alumno.Estado)
             
            };

            return DBHelper.ExecuteDataSet("PA_Alumnos", dbParametros);
        }

        public static DataSet Actualizar(Alumno alumno)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,alumno.Persona.Id), 
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,alumno.Persona.Nombre),
                DBHelper.MakeParam("@PrimerNombre",SqlDbType.VarChar,0,alumno.Persona.PrimerNombre),
                DBHelper.MakeParam("@SegundoNombre",SqlDbType.VarChar,0,alumno.Persona.SegundoNombre),
                DBHelper.MakeParam("@PrimerApellido",SqlDbType.VarChar,0,alumno.Persona.PrimerApellido),
                DBHelper.MakeParam("@SegundoApellido",SqlDbType.VarChar,0,alumno.Persona.SegundoApellido),
                DBHelper.MakeParam("@Identificacion",SqlDbType.VarChar,0,alumno.Persona.Identificacion),
                DBHelper.MakeParam("@Carnet",SqlDbType.VarChar,0,alumno.Carnet),
                DBHelper.MakeParam("@Direccion",SqlDbType.VarChar,0,alumno.Persona.Direccion),
                DBHelper.MakeParam("@Telefono",SqlDbType.VarChar,0,alumno.Persona.Telefono),
                DBHelper.MakeParam("@Email",SqlDbType.VarChar,0,alumno.Persona.Email),
                DBHelper.MakeParam("@Sexo",SqlDbType.VarChar,0,alumno.Persona.Sexo),
                DBHelper.MakeParam("@Estado",SqlDbType.VarChar,0,alumno.Estado)
            };

            return DBHelper.ExecuteDataSet("PA_Alumnos", dbParametros);
        }

        public static DataSet GetAlumnoOne(Alumno alumno)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,alumno.Persona.Id),              
            };

            return DBHelper.ExecuteDataSet("PA_Alumnos", dbParametros);
        }

        public static DataSet GetAlumnoAll(int año)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL") , 
                DBHelper.MakeParam("@AñoElectivo",SqlDbType.Int,0,año),             
            };

            return DBHelper.ExecuteDataSet("PA_Alumnos", dbParametros);
        }

        public static DataSet GetPersonaIdentificacion(Alumno alumno)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTIDENTI"), 
                DBHelper.MakeParam("@Identificacion",SqlDbType.VarChar,0,alumno.Persona.Identificacion),               
            };

            return DBHelper.ExecuteDataSet("PA_Alumnos", dbParametros);

        }

        public static Int32 Eliminar(Alumno alumno)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,alumno.Persona.Id),  
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Alumnos", dbParametros));
        }
    }
}
