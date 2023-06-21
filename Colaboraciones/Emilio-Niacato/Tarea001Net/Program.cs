using System;
using System.Collections.Generic;
using System.Drawing;
using ConsoleTables;
using Console = Colorful.Console;

public class Tarea
{
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Estado { get; set; }
}

public class Program
{
    private static List<Tarea> tareas = new List<Tarea>();

    public static void Main(string[] args)
    {
        bool ejecutando = true;

        while (ejecutando)
        {
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Eliminar tarea");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Mostrar tareas");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese el número de la opción deseada: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    EliminarTarea();
                    break;
                case "3":
                    MarcarTareaComoCompletada();
                    break;
                case "4":
                    MostrarTareas();
                    break;
                case "5":
                    ejecutando = false;
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void AgregarTarea()
    {
        Console.Write("Ingrese el título de la tarea: ");
        string titulo = Console.ReadLine();
        Console.Write("Ingrese la descripción de la tarea: ");
        string descripcion = Console.ReadLine();

        tareas.Add(new Tarea { Titulo = titulo, Descripcion = descripcion, Estado = "Pendiente" });

        Console.WriteLine("Tarea agregada correctamente.");
    }

    private static void EliminarTarea()
    {
        Console.Write("Ingrese el índice de la tarea a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 0 && indice < tareas.Count)
        {
            tareas.RemoveAt(indice);
            Console.WriteLine("Tarea eliminada correctamente.");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    private static void MarcarTareaComoCompletada()
    {
        Console.Write("Ingrese el índice de la tarea a marcar como completada: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 0 && indice < tareas.Count)
        {
            tareas[indice].Estado = "Completada";
            Console.WriteLine("Tarea marcada como completada correctamente.");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    private static void MostrarTareas()
    {
        Console.WriteLine("Lista de tareas:");

        var table = new ConsoleTable("Índice", "Título", "Estado", "Descripción");

        for (int i = 0; i < tareas.Count; i++)
        {
            string estadoColoreado = tareas[i].Estado == "Completada" ? "Completada" : "Pendiente";
            table.AddRow(i, tareas[i].Titulo, estadoColoreado, tareas[i].Descripcion);
        }

        Console.WriteLine(table.Configure(o => o.EnableCount = false), Color.Pink);

    }
}