﻿using System;
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
        public Color ColorTexto { get; set; }
        public String ColorFigura { get; set; }
        public String Texto { get; set; }
        public DiagramDTO(){}
       
        public String toString()
        {
            return "figura: " + TipoFigura + ", point: "+Point+", color texto: "+ColorTexto+", color figura: "+ColorFigura+", texto: "+Texto;
        }
    }
}
