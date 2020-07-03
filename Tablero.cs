using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tateti_con_interface
{
    class Tablero
    {
        private string[,] tablero;

        public Tablero()
        {
            tablero = new string[3, 3];
            
            tablero[0, 0] = "1";
            tablero[0, 1] = "2";
            tablero[0, 2] = "3";
            tablero[1, 0] = "4";
            tablero[1, 1] = "5";
            tablero[1, 2] = "6";
            tablero[2, 0] = "7";
            tablero[2, 1] = "8";
            tablero[2, 2] = "9";
        }

        public void imprimirTablero()
        {
            for (int f = 0; f < 3; f++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Console.Write(tablero[f, c] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("---------");
            }
        }

        public void setPosicion(string posicion, Ficha ficha)
        {
            switch (posicion)
            {
                case "1":
                    tablero[0, 0] = ficha.ToString();
                    break;
                case "2":
                    tablero[0, 1] = ficha.ToString();
                    break;
                case "3":
                    tablero[0, 2] = ficha.ToString();
                    break;
                case "4":
                    tablero[1, 0] = ficha.ToString();
                    break;
                case "5":
                    tablero[1, 1] = ficha.ToString();
                    break;
                case "6":
                    tablero[1, 2] = ficha.ToString();
                    break;
                case "7":
                    tablero[2, 0] = ficha.ToString();
                    break;
                case "8":
                    tablero[2, 1] = ficha.ToString();
                    break;
                case "9":
                    tablero[2, 2] = ficha.ToString();
                    break;
            }
        }

        public string getPosicion(string posicion)
        {
            switch (posicion)
            {
                case "1":
                    return tablero[0, 0];
                case "2":
                    return tablero[0, 1];
                case "3":
                    return tablero[0, 2];
                case "4":
                    return tablero[1, 0];
                case "5":
                    return tablero[1, 1];
                case "6":
                    return tablero[1, 2];
                case "7":
                    return tablero[2, 0];
                case "8":
                    return tablero[2, 1];
                case "9":
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
                    return true;
                }
            }
            // Verificar columnas
            for (int c = 0; c < 3; c++)
            {
                if (tablero[0, c].Equals(tablero[1, c]) && tablero[1, c].Equals(tablero[2, c]))
                {
                    return true;
                }
            }
            //Verificar diagonal principal
            if (tablero[0, 0].Equals(tablero[1, 1]) && tablero[1, 1].Equals(tablero[2, 2]))
            {
                return true;
            }
            //Verificar diagonal opuesta
            if (tablero[0, 2].Equals(tablero[1, 1]) && tablero[1, 1].Equals(tablero[2, 0]))
            {
                return true;
            }

            return false;
        }

        public bool hayEmpate()
        {
            for (int p = 1; p <= 9; p++)
            {
                if (!PosicionOcupada(p.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        public bool PosicionOcupada(string posicion)
        {
            return (getPosicion(posicion).Equals("O") || getPosicion(posicion).Equals("X"));
        }

        public bool jugar(Ficha ficha, string posición)
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
