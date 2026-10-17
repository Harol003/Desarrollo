
using System;

// Clase para aprender metodos
public class Ejemplo08Metodos
{
    // Metodo principal del ejemplo
    public static void Ejecutar()
    {
        Console.WriteLine("EJEMPLO 8: METODOS");
        Console.WriteLine("------------------");

        // Solicitamos dos numeros
        Console.Write("Ingresa el primer numero: ");

        if (!double.TryParse(Console.ReadLine(), out double numero1))
        {
            Console.WriteLine("Dato no valido.");
            return;
        }

        Console.Write("Ingresa el segundo numero: ");

        if (!double.TryParse(Console.ReadLine(), out double numero2))
        {
            Console.WriteLine("Dato no valido.");
            return;
        }

        // Llamamos al metodo y recibimos el resultado
        double resultado = Sumar(numero1, numero2);

        // Mostramos el resultado devuelto
        Console.WriteLine("La suma es: " + resultado);

        // Llamamos a un metodo que no devuelve un valor
        MostrarMensaje();

        // Reto para el estudiante
        Console.WriteLine("\nRETO:");
        Console.WriteLine("Crea un metodo para restar dos numeros.");
    }

    // Metodo que recibe dos parametros y devuelve su suma
    public static double Sumar(double a, double b)
    {
        return a + b;
    }

    // Metodo que muestra un mensaje y no devuelve un resultado
    public static void MostrarMensaje()
    {
        Console.WriteLine("La operacion ha finalizado.");
    }
}
