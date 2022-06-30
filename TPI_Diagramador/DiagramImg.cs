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
        private string fontFam;
        private float fontSize=15;
        private Panel menu;
        private bool isButonsFocus;
        private Color colorTexto;
        private Boolean relleno = false;
        //para agrandar ya chicar elementos
        private int porcentajeMas = 10;
        private int porcentajeMenos = 5;

        public Boolean Relleno { get { return this.relleno; } set { this.relleno = value; } }
        public float FontSize { get { return this.fontSize; } set { this.fontSize = value; } }
        public string FontFam { get { return this.fontFam; } set { this.fontFam = value; } }
        public Color ColorTexto { get { return this.colorTexto; } set { this.colorTexto = value; } }
        public string TextoImagen { get { return this.textoImagen; } set { this.textoImagen = value; } }
        public string NombreFigura { get { return this.nombreFigura; } set { this.nombreFigura = value; } }
        public string ColorFigura { get { return this.colorFigura; } set { this.colorFigura = value; } }
        public bool Focus { get { return this.focus; } set { this.focus = value; } }
        public bool ColorRecuadro { get; set; } // para modificar el color del recuadro cuando esta seleccionado

        public int PorcentajeMas { get { return this.porcentajeMas; }}
        public int PorcentajeMenos { get { return this.porcentajeMenos; } }
        public DiagramImg()
        {
            focus = false;
            colorRecuadro = Color.Coral;
            menu= new Panel();
            menu.Name = "menu";
            colorTexto = Color.Black;
            fontFam = "Arial";
        }

        public override string ToString()
        {
            return "figura: " + nombreFigura + ", point: " + this.Location + ", color texto: " + ColorTexto + ", color figura: " + ColorFigura + ", texto: " + textoImagen;
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
            Font fontFake = new Font(this.fontFam, this.fontSize);
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphicsFake = Graphics.FromImage(fakeImage);
            SizeF size = graphicsFake.MeasureString(t, fontFake);
            System.Diagnostics.Debug.WriteLine("width: " + (size.Width)+", heigth: "+ size.Height);

            //crear iamgen
            
            Image image = new Bitmap((int)size.Width/*-(int(this.Size.Width*0.07)*/, (int)size.Height/*- (int)(this.Size.Width * 0.07)*/);
            var font = new Font(this.fontFam, (int) this.fontSize, FontStyle.Regular);
            
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
            
            if (this.TextoImagen != null)
            {
                this.colorTexto = Color.FromArgb(255, 28, 0);
                Brush br = new SolidBrush(colorTexto);
                writeImage(this.textoImagen, br);
            }
            else
            {
                this.ColorFigura = "rojo";

                if (this.NombreFigura == "flecha_derecha")
                {
                    System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                    this.Image = Properties.Resources.flecha_derecha_roja;
                }
                else if (this.NombreFigura == "flecha_izquierda")
                {
                    this.Image = Properties.Resources.flecha_izquierda_roja;
                }
                else if (this.NombreFigura == "flecha_arriba")
                {
                    this.Image = Properties.Resources.flecha_arriba_rojo;
                }
                else if (this.NombreFigura == "flecha_abajo")
                {
                    this.Image = Properties.Resources.flecha_abajo_rojo;
                }
                else if (this.NombreFigura == "flechaD_arriba_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_arriba_izquierda_rojo;
                }
                else if (this.NombreFigura == "flechaD_arriba_derecha")
                {
                    this.Image = Properties.Resources.flechaD_arriba_derecha_rojo;
                }
                else if (this.NombreFigura == "flechaD_abajo_derecha")
                {
                    this.Image = Properties.Resources.flechaD_abajo_derecha_rojo;
                }
                else if (this.NombreFigura == "flechaD_abajo_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_abajo_izquierda_rojo;
                }
                else if (this.NombreFigura == "cuadrado_vacio")
                {
                    this.Image = Properties.Resources.cuadrado_vacio_rojo;
                }
                else if (this.NombreFigura == "cuadrado_relleno")
                {
                    this.Image = Properties.Resources.cuadrado_relleno_rojo;
                }
                else if (this.NombreFigura == "circulo_vacio")
                {
                    this.Image = Properties.Resources.circulo_vacio_rojo;
                }
                else if (this.NombreFigura == "circulo_relleno")
                {
                    this.Image = Properties.Resources.circulo_relleno_rojo;
                }
                else if (this.NombreFigura == "paralelogramo_vacio")
                {
                    this.Image = Properties.Resources.paralelogramo_vacio_rojo;
                }
                else if (this.NombreFigura == "paralelogramo_relleno")
                {
                    this.Image = Properties.Resources.paralelogramo_relleno_rojo;
                }
                else if (this.NombreFigura == "rombo_vacio")
                {
                    this.Image = Properties.Resources.rombo_vacio_rojo;
                }
                else if (this.NombreFigura == "rombo_relleno")
                {
                    this.Image = Properties.Resources.rombo_relleno_rojo;
                }
                else if (this.NombreFigura == "rectangulo_vacio")
                {
                    this.Image = Properties.Resources.rectaungulo_vacio_rojo;
                }
                else if (this.NombreFigura == "rectangulo_relleno")
                {
                    this.Image = Properties.Resources.rectaungulo_relleno_rojo;
                }
                else if (this.NombreFigura == "linea_arriba_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_arriba_izquierda_rojo;
                }
                else if (this.NombreFigura == "linea_abajo_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_abajo_izquierda_rojo;
                }
                else if (this.NombreFigura == "linea_horizontal")
                {
                    this.Image = Properties.Resources.linea_horizontal_roja;
                }
                else if (this.NombreFigura == "linea_vertical")
                {
                    this.Image = Properties.Resources.linea_vertical_rojo;
                }
            }
        }

        private void onClickColorVerde(object sender, System.EventArgs e)
        {
           
            if (this.TextoImagen != null)
            {
                this.colorTexto = Color.FromArgb(0, 242, 0);
                Brush br = new SolidBrush(colorTexto);
                writeImage(this.textoImagen, br);
            }
            else
            {
                this.ColorFigura = "verde";

                if (this.NombreFigura == "flecha_derecha")
                {
                    System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                    this.Image = Properties.Resources.flecha_derecha_verde;
                }
                else if (this.NombreFigura == "flecha_izquierda")
                {
                    this.Image = Properties.Resources.flecha_izquierda_verde;
                }
                else if (this.NombreFigura == "flecha_arriba")
                {
                    this.Image = Properties.Resources.flecha_arriba_verde;
                }
                else if (this.NombreFigura == "flecha_abajo")
                {
                    this.Image = Properties.Resources.flecha_abajo_verde;
                }
                else if (this.NombreFigura == "flechaD_arriba_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_arriba_izquierda_verde;
                }
                else if (this.NombreFigura == "flechaD_arriba_derecha")
                {
                    this.Image = Properties.Resources.flechaD_arriba_derecha_verde;
                }
                else if (this.NombreFigura == "flechaD_abajo_derecha")
                {
                    this.Image = Properties.Resources.flechaD_abajo_derecha_verde;
                }
                else if (this.NombreFigura == "flechaD_abajo_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_abajo_izquierda_verde;
                }
                else if (this.NombreFigura == "cuadrado_vacio")
                {
                    this.Image = Properties.Resources.cuadrado_vacio_verde;
                }
                else if (this.NombreFigura == "cuadrado_relleno")
                {
                    this.Image = Properties.Resources.cuadrado_relleno_verde;
                }
                else if (this.NombreFigura == "circulo_vacio")
                {
                    this.Image = Properties.Resources.circulo_vacio_verde;
                }
                else if (this.NombreFigura == "circulo_relleno")
                {
                    this.Image = Properties.Resources.circulo_relleno_verde;
                }
                else if (this.NombreFigura == "paralelogramo_vacio")
                {
                    this.Image = Properties.Resources.paralelogramo_vacio_verde;
                }
                else if (this.NombreFigura == "paralelogramo_relleno")
                {
                    this.Image = Properties.Resources.paralelogramo_relleno_verde;
                }
                else if (this.NombreFigura == "rombo_vacio")
                {
                    this.Image = Properties.Resources.rombo_vacio_verde;
                }
                else if (this.NombreFigura == "rombo_relleno")
                {
                    this.Image = Properties.Resources.rombo_relleno_verde;

                }
                else if (this.NombreFigura == "rectangulo_vacio")
                {
                    this.Image = Properties.Resources.rectaungulo_vacio_verde;
                }
                else if (this.NombreFigura == "rectangulo_relleno")
                {
                    this.Image = Properties.Resources.rectaungulo_relleno_verde;
                }
                else if (this.NombreFigura == "linea_arriba_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_arriba_izquierda_verde;
                }
                else if (this.NombreFigura == "linea_abajo_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_abajo_izquierda_verde;
                }
                else if (this.NombreFigura == "linea_horizontal")
                {
                    this.Image = Properties.Resources.linea_horizontal_verde;
                }
                else if (this.NombreFigura == "linea_vertical")
                {
                    this.Image = Properties.Resources.linea_vertical_verde;
                }
            }
        }
        private void onClickColorNaranja(object sender, System.EventArgs e)
        {
            
            if (this.TextoImagen != null)
            {
                this.colorTexto = Color.FromArgb(255, 146, 0);
                Brush br = new SolidBrush(colorTexto);
                writeImage(this.textoImagen, br);
            }
            else
            {
                this.ColorFigura = "naranja";

                if (this.NombreFigura == "flecha_derecha")
                {
                    System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                    this.Image = Properties.Resources.flecha_derecha_naranja;
                }
                else if (this.NombreFigura == "flecha_izquierda")
                {
                    this.Image = Properties.Resources.flecha_izquierda_naranja;
                }
                else if (this.NombreFigura == "flecha_arriba")
                {
                    this.Image = Properties.Resources.flecha_arriba_naranja;
                }
                else if (this.NombreFigura == "flecha_abajo")
                {
                    this.Image = Properties.Resources.flecha_abajo_naranja;
                }
                else if (this.NombreFigura == "flechaD_arriba_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_arriba_izquierda_naranja;
                }
                else if (this.NombreFigura == "flechaD_arriba_derecha")
                {
                    this.Image = Properties.Resources.flechaD_arriba_derecha_naranja;
                }
                else if (this.NombreFigura == "flechaD_abajo_derecha")
                {
                    this.Image = Properties.Resources.flechaD_abajo_derecha_naranja;
                }
                else if (this.NombreFigura == "flechaD_abajo_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_abajo_izquierda_naranja;
                }
                else if (this.NombreFigura == "cuadrado_vacio")
                {
                    this.Image = Properties.Resources.cuadrado_vacio_naranja;
                }
                else if (this.NombreFigura == "cuadrado_relleno")
                {
                    this.Image = Properties.Resources.cuadrado_relleno_naranja;
                }
                else if (this.NombreFigura == "circulo_vacio")
                {
                    this.Image = Properties.Resources.circulo_vacio_naranja;
                }
                else if (this.NombreFigura == "circulo_relleno")
                {
                    this.Image = Properties.Resources.circulo_relleno_naranja;
                }
                else if (this.NombreFigura == "paralelogramo_vacio")
                {
                    this.Image = Properties.Resources.paralelogramo_vacio_naranja;
                }
                else if (this.NombreFigura == "paralelogramo_relleno")
                {
                    this.Image = Properties.Resources.paralelogramo_relleno_naranja;
                }
                else if (this.NombreFigura == "rombo_vacio")
                {
                    this.Image = Properties.Resources.rombo_vacio_naranja;
                }
                else if (this.NombreFigura == "rombo_relleno")
                {
                    this.Image = Properties.Resources.rombo_relleno_naranja;
                }
                else if (this.NombreFigura == "rectangulo_vacio")
                {
                    this.Image = Properties.Resources.rectaungulo_vacio_naranja;
                }
                else if (this.NombreFigura == "rectangulo_relleno")
                {
                    this.Image = Properties.Resources.rectaungulo_relleno_naranja;
                }
                else if (this.NombreFigura == "linea_arriba_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_arriba_izquierda_naranja;
                }
                else if (this.NombreFigura == "linea_abajo_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_abajo_izquierda_naranja;
                }
                else if (this.NombreFigura == "linea_horizontal")
                {
                    this.Image = Properties.Resources.linea_horizontal_naranja;
                }
                else if (this.NombreFigura == "linea_vertical")
                {
                    this.Image = Properties.Resources.linea_vertical_naranja;
                }
            }
        }
        private void onClickColorCeleste(object sender, System.EventArgs e)
        {
            
            if (this.TextoImagen != null)
            {
                this.colorTexto = Color.FromArgb(0, 178, 250);
                Brush br = new SolidBrush(colorTexto);
                writeImage(this.textoImagen, br);
            }
            else
            {
                this.ColorFigura = "celeste";

                if (this.NombreFigura == "flecha_derecha")
                {
                    System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                    this.Image = Properties.Resources.flecha_derecha_celeste;
                }
                else if (this.NombreFigura == "flecha_izquierda")
                {
                    this.Image = Properties.Resources.flecha_izquierda_celeste;
                }
                else if (this.NombreFigura == "flecha_arriba")
                {
                    this.Image = Properties.Resources.flecha_arriba_celeste;
                }
                else if (this.NombreFigura == "flecha_abajo")
                {
                    this.Image = Properties.Resources.flecha_abajo_celeste;

                }
                else if (this.NombreFigura == "flechaD_arriba_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_arriba_izquierda_celeste;
                }
                else if (this.NombreFigura == "flechaD_arriba_derecha")
                {
                    this.Image = Properties.Resources.flechaD_arriba_derecha_celeste;
                }
                else if (this.NombreFigura == "flechaD_abajo_derecha")
                {
                    this.Image = Properties.Resources.flechaD_abajo_derecha_celeste;
                }
                else if (this.NombreFigura == "flechaD_abajo_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_abajo_izquierda_celeste;
                }
                else if (this.NombreFigura == "cuadrado_vacio")
                {
                    this.Image = Properties.Resources.cuadrado_vacio_celeste;

                }
                else if (this.NombreFigura == "cuadrado_relleno")
                {
                    this.Image = Properties.Resources.cuadrado_relleno_celeste;
                }
                else if (this.NombreFigura == "circulo_vacio")
                {
                    this.Image = Properties.Resources.circulo_vacio_celeste;
                }
                else if (this.NombreFigura == "circulo_relleno")
                {
                    this.Image = Properties.Resources.circulo_relleno_celeste;
                }
                else if (this.NombreFigura == "paralelogramo_vacio")
                {
                    this.Image = Properties.Resources.paralelogramo_vacio_celeste;
                }
                else if (this.NombreFigura == "paralelogramo_relleno")
                {
                    this.Image = Properties.Resources.paralelogramo_relleno_celeste;
                }
                else if (this.NombreFigura == "rombo_vacio")
                {
                    this.Image = Properties.Resources.rombo_vacio_celeste;
                }
                else if (this.NombreFigura == "rombo_relleno")
                {
                    this.Image = Properties.Resources.rombo_relleno_celeste;
                }
                else if (this.NombreFigura == "rectangulo_vacio")
                {
                    this.Image = Properties.Resources.rombo_vacio_celeste;
                }
                else if (this.NombreFigura == "rectangulo_relleno")
                {
                    this.Image = Properties.Resources.rombo_relleno_celeste;
                }
                else if (this.NombreFigura == "linea_arriba_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_arriba_izquierda_celeste;
                }
                else if (this.NombreFigura == "linea_abajo_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_abajo_izquierda_celeste;
                }
                else if (this.NombreFigura == "linea_horizontal")
                {
                    this.Image = Properties.Resources.linea_horizontal_celeste;
                }
                else if (this.NombreFigura == "linea_vertical")
                {
                    this.Image = Properties.Resources.linea_vertical_celeste;
                }
            }
        }
        private void onClickColorAmarillo(object sender, System.EventArgs e)
        {
           

            if (this.TextoImagen != null)
            {
                this.colorTexto = Color.FromArgb(254, 254, 0);
                Brush br = new SolidBrush(colorTexto);
                writeImage(this.textoImagen, br);
            }
            else
            {
                this.ColorFigura = "amarillo";

                if (this.NombreFigura == "flecha_derecha")
                {
                    System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                    this.Image = Properties.Resources.flecha_derecha_amarilla;
                }
                else if (this.NombreFigura == "flecha_izquierda")
                {
                    this.Image = Properties.Resources.flecha_izquierda_amarilla;
                }
                else if (this.NombreFigura == "flecha_arriba")
                {
                    this.Image = Properties.Resources.flecha_arriba_amarillo;
                }
                else if (this.NombreFigura == "flecha_abajo")
                {
                    this.Image = Properties.Resources.flecha_abajo_amarillo;
                }
                else if (this.NombreFigura == "flechaD_arriba_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_arriba_izquierda_amarillo;
                }
                else if (this.NombreFigura == "flechaD_arriba_derecha")
                {
                    this.Image = Properties.Resources.flechaD_arriba_derecha_amarilla;
                }
                else if (this.NombreFigura == "flechaD_abajo_derecha")
                {
                    this.Image = Properties.Resources.flechaD_abajo_derecha_amarillo;
                }
                else if (this.NombreFigura == "flechaD_abajo_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_abajo_izquierda_amarillo;
                }
                else if (this.NombreFigura == "cuadrado_vacio")
                {
                    this.Image = Properties.Resources.cuadrado_vacio_amarillo;
                }
                else if (this.NombreFigura == "cuadrado_relleno")
                {
                    this.Image = Properties.Resources.cuadrado_relleno_amarillo;
                }
                else if (this.NombreFigura == "circulo_vacio")
                {
                    this.Image = Properties.Resources.circulo_vacio_amarillo;
                }
                else if (this.NombreFigura == "circulo_relleno")
                {
                    this.Image = Properties.Resources.circulo_relleno_amarillo;
                }
                else if (this.NombreFigura == "paralelogramo_vacio")
                {
                    this.Image = Properties.Resources.paralelogramo_vacio_amarillo;
                }
                else if (this.NombreFigura == "paralelogramo_relleno")
                {
                    this.Image = Properties.Resources.paralelogramo_relleno_amarillo;
                }
                else if (this.NombreFigura == "rombo_vacio")
                {
                    this.Image = Properties.Resources.rombo_vacio_amarillo;
                }
                else if (this.NombreFigura == "rombo_relleno")
                {
                    this.Image = Properties.Resources.rombo_relleno_amarillo;
                }
                else if (this.NombreFigura == "rectangulo_vacio")
                {
                    this.Image = Properties.Resources.rectaungulo_vacio_amarillo;
                }
                else if (this.NombreFigura == "rectangulo_relleno")
                {
                    this.Image = Properties.Resources.rectaungulo_relleno_amarillo;
                }
                else if (this.NombreFigura == "linea_arriba_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_arriba_izquierda_amarilla;
                }
                else if (this.NombreFigura == "linea_abajo_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_abajo_izquierda_amarilla;
                }
                else if (this.NombreFigura == "linea_horizontal")
                {
                    this.Image = Properties.Resources.linea_horizontal_amarillo;
                }
                else if (this.NombreFigura == "linea_vertical")
                {
                    this.Image = Properties.Resources.linea_vertical_amarillo;
                }
            }
        }
        private void onClickColorMorado(object sender, System.EventArgs e)
        {
            

            if (this.TextoImagen != null)
            {
                this.colorTexto = Color.FromArgb(120, 0, 255);
                Brush br = new SolidBrush(colorTexto);
                writeImage(this.textoImagen, br);
            }
            else
            {
                this.ColorFigura = "morado";

                if (this.NombreFigura == "flecha_derecha")
                {
                    System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                    this.Image = Properties.Resources.flecha_derecha_morada;
                }
                else if (this.NombreFigura == "flecha_izquierda")
                {
                    this.Image = Properties.Resources.flecha_izquierda_morada;
                }
                else if (this.NombreFigura == "flecha_arriba")
                {
                    this.Image = Properties.Resources.flecha_arriba_morado;
                }
                else if (this.NombreFigura == "flecha_abajo")
                {
                    this.Image = Properties.Resources.flecha_abajo_morado;
                }
                else if (this.NombreFigura == "flechaD_arriba_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_arriba_izquierda_morado;
                }
                else if (this.NombreFigura == "flechaD_arriba_derecha")
                {
                    this.Image = Properties.Resources.flechaD_arriba_derecha_morado;
                }
                else if (this.NombreFigura == "flechaD_abajo_derecha")
                {
                    this.Image = Properties.Resources.flechaD_abajo_derecha_morado;
                }
                else if (this.NombreFigura == "flechaD_abajo_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_abajo_izquierda_morado;
                }
                else if (this.NombreFigura == "cuadrado_vacio")
                {
                    this.Image = Properties.Resources.cuadrado_vacio_morado;
                }
                else if (this.NombreFigura == "cuadrado_relleno")
                {
                    this.Image = Properties.Resources.cuadrado_relleno_morado;
                }
                else if (this.NombreFigura == "circulo_vacio")
                {
                    this.Image = Properties.Resources.circulo_vacio_morado;
                }
                else if (this.NombreFigura == "circulo_relleno")
                {
                    this.Image = Properties.Resources.circulo_relleno_morado;
                }
                else if (this.NombreFigura == "paralelogramo_vacio")
                {
                    this.Image = Properties.Resources.paralelogramo_vacio_morado;
                }
                else if (this.NombreFigura == "paralelogramo_relleno")
                {
                    this.Image = Properties.Resources.paralelogramo_relleno_morado;
                }
                else if (this.NombreFigura == "rombo_vacio")
                {
                    this.Image = Properties.Resources.rombo_vacio_morado;
                }
                else if (this.NombreFigura == "rombo_relleno")
                {
                    this.Image = Properties.Resources.rombo_relleno_morado;

                }
                else if (this.NombreFigura == "rectangulo_vacio")
                {
                    this.Image = Properties.Resources.rectaungulo_vacio_morado;
                }
                else if (this.NombreFigura == "rectangulo_relleno")
                {
                    this.Image = Properties.Resources.rectaungulo_relleno_morado;
                }
                else if (this.NombreFigura == "linea_arriba_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_arriba_izquierda_morado;
                }
                else if (this.NombreFigura == "linea_abajo_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_abajo_izquierda_morado;
                }
                else if (this.NombreFigura == "linea_horizontal")
                {
                    this.Image = Properties.Resources.linea_horizontal_morado;
                }
                else if (this.NombreFigura == "linea_vertical")
                {
                    this.Image = Properties.Resources.linea_vertical_morado;
                }
            }
        }
        private void onClickColorNegro(object sender, System.EventArgs e)
        {
            
            if (this.TextoImagen != null)
            {
                this.colorTexto = Color.Black;
                Brush br = new SolidBrush(colorTexto);
                writeImage(this.textoImagen, br);
            }
            else
            {
                this.ColorFigura = "negro";

                if (this.NombreFigura == "flecha_derecha")
                {
                    System.Diagnostics.Debug.WriteLine("flecha negra derecha");
                    this.Image = Properties.Resources.flecha_derecha_negra;
                }
                else if (this.NombreFigura == "flecha_izquierda")
                {
                    this.Image = Properties.Resources.flecha_izquierda_negra;
                }
                else if (this.NombreFigura == "flecha_arriba")
                {
                    this.Image = Properties.Resources.flecha_arriba_negra;
                }
                else if (this.NombreFigura == "flecha_abajo")
                {
                    this.Image = Properties.Resources.flecha_abajo_negra;
                }
                else if (this.NombreFigura == "flechaD_arriba_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_arriba_izquierda_negra;
                }
                else if (this.NombreFigura == "flechaD_arriba_derecha")
                {
                    this.Image = Properties.Resources.flechaD_arriba_derecha_negra;
                }
                else if (this.NombreFigura == "flechaD_abajo_derecha")
                {
                    this.Image = Properties.Resources.flechaD_abajo_derecha_negra;
                }
                else if (this.NombreFigura == "flechaD_abajo_izquierda")
                {
                    this.Image = Properties.Resources.flechaD_abajo_izquierda_negra;
                }
                else if (this.NombreFigura == "cuadrado_vacio")
                {
                    this.Image = Properties.Resources.cuadrado_vacio_negro;

                }
                else if (this.NombreFigura == "cuadrado_relleno")
                {
                    this.Image = Properties.Resources.cuadrado_relleno_negro;
                }
                else if (this.NombreFigura == "circulo_vacio")
                {
                    this.Image = Properties.Resources.circulo_vacio_negro;
                }
                else if (this.NombreFigura == "circulo_relleno")
                {
                    this.Image = Properties.Resources.circulo_relleno_negro;
                }
                else if (this.NombreFigura == "paralelogramo_vacio")
                {
                    this.Image = Properties.Resources.paralelogramo_vacio_negro;
                }
                else if (this.NombreFigura == "paralelogramo_relleno")
                {
                    this.Image = Properties.Resources.paralelogramo_relleno_negro;
                }
                else if (this.NombreFigura == "rombo_vacio")
                {
                    this.Image = Properties.Resources.rombo_vacio_negro;
                }
                else if (this.NombreFigura == "rombo_relleno")
                {
                    this.Image = Properties.Resources.rombo_relleno_negro;
                }
                else if (this.NombreFigura == "rectangulo_vacio")
                {
                    this.Image = Properties.Resources.rectaungulo_vacio_negro;
                }
                else if (this.NombreFigura == "rectangulo_relleno")
                {
                    this.Image = Properties.Resources.rectaungulo_vacio_negro;
                }
                else if (this.NombreFigura == "linea_arriba_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_arriba_izquierda_negro;
                }
                else if (this.NombreFigura == "linea_abajo_izquierda")
                {
                    this.Image = Properties.Resources.lineaD_abajo_izquierda_negro;
                }
                else if (this.NombreFigura == "linea_horizontal")
                {
                    this.Image = Properties.Resources.linea_horizontal_negra;
                }
                else if (this.NombreFigura == "linea_vertical")
                {
                    this.Image = Properties.Resources.linea_vertical_negra;
                }
            }
        }

        private void comboBoxSelectedChange(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            this.fontFam =cmb.Items[cmb.SelectedIndex] as string;
            Brush br = new SolidBrush(colorTexto);
            this.writeImage(this.textoImagen, br);
        }
        private void editarTexto(object sender, System.EventArgs e)
        {
            InputBox inbox = new InputBox("Escriba el nuevo texto");
            inbox.ShowDialog();
            this.textoImagen = inbox.getTexto();

            if (this.textoImagen.Length > 0 || this.textoImagen != "")
            {
                Brush br = new SolidBrush(colorTexto);
                this.writeImage(this.textoImagen, br);
            }
        }

        public void crearMenu()
        {
            this.menu = new menuFigura();
            menu.BackColor = Color.Transparent;            
            menu.Name = "menu";
            menu.AutoSize = true;
            //menu.BackColor = Color.LawnGreen;
            menu.MouseEnter += new System.EventHandler(onMouseHoverButonvoid);
            menu.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);
            menu.Padding = new Padding(5,5,5,0);
            FontAwesome.Sharp.IconButton botonAgrandar = new FontAwesome.Sharp.IconButton();
            FontAwesome.Sharp.IconButton botonAchicar = new FontAwesome.Sharp.IconButton();
            botonAgrandar.IconChar = FontAwesome.Sharp.IconChar.Plus;
            botonAchicar.IconChar = FontAwesome.Sharp.IconChar.Minus;
            botonAchicar.IconSize = 15;
            botonAgrandar.IconSize = 15;

            if (this.textoImagen != null)
            {
                botonAgrandar.Dock = DockStyle.Right;
                botonAgrandar.Click += new System.EventHandler(onClickAgrandarFontSize);

                botonAchicar.Dock = DockStyle.Right;
                botonAchicar.Click += new System.EventHandler(onClickAchicarFontSize);

                FontAwesome.Sharp.IconButton btnEditar = new FontAwesome.Sharp.IconButton();
                btnEditar.IconChar = FontAwesome.Sharp.IconChar.Edit;
                btnEditar.BackColor = Color.SkyBlue;
                btnEditar.IconSize = 20;
                btnEditar.Click += new System.EventHandler(editarTexto);
                btnEditar.Height = 20;
                btnEditar.Width = 20;
                btnEditar.Dock = DockStyle.Right;

                ComboBox comboBoxFonts = new ComboBox();
                comboBoxFonts.Dock = DockStyle.Right;
                comboBoxFonts.Width = 200;
                comboBoxFonts.Height = 20;
                foreach (var font in FontFamily.Families)
                {
                    comboBoxFonts.Items.Add(font.Name);
                    System.Diagnostics.Debug.WriteLine(font);

                }
                int index = comboBoxFonts.FindString(this.fontFam);
                comboBoxFonts.SelectedIndex = index;
                comboBoxFonts.SelectedIndexChanged += new System.EventHandler(comboBoxSelectedChange);

                menu.Width += 200;
                menu.Controls.Add(btnEditar);
                menu.Controls.Add(comboBoxFonts);
            }
            else
            {                
                botonAgrandar.Dock = DockStyle.Right;
                botonAgrandar.Click += new System.EventHandler(agrandarImg);
                //botonAgrandar.MouseLeave += new System.EventHandler(onMouseLeaveButonvoid);

                botonAchicar.Dock = DockStyle.Right;
                botonAchicar.Click += new System.EventHandler(achicarImg);
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

            FontAwesome.Sharp.IconButton cobtnCerrar = new FontAwesome.Sharp.IconButton();
            cobtnCerrar.IconChar = FontAwesome.Sharp.IconChar.Times;
            cobtnCerrar.IconSize = 15;
            cobtnCerrar.Height = 20;
            cobtnCerrar.Width = 20;
            cobtnCerrar.Dock = DockStyle.Right;
            cobtnCerrar.Click += new System.EventHandler(onClickCerrar);

            menu.Controls.Add(cobtnCerrar);          
            menu.Height +=  5;
            menu.Location = new Point( (this.Location.X-(menu.Width/3)), this.Location.Y - 25);
            this.Parent.Controls.Add(menu);
            menu.BringToFront();
        }
        
        public void agrandarImg(object sender, System.EventArgs e)
        {

            this.Size = new Size(this.Size.Width + porcentajeMas, this.Size.Height + porcentajeMenos);
            this.SizeMode = PictureBoxSizeMode.StretchImage;

        }
        public void achicarImg(object sender, System.EventArgs e)
        {

            this.Size = new Size(this.Size.Width - porcentajeMas, this.Size.Height - porcentajeMenos);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }


}
