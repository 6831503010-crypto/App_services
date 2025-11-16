using System.Reflection;
using System.Threading;

namespace App_services
{
    internal class Program
    {
        //make text look like it's being typed
        static void Typewrite(string text, int delayMs)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        //display intro
        static void displayIntro()
        {
            string welcomMessage = @"This app combines learning and entertainment.
It helps you explore zodiac signs and Buddha prayers in a fun, interactive way while deepening your knowledge and self-awareness.";
            string intro = @"
    .                  .-.    .  _   *     _   .
           *          /   \     ((       _/ \       *    .
         _    .   .--'\/\_ \     `      /    \  *    ___
     *  / \_    _/ ^      \/\'__        /\/\  /\  __/   \ *
       /    \  /    .'   _/  /  \  *' /    \/  \/ .`'\_/\   .
  .   /\/\  /\/ :' __  ^/  ^/    `--./.'  ^  `-.\ _    _:\ _
     /    \/  \  _/  \-' __/.' ^ _   \_   .'\   _/ \ .  __/ \
   /\  .-   `. \/     \ / -.   _/ \ -. `_/   \ /    `._/  ^  \
  /  `-.__ ^   / .-'.--'    . /    `--./ .-'  `-.  `-. `.  -  `.
@/        `.  / /      `-.   /  .-'   / .   .'   \    \  \  .-  \%
@&8jgs@@%% @)&@&(88&@.-_=_-=_-=_-=_-=_.8@% &@&&8(8%@%8)(8@%8 8%@)%
@88:::&(&8&&8:::::%&`.~-_~~-~~_~-~_~-~~=.'@(&%::::%@8&8)::&#@8::::
`::::::8%@@%:::::@%&8:`.=~~-.~~-.~~=..~'8::::::::&@8:::::&8:::::'
 `::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::.'";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (var line in intro.Split('\n'))
            {
                Console.WriteLine(line);
                Thread.Sleep(100); // delay in milliseconds
            }

            Console.WriteLine();
            Typewrite(welcomMessage, 20);
            Console.ResetColor();
            Console.WriteLine();
        }

        //display game story
        static void displayStory()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;

            string story = @"You are a sinner who committed a lot of sins from your previous life.
To redeem your sins, you have to accumulate 1000 karma points by using our services.
Good luck on your journey to redemption!";


            string[] words = story.Split(' ');

            foreach (string word in words)
            {
                Console.Write(word + " ");
                Thread.Sleep(150); // delay in milliseconds (100–200 feels natural)
            }

            Console.ResetColor();
            Console.WriteLine("\n");
            Thread.Sleep(3500);//stays visible for 3.5 seconds
            Console.Clear();
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
                int i = 1;//For numerating items
                foreach (var item in inventory)
                {
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

        // Creating a set of prayers
        public static Prayer[] CreatePrayer()
        {
            Prayer p1 = new Prayer();
            p1.Line1 = "Namo Tatsa Pakawa To Araha To Summa Sumbhudda Sa";
            p1.Line2 = "Namo Tatsa Pakawa To Araha To Summa Sumbhudda Sa";
            p1.Line3 = "Namo Tatsa Pakawa To Araha To Summa Sumbhudda Sa";

            Prayer p2 = new Prayer();
            p2.Line1 = "Ei Mina Sakaray Na Bhudthung Apibhu Shayama";
            p2.Line2 = "Ei Mina Sakaray Na Thummung Apibhu Shayama";
            p2.Line3 = "Ei Mina Sakaray Na Sungkhung Apibhu Shayama";

            Prayer p3 = new Prayer();
            p3.Line1 = "Suppay Sutta Avera Hontuh ";
            p3.Line2 = "Aupphaya Phutsha Honthu Aneka Hontuh";
            p3.Line3 = "Sukkee Autthanung Pariha Runtuh";

            Prayer[] allprayer = { p1, p2, p3 };
            return allprayer;

        }
        static void Main(string[] args)
        {
            //variables initialization and declaration
            int choice = 0; //Have to declare and initiate choice here to use it in switch case
            int karma = -1000;//Start with -1000 karma
            string[] inventory = new string[] {"Yourself"};
            string name = "";

            zodiac_calculator zodiac_Calculator = new zodiac_calculator();
            
            //Display intro
            displayIntro();

            //Ask for user's information
            bool validName = true;//For validating name input
            while (validName)
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name cannot be empty. Please try again.");
                    Console.WriteLine();
                }
                else if (int.TryParse(name, out _))// _ means ignore this output,we don't need it, discard
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, are you a robot?");
                    Console.WriteLine();
                }
                else
                {
                    validName = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Welcome, {0}!", name);
                }
                Console.ResetColor();
            }
            

            //had to declare false to enter the loop for validating date and gender input
            bool validDate = false;
            bool validGender = false;

            //A container for user input,had to be declared outside the loop to be used after
            string input = "";//for asking input date
            string gender = "";//for asking gender

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

            //Display game story
            displayStory();

            bool validChoice = true;//For validating choice input in the game options
            //The main game loop
            while (karma<1000)
            {
                //Display status
                displayStatus(name,karma, inventory);

                //Display available services

                Console.WriteLine("------------------------");
                
                //Display main logo
                zodiac_Calculator.displayMainLogo();

                //Display menu options
                Console.WriteLine("1.Pray");
                Console.WriteLine("2.Get rewards");
                Console.WriteLine("3.Celestial Readings");    // Changed the menu to new idea
                Console.WriteLine("4.Offer");
                Console.WriteLine("5.Exit");
                Console.WriteLine("------------------------");

                //ask for user's choice and validate input loop
                while (validChoice)
                {
                    Console.Write("What do you want to do?: ");
                    if (int.TryParse(Console.ReadLine(), out choice))//out passes a variable by reference so the method can store a value in it
                    {
                        Console.WriteLine("Your choice:{0}", choice);  //if TryParse can convert to int do this (return true)
                        validChoice = false;                           // if you Parse and failed = error 
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;   // if can't do this (return false instead of error)
                        Console.WriteLine("Invalid input. Please enter a number.");
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                }

                //apply service based on user's choice
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("------------------------");
                        Typewrite("Pray Selected",20);
                        Console.WriteLine("------------------------");
                        zodiac_calculator.displayBuddah();
                        Console.WriteLine("");
                        Prayer[] Prayers = CreatePrayer();         // now we have a set of prayers 
                        int Score = Pray.PrayerInstruction();      // pick random prayer from Prayers, engage user, clean up/compare/keep score
                                                                   // Prayer doesnt randomize, fix by putting in this file?
                        
                        switch (Score)
                        {
                            case 3:
                                zodiac_calculator.Typewrite("\nYour prayer has been answered... (3/3)", 100);  //P.Kenny's method; make the text type out like a type writer
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" +300 Karma"); Console.ResetColor();
                                karma += 300;                      // 300 for now may change for more fun
                                Console.WriteLine("\n");
                                break;
                            case 2:
                                zodiac_calculator.Typewrite("\nYour prayer has been answered... (2/3)", 100);  
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" +200 Karma"); Console.ResetColor();
                                karma += 200;
                                Console.WriteLine("\n");
                                break;
                            case 1:
                                zodiac_calculator.Typewrite("\nYour prayer has been answered... (1/3)", 100);  
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" +100 Karma"); Console.ResetColor();
                                karma += 100;
                                Console.WriteLine("\n");
                                break;
                            default:
                                zodiac_calculator.Typewrite("\nYour prayer is terrible... (0/3)", 100);  
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" +0 Karma"); Console.ResetColor();
                                Console.WriteLine("\n");
                                break;
                        }
                        break;                     

                    case 2:
                        Console.Clear(); 
                        Console.WriteLine("");
                        Console.WriteLine("------------------------");
                        Typewrite("Get rewards Selected", 20);
                        Console.WriteLine("------------------------");
                        
                        Offering offering = new Offering();
                        offering.DisplayQuizzes();
                        int score = offering.CalculateScore();
                        inventory = offering.GetRewards(inventory,score);
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Clear();
                        //Display welcome message
                        zodiac_Calculator.displayStars();
                        Console.WriteLine("___________________________________________________");
                        Console.WriteLine();

                        string do_again = "y";
                        while (do_again.ToLower() == "y")
                        {
                            //Ask user's input and validate if they ask to check another date
                            if (input == null && gender == null)
                            {
                                validDate = false;
                                validGender = false;

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
                            }
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
                                        input = null;//resetting input values if user wants to do it again
                                        gender = null;//resetting input values if user wants to do it again
                                        zodiac_Calculator.displayReminder(zodiac_Calculator.getZodiacSign());
                                    }
                                }
                            }
                            Console.ResetColor();
                        }

                        zodiac_Calculator.displayReminder("");
                        zodiac_Calculator.displayGoodbyeMessage(name);
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("------------------------");
                        Typewrite("Offer Selected",20);
                        Console.WriteLine("------------------------");

                        if (inventory.Length == 0)
                        {
                            Typewrite("Sorry, you have nothing to offer yet.",20);
                            Console.WriteLine();
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            int i = 1;//For numerating items
                            foreach (var item in inventory)
                            {
                                Console.WriteLine(i + ". " + item);
                                i++;
                            }
                            Console.WriteLine("------------------------");
                            Console.WriteLine();

                            List<string> inventoryList = new List<string>(inventory);

                            //ask for user's choice and validate input loop
                            bool validItemChoice = true;
                            int itemChoice = 0;
                            while (validItemChoice)
                            {
                                Console.Write("Which item would you like to offer? (Enter the item number): ");
                                string offerItem = Console.ReadLine();

                                // Step 1: Validate integer
                                if (int.TryParse(offerItem, out itemChoice))
                                {
                                    // Step 2: Validate that the number is within the inventory range
                                    if (itemChoice >= 1 && itemChoice <= inventory.Length)
                                    {
                                        Console.WriteLine("Your choice: {0}", itemChoice);
                                        validItemChoice = false; // VALID → exit loop
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Please offer what you have.");
                                        Console.WriteLine();
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid input. Please enter a number.");
                                    Console.WriteLine();
                                    Console.ResetColor();
                                }
                            }


                            string itemToOffer = inventoryList[itemChoice - 1];//-1 to match index
                            inventoryList.Remove(itemToOffer);//remove item from inventory
                            zodiac_Calculator.displayOffering(itemToOffer);

                            //update score using switch
                            switch (itemToOffer)
                            {
                                case "Flowers":
                                    karma = karma + 75;
                                    break;
                                case "Candle":
                                    karma = karma + 50;
                                    break;
                                case "Incense sticks":
                                    karma = karma + 25;
                                    break;
                                case "Yourself":
                                    karma = karma + 1000;
                                    break;
                                default:
                                    Typewrite("Cannot find the item.", 20);
                                    break;
                            }

                            inventory = inventoryList.ToArray();//convert back to array
                            break;
                        }
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Leaving the redemption journey.");
                        //Display final status and ending when user chooses to exit
                        if (karma < 1000)
                        {
                            zodiac_Calculator.displayHell(name);
                        }
                        else
                        {
                            zodiac_Calculator.displayHeaven(name);
                        }
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;        // stops the loop vvv code runs after break
                }

                validChoice = true;
                choice = 0;
            }

            //Display final status and ending
            if (karma < 1000)
            {
                Console.Clear();
                zodiac_Calculator.displayHell(name);
            }
            else
            {
                Console.Clear();
                zodiac_Calculator.displayHeaven(name);
            }
        }
    }
}
