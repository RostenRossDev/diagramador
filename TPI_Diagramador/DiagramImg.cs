using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Diagramador
{
    internal class DiagramImg : PictureBox
    {
        private Point point; //Para obtener el centro del elemento
        private bool focus; //Para saber si esta seleccionado el elemento
        private Color colorRecuadro;
        private string nombreFigura;
        private string colorFigura;
        
        public string NombreFigura { get; set; }
        public string ColorFigura { get; set; }
        public bool Focus { get; set; }
        public bool ColorRecuadro { get; set; } // para modificar el color del recuadro cuando esta seleccionado
        public DiagramImg()
        {
            focus = false;
            colorRecuadro = Color.Coral;

        }

        public override string ToString()
        {
            return "color: " + this.colorFigura + ", figura: " + nombreFigura + ", focus: " + this.focus;
        }
        public void setFocusTrue()
        {
            this.focus = true;
        }
        public void setFocusFalse()
        {
            this.focus = false;
        }
        //Cuando el mouse dekja la superficie del elemento
        protected override void OnMouseLeave(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnMouseLeave" + this.focus + ", " + this.Name);
            this.Refresh();
        }

       
        public void dibujarContorno() 
        {
            Graphics g = Graphics.FromImage(this.Image);
            Rectangle r = Rectangle.FromLTRB(0, 0, this.Width, this.Height);
            ControlPaint.DrawBorder(g, r, Color.Coral, ButtonBorderStyle.Solid);
        }

        public void eliminarContorno(Color color)
        {
            Graphics g = Graphics.FromImage(this.Image);
            Rectangle r = Rectangle.FromLTRB(0, 0, this.Width, this.Height);
            ControlPaint.DrawBorder(g, r, color, ButtonBorderStyle.Solid);
        }

        //Cuando el mouse entra en el area del elemento
        protected override void OnMouseEnter(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnMouseEnter" + this.focus + ", " + this.Name);
            this.Refresh();
        }

        //Cuando el boton del mouse se apreta (no cuando hace click, solo detecta cuando boton baja)
        protected override void OnMouseDown(MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnMouseDown" + this.focus + ", " + this.Name);
            point = e.Location;
            this.Refresh();
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.Refresh();

            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }               

        public void moverFigura(MouseEventArgs e)
        {
            int X = e.X;
            int Y = e.Y;
            int delta = e.Delta;

            MouseEventArgs evento = new MouseEventArgs(e.Button,e.Clicks, X, Y, delta);
            OnMouseMove(evento);
        }
    }
}
