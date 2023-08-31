using System;
using System.Text;
using System.Threading;


namespace PII_Game_Of_Life
{
    public class ImprimirTablero
    {

        public string Imprimir()
        {
            LogicaJuego juego1 = new LogicaJuego();
            juego1.GenerarTablero();

           
            while (true)
            {
             bool[,] table = juego1.Juego();
            bool[,] b = table; //variable que representa el tablero
            int width = table.GetLength(0); //variabe que representa el ancho del tablero
            int height = table.GetLength(1); //variabe que representa altura del tablero
            bool k = true;
            while (k)
            {
                Console.Clear();
                StringBuilder s = new StringBuilder();
                for (int y = 0; y<height;y++)
                {
                    for (int x = 0; x<width; x++)
                    {
                        if(b[x,y])
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
                Console.WriteLine(s.ToString());
                //=================================================
                //Invocar método para calcular siguiente generación
                //=================================================
                Thread.Sleep(300);
                k =false;
            }
            }
        }
    }
}
