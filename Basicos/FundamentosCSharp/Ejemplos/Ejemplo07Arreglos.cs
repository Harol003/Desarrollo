
using System;

// Ejemplo 7: arreglos
public class Ejemplo07Arreglos
{
    public static void Ejecutar()
    {
        Console.WriteLine("ARREGLOS");
        Console.WriteLine("--------");

        // Creamos un arreglo con cinco notas
        double[] notas = new double[5];

        // Solicitamos las notas
        for (int i = 0; i < notas.Length; i++)
        {
            Console.Write("Ingresa la nota " + (i + 1) + ": ");

            if (!double.TryParse(Console.ReadLine(), out notas[i]) ||
                notas[i] < 0 || notas[i] > 5)
            {
                Console.WriteLine("Nota no valida.");
                return;
            }
        }

        // Calculamos la suma y la nota mayor
        double suma = 0;
        double mayor = notas[0];

        for (int i = 0; i < notas.Length; i++)
        {
            suma += notas[i];

            if (notas[i] > mayor)
            {
                mayor = notas[i];
            }
        }

        // Mostramos los resultados
        Console.WriteLine("Promedio: " + (suma / notas.Length).ToString("F2"));
        Console.WriteLine("Nota mayor: " + mayor);
    }
}
