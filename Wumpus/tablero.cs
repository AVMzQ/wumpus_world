using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace Wumpus
{
    internal class tablero
    {
        public static tablero_Data Td { get; set; }
        public static void Crear_Tablero()
        {
            for (int i =0; i < Td.x; i++){
                for (int j = 0; j < Td.y; j++){
                    string nom = string.Format("{0},{1}", i, j);
                    Td.tablero.Controls.Add(Crear_Posicion(nom));
                }
            }
        }
        private static Panel Crear_Posicion(string nom){
            Panel p = new Panel(){
                Name = nom,
                Width = 50,
                Height = 50,
                BackColor = Color.Gray
            };
            Label l = new Label() { Text = nom, AutoSize = true, Dock = DockStyle.Fill};
            p.Controls.Add(l);
            Aventurero_Iniciar();
            return p;
        }
        private static void Aventurero_Iniciar(){
            foreach (Control posicion in Td.tablero.Controls){
                string nom = string.Format("{0},{1}", Td.x- 1, 0);
                if(posicion.Name == nom){
                    Td.tablero.Controls.Add(Td.aventurero);
                    posicion.Controls.Add(Td.aventurero);
                    Td.Aventurero_Posicion = Tuple.Create(0, (Panel)posicion);
                    break;
                }
            }
        }
        private static void Limpiar_Posicion_Aventurero()
        {
            foreach (Control p in Td.tablero.Controls)
            {
                foreach (Control item in p.Controls)
                {
                    if (item.GetType() == typeof(PictureBox)){
                        if (item.Name == "Aventurero")
                            p.Controls.Remove(item);
                    }
                }
            }
        }
        public static void Aventurero_Mover(int movimiento) {
            Panel posicion = Td.Aventurero_Posicion.Item2;
            int vista = Td.Aventurero_Posicion.Item1;
            string[] xy = Td.Aventurero_Posicion.Item2.Name.Split(',');
            int x = Convert.ToInt32(xy[0]), y = Convert.ToInt32(xy[1]);
            switch (movimiento)
            {
                case 0:
                    x -= 1;
                    break;
                case 1:
                    y += 1;
                    break;
                case 2: 
                    x += 1;
                    break;
                case 3: 
                    y -= 1;
                    break;
            }
            if ((x < Td.x && x >= 0) && (y < Td.y && y >= 0))
            {
                string nom = string.Format("{0},{1}", x, y);
                Limpiar_Posicion_Aventurero();
                foreach (Control p in Td.tablero.Controls)
                {
                    if (p.Name == nom)
                    {
                        p.Controls.Add(Td.aventurero);
                        Td.Aventurero_Posicion = Tuple.Create(movimiento, (Panel)p);
                        break;
                    }
                }
            }
        }
        private static void Escoger_Posicion(){
            Random random = new Random();
            int x = random.Next(0, Td.x);
            int y = random.Next(0, Td.y);
        }
        private static bool Validar_Posicion(int x, int y){

            return true;
        }
        private static void Agregar_Objetos(){

        }
        private static Label Crear_Wumpus()
        {
            Label l = new Label() { Name = "Wumpus", AutoSize = true, BackColor = Color.Green };
            Td.Objeto_Interes.Add(Tuple.Create("Wumpus", l));
            return l;
        }
        private static Label Crear_Oro()
        {
            Label l = new Label() { Name = "Oro", AutoSize = true, BackColor = Color.Gold };
            Td.Objeto_Interes.Add(Tuple.Create("Oro", l));
            return l;
        }
        private static Label Crear_Hoyo()
        {
            Label l = new Label() { Name = "Hoyo", AutoSize = true, BackColor = Color.LightGray };
            Td.Objeto_Interes.Add(Tuple.Create("Hoyo", l));
            return l;
        }
        private static Label Crear_Brisa()
        {
            Label l = new Label() { Name = "Brisa", AutoSize = true, BackColor = Color.White };
            Td.Objeto_Interes.Add(Tuple.Create("Brisa", l));
            return l;
        }
        private static Label Crear_Hedor()
        {
            Label l = new Label() { Name = "Hedor", AutoSize = true, BackColor = Color.LightGreen };
            Td.Objeto_Interes.Add(Tuple.Create("Hedor", l));
            return l;
        }
    }
}
