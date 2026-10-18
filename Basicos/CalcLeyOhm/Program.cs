
using CalculadoraOhm;

CalculadoraOhmModelo modelo = new CalculadoraOhmModelo();

CalculadoraOhmVista vista = new CalculadoraOhmVista();

CalculadoraOhmControlador controlador =
    new CalculadoraOhmControlador(modelo, vista);

controlador.Iniciar();
