using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TPI_Diagramador
{
    internal class DiagramDTO
    {       
        public String TipoFigura { get; set; }
        public Point Point { get; set; }
        public int R { get; set; }
        public int B { get; set; }
        public int G { get; set; }
        public String ColorFigura { get; set; }
        public String Texto { get; set; }
        public String FontFam { get; set; }
        public float FontSize { get; set; }

        public Boolean esRelleno { get; set; }
        public DiagramDTO(){}
       
        public String toString()
        {
            return "figura: " + TipoFigura + ", point: "+Point+", color figura: "+ColorFigura + ", texto: " + Texto + ", fontFam: " + FontFam;
        }
    }
}
