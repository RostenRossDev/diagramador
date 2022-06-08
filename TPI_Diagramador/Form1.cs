using Newtonsoft.Json;

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

        private void mouseDownDrag(object sender, MouseEventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox;
            System.Diagnostics.Debug.WriteLine("pb: "+pictureBox.Name);

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
            DiagramImg img = sender as DiagramImg;

            KeyPress(img);
            base.OnMouseDown(e);
        }

        protected void OnMouseMove(object sender, MouseEventArgs e)
        {

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

        private void KeyPress(DiagramImg img)
        {
            if (Form.ModifierKeys == Keys.Alt)
            {
                isAltPressed = true;
            }else
            {
                isAltPressed = false;
            }


            if (isAltPressed)
            {
                if (figurasSeleccionadas.Contains(img)) 
                {
                    figurasSeleccionadas.Remove(img);
                    img.eliminarContorno(this.BackColor);
                }
                else
                {
                    figurasSeleccionadas.Add(img);
                    img.dibujarContorno();
                }                                   
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

        private void cargarBtn_Click(object sender, EventArgs e)
        {
            string pathFile = "";
            string json = "";
            this.openFileDialog1.ShowDialog();
            pathFile = this.openFileDialog1.FileName;
            System.Diagnostics.Debug.WriteLine("pathFile: " + pathFile);
            using (StreamReader sr = new StreamReader(pathFile))
            {
                json = sr.ReadToEnd();
                sr.Close();
            }
            
            var diagramas= JsonConvert.DeserializeObject<List<DiagramDTO>>(json);

            foreach (var item in diagramas)
            {
                DiagramImg newPic = selectFigura(item.TipoFigura);
                newPic.ColorFigura = item.ColorFigura;
                newPic.Location = item.Point;

                this.splitContainer2.Panel2.Controls.Add(newPic);
            }
            this.splitContainer2.Panel2.Refresh();
        }
        private void guardarBtn_Click(object sender, EventArgs e)
        {
            string input = "";

            InputBox inputBox = new InputBox();
            inputBox.ShowDialog();

            input=inputBox.getName()+".json";
            //Print the input provided by the user
            System.Diagnostics.Debug.WriteLine("input: " + input);

            this.folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            System.Diagnostics.Debug.WriteLine("path: " + path);

            List<DiagramDTO> diagramasDTO = new List<DiagramDTO>();

            List<DiagramImg> diagramasParaPersistir = new List<DiagramImg>();
            foreach (Control item in this.splitContainer2.Panel2.Controls)
            {

                DiagramImg diagram = item as DiagramImg;
                System.Diagnostics.Debug.WriteLine("NombreFigura: " + diagram.NombreFigura);

                DiagramDTO newDiagramDTO = new DiagramDTO();
                newDiagramDTO.ColorFigura = diagram.ColorFigura;
                newDiagramDTO.Point = diagram.Location;
                newDiagramDTO.TipoFigura = diagram.NombreFigura;
                System.Diagnostics.Debug.WriteLine("newDiagramDTO: " + newDiagramDTO.TipoFigura);
                System.Diagnostics.Debug.WriteLine("newDiagramDTO: " + newDiagramDTO.Point);
                System.Diagnostics.Debug.WriteLine("newDiagramDTO: " + newDiagramDTO.ColorFigura);

                diagramasDTO.Add(newDiagramDTO);
            }

            var json = JsonConvert.SerializeObject(diagramasDTO,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );
            System.Diagnostics.Debug.WriteLine("file: " + path+"\\"+ input);
            FileInfo f = new FileInfo(@path+"\\"+input);
            FileStream fs = f.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);

            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(json);
                writer.Close();
            }
            System.Diagnostics.Debug.WriteLine(f.FullName);

            fs.Close();
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
    }
}