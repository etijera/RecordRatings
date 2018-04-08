using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class CursoAñoElectivo
    {
        public Curso Curso { get; set; }
        public int AñoElectivo { get; set; }
        public int Estado { get; set; }

        public CursoAñoElectivo() 
        {
            Curso = new Curso();
        }

        public CursoAñoElectivo(Curso curso, int añoElectivo, int estado) 
        {
            Curso = curso;
            AñoElectivo = añoElectivo;
            Estado = estado;
        }
    }
}
