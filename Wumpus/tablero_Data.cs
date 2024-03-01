using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus
{
    public class tablero_Data
    {
        public FlowLayoutPanel tablero;
        public PictureBox aventurero = new PictureBox(){
            Image = Properties.Resources.ezgif_3_5365f0d974,
            Size = new Size(50,50),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Dock = DockStyle.Fill,
            BackColor =Color.White,
            Name = "Aventurero"
        };

        public int x = 0, y = 0;
        public List<Panel> Wumpus_posicion = new List<Panel>();
        public List<Panel> Hoyo_posicion = new List<Panel>();
        public List<Panel> Brisa_posicion = new List<Panel>();
        public List<Panel> Hedor_posicion = new List<Panel>();
        public List<Panel> Oro_posicion = new List<Panel>();
    }
}
