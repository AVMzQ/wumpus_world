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
        ReproductorDeAudio ReproductorDeAudio = new ReproductorDeAudio();
        private Tuple<int, Panel> Aventurero_Posicion;
        int x = 5, y = 7, movimientos = 0, flechas = 0;
        bool TieneOro, ganador;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private async void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Aventurero_data ad = new Aventurero_data()
            {
                tablero = this.tablero,
                Aventurero_Posicion = Aventurero_Posicion,
                x = x,
                y = y,
                TieneOro = TieneOro
            };
            Aventurero_controller Aventurero_controller = new Aventurero_controller();
            Aventurero_controller.Ad = ad;
            bool muerte = false;
            switch (e.KeyCode)
            {
                case Keys.W:
                    muerte = await Aventurero_controller.Aventurero_Mover(0);
                    Aventurero_Posicion = ad.Aventurero_Posicion;
                    pbVista.Image = Properties.Resources.flecha_hacia_arriba;
                    break;
                case Keys.D:
                    muerte = await Aventurero_controller.Aventurero_Mover(1);
                    Aventurero_Posicion = ad.Aventurero_Posicion;
                    pbVista.Image = Properties.Resources.flecha_correcta;
                    break;
                case Keys.S:
                    muerte = await Aventurero_controller.Aventurero_Mover(2);
                    Aventurero_Posicion = ad.Aventurero_Posicion;
                    pbVista.Image = Properties.Resources.flecha_hacia_abajo;
                    break;
                case Keys.A:
                    muerte = await Aventurero_controller.Aventurero_Mover(3);
                    Aventurero_Posicion = ad.Aventurero_Posicion;
                    pbVista.Image = Properties.Resources.flecha_izquierda;
                    break;
            }
            ganador = ad.ganador;
            if (muerte)
            {
                if (ad.Aventurero_Posicion.Item2.Name != "4,0")
                {
                    ReproductorDeAudio.Aventurero_Muerte_Sonido();
                    this.tablero.Controls.Clear();
                    lblxy.Text = "";
                    lblDescripcion.Text = string.Format("Descansa en paz!\nNumero de intentos {0}", movimientos);
                }
            }
            else if (ganador)
            {
                lblxy.Text = "";
                lblDescripcion.Text = string.Format("GANASTE!\nNumero de intentos {0}", movimientos);
            }
            else
            {
                TieneOro = ad.TieneOro;
                movimientos += 1;
                lblxy.Text = movimientos.ToString();
                textBox1.Clear();
                if (!TieneOro)
                {
                    switch (ad.Aventurero_Posicion.Item2.Tag.ToString())
                    {
                        case "Hedor":
                            lblDescripcion.Text = "HEDOR!";
                            break;
                        case "Brisa":
                            lblDescripcion.Text = "BRISA!";
                            break;
                        case "Hedor&Brisa":
                            lblDescripcion.Text = "HEDOR Y BRISA!!";
                            break;
                        default:
                            lblDescripcion.Text = "Encuentra el ORO!";
                            break;
                    }
                }
                else
                    lblDescripcion.Text = "SAL DE AHI!";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ganador = false;
                TieneOro = false;
                textBox1.Clear();
                textBox1.Focus();
                lblxy.Text = "";
                this.tablero.Width = 60 * y;
                this.tablero.Height = 60 * y;
                this.tablero.AutoScroll = true;
                tablero_Data td = new tablero_Data()
                {
                    tablero = this.tablero,
                    x = x,
                    y = y
                };
                tablero tablero = new tablero();
                tablero.Td = td;
                tablero.Crear_Tablero();

                Aventurero_data ad = new Aventurero_data()
                {
                    tablero = this.tablero,
                    x = x,
                    y = y
                };
                Aventurero_controller Aventurero_controller = new Aventurero_controller();
                Aventurero_controller.Ad = ad;
                Aventurero_controller.Aventurero_Iniciar();
                Aventurero_Posicion = ad.Aventurero_Posicion;
                movimientos = 0;
                lblxy.Text = movimientos.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ocurrio un error: " + x.Message);
            }
        }
        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
