using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class Periodo
    {
        public int Id { get; set; }
        public string CodigoPeriodo { get; set; }
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public int Porcentaje { get; set; }

        public Periodo() 
        { 
        
        }
        public Periodo(int id, string codigoPeriodo, string nombre, int numero, int porcentaje)
        {
            Id = id;
            CodigoPeriodo = codigoPeriodo;
            Nombre = nombre;
            Numero = numero;
            Porcentaje = porcentaje;
        }
    }
}
