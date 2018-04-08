using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public TipoUsuario() 
        { 
        }

        public TipoUsuario(int id, string codigo, string nombre) 
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
        }
    }
}
