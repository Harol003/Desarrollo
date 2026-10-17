
using System;

// Ejemplo 8: metodos con parametros y retorno
public class Ejemplo08Metodos
{
    public static void Ejecutar()
    {
        Console.WriteLine("METODOS");
        Console.WriteLine("-------");

        // Solicitamos dos numeros
        Console.Write("Primer numero: ");

        if (!double.TryParse(Console.ReadLine(), out double a))
        {
            Console.WriteLine("Dato no valido.");
            return;
        }

        Console.Write("Segundo numero: ");

        if (!double.TryParse(Console.ReadLine(), out double b))
        {
            Console.WriteLine("Dato no valido.");
            return;
        }

        // Llamamos a los metodos matematicos
        Console.WriteLine("Suma: " + Sumar(a, b));
        Console.WriteLine("Resta: " + Restar(a, b));
        Console.WriteLine("Multiplicacion: " + Multiplicar(a, b));

        // Verificamos que no se divida entre cero
        if (b != 0)
        {
            Console.WriteLine("Division: " + Dividir(a, b));
        }
        else
        {
            Console.WriteLine("No se puede dividir entre cero.");
        }
    }

    // Metodo que devuelve la suma
    public static double Sumar(double a, double b)
    {
        return a + b;
    }

    // Metodo que devuelve la resta
    public static double Restar(double a, double b)
    {
        return a - b;
    }

    // Metodo que devuelve la multiplicacion
    public static double Multiplicar(double a, double b)
    {
        return a * b;
    }

    // Metodo que devuelve la division
    public static double Dividir(double a, double b)
    {
        return a / b;
    }
}
