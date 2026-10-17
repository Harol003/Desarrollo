
using System;

// Ejemplo 9: simulacion de un sistema con micro:bit
public class Ejemplo09Microbit
{
    public static void Ejecutar()
    {
        Console.WriteLine("SIMULACION DE SENSOR DE LUZ");
        Console.WriteLine("---------------------------");

        // Solicitamos un nivel de luz simulado
        Console.Write("Nivel de luz entre 0 y 255: ");

        if (!int.TryParse(Console.ReadLine(), out int nivelLuz) ||
            nivelLuz < 0 || nivelLuz > 255)
        {
            Console.WriteLine("Nivel no valido.");
            return;
        }

        // Evaluamos el nivel de iluminacion
        bool alarmaActivada;

        if (nivelLuz < 80)
        {
            alarmaActivada = true;
        }
        else
        {
            alarmaActivada = false;
        }

        // Mostramos el estado del sistema
        Console.WriteLine("Lectura del sensor: " + nivelLuz);

        if (alarmaActivada)
        {
            Console.WriteLine("Ambiente oscuro.");
            Console.WriteLine("Alarma activada.");
        }
        else
        {
            Console.WriteLine("Iluminacion suficiente.");
            Console.WriteLine("Alarma desactivada.");
        }
    }
}
