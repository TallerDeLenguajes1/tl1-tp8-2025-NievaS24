using EspacioCalculadora;

//Menu
int opcion;
bool conversionPosible;
void elegirOpcion()
{
    do
    {
        Console.WriteLine("Seleccione una operacion:");
        Console.WriteLine("[1] - Suma.");
        Console.WriteLine("[2] - Resta.");
        Console.WriteLine("[3] - Multiplicacion.");
        Console.WriteLine("[4] - Division.");
        Console.WriteLine("[5] - Limpiar.");
        Console.WriteLine("[6] - Ver Hisotrial.");
        Console.WriteLine("[0] - Salir");
        conversionPosible = int.TryParse(Console.ReadLine(), out opcion);
    } while (!conversionPosible || opcion < 0 || opcion > 6);
}


//Principal


Calculadora calc = new Calculadora();
double numero = 0;
elegirOpcion();
while (opcion != 0)
{
    if (opcion != 5 && opcion != 6)
    {
        do
        {
            Console.WriteLine("Ingrese un numero");
            conversionPosible = double.TryParse(Console.ReadLine(), out numero);
        } while (!conversionPosible);
    }
    switch (opcion)
    {
        case 1:
            calc.Sumar(numero);
            break;
        case 2:
            calc.Restar(numero);
            break;
        case 3:
            calc.Multiplicar(numero);
            break;
        case 4:
            if (numero != 0)
            {
                calc.Dividir(numero);
            }
            else
            {
                Console.WriteLine("No se puede dividir en 0");
            }
            break;
        case 5:
            calc.Limpiar();
            break;
        case 6:
            Console.WriteLine("\n\n - - - - -  Historial - - - - - ");
            foreach (var op in calc.Historial)
            {
                Console.WriteLine($"Operacion: {op.Operador} - Numeros: (anterior) {op.ResultadoAnterior}, (actual) {op.NuevoValor} - Resultado {op.Resultado}");
            }
            Console.WriteLine("\n\n");
            break;
    }
    Console.WriteLine($"El resultado de la operacion fue {calc.Resultado}");
    elegirOpcion();
}