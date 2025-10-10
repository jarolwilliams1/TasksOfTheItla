decimal Number = 0;
int Option = 0;
bool Go = true;
int Option_Part2 = 0;
bool validate1;
bool Menu;



// Menu de inicio:
do
{
    try
    {
        Menu = true;

        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("1) Check if a number is even or odd");
        Console.WriteLine("2) Exit");
        Console.WriteLine("---------------------------------------------");

        Console.Write("Choose an option: ");
        Option = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        if (Option <= 0 || Option > 2)
        {
            Menu = false;
            Console.WriteLine("You must enter one of the given options (1 or 2)!");
            Console.WriteLine("Press any key to try again!");
            Console.ReadKey();
            Console.Clear();

        }

    }


    catch (FormatException)
    {
        Console.WriteLine("You must enter a number!");
        Console.WriteLine("Press any key to try again!");
        Console.ReadKey();
        Console.Clear();
        Menu = false;



    }
    catch (Exception)
    {
        Console.WriteLine($"There was an error, please try again.");
        Console.WriteLine("Press any key to try again!");
        Console.ReadKey();
        Console.Clear();
        Menu = false;

    }

} while (Menu == false);



// aqui estan las opcciones del programa en una estrucutura de control: 
while (Go)
{

    switch (Option)
    {

        // ocase 1 para si el usuario decide verifiar si un numero es par o impar 
        case 1:

            try
            {
                Console.Write("Enter a number: ");
                Number = Convert.ToDecimal(Console.ReadLine());
                Console.Clear();

                if (Number % 2 == 0)
                {
                    Console.WriteLine($"The number {Number} is even!");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine($"The number {Number} is odd!");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                    Console.Clear();

                }

                do
                {

                    // un try catch anidado que contiene una continuacion del programa dode se le pregunta 
                    // si desea seguir evaluando numeros pares o impares o, salir del programa: 

                    try
                    {
                        validate1 = true;
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("1) Continue with numbers");
                        Console.WriteLine("2) Exit the program");
                        Console.WriteLine("-------------------------------");
                        Console.Write("Choose an option: ");
                        Option_Part2 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (Option_Part2 <= 0 || Option_Part2 > 2)
                        {
                            validate1 = false;
                            Console.WriteLine("You must enter one of the given options (1 or 2)!");
                            Console.WriteLine("Press any key to try again!");
                            Console.ReadKey();
                            Console.Clear();

                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("You must enter a number!");
                        validate1 = false;
                        Console.WriteLine("Press any key to try again!");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"There was an error: {ex}");
                        validate1 = false;
                        Console.WriteLine("Press any key to try again!");
                        Console.ReadKey();
                        Console.Clear();
                    }

                } while (validate1 == false);

                if (Option_Part2 == 1)
                {
                    continue;
                }
                else if (Option_Part2 == 2)
                {

                    Go = false;

                    Console.Write("Exiting");

                    for (int i = 0; i < 5; i++)
                    {

                        Console.Write(".");
                        Thread.Sleep(200);

                    }
                    break;

                }

            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a number!");
                Console.WriteLine("Press any key to try again!");
                Console.ReadKey();
                Console.Clear();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error.");
                Console.WriteLine("Press any key to try again!");
                Console.ReadKey();
                Console.Clear();

            }

            break;

        // case 2 para salir del programa: 

        case 2:

            Console.Write("Exiting");

            for (int i = 0; i < 5; i++)
            {

                Console.Write(".");
                Thread.Sleep(200);

            }

            Go = false;
            break;

    }
}