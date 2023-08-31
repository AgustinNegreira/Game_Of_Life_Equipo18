using System;
using System.IO;
using System.Collections;


namespace PII_Game_Of_Life
{
    public class Interpreter
    {
        public bool[,] GenerarTablero()  // Cambio en el tipo de retorno
        {
            string url = @"../../assets/board.txt";
            string contenido = File.ReadAllText(url);
            string[] contenido_lineas = contenido.Split('\n');
            bool[,] board = new bool[contenido_lineas.Length, contenido_lineas[0].Length];
            for (int y = 0; y < contenido_lineas.Length; y++)
            {
                for (int x = 0; x < contenido_lineas[y].Length; x++)
                {
                    if (contenido_lineas[y][x] == '1')
                    {
                        board[y, x] = true;  // Cambio en el orden de las coordenadas
                    }
                }
            }
            return board;
        }
    }
}
