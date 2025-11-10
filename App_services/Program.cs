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
            string ans = "y";
            bool validChoice = true;
            int choice = 0; //Have to declare and initiate choice here to use it in switch case
            int karma = 1;
            string[] inventory = new string[] { };
            string name;


            zodiac_calculator zodiac_Calculator = new zodiac_calculator();
            //Display intro
            displayIntro();

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

            //Display game story
            displayStory();

            //The main game loop
            while (karma<1000)
            {
                karma = -1000;
          
                //Display status
                displayStatus(name,karma, inventory);

                //Display available services

                Console.WriteLine("------------------------");
                
                //Display main logo
                zodiac_Calculator.displayMainLogo();

                Console.WriteLine("1.Pray");
                Console.WriteLine("2.Go to store");
                Console.WriteLine("3.Check zodiac sign");
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
                        Console.ResetColor();
                    }
                }

                //apply service based on user's choice
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Pray Selected");
                        //Prayer[] P = Pray.CreatePrayer(); // get the method into this file| fix tmr 
                        karma = 1500; //for testing purposes, set karma to 1500 to exit the loop
                        break;

                    case 2:
                        Console.WriteLine("Store Selected");
                        string[] question = {"1.what was the original name of the Buddha?",
                              "2.Who were the father and mother of Prince Siddhartha?",
                              "3.At what age did the Buddha attain enlightenment?",
                              "4.Who was the Buddha's chief disciple on the right side?",
                              "5.Who was the first monk in Buddhism?",
                              "6.What does (The four Noble Truths) refer to?",
                              "7.Which of the following is NOT one of the FIVE PRECRPTS?",
                              "8.Where was the Buddha born?",
                              "9.Who were the first listeners of the Buddha's sermon",
                              "10.What were the four 'Divine Messengers'(Deva Duta) that Prince Siddhartha saw?"};

                        string[,] choices ={ { "Prince Siddhartha", "Prince Ajatashatru", "Prince Devadatta" },
                              {"K.Bimbisara and Q.Revadee","Emperor Ashoka and Q. Pimpaa","K.Suddhodana and Q.Sirimahamaya" },
                              { " 29 Y"," 35 Y"," 40 Y"},
                              { " Venerable Ananda "," Venerable Sariputta" , " Venerable Moggallana" },
                              { "Assaji","Venerable Ananda","Venerable Kondanna"},
                              { "The path to end suffering","Four sublime truths","The law of karma" },
                              { "Not Chanting","Not killing","Not stealing" },
                              { "Kapilavastu","Varanasi","Lumbini Garden"},
                              { "Venerable Ananda","Venerable Sariputta","The Five Ascetics(Pancavaggiya)"},
                              { "An old man, A sick person, A dead body and ascetic(Monk)",
                                "A poor man, A rich man, A good person and a bad person",
                                "A sick person, A healthy person, A beautiful person and an ugly person" } };
                        
                        int[] answers = { 0, 2, 1, 1, 2, 1, 0, 2, 2, 0 };

                        List<string> offeringHistory = new List<string>();
                        int round = 1;

                        string playAgain;
                        do
                        {
                            int score = 0;
                            Console.WriteLine($"--- offering ---");
                            Console.WriteLine(" ");
                            Console.WriteLine($" Welcome to Buddhism Quiz! - Round {round} ");
                            Console.WriteLine(" ");

                            for (int i = 0; i < question.Length; i++)
                            {
                                Console.WriteLine("========================================================");
                                Console.WriteLine($"Question No.{i + 1}");
                                Console.WriteLine(question[i]);
                                Console.WriteLine();

                                for (int j = 0; j < 3; j++)
                                {
                                    Console.WriteLine($"{j + 1}. {choices[i, j]}");
                                }

                                while (true)
                                {
                                    Console.Write("Pls...select 1,2,3 : ");
                                    //string input = Console.ReadLine();

                                    if (int.TryParse(input, out int userChoice) && userChoice >= 1 && userChoice <= 3)
                                    {
                                        if (userChoice - 1 == answers[i])
                                        {
                                            Console.WriteLine(" Correct!!! ");
                                            score++;
                                        }
                                        else
                                        {
                                            Console.WriteLine($" Wrong!!! The correct is {choices[i, answers[i]]}");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Pls select 1-3 only");
                                    }
                                }


                            }
                            Console.WriteLine("\n========================================================");
                            Console.WriteLine($"Total Score is : {score}/{question.Length}");

                            string offering;
                            if (score >= 8)
                                offering = "You offer Sangha offering";
                            else if (score >= 5)
                                offering = "You offer Money and Flower";
                            else if (score >= 2)
                                offering = "You offer Candles";
                            else
                                offering = "You offer nothing";

                            Console.WriteLine($"Your reward: {offering}");
                            Console.WriteLine("========================================================");

                            offeringHistory.Add($"Round {round}: Score {score}/10 → {offering}");
                            round++;

                            Console.Write("\nDo you want to play again? (Y/N): ");
                            playAgain = Console.ReadLine().Trim().ToUpper();

                        }
                        while (playAgain == "Y");

                        Console.WriteLine("\n--- Summary of Offerings ---");
                        foreach (var entry in offeringHistory)
                        {
                            Console.WriteLine(entry);
                        }

                        Console.WriteLine("\nThank you for playing the Buddhism Quiz!");


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
                                        input = null;
                                        gender = null;
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
                        Console.WriteLine("Offer selected.");
                        break;
                    case 5:
                        Console.WriteLine("Leaving the redemption journey.");
                        //Display final status and ending when user chooses to exit
                        if (karma < 1000)
                        {
                            zodiac_Calculator.displayHell();
                        }
                        else
                        {
                            zodiac_Calculator.displayHeaven();
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
                zodiac_Calculator.displayHell();
            }
            else
            {
                zodiac_Calculator.displayHeaven();
            }
        }
    }
}
