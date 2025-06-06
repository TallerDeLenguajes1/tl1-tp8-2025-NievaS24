using System.Reflection.Metadata;
using EspacioTarea;
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();
FuncionesTareas func = new FuncionesTareas();
//Menu
int opcion;
bool conversionPosible;
void elegirOpcion()
{
    do
    {
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("[1] - Crear tarea/s pendiente/s.");
        Console.WriteLine("[2] - Marcar tarea/s como realizada/s.");
        Console.WriteLine("[3] - Buscar tarea/s pendiente/s.");
        Console.WriteLine("[4] - Mostrar tarea/s.");
        Console.WriteLine("[0] - Salir");
        conversionPosible = int.TryParse(Console.ReadLine(), out opcion);
    } while (!conversionPosible || opcion < 0 || opcion > 4);
}
//Principal
elegirOpcion();
while (opcion != 0)
{
    switch (opcion)
    {
        case 1:
            func.nuevasTareas(tareasPendientes);
            break;
        case 2:
            func.marcarTareasRealizadas(tareasPendientes, tareasRealizadas);
            break;
        case 3:
            func.busquedaXDescripcion(tareasPendientes);
            break;
        case 4:
            func.mostrarListas(tareasPendientes, tareasRealizadas);
            break;
    }
    elegirOpcion();
}