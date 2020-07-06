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
                button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            }           
        }

        private void seleccionadorDeTurno(object sender, EventArgs e)
        {
            foreach (Control c in SeleccionadorDeTurno.Controls)
            {
                c.Visible = false;
            }
            
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

            switch (((Button)sender).Name)
            {
                case "Comienzaj1":
                    this.turno = jugador1;
                    break;
                case "Comienzaj2":
                    this.turno = jugador2;
                    break;
                case "ComienzaAleatorio":
                    Random random = new Random();
                    bool randombool = random.Next(0, 1) > 0;
                    if (randombool)
                    {
                        this.turno = jugador1;
                    }
                    else
                    {
                        this.turno = jugador2;
                    }
                    break;
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

            if (tablero.hayEmpate())
            {
                string mensaje = "¡EMPATE, MEJOR SUERTE LA PROXIMA!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(mensaje, "Resultado", buttons);
                Reset.Text = "Jugar de nuevo";
            }
            else if(tablero.hayGanador())
            {
                string mensaje = "¡" + turno.Nombre.ToUpper() + " GANÓ LA PARTIDA!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(mensaje, "Resultado", buttons);
                foreach (Button button in botones)
                {
                    button.Enabled = false;
                }
                Reset.Text = "Jugar de nuevo";
            }

            casillero.Enabled = false;
            if (turno.Ficha.Equals(Ficha.O))
            {
                casillero.BackgroundImage = Tateti_con_interface.Properties.Resources.circulo;
                turno = jugador2;
            }
            else
            {
                casillero.BackgroundImage = Tateti_con_interface.Properties.Resources.cruz;
                turno = jugador1;
            }
            casillero.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Reiniciar(object sender, EventArgs e)
        {
            foreach(Button button in botones)
            {
                button.BackgroundImage = null;
                button.Enabled = false;
            }
            tablero = new Tablero();
            foreach (Control c in SeleccionadorDeTurno.Controls)
            {
                if (c.Text == "¡A JUGAR!")
                {
                    c.Visible = false;
                }
                else
                {
                    c.Visible = true;
                }
            
            }
            
        }
    }
}
