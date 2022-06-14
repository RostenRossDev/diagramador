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
        private string textoImagen;
        private Panel menu;
        private bool isButonsFocus;

        public string TextoImagen { get { return this.textoImagen; } set { this.textoImagen = value; } }
        public string NombreFigura { get { return this.nombreFigura; } set { this.nombreFigura = value; } }
        public string ColorFigura { get { return this.colorFigura; } set { this.colorFigura = value; } }
        public bool Focus { get { return this.focus; } set { this.focus = value; } }
        public bool ColorRecuadro { get; set; } // para modificar el color del recuadro cuando esta seleccionado
        public DiagramImg()
        {
            focus = false;
            colorRecuadro = Color.Coral;
            menu= new Panel();
            menu.Name = "menu";
        }

        public override string ToString()
        {
            return "color: " + this.colorFigura + ", figura: " + nombreFigura + ", focus: " + this.focus;
        }
        
        //Cuando el mouse dekja la superficie del elemento
        protected override void OnMouseLeave(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" OnMouseLeave menu focus : " + isButonsFocus);

            if (isButonsFocus)
            {
                this.Parent.Controls.RemoveByKey("menu");
                this.menu.Dispose();
                this.menu = new Panel();
                menu.Name = "menu";
            }

            this.Refresh();
        }
       
        private void onMouseHoverButonvoid (object sender, System.EventArgs e)
        {
            this.isButonsFocus = true;
            System.Diagnostics.Debug.WriteLine(" onMouseHoverButonvoid menu focus : " + isButonsFocus);

        }

        private void onMouseLeaveButonvoid(object sender, System.EventArgs e)
        {
            this.isButonsFocus = false;
            System.Diagnostics.Debug.WriteLine("onMouseLeaveButonvoid fuera del boton");
            this.Parent.Controls.RemoveByKey("menu");
            this.menu.Dispose();
            this.menu = new Panel();
            menu.Name = "menu";

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
        protected override void OnMouseHover(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("mouse dentro");
            crearMenu();
            System.Diagnostics.Debug.WriteLine("menu focus : " + isButonsFocus);

            //base.OnMouseHover(e);
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
                System.Diagnostics.Debug.WriteLine("mouse fuera del boton");

                this.Parent.Controls.Remove(menu);
                this.menu.Dispose();
                this.menu = new Panel();
            }

        }               

        public void moverFigura(MouseEventArgs e)
        {
            int X = e.X;
            int Y = e.Y;

            int delta = e.Delta;
            this.Parent.Controls.RemoveByKey("menu");
            this.menu.Dispose();
            this.menu = new Panel();
            menu.Name = "menu";

            MouseEventArgs evento = new MouseEventArgs(e.Button,e.Clicks, X, Y, delta);
            OnMouseMove(evento);
        }


        public void writeImage(string t)
        {
            System.Diagnostics.Debug.WriteLine("texto: "+t);
            this.textoImagen = t;
            //conseguir tamaño del texto
            Font fontFake = new Font("Arial", 15.0F);
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphicsFake = Graphics.FromImage(fakeImage);
            SizeF size = graphicsFake.MeasureString(t, fontFake);
            System.Diagnostics.Debug.WriteLine("width" + size.Width+", heigth: "+ size.Height);

            //crear iamgen
            Image image = new Bitmap((int)size.Width, (int)size.Height);
            var font = new Font("Arial", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(t, font, Brushes.Black, new Point(0, 0));            
            this.Image = image;

        }       

        public void crearMenu()
        {
            this.menu = new Panel();
            menu.Name = "menu";
            menu.AutoSize = true;
            menu.BackColor = Color.LawnGreen;
            menu.MouseEnter += new System.EventHandler(onMouseHoverButonvoid);
            menu.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);
  

            Button botonAgrandar = new Button();
            botonAgrandar.Text = "+";
            botonAgrandar.Height = 20;
            botonAgrandar.Width = 20;
            botonAgrandar.Dock= DockStyle.Right;
            //botonAgrandar.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);
            //botonAgrandar.Location = new Point(this.Location.X + (this.Width / 3), this.Location.Y - 20);            
            menu.Width = botonAgrandar.Width;
            menu.Height = botonAgrandar.Height;
            menu.Controls.Add(botonAgrandar);


            Button botonAchicar = new Button();
            botonAchicar.Text = "-";
            botonAchicar.Height = 20;
            botonAchicar.Width = 20;
            botonAchicar.Dock = DockStyle.Right;
           // botonAchicar.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);

            menu.Width += botonAchicar.Width;
            menu.Controls.Add(botonAchicar);

            Button colorRojo = new Button();
            colorRojo.BackColor = Color.Red;
            colorRojo.Height = 20;
            colorRojo.Width = 20;
            colorRojo.Dock = DockStyle.Right;
           // colorRojo.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);

            menu.Width += colorRojo.Width;
            menu.Controls.Add(colorRojo);

            Button colorNegro = new Button();
            colorNegro.BackColor = Color.Black;
            colorNegro.Height = 20;
            colorNegro.Width = 20;
            colorNegro.Dock = DockStyle.Right;
           // colorNegro.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);

            menu.Width += colorNegro.Width;
            menu.Controls.Add(colorNegro);

            Button colorAmarillo = new Button();
            colorAmarillo.BackColor = Color.Yellow;
            colorAmarillo.Height = 20;
            colorAmarillo.Width = 20;
            colorAmarillo.Dock = DockStyle.Right;
           // colorAmarillo.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);

            menu.Width += colorAmarillo.Width;
            menu.Controls.Add(colorAmarillo);

            Button colorVerde = new Button();
            colorVerde.BackColor = Color.Green;
            colorVerde.Height = 20;
            colorVerde.Width = 20;
            colorVerde.Dock = DockStyle.Right;
            //colorVerde.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);

            menu.Width += colorVerde.Width;
            menu.Controls.Add(colorVerde);

            Button colorCeleste = new Button();
            colorCeleste.BackColor = Color.LightBlue;
            colorCeleste.Height = 20;
            colorCeleste.Width = 20;
            colorCeleste.Dock = DockStyle.Right;
           // colorCeleste.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);

            menu.Width += colorCeleste.Width;
            menu.Controls.Add(colorCeleste);

            Button colorNaranja = new Button();
            colorNaranja.BackColor = Color.Orange;
            colorNaranja.Height = 20;
            colorNaranja.Width = 20;
            colorNaranja.Dock = DockStyle.Right;
          // colorNaranja.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);

            menu.Width += colorNaranja.Width;
            menu.Controls.Add(colorNaranja);

            Button colorMorado = new Button();
            colorMorado.BackColor = Color.RebeccaPurple;
            colorMorado.Height = 20;
            colorMorado.Width = 20;
            colorMorado.Dock = DockStyle.Right;
          //  colorMorado.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);

            menu.Width += colorMorado.Width;
            menu.Controls.Add(colorMorado);
            menu.Location = new Point( (this.Location.X-(menu.Width/3)), this.Location.Y - 20);
            this.Parent.Controls.Add(menu);
        }       
    }
}
