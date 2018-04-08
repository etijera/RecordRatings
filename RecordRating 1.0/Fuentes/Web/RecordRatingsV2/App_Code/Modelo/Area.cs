using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Area
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public Area() 
        { 
        
        }

        public Area(int id, string codigo, string nombre) 
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
        }
    }
}
