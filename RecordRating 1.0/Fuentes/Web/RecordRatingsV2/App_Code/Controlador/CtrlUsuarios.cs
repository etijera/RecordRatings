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
    public class CtrlUsuarios
    {
        public static Int32 InsertarBasico(Usuario usuario)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERTBASICO"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,usuario.Nombre),
                DBHelper.MakeParam("@Contrasenia",SqlDbType.VarChar,0,usuario.Contrasenia),
                DBHelper.MakeParam("@CodTipoUsuario",SqlDbType.VarChar,0,usuario.TipoUsuario.Codigo), 
                DBHelper.MakeParam("@NombrePersona",SqlDbType.VarChar,0,usuario.Persona.Nombre),
                DBHelper.MakeParam("@PrimerNombre",SqlDbType.VarChar,0,usuario.Persona.PrimerNombre),
                DBHelper.MakeParam("@SegundoNombre",SqlDbType.VarChar,0,usuario.Persona.SegundoNombre),
                DBHelper.MakeParam("@PrimerApellido",SqlDbType.VarChar,0,usuario.Persona.PrimerApellido),
                DBHelper.MakeParam("@SegundoApellido",SqlDbType.VarChar,0,usuario.Persona.SegundoApellido),
                DBHelper.MakeParam("@Identificacion",SqlDbType.VarChar,0,usuario.Persona.Identificacion),
                DBHelper.MakeParam("@Direccion",SqlDbType.VarChar,0,usuario.Persona.Direccion),
                DBHelper.MakeParam("@Telefono",SqlDbType.VarChar,0,usuario.Persona.Telefono),
                DBHelper.MakeParam("@Email",SqlDbType.VarChar,0,usuario.Persona.Email),
                DBHelper.MakeParam("@Sexo",SqlDbType.VarChar,0,usuario.Persona.Sexo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Usuarios", dbParametros));
        }

        public static Int32 InsertarProfe(Usuario usuario)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERTPROFE"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,usuario.Nombre),
                DBHelper.MakeParam("@Contrasenia",SqlDbType.VarChar,0,usuario.Contrasenia),
                DBHelper.MakeParam("@CodTipoUsuario",SqlDbType.VarChar,0,usuario.TipoUsuario.Codigo), 
                DBHelper.MakeParam("@NombrePersona",SqlDbType.VarChar,0,usuario.Persona.Nombre),
                DBHelper.MakeParam("@PrimerNombre",SqlDbType.VarChar,0,usuario.Persona.PrimerNombre),
                DBHelper.MakeParam("@SegundoNombre",SqlDbType.VarChar,0,usuario.Persona.SegundoNombre),
                DBHelper.MakeParam("@PrimerApellido",SqlDbType.VarChar,0,usuario.Persona.PrimerApellido),
                DBHelper.MakeParam("@SegundoApellido",SqlDbType.VarChar,0,usuario.Persona.SegundoApellido),
                DBHelper.MakeParam("@Identificacion",SqlDbType.VarChar,0,usuario.Persona.Identificacion),
                DBHelper.MakeParam("@Direccion",SqlDbType.VarChar,0,usuario.Persona.Direccion),
                DBHelper.MakeParam("@Telefono",SqlDbType.VarChar,0,usuario.Persona.Telefono),
                DBHelper.MakeParam("@Email",SqlDbType.VarChar,0,usuario.Persona.Email),
                DBHelper.MakeParam("@Sexo",SqlDbType.VarChar,0,usuario.Persona.Sexo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Usuarios", dbParametros));
        }

        public static Int32 InsertarAlumno(Usuario usuario)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"INSERTALUMNO"),
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,usuario.Nombre),
                DBHelper.MakeParam("@Contrasenia",SqlDbType.VarChar,0,usuario.Contrasenia),
                DBHelper.MakeParam("@CodTipoUsuario",SqlDbType.VarChar,0,usuario.TipoUsuario.Codigo), 
                DBHelper.MakeParam("@NombrePersona",SqlDbType.VarChar,0,usuario.Persona.Nombre),
                DBHelper.MakeParam("@PrimerNombre",SqlDbType.VarChar,0,usuario.Persona.PrimerNombre),
                DBHelper.MakeParam("@SegundoNombre",SqlDbType.VarChar,0,usuario.Persona.SegundoNombre),
                DBHelper.MakeParam("@PrimerApellido",SqlDbType.VarChar,0,usuario.Persona.PrimerApellido),
                DBHelper.MakeParam("@SegundoApellido",SqlDbType.VarChar,0,usuario.Persona.SegundoApellido),
                DBHelper.MakeParam("@Identificacion",SqlDbType.VarChar,0,usuario.Persona.Identificacion),
                DBHelper.MakeParam("@Direccion",SqlDbType.VarChar,0,usuario.Persona.Direccion),
                DBHelper.MakeParam("@Telefono",SqlDbType.VarChar,0,usuario.Persona.Telefono),
                DBHelper.MakeParam("@Email",SqlDbType.VarChar,0,usuario.Persona.Email),
                DBHelper.MakeParam("@Sexo",SqlDbType.VarChar,0,usuario.Persona.Sexo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Usuarios", dbParametros));
        }

        public static Int32 Actualizar(Usuario usuario)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"UPDATE"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,usuario.Id), 
                DBHelper.MakeParam("@Contrasenia",SqlDbType.VarChar,0,usuario.Contrasenia),
                DBHelper.MakeParam("@CodTipoUsuario",SqlDbType.VarChar,0,usuario.TipoUsuario.Codigo), 
                DBHelper.MakeParam("@IdPersona",SqlDbType.Int,0,usuario.Persona.Id),
                DBHelper.MakeParam("@NombrePersona",SqlDbType.VarChar,0,usuario.Persona.Nombre),
                DBHelper.MakeParam("@PrimerNombre",SqlDbType.VarChar,0,usuario.Persona.PrimerNombre),
                DBHelper.MakeParam("@SegundoNombre",SqlDbType.VarChar,0,usuario.Persona.SegundoNombre),
                DBHelper.MakeParam("@PrimerApellido",SqlDbType.VarChar,0,usuario.Persona.PrimerApellido),
                DBHelper.MakeParam("@SegundoApellido",SqlDbType.VarChar,0,usuario.Persona.SegundoApellido),
                DBHelper.MakeParam("@Identificacion",SqlDbType.VarChar,0,usuario.Persona.Identificacion),
                DBHelper.MakeParam("@Direccion",SqlDbType.VarChar,0,usuario.Persona.Direccion),
                DBHelper.MakeParam("@Telefono",SqlDbType.VarChar,0,usuario.Persona.Telefono),
                DBHelper.MakeParam("@Email",SqlDbType.VarChar,0,usuario.Persona.Email),
                DBHelper.MakeParam("@Sexo",SqlDbType.VarChar,0,usuario.Persona.Sexo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Usuarios", dbParametros));
        }

        public static DataSet GetUsuarioOne(Usuario usuario)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTID"), 
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,usuario.Id),               
            };

            return DBHelper.ExecuteDataSet("PA_Usuarios", dbParametros);
        }

        public static DataSet GetUsuarioName(Usuario usuario)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTNAME"), 
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,usuario.Nombre),               
            };

            return DBHelper.ExecuteDataSet("PA_Usuarios", dbParametros);
            
        }

        public static DataSet GetUsuarioNameProfe(Usuario usuario)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SDATUSUPRO"), 
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,usuario.Nombre),               
            };

            return DBHelper.ExecuteDataSet("PA_Usuarios", dbParametros);

        }

        public static DataSet GetUsuarioNameAlum(Usuario usuario)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SDATUSUALUM"), 
                DBHelper.MakeParam("@Nombre",SqlDbType.VarChar,0,usuario.Nombre),               
            };

            return DBHelper.ExecuteDataSet("PA_Usuarios", dbParametros);

        }

        public static DataSet GetUsuarioAll()
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"SELECTALL")            
            };

            return DBHelper.ExecuteDataSet("PA_Usuarios", dbParametros);
        }

        public static Int32 Eliminar(Usuario usuario)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@Operacion",SqlDbType.VarChar,0,"DEL"),
                DBHelper.MakeParam("@Id",SqlDbType.Int,0,usuario.Id),
                DBHelper.MakeParam("@IdPersona",SqlDbType.Int,0,usuario.Persona.Id)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("PA_Usuarios", dbParametros));
        }

    }
}
