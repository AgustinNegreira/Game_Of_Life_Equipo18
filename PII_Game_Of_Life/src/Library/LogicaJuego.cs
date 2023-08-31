using System;
using System.IO;

namespace PII_Game_Of_Life
{
    public class LogicaJuego
    {
        Interpreter Inter = new Interpreter();
        public bool[,] GenerarTablero()
        {
            string url = @"../../assets/board.txt";
            string contenido = File.ReadAllText(url);
            string[] contenido_lineas = contenido.Split('\n');
            bool[,] board = new bool[contenido_lineas.Length, contenido_lineas[0].Length];
            for (int  y=0; y<contenido_lineas.Length;y++)
            {
                for (int x=0; x<contenido_lineas[y].Length; x++)
                {
                    if(contenido_lineas[y][x]=='1')
                    {
                        board[x,y]=true;
                    }
                }
            }
            this.Tablero = board;
            return board;
        }
        public bool[,] Tablero {get;set;} 

        
        public bool[,] Juego()
        {
            bool[,] table1 = this.Tablero;
            while (true)
            {
            
            bool[,] juego_board = table1;
            int board_ancho = juego_board.GetLength(0);
            int board_alto = juego_board.GetLength(1);

            bool[,] clonar = new bool[board_ancho, board_alto];
            
            for (int x = 0; x < board_ancho; x++)
            {
                for (int y = 0; y < board_alto; y++)
                {
                    int vecino_vivos = 0;
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {
                            if(i>=0 && i<board_ancho && j>=0 && j < board_alto && juego_board[i,j])
                            {
                                vecino_vivos++;
                            }
                        }
                    }
                    if(juego_board[x,y])
                    {
                        vecino_vivos--;
                    }
                    if (juego_board[x,y] && vecino_vivos < 2)
                    {
                        //Celula muere por baja población
                        clonar[x,y] = false;
                    }
                    else if (juego_board[x,y] && vecino_vivos > 3)
                    {
                        //Celula muere por sobrepoblación
                        clonar[x,y] = false;
                    }
                    else if (!juego_board[x,y] && vecino_vivos == 3)
                    {
                        //Celula nace por reproducción
                        clonar[x,y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        clonar[x,y] = juego_board[x,y];
                    }
                }
            }
            juego_board = clonar; 
            this.Tablero = juego_board;
            clonar = new bool[board_ancho, board_alto];
            
            return juego_board;
            }
        }

    }
}
