using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class Grado
    {
        public int Id { get; set; }
        public string CodigoGrado { get; set; }
        public string Nombre { get; set; }
        public int Numero { get; set; }

        public Grado() 
        { 
        }

        public Grado(int id, string codigoGrado, string nombre, int numero) 
        {
            Id = id;
            CodigoGrado = codigoGrado;
            Nombre = nombre;
            Numero = numero;
        }

    }
}
