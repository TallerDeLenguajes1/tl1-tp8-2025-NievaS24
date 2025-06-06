using System.Reflection.Metadata;
using EspacioTarea;
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();
//Crear N Tareas y guardar en tareasPendientes
int duracion, N, historialID = 0;
bool conversionPosible;
void nuevasTareas()
{
    do
    {
        Console.WriteLine("\n---- Ingrese el numero de tareas que desea crear ----\n");
        conversionPosible = int.TryParse(Console.ReadLine(), out N);
    } while (!conversionPosible || N <= 0);
    for (int i = 0; i < N; i++)
    {
        Tarea MiTarea = new Tarea();
        MiTarea.TareaID = historialID + 1;
        Console.WriteLine($"\n---- Ingrese una descripcion para la tarea Nº {i + 1} ----\n");
        MiTarea.Descripcion = Console.ReadLine();
        do
        {
            Console.WriteLine($"\n---- Ingrese la duracion de la tarea Nº {i + 1}(entre 10 y 100 minutos) ----\n");
            conversionPosible = int.TryParse(Console.ReadLine(), out duracion);
        } while (!conversionPosible || duracion < 10 || duracion > 100);
        MiTarea.Duracion = duracion;
        tareasPendientes.Add(MiTarea);
        historialID++;
    }
}
//Interfaz para mover las tareas pendientes a realizadas
int ID, decision;
void marcarTareasRealizadas()
{
    decision = 1;
    while (decision == 1)
    {
        do
        {
            Console.WriteLine("\n---- Ingrese el ID de la tarea ----\n");
            conversionPosible = int.TryParse(Console.ReadLine(), out ID);
        } while (!conversionPosible);
        Tarea tareaARealizar = tareasPendientes.Find(tarea => tarea.TareaID == ID);
        if (tareaARealizar != null)
        {
            tareasRealizadas.Add(tareaARealizar);
            tareasPendientes.Remove(tareaARealizar);
            Console.WriteLine("\n O O O O Tarea marcada como realizada O O O O\n");
        }
        else
        {
            Console.WriteLine("\n X X X X El ID ingresado no existe o la tarea ya fue realizada X X X X\n");
        }
        Console.WriteLine("\n---- Si deseas marcar otra tarea como realizada presione [1], sino presione cualquier tecla ----\n");
        int.TryParse(Console.ReadLine(), out decision);
    }
}
// //Busqueda de tareas pendientes por descripcion
string descripcionBuscada;
void busquedaXDescripcion()
{
    decision = 1;
    while (decision == 1)
    {
        Console.WriteLine("\n---- Ingrese la descripcion que quiere buscar ----\n");
        descripcionBuscada = Console.ReadLine();
        Tarea tareaBuscada = tareasPendientes.Find(tarea => tarea.Descripcion == descripcionBuscada);
        if (tareaBuscada != null)
        {
            Console.WriteLine($"\n O O O O Tarea encontrada O O O O \n\t ID: {tareaBuscada.TareaID} \n\t Descripcion: {tareaBuscada.Descripcion} \n\t Duracion: {tareaBuscada.Duracion}");
        }
        else
        {
            Console.WriteLine("\n X X X X No se ha encontrado una tarea con esa descripcion X X X X\n");
        }
        Console.WriteLine("\n---- Si deseas buscar otra tarea pendiente por su descripcion presione [1], sino presione cualquier tecla ----\n");
        int.TryParse(Console.ReadLine(), out decision);
    }
}
// //Mostrar listas
void mostrarListas()
{
    Console.WriteLine("\n\n");
    Console.WriteLine("Tareas Pendientes:");
    for (int i = 0; i < tareasPendientes.Count; i++)
    {
        Console.WriteLine($"\t Tarea {i + 1}: \n\t\t ID: {tareasPendientes[i].TareaID} \n\t\t Descripcion: {tareasPendientes[i].Descripcion} \n\t\t Duracion: {tareasPendientes[i].Duracion}");
    }

    Console.WriteLine("Tareas Realizadas:");
    for (int i = 0; i < tareasRealizadas.Count; i++)
    {
        Console.WriteLine($"\t Tarea {i + 1}: \n\t\t ID: {tareasRealizadas[i].TareaID} \n\t\t Descripcion: {tareasRealizadas[i].Descripcion} \n\t\t Duracion: {tareasRealizadas[i].Duracion}");
    }
    Console.WriteLine("\n\n");
}
//Menu
int opcion;
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
            nuevasTareas();
            break;
        case 2:
            marcarTareasRealizadas();
            break;
        case 3:
            busquedaXDescripcion();
            break;
        case 4:
            mostrarListas();
            break;
    }
    elegirOpcion();
}