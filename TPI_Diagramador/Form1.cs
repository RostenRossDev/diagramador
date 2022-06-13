//using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace TPI_Diagramador
{
    public partial class Form1 : Form
    {
        private List<DiagramImg> figurasSeleccionadas;
        //private List<Point> points;
        private bool isAltPressed;
        private bool dragging;
        private int collapsedPanel;
        private bool isCollpased;
        public Form1()
        {
            InitializeComponent();
            figurasSeleccionadas = new List<DiagramImg>();
            //points = new List<Point>();
            isAltPressed = false;
            this.splitContainer2.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(OnMouseMove);
            dragging = false;
            collapsedPanel = 0;
        }

        private void mouseDownDrag(object sender, MouseEventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox;

            DiagramImg newPic = selectFigura(pictureBox.Name);

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

        private DiagramImg selectFigura(string name)
        {

            DiagramImg newPicture = generarDiagramImg();
            //newPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            //newPicture.BackColor = Color.Transparent;
            //newPicture.Dock = System.Windows.Forms.DockStyle.None;
            //newPicture.Size = new System.Drawing.Size(116, 89);
            //newPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            //newPicture.TabIndex = 2;
            //newPicture.TabStop = false;
            //newPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(OnMouseDown);
            //newPicture.Cursor = System.Windows.Forms.Cursors.Hand;
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
            }
            else if (name == "circulo_negro")
            {
                System.Diagnostics.Debug.WriteLine("circulo_negro");
                newPicture.Image = Properties.Resources.circulo_vacio_negro;
                newPicture.NombreFigura = "circulo_negro";
                newPicture.ColorFigura = "negro";
            }
            else if (name == "cuadrado_negro")
            {
                System.Diagnostics.Debug.WriteLine("cuadrado_negro");
                newPicture.Image = Properties.Resources.cuadrado_vacio_negro;
                newPicture.NombreFigura = "cuadrado_negro";
                newPicture.ColorFigura = "negro";
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
            //base.OnMouseDown(e);
        }

        protected void OnMouseMove(object sender, MouseEventArgs e)
        {

            
            if (dragging && this.figurasSeleccionadas.Count>0 && isAltPressed) {

                for (int i = 0; i < figurasSeleccionadas.Count; i++)
                {
                    Point location = figurasSeleccionadas[i].Location;
                    DiagramImg picture = figurasSeleccionadas[i];
                    int X = e.X - picture.Left;
                    int Y= e.Y - picture.Top;
                    System.Diagnostics.Debug.WriteLine("Figura location: " + X+", "+Y);

                    //if (X < 0 || Y < 0)
                    //{
                    //    System.Diagnostics.Debug.WriteLine("Figura location: " + X+", "+Y);

                    //    return;
                    //}
                    MouseEventArgs evento = new MouseEventArgs(e.Button, e.Clicks, X, Y, e.Delta);
                    picture.moverFigura(evento);
                    //picture.Left = X;
                    //picture.Top = Y;
                    
                    //picture.Refresh();
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
            using (StreamReader sr = new StreamReader(pathFile))
            {
                json = sr.ReadToEnd();
                sr.Close();
            }
            
            //var diagramas= JsonConvert.DeserializeObject<List<DiagramDTO>>(json);
            var diagramas = JsonSerializer.Deserialize< List<DiagramDTO>>(json);

            foreach (var item in diagramas)
            {
                DiagramImg newPic = selectFigura(item.TipoFigura);
                newPic.ColorFigura = item.ColorFigura;
                newPic.Location = item.Point;

                if (item.Texto != null)
                {
                    newPic.writeImage(item.Texto);
                }               
                                            
                this.splitContainer2.Panel2.Controls.Add(newPic);
            }
            this.splitContainer2.Panel2.Refresh();
        }
        private void guardarBtn_Click(object sender, EventArgs e)
        {
            string input = "";

            InputBox inputBox = new InputBox("Ingrese el nombre");
            inputBox.ShowDialog();

            input=inputBox.getTexto()+".json";
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
                newDiagramDTO.Texto= diagram.TextoImagen;
                System.Diagnostics.Debug.WriteLine("textoDTO: " + newDiagramDTO.Texto);
                System.Diagnostics.Debug.WriteLine("textoDiagram: " + diagram.TextoImagen);
                diagramasDTO.Add(newDiagramDTO);
            }

            //var json = JsonConvert.SerializeObject(diagramasDTO,
            //    new JsonSerializerSettings()
            //    {
            //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //    }
            //);
            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            string json = JsonSerializer.Serialize<List<DiagramDTO>>(diagramasDTO, options);

            System.Diagnostics.Debug.WriteLine("json: " + json);


            FileInfo f = new FileInfo(@path+"\\"+input);            
            FileStream fs = f.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);            
            using (StreamWriter writer = new StreamWriter(fs))
            {                
                writer.WriteLine(json);
                writer.Close();
            }

            fs.Close();
        }

        private void achicarBtn_Click(object sender, EventArgs e)
        {

        }

        private void borrarBtn_Click(object sender, EventArgs e)
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
                item.Dispose();
            }
            figurasSeleccionadas.Clear();
        }

        private void crearTexto(object sender, MouseEventArgs e)
        {
            InputBox inBox = new InputBox("Ingrese el texto");
            inBox.ShowDialog();
            var texto = inBox.getTexto();

            if (texto.Length>0 || texto!= "")
            {
                DiagramImg textoImagen = generarDiagramImg();
                textoImagen.TextoImagen = texto;
                textoImagen.writeImage(texto);
                this.splitContainer2.Panel2.Controls.Add(textoImagen);
            }
            
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
                    this.flechasBtn.Text = "Flechas "+texto;
                    break;
                case "panelDropDownFiguras":
                    this.figurasBtn.Text ="Figuras "+ texto;
                    break;
                default:
                    break;
            }
        }
        private void expand(Panel panel)
        {       
            
            changeBtnText(panel, "▲");
            panel.Height += 10;
            if (panel.Size==panel.MaximumSize)
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
    }
}