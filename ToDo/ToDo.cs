namespace EspacioTarea
{
    public class Tarea
    {
        public int TareaID { get; set; } //Numero en ciclo iterativo
        public string Descripcion { get; set; }
        public int Duracion { get; set; } // Entre 10 - 100
    }
    public class FuncionesTareas
    {
        //Crear N Tareas y guardar en tareasPendientes
        private int duracion, N, historialID = 0;
        private bool conversionPosible;
        public void nuevasTareas(List<Tarea> T)
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
                T.Add(MiTarea);
                historialID++;
            }
        }
        //Interfaz para mover las tareas pendientes a realizadas
        private int ID, decision;
        public void marcarTareasRealizadas(List<Tarea> TP, List<Tarea> TR)
        {
            decision = 1;
            while (decision == 1)
            {
                do
                {
                    Console.WriteLine("\n---- Ingrese el ID de la tarea ----\n");
                    conversionPosible = int.TryParse(Console.ReadLine(), out ID);
                } while (!conversionPosible);
                Tarea tareaARealizar = TP.Find(tarea => tarea.TareaID == ID);
                if (tareaARealizar != null)
                {
                    TR.Add(tareaARealizar);
                    TP.Remove(tareaARealizar);
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
        //Busqueda de tareas pendientes por descripcion
        private string descripcionBuscada;
        public void busquedaXDescripcion(List<Tarea> T)
        {
            decision = 1;
            while (decision == 1)
            {
                Console.WriteLine("\n---- Ingrese la descripcion que quiere buscar ----\n");
                descripcionBuscada = Console.ReadLine();
                Tarea tareaBuscada = T.Find(tarea => tarea.Descripcion == descripcionBuscada);
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
        //Mostrar listas
        public void mostrarListas(List<Tarea> TP, List<Tarea> TR)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Tareas Pendientes:");
            for (int i = 0; i < TP.Count; i++)
            {
                Console.WriteLine($"\t Tarea {i + 1}: \n\t\t ID: {TP[i].TareaID} \n\t\t Descripcion: {TP[i].Descripcion} \n\t\t Duracion: {TP[i].Duracion}");
            }

            Console.WriteLine("Tareas Realizadas:");
            for (int i = 0; i < TR.Count; i++)
            {
                Console.WriteLine($"\t Tarea {i + 1}: \n\t\t ID: {TR[i].TareaID} \n\t\t Descripcion: {TR[i].Descripcion} \n\t\t Duracion: {TR[i].Duracion}");
            }
            Console.WriteLine("\n\n");
        }

    }
}