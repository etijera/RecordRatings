using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class MateriasCurso
    {

        public Curso Curso { get; set; }
        public Materia Materia { get; set; }
        public Profesor Profesor { get; set; }
        public Int32 IHS { get; set; }
        public int AñoElectivo { get; set; }
        public int Porcentaje { get; set; }
        public Area Area { get; set; }

        public MateriasCurso() 
        {
            Curso = new Curso();
            Materia = new Materia();
            Profesor = new Profesor();
            Area = new Area();
        }

        public MateriasCurso(Curso curso, Materia materia, Profesor profesor, Int32 iHS, int añoElectivo, int porcentaje, Area area) 
        {
            Curso = curso;
            Materia = materia;
            Profesor = profesor;
            IHS = iHS;
            AñoElectivo = añoElectivo;
            Porcentaje = porcentaje;
            Area = area;
        }
    }
}
