using System;
<<<<<<< Updated upstream
using System.IO;
using System.Text;
=======
using Library;
>>>>>>> Stashed changes

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {

            string archivoTablero = @""; // Cambiar esto por la ruta del archivo

            LectorArchivo lector = new LectorArchivo();
            Tablero tablero = lector.LeerArchivo(archivoTablero);

            JuegoDeLaVida juego = new JuegoDeLaVida();
            ImprimirTablero impresor = new ImprimirTablero();

            while (true)
            {
                impresor.MostrarTablero(tablero);
                juego.AvanzarGeneracion(tablero);
                System.Threading.Thread.Sleep(300); // Pausa de 300 milisegundos
            }

        }

    }
}
