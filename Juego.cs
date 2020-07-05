using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private Jugador turno;
        private List<Button> botones = new List<Button>();

        public Juego(Jugador jugador1 , Jugador jugador2)
        {
            InitializeComponent();
            this.jugador1 = jugador1;
            this.jugador2 = jugador2;
            tablero = new Tablero();
        }

        private void Juego_Load(object sender, EventArgs e)
        {            
            Comienzaj1.Text = jugador1.Nombre;
            Comienzaj2.Text = jugador2.Nombre;

            Nombrej1.Text += jugador1.Nombre;
            Nombrej2.Text += jugador2.Nombre;

            Fichaj1.Text += jugador1.Ficha.ToString();
            Fichaj2.Text += jugador2.Ficha.ToString();
            
            botones.Add(b1); botones.Add(b2); botones.Add(b3);
            botones.Add(b4); botones.Add(b5); botones.Add(b6);
            botones.Add(b7); botones.Add(b8); botones.Add(b9);
            foreach (Button button in botones)
            {
                button.Enabled = false;
            }           
        }

        private void seleccionadorDeTurno(Jugador turno)
        {
            this.turno = turno;
            SeleccionadorDeTurno.Controls.Clear();
            
            Label Ajugar = new Label();
            Ajugar.AutoSize = true;
            Ajugar.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Ajugar.Location = new System.Drawing.Point(76, 6);
            Ajugar.Size = new System.Drawing.Size(200, 42);
            Ajugar.TabIndex = 22;
            Ajugar.Text = "¡A JUGAR!";
            
            SeleccionadorDeTurno.Controls.Add(Ajugar);
            foreach (Button button in botones)
            {
                button.Enabled = true;
            }
        }

        private void Comienzaj1_Click(object sender, EventArgs e)
        {
            seleccionadorDeTurno(jugador1);
        }

        private void Comienzaj2_Click(object sender, EventArgs e)
        {
            seleccionadorDeTurno(jugador2);
        }

        private void ComienzaAleatorio_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            bool radombool = random.Next(0, 2) > 0;

            if (radombool)
            {
                seleccionadorDeTurno(jugador1);
            }
            else
            {
                seleccionadorDeTurno(jugador2);
            }
        }

        private void AccionCasillero(object sender, EventArgs e)
        {
            Button casillero = (Button)sender;           

            switch (casillero.Name)
            {
                case "b1":
                    tablero.jugar(turno.Ficha, 1);
                    break;
                case "b2":
                    tablero.jugar(turno.Ficha, 2);
                    break;
                case "b3":
                    tablero.jugar(turno.Ficha, 3);
                    break;
                case "b4":
                    tablero.jugar(turno.Ficha, 4);
                    break;
                case "b5":
                    tablero.jugar(turno.Ficha, 5);
                    break;
                case "b6":
                    tablero.jugar(turno.Ficha, 6);
                    break;
                case "b7":
                    tablero.jugar(turno.Ficha, 7);
                    break;
                case "b8":
                    tablero.jugar(turno.Ficha, 8);
                    break;
                case "b9":
                    tablero.jugar(turno.Ficha, 9);
                    break;                                                       
            }

            casillero.Enabled = false;
            if (turno.Ficha.Equals(Ficha.O))
            {
                casillero.Image = Tateti_con_interface.Properties.Resources.circulo;
            }
            else
            {
                casillero.Image = Tateti_con_interface.Properties.Resources.cruz;
            }
            casillero.ImageAlign = ContentAlignment.MiddleCenter;
        }


    }
}
