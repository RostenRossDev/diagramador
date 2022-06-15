using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Diagramador
{
    internal class menuFigura : Panel
    {
        const int WS_EX_TRANSPARENT = 0x20;

        int opacity = 50;
        public menuFigura()
        {

        }
       

        public int Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentException("Valor entre 0 y 100");
                opacity = value;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;

                return cp;
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    using (var b = new SolidBrush(Color.FromArgb(opacity * 255 / 100, BackColor)))
        //    {
        //        e.Graphics.FillRectangle(b, ClientRectangle);
        //    }

        //    base.OnPaint(e);
        //}



    }
}

