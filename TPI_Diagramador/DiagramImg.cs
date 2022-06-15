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
        private float fontSize=15;
        private Panel menu;
        private bool isButonsFocus;
        private Color colorTexto = Color.Black;
        public Color ColorTexto { get { return this.colorTexto; } set { this.colorTexto = value; } }
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

        private void onClickCerrar(object sender, System.EventArgs e)
        {
            Button bt = sender as Button;            
            bt.Parent.Dispose();
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


        public void writeImage(string t, Brush brush)
        {
            if (brush is null)
            {
                brush = new SolidBrush(this.colorTexto);
            }

            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            
            System.Diagnostics.Debug.WriteLine("texto: "+t);
            this.textoImagen = t;
            if (this.Image != null) this.Image.Dispose();

            //conseguir tamaño del texto
            Font fontFake = new Font("Arial", this.fontSize);
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphicsFake = Graphics.FromImage(fakeImage);
            SizeF size = graphicsFake.MeasureString(t, fontFake);
            System.Diagnostics.Debug.WriteLine("width: " + (size.Width)+", heigth: "+ size.Height);

            //crear iamgen
            
            Image image = new Bitmap((int)size.Width/*-(int(this.Size.Width*0.07)*/, (int)size.Height/*- (int)(this.Size.Width * 0.07)*/);
            var font = new Font("Arial", (int) this.fontSize, FontStyle.Regular);
            
            var graphics = Graphics.FromImage(image);

            //graphics.DrawString(t, font, Brushes.Black, new Point(0, 0));            
            graphics.DrawString(t, font, brush, new Point(0, 0), drawFormat);
            this.Image = image;

        }
        private void onClickAgrandarFontSize (object sender, System.EventArgs e)
        {
            if (this.fontSize <60) this.fontSize++;
            System.Diagnostics.Debug.WriteLine("size: " + this.fontSize);
            this.writeImage(this.textoImagen, null);
        }
        private void onClickAchicarFontSize(object sender, System.EventArgs e)
        {
            if(this.fontSize>2) this.fontSize--;
            System.Diagnostics.Debug.WriteLine("size: " + this.fontSize);
            this.writeImage(this.textoImagen, null);
        }
        private void onClickColorRojo(object sender, System.EventArgs e)
        {
            this.colorTexto = Color.FromArgb(255,28,0);
            Brush br = new SolidBrush(colorTexto);
            writeImage(this.textoImagen, br);
        }

        private void onClickColorVerde(object sender, System.EventArgs e)
        {
            this.colorTexto = Color.FromArgb(0, 242, 0);
            Brush br = new SolidBrush(colorTexto);
            writeImage(this.textoImagen, br);
        }
        private void onClickColorNaranja(object sender, System.EventArgs e)
        {
            this.colorTexto = Color.FromArgb(255, 146, 0);
            Brush br = new SolidBrush(colorTexto);
            writeImage(this.textoImagen, br);
        }
        private void onClickColorCeleste(object sender, System.EventArgs e)
        {
            this.colorTexto = Color.FromArgb(0, 178, 250);
            Brush br = new SolidBrush(colorTexto);
            writeImage(this.textoImagen, br);
        }
        private void onClickColorAmarillo(object sender, System.EventArgs e)
        {
            this.colorTexto = Color.FromArgb(246, 231, 250);
            Brush br = new SolidBrush(colorTexto);
            writeImage(this.textoImagen, br);
        }
        private void onClickColorMorado(object sender, System.EventArgs e)
        {
            this.colorTexto = Color.FromArgb(120, 0, 255);
            Brush br = new SolidBrush(colorTexto);
            writeImage(this.textoImagen, br);
        }
        private void onClickColorNegro(object sender, System.EventArgs e)
        {
            this.colorTexto = Color.Black;
            Brush br = new SolidBrush(colorTexto);
            writeImage(this.textoImagen, br);
        }

        public void crearMenu()
        {
            this.menu = new Panel();
            menu.Name = "menu";
            menu.AutoSize = true;
            //menu.BackColor = Color.LawnGreen;
            menu.MouseEnter += new System.EventHandler(onMouseHoverButonvoid);
            menu.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);
            menu.Padding = new Padding(5,5,5,0);
            Button botonAgrandar = new Button();
            Button botonAchicar = new Button();
            botonAgrandar.Text = "+";
            botonAchicar.Text = "-";

            if (this.textoImagen != null )
            {         
                botonAgrandar.Dock = DockStyle.Right;
                botonAgrandar.Click += new System.EventHandler(onClickAgrandarFontSize);

                botonAchicar.Dock = DockStyle.Right;
                botonAchicar.Click += new System.EventHandler(onClickAchicarFontSize);    

            }
            else
            {                
                botonAgrandar.Dock = DockStyle.Right;
                //botonAgrandar.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);

                botonAchicar.Dock = DockStyle.Right;
                // botonAchicar.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);                
            }
            botonAchicar.Height = 20;
            botonAchicar.Width = 20;
            botonAgrandar.Height = 20;
            botonAgrandar.Width = 20;

            menu.Height = 20;
            menu.Controls.Add(botonAgrandar);
            menu.Controls.Add(botonAchicar);
            Button colorRojo = new Button();
            colorRojo.BackColor = Color.Red;
            colorRojo.Height = 20;
            colorRojo.Width = 20;
            colorRojo.Dock = DockStyle.Right;
           colorRojo.Click += new System.EventHandler(onClickColorRojo);

            menu.Width += colorRojo.Width;
            menu.Controls.Add(colorRojo);

            Button colorNegro = new Button();
            colorNegro.BackColor = Color.Black;
            colorNegro.Height = 20;
            colorNegro.Width = 20;
            colorNegro.Dock = DockStyle.Right;
           colorNegro.Click += new System.EventHandler(onClickColorNegro);

            menu.Controls.Add(colorNegro);

            Button colorAmarillo = new Button();
            colorAmarillo.BackColor = Color.Yellow;
            colorAmarillo.Height = 20;
            colorAmarillo.Width = 20;
            colorAmarillo.Dock = DockStyle.Right;
           colorAmarillo.Click += new System.EventHandler(onClickColorAmarillo);

            menu.Controls.Add(colorAmarillo);

            Button colorVerde = new Button();
            colorVerde.BackColor = Color.Green;
            colorVerde.Height = 20;
            colorVerde.Width = 20;
            colorVerde.Dock = DockStyle.Right;
            colorVerde.Click += new System.EventHandler(onClickColorVerde);

            menu.Controls.Add(colorVerde);

            Button colorCeleste = new Button();
            colorCeleste.BackColor = Color.LightBlue;
            colorCeleste.Height = 20;
            colorCeleste.Width = 20;
            colorCeleste.Dock = DockStyle.Right;
            colorCeleste.Click += new System.EventHandler(onClickColorCeleste);

            menu.Controls.Add(colorCeleste);

            Button colorNaranja = new Button();
            colorNaranja.BackColor = Color.Orange;
            colorNaranja.Height = 20;
            colorNaranja.Width = 20;
            colorNaranja.Dock = DockStyle.Right;
            colorNaranja.Click += new System.EventHandler(onClickColorNaranja);

            menu.Controls.Add(colorNaranja);

            Button colorMorado = new Button();
            colorMorado.BackColor = Color.RebeccaPurple;
            colorMorado.Height = 20;
            colorMorado.Width = 20;
            colorMorado.Dock = DockStyle.Right;

            menu.Controls.Add(colorMorado);
            colorMorado.Click += new System.EventHandler(onClickColorMorado);

            Button cobtnCerrar = new Button();
            cobtnCerrar.Text = "X";
            cobtnCerrar.Height = 20;
            cobtnCerrar.Width = 20;
            cobtnCerrar.Dock = DockStyle.Right;
            cobtnCerrar.Click += new System.EventHandler(onClickCerrar);

            menu.Controls.Add(cobtnCerrar);          
            menu.Height +=  5;
            menu.Location = new Point( (this.Location.X-(menu.Width/3)), this.Location.Y - 25);
            this.Parent.Controls.Add(menu);
        }       
    }
}
