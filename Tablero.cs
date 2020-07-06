using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tateti_con_interface
{
    public class Tablero
    {
        private Ficha[,] tablero;

        public Tablero()
        {
            tablero = new Ficha[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    tablero[i,j] = Ficha.Y;
        }
       
        public void setPosicion(int posicion, Ficha ficha)
        {
            switch (posicion)
            {
                case 1:
                    tablero[0, 0] = ficha;
                    break;
                case 2:
                    tablero[0, 1] = ficha;
                    break;
                case 3:
                    tablero[0, 2] = ficha;
                    break;
                case 4:
                    tablero[1, 0] = ficha;
                    break;
                case 5:
                    tablero[1, 1] = ficha;
                    break;
                case 6:
                    tablero[1, 2] = ficha;
                    break;
                case 7:
                    tablero[2, 0] = ficha;
                    break;
                case 8:
                    tablero[2, 1] = ficha;
                    break;
                case 9:
                    tablero[2, 2] = ficha;
                    break;
            }
        }

        public Ficha getPosicion(int posicion)
        {
            switch (posicion)
            {
                case 1:
                    return tablero[0, 0];
                case 2:
                    return tablero[0, 1];
                case 3:
                    return tablero[0, 2];
                case 4:
                    return tablero[1, 0];
                case 5:
                    return tablero[1, 1];
                case 6:
                    return tablero[1, 2];
                case 7:
                    return tablero[2, 0];
                case 8:
                    return tablero[2, 1];
                case 9:
                    return tablero[2, 2];
            }

            throw new ArgumentOutOfRangeException();

        }

        public bool hayGanador()
        {
            // Verificiar filas
            for (int f = 0; f < 3; f++)
            {
                if (tablero[f, 0].Equals(tablero[f, 1]) && tablero[f, 1].Equals(tablero[f, 2]))
                {
                    if ((tablero[f, 0] != Ficha.Y) && (tablero[f, 1] != Ficha.Y) && (tablero[f, 2] != Ficha.Y))
                        return true;
                }
            }
            // Verificar columnas
            for (int c = 0; c < 3; c++)
            {
                if (tablero[0, c].Equals(tablero[1, c]) && tablero[1, c].Equals(tablero[2, c]))
                {
                    if ((tablero[0, c] != Ficha.Y) && (tablero[1, c] != Ficha.Y) && (tablero[2, c] != Ficha.Y))
                        return true;
                }
            }
            //Verificar diagonal principal
            if (tablero[0, 0].Equals(tablero[1, 1]) && tablero[1, 1].Equals(tablero[2, 2]))
            {
                if ((tablero[0, 0] != Ficha.Y) && (tablero[1, 1] != Ficha.Y) && (tablero[2, 2] != Ficha.Y))
                    return true;
            }
            //Verificar diagonal opuesta
            if (tablero[0, 2].Equals(tablero[1, 1]) && tablero[1, 1].Equals(tablero[2, 0]))
            {
                if ((tablero[0, 2] != Ficha.Y) && (tablero[1, 1] != Ficha.Y) && (tablero[2, 0] != Ficha.Y))
                    return true;
            }
            return false;
        }

        public bool hayEmpate()
        {
            for (int p = 1; p <= 9; p++)
            {
                if (!PosicionOcupada(p))
                {
                    return false;
                }
            }
            return true;
        }

        private bool PosicionOcupada(int posicion)
        {
            return (getPosicion(posicion).Equals(Ficha.O) || getPosicion(posicion).Equals(Ficha.X));
        }

        public bool jugar(Ficha ficha, int posición)
        {
            if (!PosicionOcupada(posición))
            {
                setPosicion(posición, ficha);
                return true;
            }
            return false;
        }
    }
}
