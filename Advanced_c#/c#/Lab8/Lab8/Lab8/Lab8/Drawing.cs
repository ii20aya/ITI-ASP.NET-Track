using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Drawing : Form
    {
        bool isDrawing = false;
        public Drawing()
        {
            InitializeComponent();
    
        }

        private void Drawing_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
        }

        private void Drawing_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDrawing)
            {
                Graphics graphics = this.CreateGraphics();
                graphics.FillEllipse(Brushes.Olive, e.X, e.Y, 20, 20);
                
            }

        }

        private void Drawing_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }


        private void Drawing_Load(object sender, EventArgs e)
        {

        }
    }
}
