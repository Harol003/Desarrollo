
using System.Globalization;

namespace CalculadoraOhm;

public class CalculadoraOhmControlador
{
    private readonly CalculadoraOhmModelo modelo;
    private readonly CalculadoraOhmVista vista;

    public CalculadoraOhmControlador(
        CalculadoraOhmModelo modelo,
        CalculadoraOhmVista vista)
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
            vista.MostrarMenu();

            if (!LeerEntero("Selecciona una opcion: ", out int opcion))
            {
                vista.MostrarMensaje("Debes escribir un numero entero.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    ResolverVoltaje();
                    break;

                case 2:
                    ResolverCorriente();
                    break;

                case 3:
                    ResolverResistencia();
                    break;

                case 4:
                    continuar = false;
                    continue;

                default:
                    vista.MostrarMensaje("Opcion no valida.");
                    break;
            }

            vista.LeerTexto(
                "\nPresiona ENTER para regresar al menu...");

            Console.Clear();
        }

        vista.MostrarDespedida();
    }

    private void ResolverVoltaje()
    {
        double corriente = LeerNumeroPositivo(
            "Ingresa la corriente en amperios (A): ");

        double resistencia = LeerNumeroPositivo(
            "Ingresa la resistencia en ohmios (Ω): ");

        modelo.CalcularVoltaje(corriente, resistencia);

        vista.MostrarProblema(
            $"Calcula el voltaje: V = I x R\n" +
            $"Corriente = {corriente:0.####} A\n" +
            $"Resistencia = {resistencia:0.####} ohmios");

        EvaluarRespuesta();
    }

    private void ResolverCorriente()
    {
        double voltaje = LeerNumeroPositivo(
            "Ingresa el voltaje en voltios (V): ");

        double resistencia = LeerNumeroPositivo(
            "Ingresa la resistencia en ohmios (Ω): ");

        modelo.CalcularCorriente(voltaje, resistencia);

        vista.MostrarProblema(
            $"Calcula la corriente: I = V / R\n" +
            $"Voltaje = {voltaje:0.####} V\n" +
            $"Resistencia = {resistencia:0.####} ohmios");

        EvaluarRespuesta();
    }

    private void ResolverResistencia()
    {
        double voltaje = LeerNumeroPositivo(
            "Ingresa el voltaje en voltios (V): ");

        double corriente = LeerNumeroPositivo(
            "Ingresa la corriente en amperios (A): ");

        modelo.CalcularResistencia(voltaje, corriente);

        vista.MostrarProblema(
            $"Calcula la resistencia: R = V / I\n" +
            $"Voltaje = {voltaje:0.####} V\n" +
            $"Corriente = {corriente:0.####} A");

        EvaluarRespuesta();
    }

    private void EvaluarRespuesta()
    {
        double respuesta = LeerNumeroPositivo(
            "¿Cual crees que es el resultado? ");

        bool correcto = modelo.VerificarRespuesta(respuesta);

        vista.MostrarResultado(
            correcto,
            modelo.Resultado,
            modelo.UnidadResultado);
    }

    private double LeerNumeroPositivo(string mensaje)
    {
        while (true)
        {
            string entrada = vista.LeerTexto(mensaje).Trim();

            // Acepta decimales escritos con punto o coma.
            entrada = entrada.Replace(',', '.');

            if (double.TryParse(
                entrada,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double numero)
                && double.IsFinite(numero)
                && numero > 0)
            {
                return numero;
            }

            vista.MostrarMensaje(
                "Ingresa un numero mayor que cero.");
        }
    }

    private bool LeerEntero(string mensaje, out int numero)
    {
        string entrada = vista.LeerTexto(mensaje);

        return int.TryParse(entrada, out numero);
    }
}
