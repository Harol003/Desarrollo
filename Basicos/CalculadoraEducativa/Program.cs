
using CalculadoraEducativa;

CalculadoraModelo modelo = new CalculadoraModelo();
CalculadoraVista vista = new CalculadoraVista();

CalculadoraControlador controlador =
    new CalculadoraControlador(modelo, vista);

controlador.Iniciar();
