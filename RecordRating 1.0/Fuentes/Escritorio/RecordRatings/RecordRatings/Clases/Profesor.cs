using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class Profesor
    {
        public Persona Persona { get; set; }
        public string CodigoProfesor { get; set; }
        public Usuario Usuario { get; set; }
        public string Estado { get; set; }

        public Profesor() 
        {
            Persona = new Persona();
            Usuario = new Usuario();
        }

        public Profesor(Persona persona, string codigoProfesor, Usuario usuario, string estado) 
        {
            Persona = persona;
            CodigoProfesor = codigoProfesor;
            Usuario = usuario;
            Estado = estado;
        }

    }
}
