
namespace CalculadoraOhm;

public class CalculadoraOhmModelo
{
    // Datos electricos del modelo
    public double Voltaje { get; private set; }
    public double Corriente { get; private set; }
    public double Resistencia { get; private set; }

    // Resultado que debe descubrir el estudiante
    public double Resultado { get; private set; }
    public string UnidadResultado { get; private set; } = "";

    // Calcula el voltaje: V = I * R
    public void CalcularVoltaje(double corriente, double resistencia)
    {
        Corriente = corriente;
        Resistencia = resistencia;
        Voltaje = Corriente * Resistencia;

        Resultado = Voltaje;
        UnidadResultado = "V";
    }

    // Calcula la corriente: I = V / R
    public void CalcularCorriente(double voltaje, double resistencia)
    {
        Voltaje = voltaje;
        Resistencia = resistencia;
        Corriente = Voltaje / Resistencia;

        Resultado = Corriente;
        UnidadResultado = "A";
    }

    // Calcula la resistencia: R = V / I
    public void CalcularResistencia(double voltaje, double corriente)
    {
        Voltaje = voltaje;
        Corriente = corriente;
        Resistencia = Voltaje / Corriente;

        Resultado = Resistencia;
        UnidadResultado = "ohmios";
    }

    // Comprueba la respuesta del estudiante
    public bool VerificarRespuesta(double respuesta)
    {
        return Math.Abs(respuesta - Resultado) <= 0.01;
    }
}
