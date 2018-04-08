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
    class CtrlProfesores
    {
        public static DataSet Insertar(Profesor profesor)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERT"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,profesor.Persona.Nombre),
                DBHelper.MakeParam("@PrimerNombre",SqlDbType.VarChar,0,profesor.Persona.PrimerNombre),
                DBHelper.MakeParam("@SegundoNombre",SqlDbType.VarChar,0,profesor.Persona.SegundoNombre),
                DBHelper.MakeParam("@PrimerApellido",SqlDbType.VarChar,0,profesor.Persona.PrimerApellido),
                DBHelper.MakeParam("@SegundoApellido",SqlDbType.VarChar,0,profesor.Persona.SegundoApellido),
                DBHelper.MakeParam("@Identificacion",SqlDbType.VarChar,0,profesor.Persona.Identificacion),
                DBHelper.MakeParam("@Direccion",SqlDbType.VarChar,0,profesor.Persona.Direccion),
                DBHelper.MakeParam("@Telefono",SqlDbType.VarChar,0,profesor.Persona.Telefono),
                DBHelper.MakeParam("@Email",SqlDbType.VarChar,0,profesor.Persona.Email),
                DBHelper.MakeParam("@Sexo",SqlDbType.VarChar,0,profesor.Persona.Sexo),
                DBHelper.MakeParam("@NombreUsuario",SqlDbType.VarChar,0,profesor.Usuario.Nombre),
                DBHelper.MakeParam("@Contrasenia",SqlDbType.VarChar,0,profesor.Usuario.Contrasenia),
                DBHelper.MakeParam("@CodTipoUsuario",SqlDbType.VarChar,0,profesor.Usuario.TipoUsuario.Codigo),
                DBHelper.MakeParam("@Estado",SqlDbType.VarChar,0,profesor.Estado)
            };

           return DBHelper.ExecuteDataSet("PA_Profesores", dbParametros);
        }

        public static Int32 Actualizar(Profesor profesor)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,profesor.Persona.Id), 
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,profesor.Persona.Nombre),
                DBHelper.MakeParam("@PrimerNombre",SqlDbType.VarChar,0,profesor.Persona.PrimerNombre),
                DBHelper.MakeParam("@SegundoNombre",SqlDbType.VarChar,0,profesor.Persona.SegundoNombre),
                DBHelper.MakeParam("@PrimerApellido",SqlDbType.VarChar,0,profesor.Persona.PrimerApellido),
                DBHelper.MakeParam("@SegundoApellido",SqlDbType.VarChar,0,profesor.Persona.SegundoApellido),
                DBHelper.MakeParam("@Identificacion",SqlDbType.VarChar,0,profesor.Persona.Identificacion),
                DBHelper.MakeParam("@Direccion",SqlDbType.VarChar,0,profesor.Persona.Direccion),
                DBHelper.MakeParam("@Telefono",SqlDbType.VarChar,0,profesor.Persona.Telefono),
                DBHelper.MakeParam("@Email",SqlDbType.VarChar,0,profesor.Persona.Email),
                DBHelper.MakeParam("@Sexo",SqlDbType.VarChar,0,profesor.Persona.Sexo),
                DBHelper.MakeParam("@Estado",SqlDbType.VarChar,0,profesor.Estado)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Profesores", dbParametros));
        }

        public static DataSet GetProfesorOne(Profesor profesor)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,profesor.Persona.Id),             
            };

            return DBHelper.ExecuteDataSet("PA_Profesores", dbParametros);
        }

        public static DataSet GetProfesorAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL")            
            };

            return DBHelper.ExecuteDataSet("PA_Profesores", dbParametros);
        }

        public static DataSet GetPersonaIdentificacion(Profesor profesor)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTIDENTI"), 
                DBHelper.MakeParam("@Identificacion",SqlDbType.VarChar,0,profesor.Persona.Identificacion),               
            };

            return DBHelper.ExecuteDataSet("PA_Profesores", dbParametros);

        }

        public static Int32 Eliminar(Profesor profesor)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,profesor.Persona.Id),  
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Profesores", dbParametros));
        }
    }
}
