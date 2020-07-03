using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tateti_con_interface
{
    class Jugador
    {
        private string nombre;
        private Ficha ficha;

        public Jugador(string nombre, Ficha ficha)
        {
            this.nombre = nombre;
            this.ficha = ficha;
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
        }

    }
}
