using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus
{
    public partial class Form1 : Form
    {
        private Tuple<int, Panel> Aventurero_Posicion;
        int x = 5, y = 7;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tablero.Controls.Clear();
            this.tablero.Width = 60 * y;
            this.tablero.Height = 60 * y;
            this.tablero.AutoScroll = true;
            tablero_Data td = new tablero_Data()
            {
                tablero = this.tablero,
                x = x,
                y=y};
            tablero tablero = new tablero();
            tablero.Td = td;
            tablero.Crear_Tablero();
            Aventurero_Posicion = td.Aventurero_Posicion;
        }

        private void flowLayoutPanel2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            tablero_Data td = new tablero_Data()
            {
                tablero = this.tablero,
                x = x,
                y = y,
                Aventurero_Posicion = Aventurero_Posicion
            };
            tablero tablero = new tablero();
            tablero.Td = td;
            switch (e.KeyCode)
            {
                case Keys.W:
                    tablero.Aventurero_Mover(0);
                    Aventurero_Posicion = td.Aventurero_Posicion;
                    break;
                case Keys.D:
                    tablero.Aventurero_Mover(1);
                    Aventurero_Posicion = td.Aventurero_Posicion;
                    break;
                case Keys.S:
                    tablero.Aventurero_Mover(2);
                    Aventurero_Posicion = td.Aventurero_Posicion;
                    break;
                case Keys.A:
                    tablero.Aventurero_Mover(3);
                    Aventurero_Posicion = td.Aventurero_Posicion;
                    break;
            }
            lblxy.Text = Aventurero_Posicion.Item2.Name;
            textBox1.Clear();
        }
    }
}
