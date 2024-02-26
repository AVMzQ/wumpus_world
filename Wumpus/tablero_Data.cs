using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus
{
    public class tablero_Data
    {
        public Panel tablero;
        public int x = 0, y = 0;
        public List<Tuple<int, int>> posiciones = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> Ubicacion_Wumpus = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> Ubicacion_Hedor = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> Ubicacion_Hoyo = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> Ubicacion_brisa = new List<Tuple<int, int>>();
    }
}
