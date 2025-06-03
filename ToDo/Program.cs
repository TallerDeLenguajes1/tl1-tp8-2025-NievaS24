using System.Reflection.Metadata;
using EspacioTarea;
//Crear N Tareas y guardar en tareasPendientes
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();
int duracion, N;
bool conversionPosible;
do
{
    Console.WriteLine("\n---- Ingrese el numero de tareas que desea crear ----\n");
    conversionPosible = int.TryParse(Console.ReadLine(), out N);
} while (!conversionPosible || N <= 0);
for (int i = 0; i < N; i++)
{
    Tarea MiTarea = new Tarea();
    MiTarea.TareaID = i + 1;
    Console.WriteLine($"\n---- Ingrese una descripcion para la tarea Nº {i + 1} ----\n");
    MiTarea.Descripcion = Console.ReadLine();
    do
    {
        Console.WriteLine($"\n---- Ingrese la duracion de la tarea Nº {i + 1}(entre 10 y 100 minutos) ----\n");
        conversionPosible = int.TryParse(Console.ReadLine(), out duracion);
    } while (!conversionPosible || duracion < 10 || duracion > 100);
    MiTarea.Duracion = duracion;
    tareasPendientes.Add(MiTarea);
}
//Interfaz para mover las tareas pendientes a realizadas
int ID;
Console.WriteLine("\n---- Si deseas marcar una tarea como realizada presione [1] ----\n");
int.TryParse(Console.ReadLine(), out int decision);
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
    Console.WriteLine("\n---- Si deseas marcar una tarea como realizada presione [1] ----\n");
    int.TryParse(Console.ReadLine(), out decision);
}
Console.WriteLine("\n---- Si deseas buscar una tarea pendiente por su descripcion presione [1] ----\n");
int.TryParse(Console.ReadLine(), out decision);
//Busqueda de tareas pendientes por descripcion
string descripcionBuscada;
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
    Console.WriteLine("\n---- Si deseas buscar una tarea pendiente por su descripcion presione [1] ----\n");
    int.TryParse(Console.ReadLine(), out decision);
}
//Mostrar listas
Console.WriteLine("Tareas Pendientes:");
for (int i = 0; i < tareasPendientes.Count; i++)
{
    Console.WriteLine($"\t Tarea {i}: \n\t\t ID: {tareasPendientes[i].TareaID} \n\t\t Descripcion: {tareasPendientes[i].Descripcion} \n\t\t Duracion: {tareasPendientes[i].Duracion}");
}

Console.WriteLine("Tareas Realizadas:");
for (int i = 0; i < tareasRealizadas.Count; i++)
{
    Console.WriteLine($"\t Tarea {i}: \n\t\t ID: {tareasRealizadas[i].TareaID} \n\t\t Descripcion: {tareasRealizadas[i].Descripcion} \n\t\t Duracion: {tareasRealizadas[i].Duracion}");
}
int opcion;
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
while (opcion != 0)
{
    //Hacer aca
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