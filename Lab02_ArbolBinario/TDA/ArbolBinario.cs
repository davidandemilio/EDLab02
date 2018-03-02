using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 

namespace TDA
{
    public struct Data
    {
        public int entero { get; set; }
        public Pais pais { get; set; }
    }

    public class Nodo
    {
        public Pais valor { get; set; }
        public Nodo izquierdo { get; set; }
        public Nodo derecho { get; set; }
    }

    public class ArbolB
    {
        public Nodo Raiz { get; set; }
    }
}
    

