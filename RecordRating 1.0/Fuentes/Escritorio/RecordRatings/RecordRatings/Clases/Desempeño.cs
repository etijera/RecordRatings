using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class Desempeño
    {
        public int Id { get; set; }
        public string CodigoDesemp { get; set; }
        public string Nombre { get; set; }
        public Decimal NotaMin { get; set; }
        public Decimal NotaMax { get; set; }

        public Desempeño() 
        {
        
        }

        public Desempeño(int id, string codigoDesemp, string nombre, Decimal notaMin, Decimal notaMax) 
        {
            Id = id;
            CodigoDesemp = codigoDesemp;
            Nombre = nombre;
            NotaMin = notaMin;
            NotaMax = notaMax;
        }

    }
}
