using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLReferences
{
    public class KeyValuePair<Tk, Tv>
    {
        public Tk Clave { get; set; }
        public Tv Valor { get; set; }

        public KeyValuePair(Tk k, Tv v)
        {
            Clave = k;
            Valor = v;
        }

        /// <summary>
        /// Retorna Valor.ToString();
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Valor.ToString();
        }
    }
}
