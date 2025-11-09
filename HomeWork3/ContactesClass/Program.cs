



Console.WriteLine("Welcome to my Contact list");


bool running = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastNames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();
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
            {


                AddContact(ids, names, lastNames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {
                ViewContacts(ids, names, lastNames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 3: //search
            {
                SearchContact(ids, names, lastNames, addresses, telephones, emails, ages, bestFriends);


            }
            break;
        case 4: //modify
            {
                Modify(ids, names, lastNames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 5: //delete
            {
                Delete(ids, names, lastNames, addresses, telephones, emails, ages, bestFriends);

            }
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
static void TryCatch(ref bool Continue)
{

    if (!Continue)
    {
        Continue = false;
        Console.WriteLine("There was an error");
        Console.WriteLine("Press any key to try again!");
        Console.ReadKey();
        Console.Clear();
    }



}
static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastNames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    bool ContinueName = true;
    string? name = string.Empty;
    do
    {
        ContinueName = true;
        Console.Write("Enter the person's name: ");
        name = Console.ReadLine();
        Console.Clear();

        if (string.IsNullOrWhiteSpace(name))
        {
            ContinueName = false;
            Console.WriteLine("You must enter a name!");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            Console.Clear();
        }
    } while (!ContinueName);

    Console.Write("Enter the person's last name: ");
    string? lastName = Console.ReadLine();
    Console.Clear();
    Console.Write("Enter the address: ");
    string? address = Console.ReadLine();
    Console.Clear();
    Console.Write("Enter the person's phone number: ");
    string? phone = Console.ReadLine();
    Console.Clear();
    Console.Write("Enter the person's email: ");
    string? email = Console.ReadLine();
    Console.Clear();
    int age = 0;
    bool ageGo = true;
    do
    {
        try
        {
            ageGo = true;
            Console.Write("Enter the person's age in numbers: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
        }
        catch (FormatException)
        {
            ageGo = false;
            Console.WriteLine("Invalid format! ");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            Console.Clear();
        }
    } while (!ageGo);

    bool BfGo = true;
    bool isBestFriend = true;
    do
    {
        try
        {
            BfGo = true;
            Console.Write("Specify if they are a best friend: 1. Yes, 2. No: ");
            isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;
            Console.Clear();

        }
        catch (FormatException)
        {
            BfGo = false;
            Console.WriteLine("Invalid format! ");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            Console.Clear();
        }
    } while (!BfGo);


    int id = 0;

    for (int i = 0; i < ids.Count; i++)
    {
        id++;
    }
    ids.Add(id);
    names.Add(id, name.ToLower().Trim());
    lastNames.Add(id, lastName.ToLower().Trim());
    addresses.Add(id, address.ToLower().Trim());
    telephones.Add(id, phone.ToLower().Trim());
    emails.Add(id, email.ToLower().Trim());
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
}
static void Delete(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastNames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)

{
    if (ids.Count == 0)
    {

        Console.WriteLine("No contacts have been added");
        Console.WriteLine("Press any key to try again!");
        Console.ReadKey();
        Console.Clear();
        return;


    }


    bool ContinueDelete = true;
   
    int index = 0;

    do
    {
        try
        {
            ContinueDelete = true;
            Console.Write("Enter the name of the contact you want to delete: ");
            string? delete = Console.ReadLine();

            for (int i = 0; i < ids.Count; i++)
            {
                if (delete?.ToLower().Trim() == names[i])
                {
                    index = i;
                    ids.Remove(index);
                    names.Remove(index);
                    lastNames.Remove(index);
                    addresses.Remove(index);
                    telephones.Remove(index);
                    emails.Remove(index);
                    ages.Remove(index);
                    bestFriends.Remove(index);
                    Console.WriteLine("Deleted successfully!");
                    Console.WriteLine("Press any key to return to the menu!");
                    Console.ReadKey();
                    Console.Clear();
                    return;


                }

                if (string.IsNullOrWhiteSpace(delete))
                {
                    ContinueDelete = false;
                    Console.WriteLine("You must enter a name");
                    Console.WriteLine("Press any key to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                }

            }


        }
        catch (Exception)
        {
            ContinueDelete = false;
            TryCatch(ref ContinueDelete);

        }

    } while (!ContinueDelete);


}
static void Modify(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastNames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    if (ids.Count == 0)
    {

        Console.WriteLine("No contacts have been added");
        Console.WriteLine("Press any key to try again!");
        Console.ReadKey();
        Console.Clear();
        return;


    }


    bool continueMenu = true;
    int ModifyType = 0;
    string? name = string.Empty;
    bool ContinueName = true;
    int indexx = -1;


    do
    {
        ContinueName = true;
        Console.Write("Enter the name of the contact to modify: ");
        name = Console.ReadLine();
        Console.Clear();

        if (string.IsNullOrWhiteSpace(name))
        {
            ContinueName = false;
            Console.WriteLine("You must enter a name");
            Console.WriteLine("Press any key to try again!");
            Console.ReadKey();
            Console.Clear();
            continue;

        }

        for (int i = 0; i < names.Count; i++)
        {
            if (name?.ToLower().Trim() == names[i])
            {
                indexx = i;
                break;

            }

        }
        if (indexx == -1)
        {
            ContinueName = false;
            Console.WriteLine("Name not found");
            Console.WriteLine("Press any key to try again!");
            Console.ReadKey();
            Console.Clear();
        }

    } while (!ContinueName);

    do
    {


        continueMenu = true;

        Console.WriteLine(""""
                What do you want to modify about the contact?
                1) Name
                2) Last Name
                3) Address
                4) Email
                5) Age
                6) Best Friends
                """");
        try
        {
            Console.Write("Choose the modification type: ");
            ModifyType = Convert.ToInt32(Console.ReadLine());

            if (ModifyType <= 0 || ModifyType > 6)
            {
                continueMenu = false;
                Console.WriteLine("Option out of range");
                Console.WriteLine("Press any key to try again!");
                Console.ReadKey();
                Console.Clear();

            }

        }


        catch (FormatException)
        {
            continueMenu = false;
            TryCatch(ref continueMenu);
        }
    } while (!continueMenu);



    ModifyTyp modifier = (ModifyTyp)ModifyType;



    switch (modifier)
    {
        case ModifyTyp.Name:
            string? NewName = string.Empty;
            bool Continue1 = true;
            do
            {
                try
                {
                    Continue1 = true;
                    Console.Write("Enter the new name: ");
                    NewName = Console.ReadLine();
                    Console.Clear();


                    if (string.IsNullOrWhiteSpace(NewName))
                    {
                        Continue1 = false;
                        Console.WriteLine("You must enter something!");
                        Console.WriteLine("Press any key to try again!");
                        Console.ReadKey();
                        Console.Clear();

                    }

                    names.Remove(indexx);
                    names.Add(indexx, NewName!.ToLower().Trim());


                }
                catch (Exception)
                {
                    Continue1 = false;
                    TryCatch(ref Continue1);
                }

            } while (!Continue1);

            break;

        case ModifyTyp.LastName:
            string? NewLastName = string.Empty;
            bool continue2 = true;

            do
            {
                try
                {
                    continue2 = true;

                    Console.Write("Enter the new Last Name: ");
                    NewLastName = Console.ReadLine();
                    Console.Clear();


                    if (string.IsNullOrWhiteSpace(NewLastName))
                    {
                        continue2 = false;
                        Console.WriteLine("You must enter something!");
                        Console.WriteLine("Press any key to try again!");
                        Console.ReadKey();
                        Console.Clear();

                    }


                    lastNames.Remove(indexx);
                    lastNames.Add(indexx, NewLastName!.ToLower().Trim());

                }
                catch (Exception)
                {
                    continue2 = false;
                    TryCatch(ref continue2);

                }


            } while (!continue2);

            break;

        case ModifyTyp.Address:
            string? NewAddress = string.Empty;
            bool continue3 = true;

            do
            {
                try
                {
                    continue3 = true;
                    Console.Write($"Enter the new address: ");
                    NewAddress = Console.ReadLine();
                    Console.Clear();


                    if (string.IsNullOrWhiteSpace(NewAddress))
                    {
                        continue3 = false;
                        Console.WriteLine("You must enter something!");
                        Console.WriteLine("Press any key to try again!");
                        Console.ReadKey();
                        Console.Clear();
                    }


                    addresses.Remove(indexx);
                    addresses.Add(indexx, NewAddress!.ToLower().Trim());


                }
                catch (Exception)
                {
                    continue3 = false;
                    TryCatch(ref continue3);

                }

            } while (!continue3);

            break;

        case ModifyTyp.Email:


            string? NewEmail = string.Empty;
            bool continue4 = true;

            do
            {
                try
                {
                    continue4 = true;


                    Console.Write($"Enter the new email: ");
                    NewEmail = Console.ReadLine();


                    Console.Clear();


                    if (string.IsNullOrWhiteSpace(NewEmail))
                    {
                        continue4 = false;
                        Console.WriteLine("You must enter something!");
                        Console.WriteLine("Press any key to try again!");
                        Console.ReadKey();
                        Console.Clear();
                    }


                    emails.Remove(indexx);
                    emails.Add(indexx, NewEmail!.ToLower().Trim());


                }
                catch (Exception)
                {
                    continue4 = false;
                    TryCatch(ref continue4);

                }

            } while (!continue4);

            break;

        case ModifyTyp.Age:
            int NewAge = 0;
            bool continue5 = true;

            do
            {
                try
                {
                    continue5 = true;


                    Console.Write($"Enter the new age: ");
                    NewAge = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    ages.Remove(indexx);
                    ages.Add(indexx, NewAge);


                }
                catch (Exception)
                {
                    continue5 = false;
                    TryCatch(ref continue5);

                }

            } while (!continue5);
            break;

        case ModifyTyp.BestFriends:
            string NewBestFriends = string.Empty;
            bool continue6 = true;


            do
            {
                try
                {
                    continue6 = true;

                    Console.Write("Specify if they are a best friend: 1. Yes, 2. No: ");
                    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;
                    Console.Clear();


                    bestFriends.Remove(indexx);
                    bestFriends.Add(indexx, isBestFriend);

                }
                catch (Exception)
                {
                    continue6 = false;
                    TryCatch(ref continue6);

                }

            } while (!continue6);

            break;
    }
}
static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastNames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    if (ids.Count == 0)
    {

        Console.WriteLine("No contacts have been added");
        Console.WriteLine("Press any key to try again!");
        Console.ReadKey();
        Console.Clear();
        return;


    }

    var Continue = true;
    do
    {
        Continue = true;
        Console.Write("Enter the name of the contact you want to search for: ");
        string? Search = Console.ReadLine();
        Console.Clear();

        if (string.IsNullOrWhiteSpace(Search))

        {
            Continue = false;
            Console.WriteLine("You must enter something!");
            Console.WriteLine("Press any key to return to the menu!");
            Console.ReadKey();
            Console.Clear();


        }


        for (int i = 0; i < ids.Count; i++)
        {

            if (Search?.ToLower().Trim() == names[i])
            {
                // Program.Carga(ref Continue);
                Console.WriteLine($""""
                  Id           Name                     Last Name                      addresses                      telephones                      emails                    ages                  bestFriends
                  {ids[i]}      {names[i]}      {lastNames[i]}    {addresses[i]}    {telephones[i]}    {emails[i]}  {ages[i]}  {bestFriends[i]}
                  """");
                break;


            }

        }
    } while (!Continue);
    Console.WriteLine();
    Console.WriteLine("Press any key to return to the menu!");
    Console.ReadKey();
    Console.Clear();
    return;







}

static void ViewContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastNames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    if (ids.Count == 0)
    {

        Console.WriteLine("No contacts have been added");
        Console.WriteLine("Press any key to try again!");
        Console.ReadKey();
        Console.Clear();
        return;


    }

    Console.WriteLine($"Id               Name             Last Name               Address                   Phone                 Email                   Age                   Is Best Friend?");
    Console.WriteLine($"____________________________________________________________________________________________________________________________");
    for (int id = 0; id < ids.Count; id++)
    {
        var isBestFriend = bestFriends[id];


        string isBestFriendStr = (isBestFriend == true) ? "Yes" : "No";
        Console.WriteLine($"{ids[id]}    {names[id]}          {lastNames[id]}            {addresses[id]}            {telephones[id]}             {emails[id]}             {ages[id]}            {isBestFriendStr}");
    }
    Console.WriteLine();
    Console.WriteLine("Press any key to return to the menu!");
    Console.ReadKey();
    Console.Clear();


}


enum ModifyTyp
{
    Name = 1,
    LastName = 2,
    Address = 3,
    Email = 4,
    Age = 5,
    BestFriends = 6,

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