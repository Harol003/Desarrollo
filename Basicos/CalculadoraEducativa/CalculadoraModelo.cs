
namespace CalculadoraEducativa;

public class CalculadoraModelo
{
    public int Numero1 { get; set; }
    public int Numero2 { get; set; }
    public int Operacion { get; set; }
    public double Resultado { get; private set; }

    public bool Calcular()
    {
        switch (Operacion)
        {
            case 1:
                Resultado = Numero1 + Numero2;
                return true;

            case 2:
                Resultado = Numero1 - Numero2;
                return true;

            case 3:
                Resultado = Numero1 * Numero2;
                return true;

            case 4:
                if (Numero2 == 0)
                    return false;

                Resultado = (double)Numero1 / Numero2;
                return true;

            default:
                return false;
        }
    }

    public bool VerificarRespuesta(double respuesta)
    {
        return Math.Abs(respuesta - Resultado) < 0.000001;
    }
}
