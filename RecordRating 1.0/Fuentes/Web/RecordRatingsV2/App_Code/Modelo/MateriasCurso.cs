using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MateriasCurso
    {

        public Curso Curso { get; set; }
        public Materia Materia { get; set; }
        public Profesor Profesor { get; set; }
        public Int32 IHS { get; set; }

        public MateriasCurso() 
        {
            Curso = new Curso();
            Materia = new Materia();
            Profesor = new Profesor();
        }

        public MateriasCurso(Curso curso, Materia materia, Profesor profesor, Int32 iHS) 
        {
            Curso = curso;
            Materia = materia;
            Profesor = profesor;
            IHS = iHS;
        }
    }
}
