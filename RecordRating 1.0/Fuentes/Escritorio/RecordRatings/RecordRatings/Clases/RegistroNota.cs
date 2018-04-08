using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class RegistroNota
    {

        public Alumno Alumno { get; set; }
        public Profesor Profesor { get; set; }
        public Curso Curso { get; set; }
        public Materia Materia { get; set; }
        public Periodo Periodo { get; set; }
        public Decimal Nota1 { get; set; }
        public Decimal PorcN1 { get; set; }
        public Decimal Nota2 { get; set; }
        public Decimal PorcN2 { get; set; }
        public Decimal Nota3 { get; set; }
        public Decimal PorcN3 { get; set; }
        public Decimal Nota4 { get; set; }
        public Decimal PorcN4 { get; set; }
        public Decimal NotaFinal { get; set; }
        public int Fallas { get; set; }
        public int AñoElectivo { get; set; }

        public RegistroNota() 
        {
            Alumno = new Alumno();
            Profesor = new Profesor();
            Curso = new Curso();
            Materia = new Materia();
            Periodo = new Periodo();
        }

        public RegistroNota(Alumno alumno, Profesor profesor, Curso curso, Materia materia, Periodo periodo,
                            Decimal nota1, Decimal porcN1, Decimal nota2, Decimal porcN2, Decimal nota3, Decimal porcN3,
                            Decimal nota4, Decimal porcN4, Decimal notaFinal, int fallas, int añoElectivo)
        {
            Alumno = alumno;
            Profesor = profesor;
            Curso = curso;
            Materia = materia;
            Periodo = periodo;
            Nota1 = nota1;
            PorcN1 = porcN1;
            Nota2 = nota2;
            PorcN2 = porcN2;
            Nota3 = nota3;
            PorcN3 = porcN3;
            Nota4 = nota4;
            PorcN4 = porcN4;
            NotaFinal = notaFinal;
            Fallas = fallas;
            AñoElectivo = añoElectivo;
        }
    }
}
