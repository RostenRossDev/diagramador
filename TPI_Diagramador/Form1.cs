namespace TPI_Diagramador
{
    public partial class Form1 : Form
    {
        private List<DiagramImg> figurasSeleccionadas;
        private List<Point> points;
        private bool isAltPressed;
        private bool _dragging;

        public Form1()
        {
            InitializeComponent();
            figurasSeleccionadas = new List<DiagramImg>();
            points = new List<Point>();
            isAltPressed = false;
        }




        private void guardarBtn_Click(object sender, EventArgs e)
        {

        }

        private void agrandarBtn_Click(object sender, EventArgs e)
        {

        }

        private void achicarBtn_Click(object sender, EventArgs e)
        {

        }

        private void borrarBtn_Click(object sender, EventArgs e)
        {

        }

        private void textoBtn_Click(object sender, EventArgs e)
        {

        }

        private void cargarBtn_Click(object sender, EventArgs e)
        {

        }

        private void toJPGBtn_Click(object sender, EventArgs e)
        {

        }

        private void rojoBtn_Click(object sender, EventArgs e)
        {

        }

        private void verdeBtn_Click(object sender, EventArgs e)
        {

        }

        private void moradoBtn_Click(object sender, EventArgs e)
        {

        }

        private void azulBtn_Click(object sender, EventArgs e)
        {

        }

        private void mouseDownDrag(object sender, MouseEventArgs e)
        {

            //DiagramImg newPicture = new DiagramImg();
            ////newPicture.BackColor = System.Drawing.Color.Teal;
            //newPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            //newPicture.BackColor = Color.Transparent;
            //newPicture.Dock = System.Windows.Forms.DockStyle.None;
            //newPicture.Size = new System.Drawing.Size(116, 89);
            //newPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            //newPicture.TabIndex = 2;
            //newPicture.TabStop = false;
            //newPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(OnMouseDown);
            //newPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(OnMouseMove);
            //newPicture.Cursor = System.Windows.Forms.Cursors.Hand;

            PictureBox pictureBox = sender as PictureBox;
            System.Diagnostics.Debug.WriteLine("pb: "+pictureBox.Name);


            //if (pictureBox.Name == "pictureFlechaDerecha")
            //{
            //    System.Diagnostics.Debug.WriteLine("flecha negra derecha");

            //    newPicture.Image = Properties.Resources.flecha_derecha_negra;
            //}
            //else if (pictureBox.Name == "pictureFlechaIzquierda")
            //{
            //    System.Diagnostics.Debug.WriteLine("flecha negra izquierda");
            //    newPicture.Image = Properties.Resources.flecha_izquierda_negra;

            //}
            //else if (pictureBox.Name == "pictureFlechaArriba")
            //{
            //    System.Diagnostics.Debug.WriteLine("flecha negra arriba");
            //    newPicture.Image = Properties.Resources.flecha_arriba_negra;
            //}
            //else if (pictureBox.Name == "pictureFlechaAbajo")
            //{
            //    System.Diagnostics.Debug.WriteLine("flecha negra abajo");
            //    newPicture.Image = Properties.Resources.flecha_abajo_negra;
            //}
            //System.Diagnostics.Debug.WriteLine(newPicture.Image.Tag);


            DiagramImg newPic = selectFigura(pictureBox.Name);

            System.Diagnostics.Debug.WriteLine("name: "+newPic.NombreFigura+" "+newPic.ColorFigura);
            this.splitContainer2.Panel2.Controls.Add(newPic);

        }

        private DiagramImg selectFigura(string name)
        {
            System.Diagnostics.Debug.WriteLine("name fun: "+ name);

            DiagramImg newPicture = new DiagramImg();
            newPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            newPicture.BackColor = Color.Transparent;
            newPicture.Dock = System.Windows.Forms.DockStyle.None;
            newPicture.Size = new System.Drawing.Size(116, 89);
            newPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            newPicture.TabIndex = 2;
            newPicture.TabStop = false;
            newPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(OnMouseDown);
            newPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(OnMouseMove);
            newPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            if (name == "flecha_derecha")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                newPicture.Image = Properties.Resources.flecha_derecha_negra;
                newPicture.NombreFigura = "flecha_derecha";
                newPicture.ColorFigura = "negro";
            }
            else if (name == "flecha_izquierda")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra izquierda");
                newPicture.Image = Properties.Resources.flecha_izquierda_negra;
                newPicture.NombreFigura = "flecha_izquierda";
                newPicture.ColorFigura = "negro";
            }
            else if (name == "flecha_arriba")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra arriba");
                newPicture.Image = Properties.Resources.flecha_arriba_negra;
                newPicture.NombreFigura = "flecha_arriba";
                newPicture.ColorFigura = "negro";
            }
            else if (name == "flecha_abajo")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra abajo");
                newPicture.Image = Properties.Resources.flecha_abajo_negra;
                newPicture.NombreFigura = "flecha_abajo";
                newPicture.ColorFigura = "negro";
            }
            else if (name == "flechaD_arriba_izquierda")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra abajo");
                newPicture.Image = Properties.Resources.flechaD_arriba_izquierda_negra;
                newPicture.NombreFigura = "flecha_abajo";
                newPicture.ColorFigura = "negro";
            }
            else if (name == "flechaD_arriba_derecha")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra abajo");
                newPicture.Image = Properties.Resources.flechaD_arriba_derecha_negra;
                newPicture.NombreFigura = "flecha_abajo";
                newPicture.ColorFigura = "negro";
            }
            else if (name == "flechaD_abajo_derecha")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra abajo");
                newPicture.Image = Properties.Resources.flechaD_abajo_derecha_negra;
                newPicture.NombreFigura = "flecha_abajo";
                newPicture.ColorFigura = "negro";
            }
            else if (name == "flechaD_abajo_izquierda")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra abajo");
                newPicture.Image = Properties.Resources.flechaD_abajo_izquierda_negra;
                newPicture.NombreFigura = "flecha_abajo";
                newPicture.ColorFigura = "negro";
            }//agregar mas else if segun imagenes se agreguen
            System.Diagnostics.Debug.WriteLine("asd");

            return newPicture;
        }
        protected void OnMouseDown(object sender, MouseEventArgs e)
        {
            var imagen = sender as DiagramImg;
            if (figurasSeleccionadas.Contains(imagen))
            {
                figurasSeleccionadas.Remove(imagen);
                imagen.Focus = false;
            }
            else
            {
                if (isAltPressed)
                {
                    figurasSeleccionadas.Add(imagen);
                    points.Add(e.Location);
                    imagen.Focus = true;
                }
            }

            imagen.Refresh();
            //var imagenPrevia = focused as DiagramImg;

            //imagenPrevia.Focus=false;
            //imagen.Focus = true;
            //focused = imagen as DiagramImg;
            //imagenPrevia.Refresh();

            _dragging = true;
            //point = e.Location;
        }

        protected void OnMouseMove(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Se mueve imagen");

            var c = sender as DiagramImg;

            if (!_dragging || null == c) return;

            for (int i = 0; i < figurasSeleccionadas.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("x: " + points[i].X + ", y: " + points[i].Y);
                System.Diagnostics.Debug.WriteLine("cX: " + figurasSeleccionadas[i].Left + ", cY: " + figurasSeleccionadas[i].Top);

                figurasSeleccionadas[i].Left = e.X - points[i].X;
                figurasSeleccionadas[i].Top = e.Y - points[i].Y;
            }            

        }

        protected void OnMouseEnter(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Encima de la imagen");
            //var pic = sender as PictureBox;            

            foreach (var item in figurasSeleccionadas)
            {
                item.Paint += (arg1, arg2) =>
                {
                    arg2.Graphics.DrawString(item.Tag.ToString(), item.Font, Brushes.OrangeRed, item.ClientRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });
                };
            }
            
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("KeyPress: { "+ Convert.ToInt32(e.KeyChar)+", "+Convert.ToInt32(Keys.Alt)+" }");

            if (Convert.ToInt32(e.KeyChar) == Convert.ToInt32(Keys.Alt))
            {
                isAltPressed = true;
                System.Diagnostics.Debug.WriteLine("Alt es presionado");
            }
        }
        private void keyDown(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("KeyUp: { " + Convert.ToInt32(e.Alt) + ", " + Convert.ToInt32(Keys.Alt) + " }");

            if (Convert.ToInt32(e.Alt) == Convert.ToInt32(Keys.Alt))
            {
                isAltPressed = false;
                System.Diagnostics.Debug.WriteLine("Alt es presionado");
            }
        }
        private void altKeyUp(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("KeyUp: { " + Convert.ToInt32(e.Alt) + ", " + Convert.ToInt32(Keys.Alt) + " }");

            if (Convert.ToInt32(e.Alt) == Convert.ToInt32(Keys.Alt))
            {
                isAltPressed = false;
                System.Diagnostics.Debug.WriteLine("Alt es soltado");
            }
        }
        private void Borrar(object sender, EventArgs e)
        {
           
        }

        private void MasChico(object sender, EventArgs e)
        {
            
        }
        private void MasGrande(object sender, EventArgs e)
        {
                        

        }
    }
}