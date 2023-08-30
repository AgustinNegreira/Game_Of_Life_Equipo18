using System;
using System.IO;
using System.Text;

namespace PII_Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
         

        }
public class Lector
{
    public Lector()
    {
        string url = "ruta del archivo";
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
    }
}


    }


}