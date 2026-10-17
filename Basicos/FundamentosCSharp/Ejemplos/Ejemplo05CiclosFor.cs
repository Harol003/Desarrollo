
using System;

// Ejemplo 5: ciclo for
public class Ejemplo05CiclosFor
{
    public static void Ejecutar()
    {
        Console.WriteLine("CICLO FOR");
        Console.WriteLine("---------");

        // Recorremos los numeros del 1 al 10
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("Numero: " + i);
        }

        // Sumamos los numeros del 1 al 10
        int suma = 0;

        for (int i = 1; i <= 10; i++)
        {
            suma += i;
        }

        Console.WriteLine("La suma total es: " + suma);
    }
}
