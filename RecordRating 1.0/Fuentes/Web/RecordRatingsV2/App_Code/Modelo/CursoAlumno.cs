using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CursoAlumno
    {
        public Curso Curso { get; set; }
        public Alumno Alumno { get; set; }
        public int AñoElectivo { get; set; }

        public CursoAlumno() 
        {
            Curso = new Curso();
            Alumno = new Alumno();
        }

        public CursoAlumno(Curso curso, Alumno alumno, int añoElectivo) 
        {
            Curso = curso;
            Alumno = alumno;
            AñoElectivo = añoElectivo;
        }
    }
}
