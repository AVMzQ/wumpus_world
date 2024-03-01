using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus
{
    internal class Aventurero_controller
    {
        ReproductorDeAudio ReproductorDeAudio = new ReproductorDeAudio();
        public static Aventurero_data Ad { get; set; }
        public static void Aventurero_Iniciar()
        {
            foreach (Control posicion in Ad.tablero.Controls)
            {
                string nom = string.Format("{0},{1}", Ad.x - 1, 0);
                if (posicion.Name == nom)
                {
                    Ad.tablero.Controls.Add(Ad.aventurero);
                    posicion.Controls.Add(Ad.aventurero);
                    Ad.Aventurero_Posicion = Tuple.Create(0, (Panel)posicion);
                    break;
                }
            }
        }
        public static void Limpiar_Posicion_Aventurero()
        {
            foreach (Control p in Ad.tablero.Controls)
            {
                foreach (Control item in p.Controls)
                {
                    if (item.GetType() == typeof(PictureBox))
                    {
                        if (item.Name == "Aventurero")
                            p.Controls.Remove(item);
                    }
                }
            }
        }
        public async static Task<bool> Aventurero_Mover(int movimiento)
        {
            bool res = true, reproducir_audio = true;
            Panel posicion = Ad.Aventurero_Posicion.Item2;
            int vista = Ad.Aventurero_Posicion.Item1;
            string[] xy = Ad.Aventurero_Posicion.Item2.Name.Split(',');
            int x = Convert.ToInt32(xy[0]), y = Convert.ToInt32(xy[1]);
            switch (movimiento)
            {
                case 0:
                    if (vista == 90)
                        x -= 1;
                    else
                    { vista = 90; reproducir_audio = false; }
                    break;
                case 1:
                    if (vista == 0)
                        y += 1;
                    else
                    { vista = 0; reproducir_audio = false; }
                    break;
                case 2:
                    if (vista == 270)
                        x += 1;
                    else
                    { vista = 270; reproducir_audio = false; }
                    break;
                case 3:
                    if (vista == 180)
                        y -= 1;
                    else
                    { vista = 180; reproducir_audio = false; }
                    break;
            }
            if ((x < Ad.x && x >= 0) && (y < Ad.y && y >= 0))
            {
                string nom = string.Format("{0},{1}", x, y);
                Limpiar_Posicion_Aventurero();
                foreach (Control p in Ad.tablero.Controls)
                {
                    if (p.Name == nom)
                    {
                        p.Controls.Add(Ad.aventurero);
                        Ad.Aventurero_Posicion = Tuple.Create(vista, (Panel)p);
                        break;
                    }
                }
            }
            if (! await Aventurero_Muerte(reproducir_audio))
            {
                if (!Aventurero_Oro())
                {
                    await Aventurero_Hedor(reproducir_audio);
                    await Aventurero_Brisa(reproducir_audio);
                    await Aventurero_Hedor_y_Brisa(reproducir_audio);
                    res = false;
                }
                else
                {
                    if (Aventurero_Ganador())
                    {
                        Ad.tablero.Controls.Clear();
                    }
                    res = false;
                }
            }
            return res;
        }
        public static bool Aventurero_Oro()
        {
            bool res = false;
            Panel posicion = Ad.Aventurero_Posicion.Item2;
            if (Ad.TieneOro)
            {
                res = true;
            }
            else
            {
                foreach (Control c in Ad.tablero.Controls)
                {
                    if (Ad.Aventurero_Posicion.Item2 == (Panel)c)
                    {
                        if (c.Tag != null)
                        {
                            if (c.Tag.ToString() == "oro")
                            {
                                res = true;
                                if (!Ad.TieneOro)
                                {
                                    Ad.TieneOro = true;
                                    ReproductorDeAudio.Aviso_TieneOro();
                                    foreach (Control p in c.Controls)
                                    {
                                        p.Visible = true;
                                        if (p.Name == "oro")
                                        {
                                            c.Controls.Remove(p);
                                            break;
                                        }
                                    }
                                }
                                break;
                            }

                        }
                    }
                }
            }
            return res;
        }
        public static bool Aventurero_Ganador()
        {
            bool res = false;
            Panel posicion = Ad.Aventurero_Posicion.Item2;
            foreach (Control c in Ad.tablero.Controls)
            {
                if(posicion.Name == "4,0")
                {
                    if (Ad.TieneOro)
                    {
                        res = true;
                        Ad.tablero.Controls.Clear();
                        Ad.ganador = true;
                        ReproductorDeAudio.Aviso_Ganador();
                        break;
                    }
                }
            }
            return res;
        }
        public static async Task<bool> Aventurero_Muerte(bool reproducir_Audio)
        {
            bool res = false;
            Panel posicion = Ad.Aventurero_Posicion.Item2;
            foreach (Control c in Ad.tablero.Controls){
                if(Ad.Aventurero_Posicion.Item2 == (Panel)c)
                {
                    if(c.Tag != null){
                        if (c.Tag.ToString() == "Wumpus" || c.Tag.ToString() == "Hoyo")
                        {
                            res = true;
                            foreach (Control p in c.Controls)
                            {
                                PictureBox pb = (PictureBox)p;
                                pb.Visible = true;
                                await Task.Delay(500);
                            }
                            break;
                        }
                    }
                }
            }
            return res;
        }
        public static async Task<bool> Aventurero_Hedor(bool reproducir_Audio)
        {
            bool res = false;
            Panel posicion = Ad.Aventurero_Posicion.Item2;
            foreach (Control c in Ad.tablero.Controls)
            {
                if (Ad.Aventurero_Posicion.Item2 == (Panel)c)
                {
                    if (c.Tag.ToString() == "Hedor")
                    {
                        if (reproducir_Audio)
                        {
                            ReproductorDeAudio.Aviso_Monstruo();
                        }
                        res = true;
                        break;
                    }
                }
            }
            return res;
        }
        public async static Task<bool> Aventurero_Brisa(bool reproducir_Audio)
        {
            bool res = false;
            Panel posicion = Ad.Aventurero_Posicion.Item2;
            foreach (Control c in Ad.tablero.Controls)
            {
                if (Ad.Aventurero_Posicion.Item2 == (Panel)c)
                {
                    if (c.Tag.ToString() == "Brisa")
                    {
                        if (reproducir_Audio)
                        {
                            ReproductorDeAudio.Aviso_Brisa();
                        }
                        res = true;
                        break;
                    }
                }
            }
            return res;
        }
        public static async Task<bool> Aventurero_Hedor_y_Brisa(bool reproducir_Audio)
        {
            bool res = false;
            Panel posicion = Ad.Aventurero_Posicion.Item2;
            foreach (Control c in Ad.tablero.Controls)
            {
                if (Ad.Aventurero_Posicion.Item2 == (Panel)c)
                {
                    if (c.Tag.ToString() == "Hedor&Brisa")
                    {
                        if (reproducir_Audio)
                        {
                            await Task.Run(() => ReproductorDeAudio.Aviso_Monstruo());
                            ReproductorDeAudio.Aviso_Brisa();
                        }
                        res = true;
                        break;
                    }
                }
            }
            return res;
        }
    }
}
