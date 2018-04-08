using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Persona Persona { get; set; }

        public Usuario() 
        {
            TipoUsuario = new TipoUsuario();
            Persona = new Persona();
        }

        public Usuario(int id, string codigo, string nombre, string contrasenia, TipoUsuario tipouUsuario, Persona persona) 
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Contrasenia = contrasenia;
            TipoUsuario = tipouUsuario;
            Persona = persona;
        }
    }
}
