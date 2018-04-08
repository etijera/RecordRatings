using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class Materia
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string CodMateria { get; set; }
        public string Nombre { get; set; }

        public Materia()
        {
            Area = new Area();
        }

        public Materia(int id, Area area, string codMateria, string nombre) 
        {
            Id = id;
            Area = area;
            CodMateria = codMateria;
            Nombre = nombre;
        }
    }
}
