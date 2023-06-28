using System;
using System.Collections.Generic;
using Console = Colorful.Console;
using Colorful;
using System.Drawing;
//comando para instalar colorful dotnet add package Colorful.Console --version 1.2.15
public class Tarea
{
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public bool Completada { get; set; }

    public Tarea(string titulo, string descripcion)
    {
        Titulo = titulo;
        Descripcion = descripcion;
        Completada = false;
    }

    public void MarcarCompletada()
    {
        Completada = true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Tarea> listaTareas = new List<Tarea>();

        Console.WriteLine("¡Bienvenido a la aplicación de gestión de tareas!");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Marcar tarea como completada");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Mostrar todas las tareas");
            Console.WriteLine("5. Salir");
            Console.WriteLine();

            Console.Write("Ingrese una opción: ");
            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título de la tarea: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Ingrese la descripción de la tarea: ");
                    string descripcion = Console.ReadLine();

                    listaTareas.Add(new Tarea(titulo, descripcion));

                    Console.WriteLine("Tarea agregada exitosamente.");
                    Console.WriteLine();
                    break;

                case "2":
                    if (listaTareas.Count == 0)
                    {
                        Console.WriteLine("No hay tareas en la lista.");
                        Console.WriteLine();
                        break;
                    }

                    Console.WriteLine("----- TAREAS -----");
                    MostrarTareas(listaTareas);

                    Console.Write("Ingrese el número de la tarea que desea marcar como completada: ");
                    int tareaCompletar;
                    if (int.TryParse(Console.ReadLine(), out tareaCompletar) && tareaCompletar >= 1 && tareaCompletar <= listaTareas.Count)
                    {
                        listaTareas[tareaCompletar - 1].MarcarCompletada();
                        Console.WriteLine("Tarea marcada como completada.");
                    }
                    else
                    {
                        Console.WriteLine("Número de tarea inválido.");
                    }

                    Console.WriteLine();
                    break;

                case "3":
                    if (listaTareas.Count == 0)
                    {
                        Console.WriteLine("No hay tareas en la lista.");
                        Console.WriteLine();
                        break;
                    }

                    Console.WriteLine("----- TAREAS -----");
                    MostrarTareas(listaTareas);

                    Console.Write("Ingrese el número de la tarea que desea eliminar: ");
                    int tareaEliminar;
                    if (int.TryParse(Console.ReadLine(), out tareaEliminar) && tareaEliminar >= 1 && tareaEliminar <= listaTareas.Count)
                    {
                        listaTareas.RemoveAt(tareaEliminar - 1);
                        Console.WriteLine("Tarea eliminada.");
                    }
                    else
                    {
                        Console.WriteLine("Número de tarea inválido.");
                    }

                    Console.WriteLine();
                    break;

                case "4":
                    if (listaTareas.Count == 0)
                    {
                        Console.WriteLine("No hay tareas en la lista.");
                    }
                    else
                    {
                        Console.WriteLine("----- TAREAS -----");
                        MostrarTareas(listaTareas);
                    }

                    Console.WriteLine();
                    break;

                case "5":
                    Console.WriteLine("¡Hasta luego!");
                    return;

                default:
                    Console.WriteLine("Opción inválida. Por favor, ingrese una opción válida.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    static void MostrarTareas(List<Tarea> tareas)
    {
        for (int i = 0; i < tareas.Count; i++)
        {
            string estado = tareas[i].Completada ? "Completada" : "Pendiente";

            Console.WriteLine($"[{i + 1}] Título: {tareas[i].Titulo}");
            Console.WriteLine($"    Descripción: {tareas[i].Descripcion}");
            Console.Write("    Estado: ");

            if (tareas[i].Completada)
            {
                Console.WriteLine(estado, Color.Green);
            }
            else
            {
                Console.WriteLine(estado, Color.Yellow);
            }

            Console.WriteLine();
        }
    }
}
