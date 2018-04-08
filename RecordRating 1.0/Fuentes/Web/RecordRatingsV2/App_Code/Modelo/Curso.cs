using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Curso
    {
        public int Id { get; set; }
        public string CodigoCurso { get; set; }
        public string Nombre { get; set; }
        public Grupo Grupo { get; set; }
        public Grado Grado { get; set; }
        public string Jornada { get; set; }

        public Curso() 
        {
            Grupo = new Grupo();
            Grado = new Grado();
        }

        public Curso(int id, string codigoCurso, string nombre, Grupo grupo, Grado grado, string jornada) 
        {
            Id = id;
            CodigoCurso = codigoCurso;
            Nombre = nombre;
            Grupo = grupo;
            Grado = grado;
            Jornada = jornada;

        }

    }
}
