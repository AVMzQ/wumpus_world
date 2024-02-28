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
using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;
namespace Wumpus
{
    internal class tablero
    {
        static int x, y;
        public static tablero_Data Td { get; set; }
        public static void Crear_Tablero()
        {
            for (int i =0; i < Td.x; i++){
                for (int j = 0; j < Td.y; j++){
                    string nom = string.Format("{0},{1}", i, j);
                    Td.tablero.Controls.Add(Crear_Posicion(nom));
                }
            }
            for (int i = 0; i < 3; i++)
            {
                PictureBox oro = new PictureBox()
                {
                    Image = Properties.Resources.lingote_de_oro,
                    Size = new Size(50, 50),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill,
                    BackColor = Color.Gold,
                    Name = i.ToString(),
                    Tag = "Oro",
                    Visible = true
                };
                Poscion_Objetos_Interes(1, oro);
            }
            for (int i = 0; i < 5; i++){
                PictureBox wumpus = new PictureBox()
                {
                    Image = Properties.Resources.bastante_sorprendidos_y_preocupados_buscando_2_encabezada_monstruo_con_una_personalidad_dividida_e61g68,
                    Size = new Size(50, 50),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill,
                    BackColor = Color.Gold,
                    Name = i.ToString(),
                    Tag = "Wumpus",
                    Visible = true
                };
                Poscion_Objetos_Interes(2, wumpus);
            }
            for (int i = 0; i < 3; i++)
            {
                PictureBox Hoyo = new PictureBox()
                {
                    Image = Properties.Resources.agujero,
                    Size = new Size(50, 50),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill,
                    BackColor = Color.Gold,
                    Name = i.ToString(),
                    Tag = "Hoyo",
                    Visible = true
                };
                Poscion_Objetos_Interes(3, Hoyo);
            }
            MessageBox.Show(Td.Oro_posicion.Count.ToString());
        }
        private static Panel Crear_Posicion(string nom){
            Panel p = new Panel(){
                Name = nom,
                Width = 50,
                Height = 50,
                BackColor = Color.Gray
            };
            //Label l = new Label() { Text = nom, AutoSize = true, Dock = DockStyle.Fill};
            //p.Controls.Add(l);
            return p;
        }
        private static string Escoger_Posicion(){
            string nom = "";
            Random random = new Random();
            x = random.Next(0, Td.x);
            y = random.Next(0, Td.y);
            nom = x.ToString() + "," + y.ToString();
            return nom;
        }
        private static void Poscion_Objetos_Interes(int tipo, PictureBox ilustracion)
        {
            try
            {
                string xy = Escoger_Posicion();
                if (Posicion_Excluida(xy))
                {
                    if (Posicion_Libre(xy))
                    {
                        foreach (Control c in Td.tablero.Controls)
                        {
                            if (c.Name == xy)
                            {
                                switch (tipo)
                                {
                                    case 1://Oro
                                        Td.Oro_posicion.Add((Panel)c);
                                        c.Controls.Add(ilustracion);
                                        break;
                                    case 2://Wumpus
                                        Td.Wumpus_posicion.Add((Panel)c);
                                        c.Controls.Add(ilustracion);
                                        for (int i = 1; i <= 4; i++)
                                        {
                                            Posicion_Hedor((Panel)c, i);
                                        }
                                        break;
                                    case 3://Hoyo
                                        Td.Hoyo_posicion.Add((Panel)c);
                                        c.Controls.Add(ilustracion);
                                        for (int i = 1; i <= 4; i++)
                                        {
                                            Posicion_Brisa((Panel)c, i);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Poscion_Objetos_Interes(tipo, ilustracion);
            }
        }
        private static PictureBox hedor_()
        {
            PictureBox hedor = new PictureBox()
            {
                Image = Properties.Resources.bacterias,
                Size = new Size(25, 25),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Top,
                BackColor = Color.Gold,
                Tag = "Hedor",
                Visible = true
            };
            return hedor;
        }
        private static PictureBox Brisa_()
        {
            PictureBox hedor = new PictureBox()
            {
                Image = Properties.Resources.viento,
                Size = new Size(25, 25),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Bottom,
                BackColor = Color.Gold,
                Tag = "Brisa",
                Visible = true
            };
            return hedor;
        }
        private static void Posicion_Hedor(Panel posicion, int orientacion)
        {
            string[] xy = posicion.Name.Split(',');
            int x = int.Parse(xy[0]);
            int y = int.Parse(xy[1]);
            PictureBox hedor = hedor_();
            switch (orientacion)
            {
                case 1: x += 1;
                    break;
                case 2: y += 1;
                    break;
                case 3:
                    x -= 1;
                    break;
                case 4:
                    y -= 1;
                    break;
            }
            string nom = string.Format("{0},{1}", x, y);
            foreach (Control item in Td.tablero.Controls){
                if(item.Name == nom){
                    if(item.Controls.Count == 0)
                        item.Controls.Add(hedor);
                    else
                    {
                        bool NoTieneOro = false;
                        foreach (Control item2 in item.Controls)
                        {
                            if (item2.Name == "Oro")
                                NoTieneOro = true; break;
                        }
                        if (NoTieneOro)
                            item.Controls.Add(hedor);
                    }
                }
            }
        }

        private static void Posicion_Brisa(Panel posicion, int orientacion)
        {
            string[] xy = posicion.Name.Split(',');
            int x = int.Parse(xy[0]);
            int y = int.Parse(xy[1]);
            PictureBox brisa = Brisa_();
            switch (orientacion)
            {
                case 1:
                    x += 1;
                    break;
                case 2:
                    y += 1;
                    break;
                case 3:
                    x -= 1;
                    break;
                case 4:
                    y -= 1;
                    break;
            }
            string nom = string.Format("{0},{1}", x, y);
            foreach (Control item in Td.tablero.Controls)
            {
                if (item.Name == nom)
                {
                    if (item.Controls.Count == 0)
                        item.Controls.Add(brisa);
                    else
                    {
                        bool NoTieneOro = false;
                        foreach (Control item2 in item.Controls)
                        {
                            if (item2.Name == "Oro")
                                NoTieneOro = true; break;
                        }
                        if (NoTieneOro)
                            item.Controls.Add(brisa);
                    }
                }
            }
        }
        private static bool Posicion_Excluida(string posicion)
        {
            bool res = true;
            string[] Posicion_Excluida = { "10,0", "10,1", "9,0", "9,1" };
            foreach (var item in Posicion_Excluida){
                if (item == posicion){
                    res = false;
                    break;
                }
            }
            return res;
        }
        private static bool Posicion_Libre(string nom)
        {
            bool res = false;
            foreach (Control c in Td.tablero.Controls){
                if (c.Name == nom ){
                    if(c.Controls.Count == 0){
                        res = true;
                        break;
                    }
                    else{
                        if (PosicionEs_Hedor_Brisa((Panel)c)){
                            res = true;
                        }
                    }
                }
            }
            return res;
        }
        private static bool PosicionEs_Hedor_Brisa(Panel posicion)
        {
            bool res = false;
            foreach(var item in Td.Brisa_posicion)
            {
                if (item == posicion)
                    res = true;
            }
            foreach (var item in Td.Hedor_posicion)
            {
                if (item == posicion)
                    res = true;
            }
            return res;
        }
    }
}
