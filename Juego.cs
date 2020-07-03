using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tateti_con_interface
{
    public partial class Juego : Form
    {
        private Jugador jugador1;
        private Jugador jugador2;
        private Tablero tablero;

        public Juego(Jugador jugador1 , Jugador jugador2)
        {
            InitializeComponent();
            this.jugador1 = jugador1;
            this.jugador2 = jugador2;
            tablero = new Tablero();
        }


    }
}
