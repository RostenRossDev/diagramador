namespace TPI_Diagramador
{
    public partial class Form1 : Form
    {
        private List<DiagramImg> figurasSeleccionadas;
        private List<Point> points;

        private bool _dragging;

        public Form1()
        {
            InitializeComponent();
            figurasSeleccionadas = new List<DiagramImg>();
            points = new List<Point>();
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

            DiagramImg newPicture = new DiagramImg();
            //newPicture.BackColor = System.Drawing.Color.Teal;
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

            PictureBox pictureBox = sender as PictureBox;
            //System.Diagnostics.Debug.WriteLine(pictureBox.Name);


            if (pictureBox.Name == "pictureFlechaDerecha")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra derecha");

                newPicture.Image = Properties.Resources.flecha_derecha_negra;
            }
            else if (pictureBox.Name == "pictureFlechaIzquierda")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra izquierda");
                newPicture.Image = Properties.Resources.flecha_izquierda_negra;

            }
            else if (pictureBox.Name == "pictureFlechaArriba")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra arriba");
                newPicture.Image = Properties.Resources.flecha_arriba_negra;
            }
            else if (pictureBox.Name == "pictureFlechaAbajo")
            {
                System.Diagnostics.Debug.WriteLine("flecha negra abajo");
                newPicture.Image = Properties.Resources.flecha_abajo_negra;
            }
            System.Diagnostics.Debug.WriteLine(newPicture.Image.Tag);



            System.Diagnostics.Debug.WriteLine("no es nulo");
            this.splitContainer2.Panel2.Controls.Add(newPicture);

        }
        protected void OnMouseDown(object sender, MouseEventArgs e)
        {
            var imagenPrevia = focused as DiagramImg;

            imagenPrevia.Focus=false;
            var imagen = sender as DiagramImg;
            imagen.Focus = true;
            focused = imagen as DiagramImg;
            imagenPrevia.Refresh();

            _dragging = true;
            point = e.Location;
        }

        protected void OnMouseMove(object sender, MouseEventArgs e)
        {
            var c = sender as PictureBox;

            System.Diagnostics.Debug.WriteLine("Se mueve imagen");
            System.Diagnostics.Debug.WriteLine("x: " + point.X + ", y: " + point.Y);
            System.Diagnostics.Debug.WriteLine("cX: " + c.Left + ", cY: " + c.Top);

            if (!_dragging || null == c) return;
            c.Left += e.X - point.X;
            c.Top += e.Y - point.Y;

        }

        protected void OnMouseEnter(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Encima de la imagen");
            var pic = sender as PictureBox;

            pic.Paint += (arg1, arg2) =>
            {
                arg2.Graphics.DrawString(pic.Tag.ToString(), pic.Font, Brushes.OrangeRed, pic.ClientRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });
            };
        }

        private void Borrar(object sender, EventArgs e)
        {
            this.focused.Dispose();
            this.focused = new DiagramImg();
        }

        private void MasChico(object sender, EventArgs e)
        {
            if (this.focused.Width > 20)
            {
                System.Diagnostics.Debug.WriteLine("-5");
                this.focused.Width = this.focused.Width - 5;
                this.focused.Height = this.focused.Height - 5;
                this.Refresh();
            }
        }
        private void MasGrande(object sender, EventArgs e)
        {

            if (this.focused.Width < 200)
            {

                System.Diagnostics.Debug.WriteLine("+5");
                this.focused.Width = this.focused.Width + 5;
                this.focused.Height = this.focused.Height + 5;
                Bitmap bm = new Bitmap(this.focused.Image, focused.Width, focused.Height);
                this.focused.Image = bm.GetThumbnailImage(focused.Width, focused.Height, null, IntPtr.Zero);
                this.Refresh();
            }

        }              
    }
}