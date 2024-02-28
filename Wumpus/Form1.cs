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
        int x = 10, y = 10, movimientos = 0, flechas = 0;
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

            Aventurero_data ad = new Aventurero_data() { 
                tablero = this.tablero,
                x = x,
                y = y};
            Aventurero_controller Aventurero_controller = new Aventurero_controller();
            Aventurero_controller.Ad =ad;
            Aventurero_controller.Aventurero_Iniciar();
            Aventurero_Posicion = ad.Aventurero_Posicion;
            movimientos = 0;
            lblxy.Text = movimientos.ToString();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Aventurero_data ad = new Aventurero_data()
            {
                tablero = this.tablero,
                Aventurero_Posicion = Aventurero_Posicion,
                x = x,
                y = y
            };
            Aventurero_controller Aventurero_controller = new Aventurero_controller();
            Aventurero_controller.Ad = ad;
            switch (e.KeyCode)
            {
                case Keys.W:
                    Aventurero_controller.Aventurero_Mover(0);
                    Aventurero_Posicion = ad.Aventurero_Posicion;
                    pbVista.Image = Properties.Resources.flecha_hacia_arriba;
                    break;
                case Keys.D:
                    Aventurero_controller.Aventurero_Mover(1);
                    Aventurero_Posicion = ad.Aventurero_Posicion;
                    pbVista.Image = Properties.Resources.flecha_correcta;
                    break;
                case Keys.S:
                    Aventurero_controller.Aventurero_Mover(2);
                    Aventurero_Posicion = ad.Aventurero_Posicion;
                    pbVista.Image = Properties.Resources.flecha_hacia_abajo;
                    break;
                case Keys.A:
                    Aventurero_controller.Aventurero_Mover(3);
                    Aventurero_Posicion = ad.Aventurero_Posicion;
                    pbVista.Image = Properties.Resources.flecha_izquierda;
                    break;
            }
            movimientos += 1;
            lblxy.Text = movimientos.ToString();
            textBox1.Clear();
        }
    }
}
