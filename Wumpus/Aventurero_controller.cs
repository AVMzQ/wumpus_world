using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus
{
    internal class Aventurero_controller
    {
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
        public static void Aventurero_Mover(int movimiento)
        {
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
                        vista = 90;
                    break;
                case 1:
                    if(vista == 0) 
                        y += 1;
                    else
                        vista = 0;
                    break;
                case 2:
                    if(vista == 270) 
                        x += 1;
                    else
                        vista = 270;
                    break;
                case 3:
                    if(vista == 180) 
                        y -= 1;
                    else
                        vista = 180;
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
        }
    }
}
