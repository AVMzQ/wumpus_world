﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablero_Data td = new tablero_Data() { 
                tablero = pTablero};
            tablero tablero = new tablero();
            tablero.Td = td;
            tablero.Dibujar_X();
        }
    }
}
