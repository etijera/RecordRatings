using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class Nivel
    {
         public int Id { get; set; }
         public string CodNivel { get; set; }
         public string Nombre { get; set; }

        public Nivel() 
        { 
        
        }

        public Nivel(int id, string codNivel, string nombre) 
        {
            Id = id;
            CodNivel = codNivel;
            Nombre = nombre;
        }
    }
}
