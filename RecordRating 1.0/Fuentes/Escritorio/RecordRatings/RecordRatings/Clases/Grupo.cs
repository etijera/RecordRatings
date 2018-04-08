using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Clases
{
    class Grupo
    {

        public int Id { get; set; }
        public string CodigoGrupo { get; set; }
        public string Nombre { get; set; }

        public Grupo() 
        { 
        
        }

        public Grupo(int id, string codigoGrupo, string nombre) 
        {
            Id = id;
            CodigoGrupo = codigoGrupo;
            Nombre = nombre;
        }
    }
}
