using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus
{
    internal class ReproductorDeAudio
    {
        public static bool Aventurero_Muerte_Sonido()
        {
            var stream = Properties.Resources.Dark_Souls___You_Died___Sound_Effect;
            SoundPlayer reproductor = new SoundPlayer(stream);
            reproductor.Load();
            if(reproductor.IsLoadCompleted)
                reproductor.Play();
            return true;
        }
        public static bool Aviso_Brisa()
        {
            var stream = Properties.Resources.Brisa__efecto_de_sonido;
            SoundPlayer reproductor = new SoundPlayer(stream);
            reproductor.Load();
            if (reproductor.IsLoadCompleted)
                reproductor.Play();
            return true;
        }
        public static bool Aviso_Monstruo()
        {
            var stream = Properties.Resources.Gruñido_de_Monstruo_Sonido___Monster_Snarling_Sound;
            SoundPlayer reproductor = new SoundPlayer(stream);
            reproductor.Load();
            if (reproductor.IsLoadCompleted)
                reproductor.Play();
            return true;
        }
        public static void Aviso_TieneOro()
        {
            var stream = Properties.Resources.Pokémon_Blanco_y_Negro_OST___52__Problemas_en_Combate;
            SoundPlayer reproductor = new SoundPlayer(stream);
            reproductor.Load();
            if (reproductor.IsLoadCompleted)
                reproductor.PlayLooping();
        }
        public static void Aviso_Ganador()
        {
            var stream = Properties.Resources.Sonido_de_ganador;
            SoundPlayer reproductor = new SoundPlayer(stream);
            reproductor.Load();
            if (reproductor.IsLoadCompleted)
                reproductor.Play();
        }
    }
}
