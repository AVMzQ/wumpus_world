using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
namespace Wumpus
{
    internal class tablero
    {
        public static tablero_Data Td { get; set; }
        public static void Dibujar_X()
        {
            Graphics g = Td.tablero.CreateGraphics();
            Pen lapiz = new Pen(Color.Black, 2);
            //x, y, ancho, largo
            for (int x = 50; x < Td.tablero.Width -50; x++){
                for (int y = 50; y < Td.tablero.Height -50; y++){
                    g.DrawRectangle(lapiz, x, y, 50, 50);
                    Td.posiciones.Add(new Tuple<int, int>(x, y));
                    y += 50;
                }
                x += 50;
            }

        }
    }
}
