using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus
{
    internal class Aventurero_data
    {
        public FlowLayoutPanel tablero;
        public int x, y, flechas;
        public PictureBox aventurero = new PictureBox()
        {
            Image = Properties.Resources.ezgif_3_5365f0d974,
            Size = new Size(50, 50),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            Name = "Aventurero"
        };
        public Tuple<int, Panel> Aventurero_Posicion;
    }
}
