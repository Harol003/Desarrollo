
using System;

// Ejemplo 6: ciclo while
public class Ejemplo06CiclosWhile
{
    public static void Ejecutar()
    {
        Console.WriteLine("CICLO WHILE");
        Console.WriteLine("-----------");

        // Inicializamos el contador
        int numero = 1;
        int suma = 0;

        // Repetimos mientras la condicion sea verdadera
        while (numero <= 5)
        {
            Console.WriteLine("Numero: " + numero);

            // Acumulamos el valor actual
            suma += numero;

            // Aumentamos el contador
            numero++;
        }

        Console.WriteLine("Suma total: " + suma);
    }
}
