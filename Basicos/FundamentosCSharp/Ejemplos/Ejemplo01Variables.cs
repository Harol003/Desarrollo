
using System;

// Ejemplo 1: tipos de datos y variables
public class Ejemplo01Variables
{
    public static void Ejecutar()
    {
        Console.WriteLine("TIPOS DE DATOS Y VARIABLES");
        Console.WriteLine("--------------------------");

        // Declaramos variables de diferentes tipos
        string nombre = "Carlos";
        int edad = 15;
        double estatura = 1.65;
        char grupo = 'A';
        bool matriculado = true;

        // Mostramos el contenido de las variables
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("Estatura: " + estatura);
        Console.WriteLine("Grupo: " + grupo);
        Console.WriteLine("Matriculado: " + matriculado);

        // Modificamos el valor de una variable
        edad = 16;

        Console.WriteLine("\nNueva edad: " + edad);
    }
}
