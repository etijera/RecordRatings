using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class Alumno
    {

        public Persona Persona { get; set; }
        public string CodigoAlum { get; set; }
        public string Carnet { get; set; }
        public Curso Curso { get; set; }
        public Usuario Usuario { get; set; }
        public string Estado { get; set; }

        public Alumno() 
        {
            Persona = new Persona();
            Curso = new Curso();
            Usuario = new Usuario();
        }

        public Alumno(Persona persona, string codigoAlum, string carnet, Curso curso, Usuario usuario, string estado) 
        {
            Persona = persona;
            CodigoAlum = codigoAlum;
            Carnet = carnet;
            Curso = curso;
            Usuario = usuario;
            Estado = estado;
        }
    }
}
