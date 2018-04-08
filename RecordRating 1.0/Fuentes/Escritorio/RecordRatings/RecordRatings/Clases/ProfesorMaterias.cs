using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class ProfesorMaterias
    {
        public Materia Materia { get; set; }
        public Profesor Profesor { get; set; }

        public ProfesorMaterias()         
        {
            Materia = new Materia();
            Profesor = new Profesor();
        }

        public ProfesorMaterias(Materia materia, Profesor profesor) 
        {
            Materia = materia;
            Profesor = profesor;
        }
    }
}
