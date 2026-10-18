
namespace CalculadoraEducativa;

public class CalculadoraVista
{
    public void MostrarBienvenida()
    {
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine("     CALCULADORA EDUCATIVA");
        Console.WriteLine("================================");
    }

    public string LeerDato(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine() ?? "";
    }

    public void MostrarOperacion(
        int numero1, int numero2, int operacion)
    {
        string simbolo = operacion switch
        {
            1 => "+",
            2 => "-",
            3 => "*",
            4 => "/",
            _ => "?"
        };

        Console.WriteLine(
            $"\nResuelve: {numero1} {simbolo} {numero2}");
    }

    public void MostrarMensaje(string mensaje)
    {
        Console.WriteLine(mensaje);
    }

    public void MostrarResultadoCorrecto(double resultado)
    {
        Console.WriteLine("El resultado correcto era: " + resultado);
    }
}
