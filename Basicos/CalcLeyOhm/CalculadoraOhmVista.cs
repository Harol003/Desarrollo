
namespace CalculadoraOhm;

public class CalculadoraOhmVista
{
    public void MostrarBienvenida()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("     CALCULADORA DE LA LEY DE OHM");
        Console.WriteLine("========================================");
        Console.WriteLine("Aprende electricidad resolviendo retos.");
        Console.WriteLine();
    }

    public void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("QUE MAGNITUD DESEAS CALCULAR?");
        Console.WriteLine("1. Voltaje (V)");
        Console.WriteLine("2. Corriente (I)");
        Console.WriteLine("3. Resistencia (R)");
        Console.WriteLine("4. Salir");
    }

    public string LeerTexto(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine() ?? "";
    }

    public void MostrarProblema(string problema)
    {
        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(problema);
        Console.WriteLine("----------------------------------------");
    }

    public void MostrarMensaje(string mensaje)
    {
        Console.WriteLine(mensaje);
    }

    public void MostrarResultado(bool correcto, double resultado, string unidad)
    {
        Console.WriteLine();

        if (correcto)
        {
            Console.WriteLine("¡Excelente! Tu respuesta es correcta.");
        }
        else
        {
            Console.WriteLine("Tu respuesta no es correcta.");
        }

        Console.WriteLine(
            $"El resultado correcto es: {resultado:0.####} {unidad}");
    }

    public void MostrarDespedida()
    {
        Console.WriteLine();
        Console.WriteLine("Gracias por aprender electronica.");
    }
}
