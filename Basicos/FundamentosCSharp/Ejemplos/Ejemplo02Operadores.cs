
using System;

// Ejemplo 2: operadores matematicos
public class Ejemplo02Operadores
{
    public static void Ejecutar()
    {
        Console.WriteLine("OPERADORES MATEMATICOS");
        Console.WriteLine("----------------------");

        // Declaramos dos numeros enteros
        int numero1 = 20;
        int numero2 = 6;

        // Realizamos las operaciones matematicas
        Console.WriteLine("Numero 1: " + numero1);
        Console.WriteLine("Numero 2: " + numero2);
        Console.WriteLine("Suma: " + (numero1 + numero2));
        Console.WriteLine("Resta: " + (numero1 - numero2));
        Console.WriteLine("Multiplicacion: " + (numero1 * numero2));
        Console.WriteLine("Division entera: " + (numero1 / numero2));
        Console.WriteLine("Residuo: " + (numero1 % numero2));

        // Comparamos los dos numeros
        Console.WriteLine("Numero 1 es mayor: " + (numero1 > numero2));
        Console.WriteLine("Son iguales: " + (numero1 == numero2));
    }
}
