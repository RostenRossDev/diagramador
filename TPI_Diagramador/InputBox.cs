using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPI_Diagramador
{
    public partial class InputBox : Form
    {
        private string text = "";
        public InputBox()
        {
            InitializeComponent();
        }

        public string getName()
        {
            return this.text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.text=textBox1.Text;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
