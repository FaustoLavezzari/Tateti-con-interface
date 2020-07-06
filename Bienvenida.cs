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
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private int Validaciones()
        {
            
            if (Nombrej1.Text.Trim().Equals(string.Empty) || Nombrej2.Text.Trim().Equals(string.Empty))
            {
                return 0;
            }
            else if (SeleccionadorFichaj1.SelectedIndex < 0 || SeleccionadorFichaj2.SelectedIndex < 0 
                || SeleccionadorFichaj1.SelectedItem.Equals(SeleccionadorFichaj2.SelectedItem))
            {
                return 1;
            }

            return 2;
        }

        private void Continuar_Click(object sender, EventArgs e)
        {
            switch (Validaciones())
            {
                case 0:
                    {
                        string mensaje = "Ambos jugadores deben ingresar un nombre";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(mensaje, "Error", buttons);
                        break;
                    }
                case 1:
                    {
                        string mensaje = "Las fichas deben ser distintas";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(mensaje, "Error", buttons);
                        break;
                    }

                case 2:
                    {
                        Jugador jugador1 = new Jugador(Nombrej1.Text.Trim(), (Ficha)SeleccionadorFichaj1.SelectedItem);
                        Jugador jugador2 = new Jugador(Nombrej2.Text.Trim(), (Ficha)SeleccionadorFichaj2.SelectedItem);
                        Juego ventanaJuego = new Juego(jugador1, jugador2);
                        ventanaJuego.Show();
                        this.Close();
                        break;
                    }
            }
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {
            SeleccionadorFichaj1.DropDownStyle = ComboBoxStyle.DropDownList;
            SeleccionadorFichaj2.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (Ficha f in Enum.GetValues(typeof(Ficha)))
            {
                if(f != Ficha.Y) {
                    SeleccionadorFichaj1.Items.Add(f);
                    SeleccionadorFichaj2.Items.Add(f);
                }
            }                 
        }
    } 
}
