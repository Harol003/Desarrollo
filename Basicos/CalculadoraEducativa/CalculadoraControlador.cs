
namespace CalculadoraEducativa;

public class CalculadoraControlador
{
    private readonly CalculadoraModelo modelo;
    private readonly CalculadoraVista vista;

    public CalculadoraControlador(
        CalculadoraModelo modelo,
        CalculadoraVista vista)
    {
        this.modelo = modelo;
        this.vista = vista;
    }

    public void Iniciar()
    {
        bool continuar = true;

        vista.MostrarBienvenida();

        while (continuar)
        {
            if (!LeerEntero("Escribe el primer numero: ",
                    out int numero1))
                continue;

            if (!LeerEntero("Escribe el segundo numero: ",
                    out int numero2))
                continue;

            if (!LeerEntero(
                    "Operacion (1 suma, 2 resta, 3 multiplicacion, 4 division): ",
                    out int operacion))
                continue;

            if (operacion < 1 || operacion > 4)
            {
                vista.MostrarMensaje("Operacion no valida.");
                continue;
            }

            if (operacion == 4 && numero2 == 0)
            {
                vista.MostrarMensaje(
                    "No se puede dividir entre cero.");
                continue;
            }

            modelo.Numero1 = numero1;
            modelo.Numero2 = numero2;
            modelo.Operacion = operacion;

            vista.MostrarOperacion(
                modelo.Numero1,
                modelo.Numero2,
                modelo.Operacion);

            if (!modelo.Calcular())
            {
                vista.MostrarMensaje(
                    "No se pudo realizar la operacion.");
                continue;
            }

            string entrada = vista.LeerDato(
                "Cual crees que es el resultado? ");

            if (!double.TryParse(entrada, out double respuesta))
            {
                vista.MostrarMensaje(
                    "Debes escribir un resultado numerico.");
            }
            else if (modelo.VerificarRespuesta(respuesta))
            {
                vista.MostrarMensaje(
                    "¡Excelente! Tu respuesta es correcta.");
            }
            else
            {
                vista.MostrarMensaje(
                    "Tu respuesta es incorrecta.");
                vista.MostrarResultadoCorrecto(
                    modelo.Resultado);
            }

            string otra = vista.LeerDato(
                "\nQuieres resolver otra operacion? (s/n): ");

            continuar = otra.Trim().Equals(
                "s", StringComparison.OrdinalIgnoreCase);
        }

        vista.MostrarMensaje(
            "Gracias por practicar matematicas.");
    }

    private bool LeerEntero(string mensaje, out int numero)
    {
        string entrada = vista.LeerDato(mensaje);

        if (int.TryParse(entrada, out numero))
            return true;

        vista.MostrarMensaje(
            "Debes ingresar un numero entero valido.");

        return false;
    }
}
