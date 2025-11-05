using System.Reflection;

namespace App_services
{
    internal class Program
    {
        //display game story
        static void displayStory()
        {
            Console.WriteLine("You are a sinner who commited a lot of sins from previous life.");
            Console.WriteLine("To redeem your sins, you have to accumulate 1000 karma points by using our services.");
            Console.WriteLine("Good luck on your journey to redemption!");
            Console.WriteLine("adfadfasfafda");
            Console.WriteLine("dafafda");
            Console.WriteLine("This is a test");
            Console.WriteLine("This is aq test again");
        }

        //display status
        static void displayStatus(string name,int karma, string[] inventory)
        {
            Console.WriteLine("Player Name: {0}", name);
            Console.WriteLine("Your current karma points: {0}", karma);
            Console.WriteLine("Your current inventory: ");
            Console.WriteLine("------------------------");
            if (inventory.Length == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach (var item in inventory)
                {
                    int i = 1;//For numerating items
                    Console.WriteLine(i + ". " + item);
                    i++;
                }
            }
            Console.WriteLine("------------------------");
        }

        //zodiac calculator input setter
        static void setInput(zodiac_calculator zodiac, string input, string gender)
        {
            //Set values in zodiac_date class
            string[] dateParts = input.Split(new char[] { '.', '/' });

            int date = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);

            zodiac.setDate(date);
            zodiac.setMonth(month);
            zodiac.setYear(year);
            zodiac.setGender(gender);
        }

        //Validate input for do again in zodiac calculator
        static bool validateDoAgain(string input)
        {
            string answer = input.ToLower();
            if (answer == "y" || answer == "n")
            {
                return true;
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please answer with 'y' or 'n'.");
                Console.WriteLine();
                Console.ResetColor();
                return false;
            }
        }
        static void Main(string[] args)
        {
            //variables initialization and declaration
            string ans = "y";
            bool validChoice = true;
            int choice = 0; //Have to declare choice here to use it in switch case
            int karma = 1;
            string[] inventory = new string[] { };
            string name;

            zodiac_calculator zodiac_Calculator = new zodiac_calculator();

            //Ask for user's information
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            
            bool validDate = false;
            bool validGender = false;

            string input = "";
            string gender = "";
            while (!validDate || !validGender)
            {
                if (!validDate)
                {
                    Console.WriteLine();
                    input = zodiac_Calculator.askDate();
                    validDate = zodiac_Calculator.validateDate(input);
                }
                else if (!validGender)
                {
                    Console.WriteLine();
                    gender = zodiac_Calculator.askGender();
                    validGender = zodiac_Calculator.validateGender(gender);
                }
                else
                {
                    Console.WriteLine();
                    input = zodiac_Calculator.askDate();
                    gender = zodiac_Calculator.askGender();
                    validDate = zodiac_Calculator.validateDate(input);
                    validGender = zodiac_Calculator.validateGender(gender);
                }

            }




            while (karma<1000)
            {
                karma = -1000;
                //Display story
                displayStory();

                //Display status
                displayStatus(name,karma, inventory);

                //Display available services
                zodiac_Calculator.displayBuddah();

                Console.WriteLine("-------------------------");
                Console.WriteLine("");
                Console.WriteLine("1.Pray");
                Console.WriteLine("2.Store");
                Console.WriteLine("3.Zodiac Info");
                Console.WriteLine("4.Exit");
                Console.WriteLine("-------------------------");

                //ask for user's choice
                while (validChoice)
                {
                    Console.Write("Enter your choice: ");
                    if (int.TryParse(Console.ReadLine(), out choice))//out passes a variable by reference so the method can store a value in it
                    {
                        Console.WriteLine("Your choice:{0}", choice);
                        validChoice = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a number.");
                        Console.ResetColor();
                    }
                }


                //apply service based on user's choice
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Pray Selected");
                        break;
                    case 2:
                        Console.WriteLine("Store Selected");
                        break;
                    case 3:
                        
                        //Display welcome message
                        zodiac_Calculator.displayWelcomeMessage();
                        Console.WriteLine();
                        Console.WriteLine("Let's see what your zodiac signs and traits are!!!");
                        Console.WriteLine("___________________________________________________");
                        Console.WriteLine();

                        string do_again = "y";
                        while (do_again.ToLower() == "y")
                        {
                            //Read input values
                            setInput(zodiac_Calculator, input, gender);

                            //Calculate zodiac sign
                            zodiac_Calculator.calculate_zodiac(zodiac_Calculator.getDate(), zodiac_Calculator.getMonth());

                            //Display zodiac signs and traits
                            zodiac_Calculator.displayZodiacSign(zodiac_Calculator.getZodiacSign());
                            zodiac_Calculator.displayTraits(zodiac_Calculator.getZodiacSign(), zodiac_Calculator.getGender());
                            zodiac_Calculator.displayZodiacCompatibility(zodiac_Calculator.getZodiacSign());
                            zodiac_Calculator.displayCareer(zodiac_Calculator.getZodiacSign());
                            Console.ResetColor();


                            //Ask the user if they want to do it again and validate input
                            Console.WriteLine();
                            bool validDoAgain = false;
                            while (!validDoAgain)
                            {
                                Console.Write("Do you want to check another date? (y/n): ");
                                do_again = Console.ReadLine().ToLower();
                                if (validateDoAgain(do_again))
                                {
                                    validDoAgain = true;
                                    if (do_again == "y")
                                    {
                                        zodiac_Calculator.displayReminder(zodiac_Calculator.getZodiacSign());
                                    }
                                }
                                ;
                            }
                            Console.ResetColor();

                        }

                        zodiac_Calculator.displayReminder("");
                        zodiac_Calculator.displayGoodbyeMessage();
                        break;
                    case 4:
                        Console.WriteLine("Exiting the application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.Write("Do you want to continue? (y/n): ");
                ans = Console.ReadLine();

                //reset validChoice and choice for next iteration
                validChoice = true;
                choice = 0;
            }
        }
    }
}
