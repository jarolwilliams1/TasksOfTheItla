
public class ContactManager
{
   public List<int> ids = new List<int>();
   public Dictionary<int, string> names = new Dictionary<int, string>();
   public Dictionary<int, string> lastNames = new Dictionary<int, string>();
   public Dictionary<int, string> addresses = new Dictionary<int, string>();
   public Dictionary<int, string> telephones = new Dictionary<int, string>();
   public Dictionary<int, string> emails = new Dictionary<int, string>();
   public Dictionary<int, int> ages = new Dictionary<int, int>();
   public Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

    private void TryCatch(ref bool Continue)
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

    public void AddContact()
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

    public void ViewContacts()
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
            string isBestFriendStr = (bestFriends[id] == true) ? "Yes" : "No";

            Console.WriteLine($"{ids[id]}     {names[id]}           {lastNames[id]}            {addresses[id]}             {telephones[id]}               {emails[id]}                   {ages[id]}            {isBestFriendStr}");
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu!");
        Console.ReadKey();
        Console.Clear();
    }

    public void SearchContact()
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
                   
                    Console.WriteLine($""""
                        Id           Name                     Last Name                      Address                      Telephones                      Emails                    Age                  BestFriends
                        {i}          {names[i]}               {lastNames[i]}                 {addresses[i]}               {telephones[i]}                {emails[i]}              {ages[i]}            {bestFriends[i]}
                        """");
                    break;
                }
            }
        } while (!Continue);

        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu!");
        Console.ReadKey();
        Console.Clear();
    }

    private enum ModifyType
    {
        Name = 1,
        LastName = 2,
        Address = 3,
        Email = 4,
        Age = 5,
        BestFriends = 6,
    }

    public void Modify()
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
        int ModifyTypeInt = 0; 
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

            for (int i = 0; i < ids.Count; i++)
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
                ModifyTypeInt = Convert.ToInt32(Console.ReadLine());

                if (ModifyTypeInt <= 0 || ModifyTypeInt > 6)
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

        ModifyType modifier = (ModifyType)ModifyTypeInt;

        switch (modifier)
        {
            case ModifyType.Name:
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
                        names.Add(indexx, NewName.ToLower().Trim());

                    }
                    catch (Exception)
                    {
                        Continue1 = false;
                        TryCatch(ref Continue1);
                    }
                } while (!Continue1);
                break;

            case ModifyType.LastName:
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
                        lastNames.Add(indexx, NewLastName.ToLower().Trim());
                    }
                    catch (Exception)
                    {
                        continue2 = false;
                        TryCatch(ref continue2);
                    }
                } while (!continue2);
                break;


            case ModifyType.Address:
                string? NewAddress = string.Empty;
                bool continue3 = true;
                do
                {
                    try
                    {
                        continue3 = true; Console.Write($"Enter the new address: "); NewAddress = Console.ReadLine(); Console.Clear();
                        if (string.IsNullOrWhiteSpace(NewAddress)) { continue3 = false; Console.WriteLine("You must enter something!"); Console.WriteLine("Press any key to try again!"); Console.ReadKey(); Console.Clear(); }
                        addresses.Remove(indexx);
                        addresses.Add(indexx, NewAddress.ToLower().Trim());
                    }
                    catch (Exception) { continue3 = false; TryCatch(ref continue3); }
                } while (!continue3);
                break;
            case ModifyType.Email:
                string? NewEmail = string.Empty;
                bool continue4 = true;
                do
                {
                    try
                    {
                        continue4 = true; Console.Write($"Enter the new email: "); NewEmail = Console.ReadLine(); Console.Clear();
                        if (string.IsNullOrWhiteSpace(NewEmail)) { continue4 = false; Console.WriteLine("You must enter something!"); Console.WriteLine("Press any key to try again!"); Console.ReadKey(); Console.Clear(); }
                        emails.Remove(indexx);
                        emails.Add(indexx, NewEmail.ToLower().Trim());
                    }
                    catch (Exception) { continue4 = false; TryCatch(ref continue4); }
                } while (!continue4);
                break;
            case ModifyType.Age:
                int NewAge = 0;
                bool continue5 = true;
                do
                {
                    try
                    {
                        continue5 = true; Console.Write($"Enter the new age: "); NewAge = Convert.ToInt32(Console.ReadLine()); Console.Clear();
                        ages.Remove(indexx);
                        ages.Add(indexx, NewAge);
                    }
                    catch (Exception) { continue5 = false; TryCatch(ref continue5); }
                } while (!continue5);
                break;

            case ModifyType.BestFriends:
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
                        bestFriends.Add(indexx,isBestFriend);
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

    public void Delete()
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
        int index = -1;

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
                        break;
                    }

                    if (string.IsNullOrWhiteSpace(delete))
                    {
                        ContinueDelete = false;
                        Console.WriteLine("You must enter a name");
                        Console.WriteLine("Press any key to try again!");
                        Console.ReadKey();
                        Console.Clear();
                        return; 
                    }
                }

                if (index != -1)
                {
                    
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
                else
                {
                    Console.WriteLine("Name not found!");
                    Console.WriteLine("Press any key to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    ContinueDelete = false; 
                }

            }
            catch (Exception)
            {
                ContinueDelete = false;
                TryCatch(ref ContinueDelete);
            }

        } while (!ContinueDelete);
    }
}

