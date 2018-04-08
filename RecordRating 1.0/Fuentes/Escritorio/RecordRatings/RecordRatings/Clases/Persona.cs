using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class Persona
    {       
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }

        public Persona() 
        { 
        }

        public Persona(int id, string nombre, string primerNombre, string segundoNombre, string primerApellido,
                       string segundoApellido, string identificacion, string direccion, string telefono, string email, string sexo)
        {
            Id = id;
            Nombre = nombre;
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Identificacion = identificacion;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Sexo = sexo;
        }

    }
}
