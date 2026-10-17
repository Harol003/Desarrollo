
using System;

// Ejemplo 3: condicionales if, else if y else
public class Ejemplo03Condicionales
{
    public static void Ejecutar()
    {
        Console.WriteLine("CONDICIONALES");
        Console.WriteLine("-------------");

        // Solicitamos la nota
        Console.Write("Ingresa una nota entre 0 y 5: ");

        if (!double.TryParse(Console.ReadLine(), out double nota))
        {
            Console.WriteLine("Debes ingresar un numero.");
            return;
        }

        // Verificamos que la nota este dentro del rango permitido
        if (nota < 0 || nota > 5)
        {
            Console.WriteLine("La nota no es valida.");
        }
        else if (nota < 3)
        {
            Console.WriteLine("Desempeno bajo.");
        }
        else if (nota < 4)
        {
            Console.WriteLine("Desempeno basico.");
        }
        else if (nota < 4.6)
        {
            Console.WriteLine("Desempeno alto.");
        }
        else
        {
            Console.WriteLine("Desempeno superior.");
        }
    }
}
