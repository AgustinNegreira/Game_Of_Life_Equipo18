using System;
using System.IO;
using System.Text;

namespace Library
{
    public class Tablero
    {
        public bool[,] b;
        public int width;
        public int height;

        // Constructor para inicializar el tablero
        public Tablero(bool[,] b)
        {
            this.b = b;
            width = b.GetLength(0);
            height = b.GetLength(1);
        }
    }

    public class LectorArchivo
    {
        public Tablero LeerArchivo(string url)
        {
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
            bool[,] board = new bool[contentLines.Length, contentLines[0].Length];

            for (int y = 0; y < contentLines.Length; y++)
            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        board[y, x] = true;
                    }
                }
            }

            return new Tablero(board);
        }
    }

    public class JuegoDeLaVida
    {
        public void AvanzarGeneracion(Tablero tablero)
        {
            int width = tablero.width;
            int height = tablero.height;
            bool[,] cloneboard = new bool[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int aliveNeighbors = ContarVecinosVivos(tablero, x, y);

                    if (tablero.b[x, y])
                    {
                        if (aliveNeighbors < 2 || aliveNeighbors > 3)
                        {
                            cloneboard[x, y] = false;
                        }
                        else
                        {
                            cloneboard[x, y] = true;
                        }
                    }
                    else
                    {
                        if (aliveNeighbors == 3)
                        {
                            cloneboard[x, y] = true;
                        }
                    }
                }
            }

            tablero.b = cloneboard;
        }

        private int ContarVecinosVivos(Tablero tablero, int x, int y)
        {
            int width = tablero.width;
            int height = tablero.height;
            int aliveNeighbors = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < width && j >= 0 && j < height && !(i == x && j == y) && tablero.b[i, j])
                    {
                        aliveNeighbors++;
                    }
                }
            }

            return aliveNeighbors;
        }
    }

    public class ImprimirTablero
    {
        public void MostrarTablero(Tablero tablero)
        {
            StringBuilder s = new StringBuilder();

            for (int y = 0; y < tablero.height; y++)
            {
                for (int x = 0; x < tablero.width; x++)
                {
                    if (tablero.b[x, y])
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }
                s.Append("\n");
            }

            Console.Clear();
            Console.WriteLine(s.ToString());
        }
    }
}

