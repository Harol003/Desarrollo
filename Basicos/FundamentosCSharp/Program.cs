
using System;

// Programa principal del curso de programacion en C#

bool continuar = true;

while (continuar)
{
    Console.Clear();

    Console.WriteLine("========================================");
    Console.WriteLine("       CURSO DE PROGRAMACION C#");
    Console.WriteLine("========================================");
    Console.WriteLine("1. Variables y tipos de datos");
    Console.WriteLine("2. Operadores matematicos");
    Console.WriteLine("3. Condicionales if y else");
    Console.WriteLine("4. Calculadora educativa");
    Console.WriteLine("5. Ciclo for");
    Console.WriteLine("6. Ciclo while");
    Console.WriteLine("7. Arreglos");
    Console.WriteLine("8. Metodos");
    Console.WriteLine("9. Simulacion con micro:bit");
    Console.WriteLine("10. Salir");
    Console.WriteLine("----------------------------------------");
    Console.Write("Selecciona un ejemplo: ");

    // Validamos que el usuario ingrese un numero entero
    if (!int.TryParse(Console.ReadLine(), out int opcion))
    {
        Console.WriteLine("Debes ingresar un numero valido.");
        Console.ReadLine();
        continue;
    }

    Console.Clear();

    // Seleccionamos el ejemplo que se va a ejecutar
    switch (opcion)
    {
        case 1:
            Ejemplo01Variables.Ejecutar();
            break;

        case 2:
            Ejemplo02Operadores.Ejecutar();
            break;

        case 3:
            Ejemplo03Condicionales.Ejecutar();
            break;

        case 4:
            Ejemplo04Calculadora.Ejecutar();
            break;

        case 5:
            Ejemplo05CiclosFor.Ejecutar();
            break;

        case 6:
            Ejemplo06CiclosWhile.Ejecutar();
            break;

        case 7:
            Ejemplo07Arreglos.Ejecutar();
            break;

        case 8:
            Ejemplo08Metodos.Ejecutar();
            break;

        case 9:
            Ejemplo09Microbit.Ejecutar();
            break;

        case 10:
            continuar = false;
            Console.WriteLine("Gracias por aprender C#.");
            continue;

        default:
            Console.WriteLine("Opcion no valida.");
            break;
    }

    // Esperamos a que el usuario termine de revisar el resultado
    Console.WriteLine("\nPresiona ENTER para regresar al menu.");
    Console.ReadLine();
}

Console.WriteLine("Programa finalizado.");
