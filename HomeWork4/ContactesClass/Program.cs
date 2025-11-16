
using System;
using System.Collections.Generic;
using System.Threading;



public class Program
{
    static void Main(string[] args)
    {
        ContactManager manager = new ContactManager();

        Console.WriteLine("Welcome to my Contact list");

        bool running = true;
        int typeOption = 0;
        bool menu = true;


        while (running)
        {
            do
            {

                try
                {
                    menu = true;
                    Console.WriteLine("""
                        1. Add Contact
                        2. View Contacts
                        3. Search Contacts
                        4. Modify Contact
                        5. Delete Contact
                        6. Exit
                        """);
                    Console.Write("Enter the number of the desired option: ");
                    typeOption = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (typeOption <= 0 || typeOption > 6)
                    {
                        menu = false;
                        Console.WriteLine("You must enter an option from 1 to 6");
                        Console.WriteLine("Press any key to try again! ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                catch (Exception)
                {
                    menu = false;
                    Console.WriteLine("There was an error!");
                    Console.WriteLine("Press any key to try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
                ;

            } while (!menu);

            switch (typeOption)
            {
                case 1:
                    manager.AddContact();
                    break;
                case 2:
                    manager.ViewContacts(); 
                    break;
                case 3:
                    manager.SearchContact();
                    break;
                case 4:
                    manager.Modify(); 
                    break;
                case 5:
                    manager.Delete();
                    break;
                case 6:
                    running = false;
                    Console.Write("Exiting");
                    for (int i = 0; i < 6; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(700);
                    }
                    Console.Clear();
                    Console.WriteLine("Goodbye :)");
                    break;
                default:
                    Console.WriteLine("Are you stupid or pretending to be?");
                    break;
            }
        }
    }
}











































































































































//decimal ValorBarra = 100;

//decimal barra = 0;
//int Option = 0;
//int index = 0;
//var Agregar = true;
//var elimi = true;
//var Menu = true;

//int Cantidad = 0;





//var seguir = true;


//decimal ValorElemento = 0;

//List<string> Tareas = new List<string>();
//while (seguir)
//{
//    if (barra > 0)
//    {
//        Console.WriteLine($"Progreso: {barra}%");
//    }

//    if (barra == ValorBarra)
//    {
//        Console.WriteLine("felicidades, Completaste el curso!!");
//        seguir = false;


//    }

//    do
//    {
//        try
//        {
//            Menu = true;
//            Console.WriteLine(""""

//        1) Agregar Tareas
//        2) Ver tareas
//        3) Marcar Tarea como completada
//        """");

//            Console.Write("ingrese una opcion: ");
//            Option = Convert.ToInt32(Console.ReadLine());
//            if (Option <= 0 || Option > 3)
//            {
//                Menu = false;
//                Console.WriteLine("Numero fuera de rango!");
//                Console.ReadKey();
//                Console.Clear();
//            }
//        }

//        catch (FormatException)
//        {
//            Menu = false;
//            Console.WriteLine("ingrese una opcion valida!");
//            Console.ReadKey();
//            Console.Clear();

//        }
//    } while (!Menu);



//    switch (Option)

//    {

//        case 1:
//            {
//                do
//                {
//                    try
//                    {
//                        Agregar = true;
//                        Console.Write("ingrese la cantidad de tareas: ");
//                         Cantidad = Convert.ToInt32(Console.ReadLine());
//                        Console.Clear();
//                        ValorElemento = ValorBarra / Cantidad;


//                        for (int i = 0; i < Cantidad; i++)
//                        {
//                            Console.Write($"ingrese su tarea #{i + 1}: ");
//                            string? tarea = Console.ReadLine();
//                            Console.Clear();
//                            Tareas.Add(tarea);
//                        }

//                    }
//                    catch (FormatException)
//                    {
//                        Agregar = false;
//                        Console.WriteLine("ingrese una opcion valida!");
//                        Console.ReadKey();
//                        Console.Clear();
//                    }
//                } while (!Agregar);

//                break;
//            }


//        case 2:
//            {
//                if (Tareas.Count == 0)
//                {
//                    Console.WriteLine("No Hay Tareas para ver, Presione una tecla para volver al menu!");
//                    Console.ReadKey();
//                    Console.Clear();
//                    break;

//                }


//                Console.WriteLine("Lista de Tareas: ");

//                for( int i = 0; i < Tareas.Count; i++)
//                {


//                    Console.WriteLine($"{i + 1}) {Tareas[i]}");
//                }
//                Console.WriteLine("presione una tecla para continuar");
//                Console.ReadKey();
//                Console.Clear();
//                break;
//            }


//        case 3:
//            {
//                if (Tareas.Count == 0)
//                {

//                    Console.WriteLine("No hay Tareas!");
//                    Console.WriteLine("presione una tecla para continuar");
//                    Console.ReadKey();
//                    Console.Clear();
//                    break;
//                }
//                Console.WriteLine("Lista de Tareas: ");

//                for (int i = 0; i < Tareas.Count; i++)
//                {


//                    Console.WriteLine($"{i + 1}) {Tareas[i]}");
//                }
//                Console.WriteLine("presione una tecla para continuar");

//                do
//                {
//                    try
//                    {
//                        Console.Write("Que tarea desea marcar como completada? (marque el numero): ");
//                        int Eliminar = Convert.ToInt32(Console.ReadLine());
//                        Console.Clear();
//                        index = Eliminar - 1;
//                        Tareas.Remove(Tareas[index]);

//                        //if (index > Tareas.Count)
//                        //{
//                        //    elimi = false;
//                        //    Console.WriteLine("Debe de ingresar un numero en el rango!");
//                        //    Console.WriteLine("presione una tecla para continuar");
//                        //    Console.ReadKey();
//                        //    Console.Clear();
//                        //}

//                            Console.WriteLine("Tarea marcada como completada :)");
//                            barra += (int)ValorElemento;


//                    }
//                    catch (FormatException)
//                    {
//                        elimi = false;
//                        Console.WriteLine("Debe de ingresar un numero!");
//                        Console.WriteLine("presione una tecla para continuar");
//                        Console.ReadKey();
//                        Console.Clear();
//                    }
//                    catch (ArgumentOutOfRangeException)
//                    {
//                        elimi = false;
//                        Console.WriteLine("Opcion fuera de rango!");
//                        Console.WriteLine("presione una tecla para continuar");
//                        Console.ReadKey();
//                        Console.Clear();
//                    }
//                }while (!elimi);


//                break;
//            }






//    }









//}
//enum OPtion
//{
//    Agregar = 1,
//    Ver = 2, 
//    Eliminar = 3

//}