using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class Institucion
    {

        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Resolusion { get; set; }
        public string CodigoDane { get; set; }
        public string Abreviaura { get; set; }
        public string Lema { get; set; }
        public string Director { get; set; }
        public string Secretaria { get; set; }
        public string Coordinador { get; set; }
        public string Logo { get; set; }

        public Institucion() 
        { 

        }

        public Institucion (string nombre, string nit, string direccion, string telefono, string email, string resolusion,
                        string codigoDane, string abreviaura, string lema, string director, string secretaria, string coordinador, string logo) 
        {
            Nombre = nombre;
            Nit = nit;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Resolusion = resolusion;
            CodigoDane = codigoDane;
            Abreviaura = abreviaura;
            Lema = lema;
            Director = director;
            Secretaria = secretaria;
            Coordinador = coordinador;
            Logo = logo;
        }
    }
}
