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
        private Jugador jugador1;
        private Jugador jugador2;
        private List<Ficha> fichas;


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
                case 2:
                    {
                        break;

                    }
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
            }
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {
            fichas = new List<Ficha>();
            foreach (Ficha f in Enum.GetValues(typeof(Ficha)))
            {
                fichas.Add(f);
            }
            SeleccionadorFichaj1.DataSource = fichas;
            SeleccionadorFichaj2.DataSource = fichas;           
        }
    } 
}
