namespace TPI_Diagramador
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.azulBtn = new System.Windows.Forms.Button();
            this.moradoBtn = new System.Windows.Forms.Button();
            this.verdeBtn = new System.Windows.Forms.Button();
            this.rojoBtn = new System.Windows.Forms.Button();
            this.toJPGBtn = new System.Windows.Forms.Button();
            this.borrarBtn = new System.Windows.Forms.Button();
            this.textoBtn = new System.Windows.Forms.Button();
            this.agrandarBtn = new System.Windows.Forms.Button();
            this.achicarBtn = new System.Windows.Forms.Button();
            this.abrirBtn = new System.Windows.Forms.Button();
            this.guardarBtn = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDropDownFiguras = new System.Windows.Forms.Panel();
            this.figurasBtn = new System.Windows.Forms.Button();
            this.circulo_negro = new System.Windows.Forms.PictureBox();
            this.cuadrado_negro = new System.Windows.Forms.PictureBox();
            this.panelDropDownFlechas = new System.Windows.Forms.Panel();
            this.flechaD_arriba_derecha = new System.Windows.Forms.PictureBox();
            this.flechaD_abajo_izquierda = new System.Windows.Forms.PictureBox();
            this.flechaD_abajo_derecha = new System.Windows.Forms.PictureBox();
            this.flechasBtn = new System.Windows.Forms.Button();
            this.flechaD_arriba_izquierda = new System.Windows.Forms.PictureBox();
            this.flecha_izquierda = new System.Windows.Forms.PictureBox();
            this.flecha_abajo = new System.Windows.Forms.PictureBox();
            this.flecha_derecha = new System.Windows.Forms.PictureBox();
            this.flecha_arriba = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelDropDownFiguras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circulo_negro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadrado_negro)).BeginInit();
            this.panelDropDownFlechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flechaD_arriba_derecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flechaD_abajo_izquierda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flechaD_abajo_derecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flechaD_arriba_izquierda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flecha_izquierda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flecha_abajo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flecha_derecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flecha_arriba)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Coral;
            this.splitContainer1.Panel1.Controls.Add(this.azulBtn);
            this.splitContainer1.Panel1.Controls.Add(this.moradoBtn);
            this.splitContainer1.Panel1.Controls.Add(this.verdeBtn);
            this.splitContainer1.Panel1.Controls.Add(this.rojoBtn);
            this.splitContainer1.Panel1.Controls.Add(this.toJPGBtn);
            this.splitContainer1.Panel1.Controls.Add(this.borrarBtn);
            this.splitContainer1.Panel1.Controls.Add(this.textoBtn);
            this.splitContainer1.Panel1.Controls.Add(this.agrandarBtn);
            this.splitContainer1.Panel1.Controls.Add(this.achicarBtn);
            this.splitContainer1.Panel1.Controls.Add(this.abrirBtn);
            this.splitContainer1.Panel1.Controls.Add(this.guardarBtn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 40;
            this.splitContainer1.Size = new System.Drawing.Size(921, 450);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.TabIndex = 0;
            // 
            // azulBtn
            // 
            this.azulBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.azulBtn.Location = new System.Drawing.Point(750, 0);
            this.azulBtn.Name = "azulBtn";
            this.azulBtn.Size = new System.Drawing.Size(75, 53);
            this.azulBtn.TabIndex = 10;
            this.azulBtn.Text = "Azul";
            this.azulBtn.UseVisualStyleBackColor = true;
            this.azulBtn.Click += new System.EventHandler(this.azulBtn_Click);
            // 
            // moradoBtn
            // 
            this.moradoBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.moradoBtn.Location = new System.Drawing.Point(675, 0);
            this.moradoBtn.Name = "moradoBtn";
            this.moradoBtn.Size = new System.Drawing.Size(75, 53);
            this.moradoBtn.TabIndex = 9;
            this.moradoBtn.Text = "morado";
            this.moradoBtn.UseVisualStyleBackColor = true;
            this.moradoBtn.Click += new System.EventHandler(this.moradoBtn_Click);
            // 
            // verdeBtn
            // 
            this.verdeBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.verdeBtn.Location = new System.Drawing.Point(600, 0);
            this.verdeBtn.Name = "verdeBtn";
            this.verdeBtn.Size = new System.Drawing.Size(75, 53);
            this.verdeBtn.TabIndex = 8;
            this.verdeBtn.Text = "verde";
            this.verdeBtn.UseVisualStyleBackColor = true;
            this.verdeBtn.Click += new System.EventHandler(this.verdeBtn_Click);
            // 
            // rojoBtn
            // 
            this.rojoBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.rojoBtn.Location = new System.Drawing.Point(525, 0);
            this.rojoBtn.Name = "rojoBtn";
            this.rojoBtn.Size = new System.Drawing.Size(75, 53);
            this.rojoBtn.TabIndex = 7;
            this.rojoBtn.Text = "Rojo";
            this.rojoBtn.UseVisualStyleBackColor = true;
            this.rojoBtn.Click += new System.EventHandler(this.rojoBtn_Click);
            // 
            // toJPGBtn
            // 
            this.toJPGBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.toJPGBtn.Location = new System.Drawing.Point(450, 0);
            this.toJPGBtn.Name = "toJPGBtn";
            this.toJPGBtn.Size = new System.Drawing.Size(75, 53);
            this.toJPGBtn.TabIndex = 6;
            this.toJPGBtn.Text = "ToJpg";
            this.toJPGBtn.UseVisualStyleBackColor = true;
            this.toJPGBtn.Click += new System.EventHandler(this.toJPGBtn_Click);
            // 
            // borrarBtn
            // 
            this.borrarBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.borrarBtn.Location = new System.Drawing.Point(375, 0);
            this.borrarBtn.Name = "borrarBtn";
            this.borrarBtn.Size = new System.Drawing.Size(75, 53);
            this.borrarBtn.TabIndex = 5;
            this.borrarBtn.Text = "Borrar";
            this.borrarBtn.UseVisualStyleBackColor = true;
            this.borrarBtn.Click += new System.EventHandler(this.borrar);
            // 
            // textoBtn
            // 
            this.textoBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.textoBtn.Location = new System.Drawing.Point(300, 0);
            this.textoBtn.Name = "textoBtn";
            this.textoBtn.Size = new System.Drawing.Size(75, 53);
            this.textoBtn.TabIndex = 4;
            this.textoBtn.Text = "Texto(experimental)";
            this.textoBtn.UseVisualStyleBackColor = true;
            this.textoBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.crearTexto);
            // 
            // agrandarBtn
            // 
            this.agrandarBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.agrandarBtn.Location = new System.Drawing.Point(225, 0);
            this.agrandarBtn.Name = "agrandarBtn";
            this.agrandarBtn.Size = new System.Drawing.Size(75, 53);
            this.agrandarBtn.TabIndex = 3;
            this.agrandarBtn.Text = "+";
            this.agrandarBtn.UseVisualStyleBackColor = true;
            this.agrandarBtn.Click += new System.EventHandler(this.borrarBtn_Click);
            // 
            // achicarBtn
            // 
            this.achicarBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.achicarBtn.Location = new System.Drawing.Point(150, 0);
            this.achicarBtn.Name = "achicarBtn";
            this.achicarBtn.Size = new System.Drawing.Size(75, 53);
            this.achicarBtn.TabIndex = 2;
            this.achicarBtn.Text = "-";
            this.achicarBtn.UseVisualStyleBackColor = true;
            this.achicarBtn.Click += new System.EventHandler(this.achicarBtn_Click);
            // 
            // abrirBtn
            // 
            this.abrirBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.abrirBtn.Location = new System.Drawing.Point(75, 0);
            this.abrirBtn.Name = "abrirBtn";
            this.abrirBtn.Size = new System.Drawing.Size(75, 53);
            this.abrirBtn.TabIndex = 1;
            this.abrirBtn.Text = "Abrir";
            this.abrirBtn.UseVisualStyleBackColor = true;
            this.abrirBtn.Click += new System.EventHandler(this.cargarBtn_Click);
            // 
            // guardarBtn
            // 
            this.guardarBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.guardarBtn.Location = new System.Drawing.Point(0, 0);
            this.guardarBtn.Name = "guardarBtn";
            this.guardarBtn.Size = new System.Drawing.Size(75, 53);
            this.guardarBtn.TabIndex = 0;
            this.guardarBtn.Text = "Guardar";
            this.guardarBtn.UseVisualStyleBackColor = true;
            this.guardarBtn.Click += new System.EventHandler(this.guardarBtn_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.splitContainer2.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.splitContainer2.Panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            this.splitContainer2.Size = new System.Drawing.Size(921, 393);
            this.splitContainer2.SplitterDistance = 176;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelDropDownFiguras);
            this.flowLayoutPanel1.Controls.Add(this.panelDropDownFlechas);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 3);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(152, 900);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(152, 415);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(152, 415);
            this.flowLayoutPanel1.TabIndex = 37;
            // 
            // panelDropDownFiguras
            // 
            this.panelDropDownFiguras.Controls.Add(this.figurasBtn);
            this.panelDropDownFiguras.Controls.Add(this.circulo_negro);
            this.panelDropDownFiguras.Controls.Add(this.cuadrado_negro);
            this.panelDropDownFiguras.Location = new System.Drawing.Point(3, 3);
            this.panelDropDownFiguras.MaximumSize = new System.Drawing.Size(147, 243);
            this.panelDropDownFiguras.MinimumSize = new System.Drawing.Size(147, 35);
            this.panelDropDownFiguras.Name = "panelDropDownFiguras";
            this.panelDropDownFiguras.Size = new System.Drawing.Size(147, 35);
            this.panelDropDownFiguras.TabIndex = 0;
            // 
            // figurasBtn
            // 
            this.figurasBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.figurasBtn.Location = new System.Drawing.Point(0, 0);
            this.figurasBtn.Name = "figurasBtn";
            this.figurasBtn.Size = new System.Drawing.Size(147, 35);
            this.figurasBtn.TabIndex = 1;
            this.figurasBtn.Text = "Figuras ▼";
            this.figurasBtn.UseVisualStyleBackColor = true;
            this.figurasBtn.Click += new System.EventHandler(this.figurasBtn_Click);
            // 
            // circulo_negro
            // 
            this.circulo_negro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circulo_negro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.circulo_negro.Image = global::TPI_Diagramador.Properties.Resources.circulo_vacio_negro;
            this.circulo_negro.Location = new System.Drawing.Point(0, -65);
            this.circulo_negro.Name = "circulo_negro";
            this.circulo_negro.Size = new System.Drawing.Size(147, 50);
            this.circulo_negro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.circulo_negro.TabIndex = 35;
            this.circulo_negro.TabStop = false;
            this.circulo_negro.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownDrag);
            // 
            // cuadrado_negro
            // 
            this.cuadrado_negro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cuadrado_negro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cuadrado_negro.Image = global::TPI_Diagramador.Properties.Resources.cuadrado_vacio_negro;
            this.cuadrado_negro.Location = new System.Drawing.Point(0, -15);
            this.cuadrado_negro.Name = "cuadrado_negro";
            this.cuadrado_negro.Size = new System.Drawing.Size(147, 50);
            this.cuadrado_negro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cuadrado_negro.TabIndex = 36;
            this.cuadrado_negro.TabStop = false;
            this.cuadrado_negro.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownDrag);
            // 
            // panelDropDownFlechas
            // 
            this.panelDropDownFlechas.Controls.Add(this.flechaD_arriba_derecha);
            this.panelDropDownFlechas.Controls.Add(this.flechaD_abajo_izquierda);
            this.panelDropDownFlechas.Controls.Add(this.flechaD_abajo_derecha);
            this.panelDropDownFlechas.Controls.Add(this.flechasBtn);
            this.panelDropDownFlechas.Controls.Add(this.flechaD_arriba_izquierda);
            this.panelDropDownFlechas.Controls.Add(this.flecha_izquierda);
            this.panelDropDownFlechas.Controls.Add(this.flecha_abajo);
            this.panelDropDownFlechas.Controls.Add(this.flecha_derecha);
            this.panelDropDownFlechas.Controls.Add(this.flecha_arriba);
            this.panelDropDownFlechas.Location = new System.Drawing.Point(3, 44);
            this.panelDropDownFlechas.MaximumSize = new System.Drawing.Size(147, 434);
            this.panelDropDownFlechas.MinimumSize = new System.Drawing.Size(147, 35);
            this.panelDropDownFlechas.Name = "panelDropDownFlechas";
            this.panelDropDownFlechas.Size = new System.Drawing.Size(147, 35);
            this.panelDropDownFlechas.TabIndex = 0;
            // 
            // flechaD_arriba_derecha
            // 
            this.flechaD_arriba_derecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flechaD_arriba_derecha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flechaD_arriba_derecha.Image = global::TPI_Diagramador.Properties.Resources.flechaD_arriba_derecha_negra;
            this.flechaD_arriba_derecha.Location = new System.Drawing.Point(0, -353);
            this.flechaD_arriba_derecha.Name = "flechaD_arriba_derecha";
            this.flechaD_arriba_derecha.Size = new System.Drawing.Size(147, 39);
            this.flechaD_arriba_derecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.flechaD_arriba_derecha.TabIndex = 32;
            this.flechaD_arriba_derecha.TabStop = false;
            this.flechaD_arriba_derecha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownDrag);
            // 
            // flechaD_abajo_izquierda
            // 
            this.flechaD_abajo_izquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flechaD_abajo_izquierda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flechaD_abajo_izquierda.Image = global::TPI_Diagramador.Properties.Resources.flechaD_abajo_izquierda_negra;
            this.flechaD_abajo_izquierda.Location = new System.Drawing.Point(0, -314);
            this.flechaD_abajo_izquierda.Name = "flechaD_abajo_izquierda";
            this.flechaD_abajo_izquierda.Size = new System.Drawing.Size(147, 50);
            this.flechaD_abajo_izquierda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.flechaD_abajo_izquierda.TabIndex = 34;
            this.flechaD_abajo_izquierda.TabStop = false;
            this.flechaD_abajo_izquierda.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownDrag);
            // 
            // flechaD_abajo_derecha
            // 
            this.flechaD_abajo_derecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flechaD_abajo_derecha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flechaD_abajo_derecha.Image = global::TPI_Diagramador.Properties.Resources.flechaD_abajo_derecha_negra;
            this.flechaD_abajo_derecha.Location = new System.Drawing.Point(0, -264);
            this.flechaD_abajo_derecha.Name = "flechaD_abajo_derecha";
            this.flechaD_abajo_derecha.Size = new System.Drawing.Size(147, 49);
            this.flechaD_abajo_derecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.flechaD_abajo_derecha.TabIndex = 33;
            this.flechaD_abajo_derecha.TabStop = false;
            this.flechaD_abajo_derecha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownDrag);
            // 
            // flechasBtn
            // 
            this.flechasBtn.Location = new System.Drawing.Point(0, 0);
            this.flechasBtn.Name = "flechasBtn";
            this.flechasBtn.Size = new System.Drawing.Size(147, 35);
            this.flechasBtn.TabIndex = 0;
            this.flechasBtn.Text = "Flechas ▼";
            this.flechasBtn.UseVisualStyleBackColor = true;
            this.flechasBtn.Click += new System.EventHandler(this.flechas_button_Click);
            // 
            // flechaD_arriba_izquierda
            // 
            this.flechaD_arriba_izquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flechaD_arriba_izquierda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flechaD_arriba_izquierda.Image = global::TPI_Diagramador.Properties.Resources.flechaD_arriba_izquierda_negra;
            this.flechaD_arriba_izquierda.Location = new System.Drawing.Point(0, -215);
            this.flechaD_arriba_izquierda.Name = "flechaD_arriba_izquierda";
            this.flechaD_arriba_izquierda.Size = new System.Drawing.Size(147, 50);
            this.flechaD_arriba_izquierda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.flechaD_arriba_izquierda.TabIndex = 31;
            this.flechaD_arriba_izquierda.TabStop = false;
            this.flechaD_arriba_izquierda.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownDrag);
            // 
            // flecha_izquierda
            // 
            this.flecha_izquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flecha_izquierda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flecha_izquierda.Image = global::TPI_Diagramador.Properties.Resources.flecha_izquierda_negra;
            this.flecha_izquierda.Location = new System.Drawing.Point(0, -165);
            this.flecha_izquierda.Name = "flecha_izquierda";
            this.flecha_izquierda.Size = new System.Drawing.Size(147, 50);
            this.flecha_izquierda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.flecha_izquierda.TabIndex = 29;
            this.flecha_izquierda.TabStop = false;
            this.flecha_izquierda.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownDrag);
            // 
            // flecha_abajo
            // 
            this.flecha_abajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flecha_abajo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flecha_abajo.Image = global::TPI_Diagramador.Properties.Resources.flecha_abajo_negra;
            this.flecha_abajo.Location = new System.Drawing.Point(0, -115);
            this.flecha_abajo.Name = "flecha_abajo";
            this.flecha_abajo.Size = new System.Drawing.Size(147, 50);
            this.flecha_abajo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.flecha_abajo.TabIndex = 30;
            this.flecha_abajo.TabStop = false;
            this.flecha_abajo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownDrag);
            // 
            // flecha_derecha
            // 
            this.flecha_derecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flecha_derecha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flecha_derecha.Image = global::TPI_Diagramador.Properties.Resources.flecha_derecha_negra;
            this.flecha_derecha.Location = new System.Drawing.Point(0, -65);
            this.flecha_derecha.Name = "flecha_derecha";
            this.flecha_derecha.Size = new System.Drawing.Size(147, 50);
            this.flecha_derecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.flecha_derecha.TabIndex = 27;
            this.flecha_derecha.TabStop = false;
            this.flecha_derecha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownDrag);
            // 
            // flecha_arriba
            // 
            this.flecha_arriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flecha_arriba.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flecha_arriba.Image = global::TPI_Diagramador.Properties.Resources.flecha_arriba_negra;
            this.flecha_arriba.Location = new System.Drawing.Point(0, -15);
            this.flecha_arriba.Name = "flecha_arriba";
            this.flecha_arriba.Size = new System.Drawing.Size(147, 50);
            this.flecha_arriba.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.flecha_arriba.TabIndex = 28;
            this.flecha_arriba.TabStop = false;
            this.flecha_arriba.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownDrag);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "json";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelDropDownFiguras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.circulo_negro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadrado_negro)).EndInit();
            this.panelDropDownFlechas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flechaD_arriba_derecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flechaD_abajo_izquierda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flechaD_abajo_derecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flechaD_arriba_izquierda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flecha_izquierda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flecha_abajo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flecha_derecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flecha_arriba)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Button rojoBtn;
        private Button toJPGBtn;
        private Button borrarBtn;
        private Button textoBtn;
        private Button agrandarBtn;
        private Button achicarBtn;
        private Button abrirBtn;
        private Button guardarBtn;
        private SplitContainer splitContainer2;
        private Button azulBtn;
        private Button moradoBtn;
        private Button verdeBtn;
        private PictureBox flecha_derecha;
        private PictureBox flechaD_abajo_izquierda;
        private PictureBox flechaD_abajo_derecha;
        private PictureBox flechaD_arriba_derecha;
        private PictureBox flechaD_arriba_izquierda;
        private PictureBox flecha_abajo;
        private PictureBox flecha_izquierda;
        private PictureBox flecha_arriba;
        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;
        private PictureBox circulo_negro;
        private PictureBox cuadrado_negro;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panelDropDownFlechas;
        private Button flechasBtn;
        private Panel panelDropDownFiguras;
        private Button figurasBtn;
        private System.Windows.Forms.Timer timer1;
    }
}