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
    public partial class DragAndDrop : Form
    {
        public DragAndDrop()
        {
            InitializeComponent();
            this.AllowDrop = true;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panel = (sender as Panel);
            panel.DoDragDrop(panel, DragDropEffects.Move);
        }

        private void DragAndDrop_DragDrop(object sender, DragEventArgs e)
        {

            var panel = e.Data.GetData(e.Data.GetFormats()[0]) as Panel;
            panel.Location = this.PointToClient(new Point(e.X, e.Y));
            panel1.Controls.Add(panel);
            //this.Controls.Remove(panel1);

        }
        private void DragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DragAndDrop_Load(object sender, EventArgs e)
        {

        }
    }
}
