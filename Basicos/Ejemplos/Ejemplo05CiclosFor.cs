
using System;

// Clase para aprender el ciclo for
public class Ejemplo05CiclosFor
{
    public static void Ejecutar()
    {
        Console.WriteLine("EJEMPLO 5: CICLO FOR");
        Console.WriteLine("--------------------");

        // Mostramos los numeros del 1 al 10
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("Numero: " + i);
        }

        // Calculamos la suma de los numeros del 1 al 10
        int suma = 0;

        for (int i = 1; i <= 10; i++)
        {
            suma = suma + i;
        }

        // Mostramos el resultado de la suma
        Console.WriteLine("\nLa suma de 1 a 10 es: " + suma);

        // Reto para el estudiante
        Console.WriteLine("\nRETO:");
        Console.WriteLine("Modifica el ciclo para mostrar del 10 al 1.");
    }
}
