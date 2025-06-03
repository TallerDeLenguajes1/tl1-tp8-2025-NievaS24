using System.Reflection.Metadata;
using EspacioTarea;
//Crear N Tareas y guardar en tareasPendientes
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();
int duracion, N;
bool conversionPosible;
do
{
    Console.WriteLine("Ingrese el numero de tareas que desea crear:");
    conversionPosible = int.TryParse(Console.ReadLine(), out N);
} while (!conversionPosible || N <= 0);
for (int i = 0; i < N; i++)
{
    Tarea MiTarea = new Tarea();
    MiTarea.TareaID = i + 1;
    Console.WriteLine($"Ingrese una descripcion para la tarea nº {i + 1}:");
    MiTarea.Descripcion = Console.ReadLine();
    do
    {
        Console.WriteLine($"Ingrese la duracion de la tarea nº {i + 1}(entre 10 y 100):");
        conversionPosible = int.TryParse(Console.ReadLine(), out duracion);
    } while (!conversionPosible || duracion < 10 || duracion > 100);
    MiTarea.Duracion = duracion;
    tareasPendientes.Add(MiTarea);
}
//Interfaz para mover las tareas pendientes a realizadas
int ID;
Console.WriteLine("Si deseas marcar una tarea como realizada presione [1]:");
int.TryParse(Console.ReadLine(), out int decision);
while (decision == 1)
{
    do
    {
        Console.WriteLine("Ingrese el ID de la tarea:");
        conversionPosible = int.TryParse(Console.ReadLine(), out ID);
    } while (!conversionPosible);
    Tarea tareaARealizar = tareasPendientes.Find(tarea => tarea.TareaID == ID);
    if (tareaARealizar != null)
    {
        tareasRealizadas.Add(tareaARealizar);
        tareasPendientes.Remove(tareaARealizar);
        Console.WriteLine("Tarea marcada como realizada.");
    }
    else 
    {
        Console.WriteLine("El ID ingresado no existe o la tarea ya fue realizada.");
    }
    Console.WriteLine("Si deseas marcar una tarea como realizada presione [1]:");
    int.TryParse(Console.ReadLine(), out decision);
}
Console.WriteLine("Si deseas buscar una tarea pendiente por su descripcion presione [1]:");
int.TryParse(Console.ReadLine(), out decision);
//Busqueda de tareas pendientes por descripcion
string descripcionBuscada;
while (decision == 1)
{
    Console.WriteLine("Ingrese la descripcion que quiere buscar:");
    descripcionBuscada = Console.ReadLine();
    Tarea tareaBuscada = tareasPendientes.Find(tarea => tarea.Descripcion == descripcionBuscada);
    if (tareaBuscada != null)
    {
        Console.WriteLine($"Tarea encontrada: \n ID: {tareaBuscada.TareaID} \n Descripcion: {tareaBuscada.Descripcion} \n Duracion: {tareaBuscada.Duracion}");
    }
    else
    {
        Console.WriteLine("No se ha encontrado una tarea con esa descripcion.");
    }
    Console.WriteLine("Si deseas buscar una tarea pendiente por su descripcion presione [1]:");
    int.TryParse(Console.ReadLine(), out decision);
}
