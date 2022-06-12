using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Diagramador
{
    internal class DiagramDTO
    {
        private string tipoFigura;      
        private Point point;
        private string colorFigura;
        private string texto;
        public string Texto { get; set; }
        public string TipoFigura { get; set; }
        public Point Point { get; set; }
        public string ColorFigura { get; set; }
        public DiagramDTO(){}
    }
}
