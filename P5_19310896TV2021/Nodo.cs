using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_19310896TV2021
{
    class Nodo
    {
        private string dato;
        private Nodo liga;

        public Nodo(string dt)
        {
            Dato = dt;
            Liga = null;
        }

        public string Dato { get => dato; set => dato = value; }
        internal Nodo Liga { get => liga; set => liga = value; }
    }
}
