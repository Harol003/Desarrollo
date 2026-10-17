
using System;

// Clase para aprender el ciclo while
public class Ejemplo06CiclosWhile
{
    public static void Ejecutar()
    {
        Console.WriteLine("EJEMPLO 6: CICLO WHILE");
        Console.WriteLine("----------------------");

        // Declaramos las variables de control
        int numero = 1;
        int suma = 0;

        // Repetimos mientras el numero sea menor o igual a 5
        while (numero <= 5)
        {
            Console.WriteLine("Numero actual: " + numero);

            // Acumulamos el valor del numero
            suma = suma + numero;

            // Aumentamos el contador para evitar un ciclo infinito
            numero++;
        }

        // Mostramos la suma calculada
        Console.WriteLine("\nLa suma total es: " + suma);

        // Reto para el estudiante
        Console.WriteLine("\nRETO:");
        Console.WriteLine("Modifica el ciclo para sumar del 1 al 20.");
    }
}
