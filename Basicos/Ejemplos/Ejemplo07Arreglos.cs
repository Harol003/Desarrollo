
using System;

// Clase para aprender a utilizar arreglos
public class Ejemplo07Arreglos
{
    public static void Ejecutar()
    {
        Console.WriteLine("EJEMPLO 7: ARREGLOS");
        Console.WriteLine("-------------------");

        // Creamos un arreglo con cinco notas
        double[] notas = new double[5];

        // Solicitamos las notas al estudiante
        for (int i = 0; i < notas.Length; i++)
        {
            Console.Write("Ingresa la nota " + (i + 1) + ": ");

            // Validamos que la nota sea numerica y este entre 0 y 5
            if (!double.TryParse(Console.ReadLine(), out notas[i]) ||
                notas[i] < 0 || notas[i] > 5)
            {
                Console.WriteLine("Nota no valida.");
                return;
            }
        }

        // Declaramos las variables para los calculos
        double suma = 0;
        double notaMayor = notas[0];

        // Recorremos el arreglo para procesar las notas
        for (int i = 0; i < notas.Length; i++)
        {
            suma += notas[i];

            // Comparamos cada nota con la nota mayor actual
            if (notas[i] > notaMayor)
            {
                notaMayor = notas[i];
            }
        }

        // Calculamos el promedio
        double promedio = suma / notas.Length;

        // Mostramos los resultados
        Console.WriteLine("\nRESULTADOS");

        for (int i = 0; i < notas.Length; i++)
        {
            Console.WriteLine(
                "Nota " + (i + 1) + ": " + notas[i]);
        }

        Console.WriteLine("Promedio: " + promedio.ToString("F2"));
        Console.WriteLine("Nota mas alta: " + notaMayor);

        // Reto para el estudiante
        Console.WriteLine("\nRETO:");
        Console.WriteLine("Encuentra tambien la nota mas baja.");
    }
}
