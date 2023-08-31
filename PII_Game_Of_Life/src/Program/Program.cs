using System;


namespace PII_Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            LogicaJuego juego1 = new LogicaJuego();
            juego1.GenerarTablero();
            ImprimirTablero a = new ImprimirTablero();
            
            a.Imprimir();
            
            
        }
    }
}
