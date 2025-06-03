using System.Reflection.Metadata;
using EspacioTarea;

List<Tarea> tareasPendientes = new List<Tarea>();
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
    MiTarea.TareaID = i;
    Console.WriteLine($"Ingrese una descripcion para la tarea nº {i}");
    MiTarea.Descripcion = Console.ReadLine();
    do
    {
        Console.WriteLine($"Ingrese la duracion de la tarea nº {i}(entre 10 y 100)");
        conversionPosible = int.TryParse(Console.ReadLine(), out duracion);
    } while (!conversionPosible || duracion < 10 || duracion > 100);
    MiTarea.Duracion = duracion;
    tareasPendientes.Add(MiTarea);
}
