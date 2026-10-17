
using System;

// Ejemplo 4: calculadora educativa
public class Ejemplo04Calculadora
{
    public static void Ejecutar()
    {
        Console.WriteLine("CALCULADORA EDUCATIVA");
        Console.WriteLine("---------------------");

        // Creamos el generador de numeros aleatorios
        Random aleatorio = new Random();

        // Generamos dos numeros
        int numero1 = aleatorio.Next(1, 21);
        int numero2 = aleatorio.Next(1, 21);

        // Mostramos el menu de operaciones
        Console.WriteLine("1. Suma");
        Console.WriteLine("2. Resta");
        Console.WriteLine("3. Multiplicacion");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Modulo");

        Console.Write("Selecciona una operacion: ");

        if (!int.TryParse(Console.ReadLine(), out int opcion))
        {
            Console.WriteLine("Opcion no valida.");
            return;
        }

        // Calculamos el resultado sin mostrarlo al estudiante
        double resultadoCorrecto;

        switch (opcion)
        {
            case 1:
                resultadoCorrecto = numero1 + numero2;
                break;

            case 2:
                resultadoCorrecto = numero1 - numero2;
                break;

            case 3:
                resultadoCorrecto = numero1 * numero2;
                break;

            case 4:
                // Creamos una division con resultado entero
                numero2 = aleatorio.Next(1, 13);
                resultadoCorrecto = aleatorio.Next(1, 13);
                numero1 = numero2 * (int)resultadoCorrecto;
                break;

            case 5:
                resultadoCorrecto = numero1 % numero2;
                break;

            default:
                Console.WriteLine("Opcion no valida.");
                return;
        }

        // Mostramos la operacion seleccionada
        string simbolo = "";

        switch (opcion)
        {
            case 1:
                simbolo = "+";
                break;
            case 2:
                simbolo = "-";
                break;
            case 3:
                simbolo = "*";
                break;
            case 4:
                simbolo = "/";
                break;
            case 5:
                simbolo = "%";
                break;
        }

        Console.WriteLine(
            "\nResuelve: " + numero1 + " " + simbolo + " " + numero2);

        // Solicitamos primero la respuesta del estudiante
        Console.Write("Tu respuesta: ");

        if (!double.TryParse(Console.ReadLine(), out double respuesta))
        {
            Console.WriteLine("Debes ingresar un numero.");
            return;
        }

        // Comparamos la respuesta ingresada con la correcta
        if (Math.Abs(respuesta - resultadoCorrecto) < 0.000001)
        {
            Console.WriteLine("Correcto. Excelente trabajo!");
        }
        else
        {
            Console.WriteLine("Respuesta incorrecta.");
            Console.WriteLine("Resultado correcto: " + resultadoCorrecto);
        }
    }
}
