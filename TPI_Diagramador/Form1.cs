//using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Drawing.Imaging;

namespace TPI_Diagramador
{
    public partial class Form1 : Form
    {
        private List<DiagramImg> figurasSeleccionadas;
        private bool isAltPressed;
        private bool dragging;
        private int collapsedPanel;
        private bool isCollpased;

        public Form1()
        {
            InitializeComponent();

            this.splitContainer2.Panel1MinSize = 160;
            this.splitContainer2.Panel2MinSize = 889;

            //this.splitContainer1.Panel1MinSize = 10;
            //this.splitContainer1.Panel2MinSize = 900;

            figurasSeleccionadas = new List<DiagramImg>();
            isAltPressed = false;
            this.splitContainer2.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(OnMouseMove);
            dragging = false;
            collapsedPanel = 0;
        }



        private void mouseDownDrag(object sender, MouseEventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox;

            DiagramImg newPic = selectFigura(pictureBox.Name, "negro");

            this.splitContainer2.Panel2.Controls.Add(newPic);
        }

        private DiagramImg generarDiagramImg()
        {
            DiagramImg newPicture = new DiagramImg();
            newPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            newPicture.BackColor = Color.Transparent;
            newPicture.Dock = System.Windows.Forms.DockStyle.None;
            newPicture.Size = new System.Drawing.Size(116, 89);
            newPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            newPicture.TabIndex = 2;
            newPicture.TabStop = false;
            newPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(OnMouseDown);
            newPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            return newPicture;
        }

        private DiagramImg selectFigura(string name, string color)
        {

            DiagramImg newPicture = generarDiagramImg();
            newPicture.ColorFigura = color;

            if (name == "flecha_derecha")
            {
                newPicture.NombreFigura = "flecha_derecha";
                if (color=="negro")
                {
                    newPicture.Image = Properties.Resources.flecha_derecha_negra;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.flecha_derecha_morada;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.flecha_derecha_roja;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.flecha_derecha_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.flecha_derecha_amarilla;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.flecha_derecha_celeste;
                }
            }
            else if (name == "flecha_izquierda")
            {
                newPicture.NombreFigura = "flecha_izquierda";

                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.flecha_izquierda_negra;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.flecha_izquierda_morada;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.flecha_izquierda_roja;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.flecha_izquierda_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.flecha_izquierda_amarilla;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.flecha_izquierda_celeste;
                }
            }
            else if (name == "flecha_arriba")
            {
                newPicture.NombreFigura = "flecha_arriba";

                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.flecha_arriba_negra;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.flecha_arriba_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.flecha_arriba_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.flecha_arriba_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.flecha_arriba_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.flecha_arriba_celeste;
                }
            }
            else if (name == "flecha_abajo")
            {
                newPicture.NombreFigura = "flecha_abajo";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.flecha_abajo_negra;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.flecha_abajo_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.flecha_abajo_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.flecha_abajo_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.flecha_abajo_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.flecha_abajo_celeste;
                }
            }
            else if (name == "flechaD_arriba_izquierda")
            {
                newPicture.NombreFigura = "flechaD_arriba_izquierda";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_izquierda_negra;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_izquierda_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_izquierda_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_izquierda_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_izquierda_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_izquierda_celeste;
                }
            }
            else if (name == "flechaD_arriba_derecha")
            {
                newPicture.NombreFigura = "flechaD_arriba_derecha";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_derecha_negra;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_derecha_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_derecha_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_derecha_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_derecha_amarilla;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.flechaD_arriba_derecha_celeste;
                }
            }
            else if (name == "flechaD_abajo_derecha")
            {
                newPicture.NombreFigura = "flechaD_abajo_derecha";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_derecha_negra;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_derecha_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_derecha_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_derecha_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_derecha_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_derecha_celeste;
                }
            }
            else if (name == "flechaD_abajo_izquierda")
            {
                newPicture.NombreFigura = "flechaD_abajo_izquierda";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_izquierda_negra;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_izquierda_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_izquierda_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_izquierda_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_izquierda_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.flechaD_abajo_izquierda_celeste;
                }
            }
            else if (name == "linea_abajo_izquierda")
            {
                newPicture.NombreFigura = "linea_abajo_izquierda";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.lineaD_abajo_izquierda_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.lineaD_abajo_izquierda_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.lineaD_abajo_izquierda_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.lineaD_abajo_izquierda_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.lineaD_abajo_izquierda_amarilla;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.lineaD_abajo_izquierda_celeste;
                }
            }
            else if (name == "linea_arriba_izquierda")
            {
                newPicture.NombreFigura = "linea_arriba_izquierda";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.lineaD_arriba_izquierda_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.lineaD_arriba_izquierda_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.lineaD_arriba_izquierda_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.lineaD_arriba_izquierda_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.lineaD_arriba_izquierda_amarilla;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.lineaD_arriba_izquierda_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.lineaD_arriba_izquierda_naranja;
                }
            }
            else if (name == "linea_horizontal")
            {
                newPicture.NombreFigura = "linea_horizontal";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.linea_horizontal_negra;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.linea_horizontal_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.linea_horizontal_roja;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.linea_horizontal_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.linea_horizontal_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.linea_horizontal_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.linea_horizontal_naranja;
                }
            }
            else if (name == "linea_vertical")
            {
                newPicture.NombreFigura = "linea_vertical";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.linea_vertical_negra;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.linea_vertical_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.linea_vertical_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.linea_vertical_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.linea_vertical_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.linea_vertical_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.linea_vertical_naranja;
                }
            }
            else if (name == "circulo_vacio")
            {
                newPicture.NombreFigura = "circulo_vacio";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.circulo_vacio_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.circulo_vacio_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.circulo_vacio_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.circulo_vacio_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.circulo_vacio_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.circulo_vacio_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.circulo_vacio_naranja;
                }
            }
            else if (name == "circulo_relleno")
            {
                newPicture.NombreFigura = "circulo_relleno";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.circulo_relleno_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.circulo_relleno_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.circulo_relleno_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.circulo_relleno_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.circulo_relleno_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.circulo_relleno_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.circulo_relleno_naranja;
                }
            }
            else if (name == "cuadrado_vacio")
            {
                newPicture.NombreFigura = "cuadrado_vacio";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.cuadrado_vacio_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.cuadrado_vacio_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.cuadrado_vacio_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.cuadrado_vacio_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.cuadrado_vacio_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.cuadrado_vacio_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.cuadrado_vacio_naranja;
                }
            }
            else if (name == "cuadrado_relleno")
            {
                newPicture.NombreFigura = "cuadrado_relleno";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.cuadrado_relleno_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.cuadrado_relleno_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.cuadrado_relleno_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.cuadrado_relleno_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.cuadrado_relleno_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.cuadrado_relleno_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.cuadrado_relleno_naranja;
                }
            }
            else if (name == "paralelogramo_vacio")
            {
                newPicture.NombreFigura = "paralelogramo_vacio";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_vacio_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_vacio_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_vacio_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_vacio_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_vacio_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_vacio_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_vacio_naranja;
                }
            }
            else if (name == "paralelogramo_relleno")
            {
                newPicture.NombreFigura = "paralelogramo_relleno";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_relleno_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_relleno_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_relleno_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_relleno_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_relleno_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_relleno_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.paralelogramo_relleno_naranja;
                }
            }
            else if (name == "rectangulo_vacio")
            {
                newPicture.NombreFigura = "rectangulo_vacio";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_vacio_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_vacio_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_vacio_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_vacio_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_vacio_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_vacio_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_vacio_naranja;
                }
            }
            else if (name == "rectangulo_relleno")
            {
                newPicture.NombreFigura = "rectangulo_relleno";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_relleno_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_relleno_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_relleno_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_relleno_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_relleno_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_relleno_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.rectaungulo_relleno_naranja;
                }
            }
            else if (name == "rombo_vacio")
            {
                newPicture.NombreFigura = "rombo_vacio";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.rombo_vacio_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.rombo_vacio_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.rombo_vacio_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.rombo_vacio_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.rombo_vacio_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.rombo_vacio_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.rombo_vacio_naranja;
                }
            }
            else if (name == "rombo_relleno")
            {
                newPicture.NombreFigura = "rombo_relleno";
                if (color == "negro")
                {
                    newPicture.Image = Properties.Resources.rombo_relleno_negro;
                }
                else if (color == "morado")
                {
                    newPicture.Image = Properties.Resources.rombo_relleno_morado;
                }
                else if (color == "rojo")
                {
                    newPicture.Image = Properties.Resources.rombo_relleno_rojo;
                }
                else if (color == "verde")
                {
                    newPicture.Image = Properties.Resources.rombo_relleno_verde;
                }
                else if (color == "amarillo")
                {
                    newPicture.Image = Properties.Resources.rombo_relleno_amarillo;
                }
                else if (color == "celeste")
                {
                    newPicture.Image = Properties.Resources.rombo_relleno_celeste;
                }
                else if (color == "naranja")
                {
                    newPicture.Image = Properties.Resources.rombo_relleno_naranja;
                }
            }//agregar mas else if segun imagenes se agreguen
            else
            {
                newPicture.ColorFigura = "negro";
            }

            return newPicture;
        }
        protected void OnMpuseUp(MouseEventArgs e)
        {
            dragging = false;

        }
        protected void OnMouseDown(object sender, MouseEventArgs e)
        {

            DiagramImg img = sender as DiagramImg;

            KeyPress(img);
        }

        protected void OnMouseMove(object sender, MouseEventArgs e)
        {


            if (dragging && this.figurasSeleccionadas.Count > 0 && isAltPressed) {

                for (int i = 0; i < figurasSeleccionadas.Count; i++)
                {
                    Point location = figurasSeleccionadas[i].Location;
                    DiagramImg picture = figurasSeleccionadas[i];
                    int X = e.X - picture.Left;
                    int Y = e.Y - picture.Top;
                    System.Diagnostics.Debug.WriteLine("Figura location: " + X + ", " + Y);

                    MouseEventArgs evento = new MouseEventArgs(e.Button, e.Clicks, X, Y, e.Delta);
                    picture.moverFigura(evento);

                    System.Diagnostics.Debug.WriteLine("Figura numero: " + i);
                    System.Diagnostics.Debug.WriteLine("x: " + location.X + ", y: " + location.Y);
                    System.Diagnostics.Debug.WriteLine("X: " + picture.Left + ", Y: " + picture.Top);
                }
            }

        }

        protected void OnMouseEnter(object sender, MouseEventArgs e)
        {
            //var pic = sender as PictureBox;            

            foreach (var item in figurasSeleccionadas)
            {
                item.Paint += (arg1, arg2) =>
                {
                    arg2.Graphics.DrawString(item.Tag.ToString(), item.Font, Brushes.OrangeRed, item.ClientRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });
                };
            }

        }

        private void KeyPress(DiagramImg img)
        {
            if (Form.ModifierKeys == Keys.Alt)
            {
                isAltPressed = true;
                System.Diagnostics.Debug.WriteLine("alt apretado");

            }
            else
            {
                isAltPressed = false;
                System.Diagnostics.Debug.WriteLine("alt no apretado");

            }


            if (isAltPressed)
            {
                System.Diagnostics.Debug.WriteLine("alt apretado");

                if (figurasSeleccionadas.Contains(img))
                {
                    figurasSeleccionadas.Remove(img);
                    img.eliminarContorno(this.BackColor);
                    System.Diagnostics.Debug.WriteLine("removido");

                }
                else
                {
                    figurasSeleccionadas.Add(img);
                    img.dibujarContorno();
                    System.Diagnostics.Debug.WriteLine("agregado");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("alt no apretado");

            }

        }

        private void MasChico(object sender, EventArgs e)
        {

            for (int i = 0; i < figurasSeleccionadas.Count; i++)
            {
                DiagramImg picture = figurasSeleccionadas[i];

                picture.Size = new System.Drawing.Size(picture.Width - picture.PorcentajeMas, picture.Height - picture.PorcentajeMenos);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;


                this.Refresh();
            }

        }
        private void MasGrande(object sender, EventArgs e)
        {
            for (int i = 0; i < figurasSeleccionadas.Count; i++)
            {
                DiagramImg picture = figurasSeleccionadas[i];

                picture.Size = new System.Drawing.Size(picture.Width + picture.PorcentajeMas, picture.Height + picture.PorcentajeMenos);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;

                this.Refresh();
            }
        }

        private void cargarBtn_Click(object sender, EventArgs e)
        {
            string pathFile = "";
            string json = "";
            DialogResult dialogResult = this.openFileDialog1.ShowDialog();

            pathFile = this.openFileDialog1.FileName;
            if (dialogResult != DialogResult.Cancel)
            {

                using (StreamReader sr = new StreamReader(pathFile))
                {
                    json = sr.ReadToEnd();
                    sr.Close();
                }

                var diagramas = JsonSerializer.Deserialize<List<DiagramDTO>>(json);
                System.Diagnostics.Debug.WriteLine("figura tipo: " + diagramas[0].TipoFigura);

                foreach (var item in diagramas)
                {

                    DiagramImg newPic = selectFigura(item.TipoFigura, item.ColorFigura);

                    newPic.ColorFigura = item.ColorFigura;
                    newPic.Location = item.Point;
                    Color newColor = Color.FromArgb(item.R, item.G, item.B);
                    newPic.FontFam = item.FontFam;
                    newPic.ColorTexto = newColor;
                    newPic.Relleno = item.esRelleno;
                    System.Diagnostics.Debug.WriteLine("figura tipo: " + item.TipoFigura);

                    if (item.Texto != null)
                    {
                        Brush br = new SolidBrush(newColor);
                        newPic.writeImage(item.Texto, br);
                    }
                    System.Diagnostics.Debug.WriteLine("item: " + newPic.ToString());

                    this.splitContainer2.Panel2.Controls.Add(newPic);
                }
                this.splitContainer2.Panel2.Refresh();
            }
        }
        private void guardarBtn_Click(object sender, EventArgs e)
        {
            this.splitContainer2.Panel2.Controls.RemoveByKey("menu");

            string input = "";

            InputBox inputBox = new InputBox("Ingrese el nombre");
            inputBox.ShowDialog();

            input = inputBox.getTexto() + ".json";
            //Print the input provided by the user

            this.folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;

            List<DiagramDTO> diagramasDTO = new List<DiagramDTO>();

            List<DiagramImg> diagramasParaPersistir = new List<DiagramImg>();
            foreach (Control item in this.splitContainer2.Panel2.Controls)
            {

                DiagramImg diagram = (DiagramImg)item;

                DiagramDTO newDiagramDTO = new DiagramDTO();
                newDiagramDTO.ColorFigura = diagram.ColorFigura;
                newDiagramDTO.Point = diagram.Location;
                newDiagramDTO.TipoFigura = diagram.NombreFigura;
                newDiagramDTO.Texto = diagram.TextoImagen;
                newDiagramDTO.R = diagram.ColorTexto.R;
                newDiagramDTO.B = diagram.ColorTexto.B;
                newDiagramDTO.G = diagram.ColorTexto.G;

                newDiagramDTO.FontFam = diagram.FontFam;
                newDiagramDTO.FontSize = diagram.FontSize;
                newDiagramDTO.esRelleno = diagram.Relleno;

                System.Diagnostics.Debug.WriteLine("textoDiagram: " + newDiagramDTO.toString());
                diagramasDTO.Add(newDiagramDTO);
            }

            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            string json = JsonSerializer.Serialize<List<DiagramDTO>>(diagramasDTO, options);

            System.Diagnostics.Debug.WriteLine("json: " + json);


            FileInfo f = new FileInfo(@path + "\\" + input);
            FileStream fs = f.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(json);
                writer.Close();
            }

            fs.Close();
        }


        private void toJPGBtn_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(this.splitContainer2.Panel2.Width, this.splitContainer2.Panel2.Height);
                this.splitContainer2.Panel2.AutoScroll = false;
                this.splitContainer2.Panel2.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                bmp.Save(sfd.FileName, ImageFormat.Jpeg);
                this.splitContainer2.Panel2.AutoScroll = true;

                //MessageBox.Show("La imagen se ha guardado correctamente");
            }
        }



        private void MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;

        }

        private void borrar(object sender, EventArgs e)
        {
            foreach (var item in figurasSeleccionadas)
            {
                //evita que el menu queden al borrar el item lo cual proboca un erro al intenta borrar despues al menu ya que su padre
                // no existe mas, por lo tanto borramos todos los menus primero y luego la figura.
                foreach (var menu in this.splitContainer2.Panel2.Controls.Find("menu", false))
                {
                    menu.Dispose();
                }

                item.Dispose();
            }
            figurasSeleccionadas.Clear();
        }

        private void crearTexto(object sender, EventArgs e)
        {
            InputBox inBox = new InputBox("Ingrese el texto");
            inBox.ShowDialog();
            var texto = inBox.getTexto();

            if (texto.Length > 0 || texto != "")
            {
                DiagramImg textoImagen = generarDiagramImg();
                textoImagen.TextoImagen = texto;
                textoImagen.writeImage(texto, null);
                this.splitContainer2.Panel2.Controls.Add(textoImagen);
            }
        }

        private void lineas_button_Click(object sender, EventArgs e)
        {
            timer1.Start();
            this.collapsedPanel = 3;
        }
        private void flechas_button_Click(object sender, EventArgs e)
        {
            timer1.Start();
            this.collapsedPanel = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            switch (collapsedPanel)
            {
                case 1:
                    expandCollapse(this.panelDropDownFlechas, isCollpased);
                    break;
                case 2:
                    expandCollapse(this.panelDropDownFiguras, isCollpased);
                    break;
                case 3:
                    expandCollapse(this.panelDropDownLineas, isCollpased);
                    break;
                default:
                    break;
            }
        }

        private void expandCollapse(Panel panel, bool panelIsCollapsed)
        {
            if (panelIsCollapsed)
            {
                expand(panel);
            }
            else
            {
                collapse(panel);
            }
        }
        private void changeBtnText(Panel panel, string texto)
        {
            switch (panel.Name)
            {
                case "panelDropDownFlechas":
                    this.flechasBtn.Text = "Flechas " + texto;
                    break;
                case "panelDropDownFiguras":
                    this.figurasBtn.Text = "Figuras " + texto;
                    break;
                case "panelDropDownLineas":
                    this.btnLineas.Text = "Lineas " + texto;
                    break;
                default:
                    break;
            }
        }
        private void expand(Panel panel)
        {
            System.Diagnostics.Debug.WriteLine("panel: " + panel.Name);

            changeBtnText(panel, "▲");
            panel.Height += 10;
            if (panel.Size == panel.MaximumSize)
            {
                timer1.Stop();
                isCollpased = false;
            }
        }

        private void collapse(Panel panel)
        {
            changeBtnText(panel, "▼");
            panel.Height -= 10;
            if (panel.Size == panel.MinimumSize)
            {
                timer1.Stop();
                collapsedPanel = 0;
                isCollpased = true;
            }
        }

        private void figurasBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
            this.collapsedPanel = 2;
        }

       

        private void onResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.splitContainer2.Panel1MinSize = 160;
                this.splitContainer2.Panel2MinSize = 1440;
               
                this.splitContainer1.Panel1MinSize = 24;
                //this.splitContainer1.Panel2MinSize = 1600;
            }
            else
            {
                this.splitContainer2.Panel1MinSize = 160;
                this.splitContainer2.Panel2MinSize = 1440;

                this.splitContainer1.Panel1MinSize = 24;
                //this.splitContainer1.Panel2MinSize = 718;
            }
        }

        private void btnRojo_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < figurasSeleccionadas.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(figurasSeleccionadas[i].NombreFigura);
                System.Diagnostics.Debug.WriteLine(figurasSeleccionadas[i].ColorFigura);
                if (figurasSeleccionadas[i].TextoImagen != null)
                {
                    Brush brushRojo = new SolidBrush(Color.FromArgb(255, 28, 0));
                    figurasSeleccionadas[i].writeImage(figurasSeleccionadas[i].TextoImagen, brushRojo);
                }
                else
                {
                    figurasSeleccionadas[i].ColorFigura = "rojo";

                    if (figurasSeleccionadas[i].NombreFigura == "flecha_derecha")
                    {
                        System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_derecha_roja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_izquierda_roja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_arriba")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_arriba_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_abajo")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_abajo_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_izquierda_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_derecha_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_derecha_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_izquierda_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_vacio_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_relleno_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_vacio_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_relleno_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_vacio_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_relleno_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_vacio_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_relleno_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_vacio_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_relleno_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_arriba_izquierda_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_abajo_izquierda_rojo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_horizontal")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_horizontal_roja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_vertical")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_vertical_rojo;
                    }
                }

            }


        }

        private void btnNegro_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < figurasSeleccionadas.Count; i++)
            {

                if (figurasSeleccionadas[i].TextoImagen != null)
                {
                    Brush brushNegro = new SolidBrush(Color.Black);
                    figurasSeleccionadas[i].ColorTexto = Color.Black;
                    figurasSeleccionadas[i].writeImage(figurasSeleccionadas[i].TextoImagen, brushNegro);
                }
                else
                {
                    figurasSeleccionadas[i].ColorFigura = "negro";
                    if (figurasSeleccionadas[i].NombreFigura == "flecha_derecha")
                    {
                        System.Diagnostics.Debug.WriteLine("flecha negra derecha");
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_derecha_negra;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_izquierda_negra;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_arriba")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_arriba_negra;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_abajo")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_abajo_negra;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_izquierda_negra;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_derecha_negra;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_derecha_negra;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_izquierda_negra;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_vacio_negro;

                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_relleno_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_vacio_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_relleno_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_vacio_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_relleno_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_vacio_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_relleno_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_vacio_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_vacio_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_arriba_izquierda_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_abajo_izquierda_negro;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_horizontal")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_horizontal_negra;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_vertical")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_vertical_negra;
                    }
                }
            }
        }

        private void btnCeleste_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < figurasSeleccionadas.Count; i++)
            {
                if (figurasSeleccionadas[i].TextoImagen != null)
                {
                    Brush brushCeleste = new SolidBrush(Color.FromArgb(0, 178, 250));
                    figurasSeleccionadas[i].ColorTexto = Color.FromArgb(0, 178, 250);

                    figurasSeleccionadas[i].writeImage(figurasSeleccionadas[i].TextoImagen, brushCeleste);
                }
                else
                {
                    figurasSeleccionadas[i].ColorFigura = "celeste";

                    if (figurasSeleccionadas[i].NombreFigura == "flecha_derecha")
                    {
                        System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_derecha_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_izquierda_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_arriba")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_arriba_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_abajo")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_abajo_celeste;

                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_izquierda_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_derecha_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_derecha_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_izquierda_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_vacio_celeste;

                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_relleno_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_vacio_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_relleno_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_vacio_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_relleno_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_vacio_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_relleno_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_vacio_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_relleno_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_arriba_izquierda_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_abajo_izquierda_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_horizontal")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_horizontal_celeste;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_vertical")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_vertical_celeste;
                    }
                }
            }
        }

        private void btnVerde_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < figurasSeleccionadas.Count; i++)
            {

                if (figurasSeleccionadas[i].TextoImagen != null)
                {
                    Brush brushVerde = new SolidBrush(Color.FromArgb(0, 242, 0));
                    figurasSeleccionadas[i].ColorTexto = Color.FromArgb(0, 242, 0);
                    figurasSeleccionadas[i].writeImage(figurasSeleccionadas[i].TextoImagen, brushVerde);
                }
                else
                {
                    figurasSeleccionadas[i].ColorFigura = "verde";

                    if (figurasSeleccionadas[i].NombreFigura == "flecha_derecha")
                    {
                        System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_derecha_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_izquierda_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_arriba")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_arriba_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_abajo")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_abajo_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_izquierda_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_derecha_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_derecha_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_izquierda_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_vacio_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_relleno_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_vacio_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_relleno_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_vacio_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_relleno_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_vacio_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_relleno_verde;

                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_vacio_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_relleno_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_arriba_izquierda_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_abajo_izquierda_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_horizontal")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_horizontal_verde;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_vertical")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_vertical_verde;
                    }
                }
            }
        }

        private void btnMorado_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < figurasSeleccionadas.Count; i++)
            {
                if (figurasSeleccionadas[i].TextoImagen != null)
                {
                    Brush brushMorado = new SolidBrush(Color.FromArgb(120, 0, 255));
                    figurasSeleccionadas[i].ColorTexto = Color.FromArgb(120, 0, 255);
                    figurasSeleccionadas[i].writeImage(figurasSeleccionadas[i].TextoImagen, brushMorado);
                }
                else
                {

                    figurasSeleccionadas[i].ColorFigura = "morado";

                    if (figurasSeleccionadas[i].NombreFigura == "flecha_derecha")
                    {
                        System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_derecha_morada;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_izquierda_morada;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_arriba")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_arriba_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_abajo")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_abajo_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_izquierda_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_derecha_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_derecha_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_izquierda_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_vacio_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_relleno_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_vacio_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_relleno_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_vacio_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_relleno_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_vacio_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_relleno_morado;

                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_vacio_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_relleno_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_arriba_izquierda_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_abajo_izquierda_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_horizontal")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_horizontal_morado;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_vertical")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_vertical_morado;
                    }
                }
            }
        }

        private void btnNaranja_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < figurasSeleccionadas.Count; i++)
            {
                if (figurasSeleccionadas[i].TextoImagen != null)
                {
                    Brush brushNaranja = new SolidBrush(Color.FromArgb(255, 146, 0));
                    figurasSeleccionadas[i].ColorTexto = Color.FromArgb(255, 146, 0);
                    figurasSeleccionadas[i].writeImage(figurasSeleccionadas[i].TextoImagen, brushNaranja);
                }
                else
                {
                    figurasSeleccionadas[i].ColorFigura = "naranja";

                    if (figurasSeleccionadas[i].NombreFigura == "flecha_derecha")
                    {
                        System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_derecha_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_izquierda_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_arriba")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_arriba_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_abajo")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_abajo_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_izquierda_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_derecha_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_derecha_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_izquierda_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_vacio_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_relleno_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_vacio_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_relleno_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_vacio_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_relleno_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_vacio_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_relleno_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_vacio_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_relleno_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_arriba_izquierda_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_abajo_izquierda_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_horizontal")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_horizontal_naranja;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_vertical")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_vertical_naranja;
                    }
                }
            }
        }

        private void btnAmarillo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < figurasSeleccionadas.Count; i++)
            {
                if (figurasSeleccionadas[i].TextoImagen != null)
                {
                    Brush brushNAmarillo = new SolidBrush(Color.FromArgb(254, 254, 0));
                    figurasSeleccionadas[i].ColorTexto = Color.FromArgb(254, 254, 0);
                    figurasSeleccionadas[i].writeImage(figurasSeleccionadas[i].TextoImagen, brushNAmarillo);
                }
                else
                {
                    figurasSeleccionadas[i].ColorFigura = "amarillo";

                    if (figurasSeleccionadas[i].NombreFigura == "flecha_derecha")
                    {
                        System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_derecha_amarilla;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_izquierda_amarilla;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_arriba")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_arriba_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flecha_abajo")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flecha_abajo_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_izquierda_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_arriba_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_arriba_derecha_amarilla;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_derecha")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_derecha_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "flechaD_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.flechaD_abajo_izquierda_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_vacio_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "cuadrado_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.cuadrado_relleno_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_vacio_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "circulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.circulo_relleno_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_vacio_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "paralelogramo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.paralelogramo_relleno_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_vacio_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rombo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rombo_relleno_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_vacio")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_vacio_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "rectangulo_relleno")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.rectaungulo_relleno_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_arriba_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_arriba_izquierda_amarilla;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_abajo_izquierda")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.lineaD_abajo_izquierda_amarilla;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_horizontal")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_horizontal_amarillo;
                    }
                    else if (figurasSeleccionadas[i].NombreFigura == "linea_vertical")
                    {
                        figurasSeleccionadas[i].Image = Properties.Resources.linea_vertical_amarillo;
                    }
                }
            }
        }

        private void rellenarToolStripMenuItem_Click(object sender, EventArgs e) 
        {

            this.figurasSeleccionadas.ForEach(item =>
            {
                System.Diagnostics.Debug.WriteLine("figura: "+item.NombreFigura+", relleno: "+item.Relleno+", color: "+item.ColorFigura);

                if (item.Relleno)
                {
                    item.Relleno = false;
                    
                    if (item.NombreFigura == "cuadrado_relleno")
                    {
                        item.NombreFigura = "cuadrado_vacio";
                        if (item.ColorFigura == "negro") 
                        {
                            item.Image = Properties.Resources.cuadrado_vacio_negro;
                        }
                        else if (item.ColorFigura == "verde")
                        {
                            item.Image = Properties.Resources.cuadrado_vacio_verde;
                        }
                        else if (item.ColorFigura == "rojo")
                        {
                            item.Image = Properties.Resources.cuadrado_vacio_rojo;
                        }
                        else if (item.ColorFigura == "amarillo")
                        {
                            item.Image = Properties.Resources.cuadrado_vacio_amarillo;
                        }
                        else if (item.ColorFigura == "morado")
                        {
                            item.Image = Properties.Resources.cuadrado_vacio_morado;
                        }
                        else if (item.ColorFigura == "celeste")
                        {
                            item.Image = Properties.Resources.cuadrado_vacio_celeste;
                        }
                        else if (item.ColorFigura == "naranja")
                        {
                            item.Image = Properties.Resources.cuadrado_vacio_naranja;
                        }
                    }
                    
                    else if (item.NombreFigura == "circulo_relleno")
                    {
                        item.NombreFigura = "circulo_vacio";
                        if (item.ColorFigura == "negro")
                        {
                            item.Image = Properties.Resources.circulo_vacio_negro;
                        }
                        else if (item.ColorFigura == "verde")
                        {
                            item.Image = Properties.Resources.circulo_vacio_verde;
                        }
                        else if (item.ColorFigura == "rojo")
                        {
                            item.Image = Properties.Resources.circulo_vacio_rojo;
                        }
                        else if (item.ColorFigura == "amarillo")
                        {
                            item.Image = Properties.Resources.circulo_vacio_amarillo;
                        }
                        else if (item.ColorFigura == "morado")
                        {
                            item.Image = Properties.Resources.circulo_vacio_morado;
                        }
                        else if (item.ColorFigura == "celeste")
                        {
                            item.Image = Properties.Resources.circulo_vacio_celeste;
                        }
                        else if (item.ColorFigura == "naranja")
                        {
                            item.Image = Properties.Resources.circulo_vacio_naranja;
                        }
                    }
                    
                    else if (item.NombreFigura == "paralelogramo_relleno")
                    {
                        item.NombreFigura = "paralelogramo_vacio";
                        if (item.ColorFigura == "negro")
                        {
                            item.Image = Properties.Resources.paralelogramo_vacio_negro;
                        }
                        else if (item.ColorFigura == "verde")
                        {
                            item.Image = Properties.Resources.paralelogramo_vacio_verde;
                        }
                        else if (item.ColorFigura == "rojo")
                        {
                            item.Image = Properties.Resources.paralelogramo_vacio_rojo;
                        }
                        else if (item.ColorFigura == "amarillo")
                        {
                            item.Image = Properties.Resources.paralelogramo_vacio_amarillo;
                        }
                        else if (item.ColorFigura == "morado")
                        {
                            item.Image = Properties.Resources.paralelogramo_vacio_morado;
                        }
                        else if (item.ColorFigura == "celeste")
                        {
                            item.Image = Properties.Resources.paralelogramo_vacio_celeste;
                        }
                        else if (item.ColorFigura == "naranja")
                        {
                            item.Image = Properties.Resources.paralelogramo_vacio_naranja;
                        }
                    }
                   
                    else if (item.NombreFigura == "rombo_relleno")
                    {
                        item.NombreFigura = "rombo_vacio";
                        if (item.ColorFigura == "negro")
                        {
                            item.Image = Properties.Resources.rombo_vacio_negro;
                        }
                        else if (item.ColorFigura == "verde")
                        {
                            item.Image = Properties.Resources.rombo_vacio_verde;
                        }
                        else if (item.ColorFigura == "rojo")
                        {
                            item.Image = Properties.Resources.rombo_vacio_rojo;
                        }
                        else if (item.ColorFigura == "amarillo")
                        {
                            item.Image = Properties.Resources.rombo_vacio_amarillo;
                        }
                        else if (item.ColorFigura == "morado")
                        {
                            item.Image = Properties.Resources.rombo_vacio_morado;
                        }
                        else if (item.ColorFigura == "celeste")
                        {
                            item.Image = Properties.Resources.rombo_vacio_celeste;
                        }
                        else if (item.ColorFigura == "naranja")
                        {
                            item.Image = Properties.Resources.rombo_vacio_naranja;
                        }
                    }
                   
                    else if (item.NombreFigura == "rectangulo_relleno")
                    {
                        item.NombreFigura = "rectangulo_vacio";
                        if (item.ColorFigura == "negro")
                        {
                            item.Image = Properties.Resources.rectaungulo_vacio_negro;
                        }
                        else if (item.ColorFigura == "verde")
                        {
                            item.Image = Properties.Resources.rectaungulo_vacio_verde;
                        }
                        else if (item.ColorFigura == "rojo")
                        {
                            item.Image = Properties.Resources.rectaungulo_vacio_rojo;
                        }
                        else if (item.ColorFigura == "amarillo")
                        {
                            item.Image = Properties.Resources.rectaungulo_vacio_amarillo;
                        }
                        else if (item.ColorFigura == "morado")
                        {
                            item.Image = Properties.Resources.rectaungulo_vacio_morado;
                        }
                        else if (item.ColorFigura == "celeste")
                        {
                            item.Image = Properties.Resources.rectaungulo_vacio_celeste;
                        }
                        else if (item.ColorFigura == "naranja")
                        {
                            item.Image = Properties.Resources.rectaungulo_vacio_naranja;
                        }
                    }
                }
                else
                {
                    item.Relleno = true;
                    if (item.NombreFigura == "cuadrado_vacio")
                    {
                        item.NombreFigura = "cuadrado_relleno";
                        if (item.ColorFigura == "negro")
                        {
                            item.Image = Properties.Resources.cuadrado_relleno_negro;
                        }
                        else if (item.ColorFigura == "verde")
                        {
                            item.Image = Properties.Resources.cuadrado_relleno_verde;
                        }
                        else if (item.ColorFigura == "rojo")
                        {
                            item.Image = Properties.Resources.cuadrado_relleno_rojo;
                        }
                        else if (item.ColorFigura == "amarillo")
                        {
                            item.Image = Properties.Resources.cuadrado_relleno_amarillo;
                        }
                        else if (item.ColorFigura == "morado")
                        {
                            item.Image = Properties.Resources.cuadrado_relleno_morado;
                        }
                        else if (item.ColorFigura == "celeste")
                        {
                            item.Image = Properties.Resources.cuadrado_relleno_celeste;
                        }
                        else if (item.ColorFigura == "naranja")
                        {
                            item.Image = Properties.Resources.cuadrado_relleno_naranja;
                        }
                    }
                    else if (item.NombreFigura == "circulo_vacio")
                    {
                        item.NombreFigura = "circulo_relleno";
                        if (item.ColorFigura == "negro")
                        {
                            item.Image = Properties.Resources.circulo_relleno_negro;
                        }
                        else if (item.ColorFigura == "verde")
                        {
                            item.Image = Properties.Resources.circulo_relleno_verde;
                        }
                        else if (item.ColorFigura == "rojo")
                        {
                            item.Image = Properties.Resources.circulo_relleno_rojo;
                        }
                        else if (item.ColorFigura == "amarillo")
                        {
                            item.Image = Properties.Resources.circulo_relleno_amarillo;
                        }
                        else if (item.ColorFigura == "morado")
                        {
                            item.Image = Properties.Resources.circulo_relleno_morado;
                        }
                        else if (item.ColorFigura == "celeste")
                        {
                            item.Image = Properties.Resources.circulo_relleno_celeste;
                        }
                        else if (item.ColorFigura == "naranja")
                        {
                            item.Image = Properties.Resources.circulo_relleno_naranja;
                        }
                    }
                    else if (item.NombreFigura == "paralelogramo_vacio")
                    {
                        item.NombreFigura = "paralelogramo_relleno";
                        if (item.ColorFigura == "negro")
                        {
                            item.Image = Properties.Resources.paralelogramo_relleno_negro;
                        }
                        else if (item.ColorFigura == "verde")
                        {
                            item.Image = Properties.Resources.paralelogramo_relleno_verde;
                        }
                        else if (item.ColorFigura == "rojo")
                        {
                            item.Image = Properties.Resources.paralelogramo_relleno_rojo;
                        }
                        else if (item.ColorFigura == "amarillo")
                        {
                            item.Image = Properties.Resources.paralelogramo_relleno_amarillo;
                        }
                        else if (item.ColorFigura == "morado")
                        {
                            item.Image = Properties.Resources.paralelogramo_relleno_morado;
                        }
                        else if (item.ColorFigura == "celeste")
                        {
                            item.Image = Properties.Resources.paralelogramo_relleno_celeste;
                        }
                        else if (item.ColorFigura == "naranja")
                        {
                            item.Image = Properties.Resources.paralelogramo_relleno_naranja;
                        }
                    }
                    else if (item.NombreFigura == "rombo_vacio")
                    {
                        item.NombreFigura = "rombo_relleno";
                        if (item.ColorFigura == "negro")
                        {
                            item.Image = Properties.Resources.rombo_relleno_negro;
                        }
                        else if (item.ColorFigura == "verde")
                        {
                            item.Image = Properties.Resources.rombo_relleno_verde;
                        }
                        else if (item.ColorFigura == "rojo")
                        {
                            item.Image = Properties.Resources.rombo_relleno_rojo;
                        }
                        else if (item.ColorFigura == "amarillo")
                        {
                            item.Image = Properties.Resources.rombo_relleno_amarillo;
                        }
                        else if (item.ColorFigura == "morado")
                        {
                            item.Image = Properties.Resources.rombo_relleno_morado;
                        }
                        else if (item.ColorFigura == "celeste")
                        {
                            item.Image = Properties.Resources.rombo_relleno_celeste;
                        }
                        else if (item.ColorFigura == "naranja")
                        {
                            item.Image = Properties.Resources.rombo_relleno_naranja;
                        }
                    }
                    else if (item.NombreFigura == "rectangulo_vacio")
                    {
                        item.NombreFigura = "rectangulo_relleno";
                        if (item.ColorFigura == "negro")
                        {
                            item.Image = Properties.Resources.rectaungulo_relleno_negro;
                        }
                        else if (item.ColorFigura == "verde")
                        {
                            item.Image = Properties.Resources.rectaungulo_relleno_verde;
                        }
                        else if (item.ColorFigura == "rojo")
                        {
                            item.Image = Properties.Resources.rectaungulo_relleno_rojo;
                        }
                        else if (item.ColorFigura == "amarillo")
                        {
                            item.Image = Properties.Resources.rectaungulo_relleno_amarillo;
                        }
                        else if (item.ColorFigura == "morado")
                        {
                            item.Image = Properties.Resources.rectaungulo_relleno_morado;
                        }
                        else if (item.ColorFigura == "celeste")
                        {
                            item.Image = Properties.Resources.rectaungulo_relleno_celeste;
                        }
                        else if (item.ColorFigura == "naranja")
                        {
                            item.Image = Properties.Resources.rectaungulo_relleno_naranja;
                        }
                    }
                }
            });
        }

        private void nuevoDiagrama(object sender, EventArgs e)
        {
            this.splitContainer2.Panel2.Controls.Clear();
        }
    }
}