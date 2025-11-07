using System;
using System.Globalization;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class zodiac_calculator
{
    private int dateInput;
    private int monthInput;
    private int yearInput;
    private string genderInput;
    private string zodiacSign;

    // Constructor
    public zodiac_calculator(int date, int month, int year, string gender)
    {
        this.dateInput = date;
        this.monthInput = month;
        this.yearInput = year;
        this.genderInput = gender;
    }

    public zodiac_calculator()
    {
        this.dateInput = 0;
        this.monthInput = 0;
        this.yearInput = 0;
        this.genderInput = " ";
    }

    // Methods
    //Determine Zodiac Color
    public void determine_zodiac_color(string zodiac)
    {
        switch (zodiac)
        {
            case "Aries":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "Taurus":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "Gemini":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "Cancer":
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case "Leo":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            case "Virgo":
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case "Libra":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "Scorpio":
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;
            case "Sagittarius":
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
            case "Capricorn":
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            case "Aquarius":
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                break;
            case "Pisces":
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White; // Default color for unknown zodiac
                break;
        }
    }

    // Calculate zodiac sign based on date and month
    public void calculate_zodiac(int date, int month)
    {
        // [Name, StartMonth, StartDay, EndMonth, EndDay]
        string[,] zodiacs =
        {
            { "Aquarius",    "1", "20", "2", "18" },
            { "Pisces",      "2", "19", "3", "20" },
            { "Aries",       "3", "21", "4", "19" },
            { "Taurus",      "4", "20", "5", "20" },
            { "Gemini",      "5", "21", "6", "20" },
            { "Cancer",      "6", "21", "7", "22" },
            { "Leo",         "7", "23", "8", "22" },
            { "Virgo",       "8", "23", "9", "22" },
            { "Libra",       "9", "23", "10", "22" },
            { "Scorpio",     "10","23","11","21" },
            { "Sagittarius", "11","22","12","21" },
            { "Capricorn",   "12","22","1","19" }
        };

        for (int i = 0; i < 12; i++)
        {
            int startM = int.Parse(zodiacs[i, 1]);
            int startD = int.Parse(zodiacs[i, 2]);
            int endM = int.Parse(zodiacs[i, 3]);
            int endD = int.Parse(zodiacs[i, 4]);

            bool inRange;
            if (startM < endM)
            {
                inRange = (month == startM && date >= startD) ||
                          (month == endM && date <= endD) ||
                          (month > startM && month < endM);
            }
            else
            {
                inRange = (month == startM && date >= startD) ||
                          (month == endM && date <= endD) ||
                          (month > startM || month < endM);
            }


            if (inRange)
            {
                this.zodiacSign = zodiacs[i, 0];
                break;
            }
            else
            {
                this.zodiacSign = "Unknown";
            }
        }
    }


    // Getters
    public int getDate()
    {
        return this.dateInput;
    }

    public int getMonth()
    {
        return this.monthInput;
    }

    public int getYear()
    {
        return this.yearInput;
    }

    public string getGender()
    {
        return this.genderInput;
    }

    public string getZodiacSign()
    {
        return this.zodiacSign;
    }

    // Setters
    public void setDate(int date)
    {
        this.dateInput = date;
    }

    public void setMonth(int month)
    {
        this.monthInput = month;
    }

    public void setYear(int year)
    {
        this.yearInput = year;
    }

    public void setGender(string gender)
    {
        this.genderInput = gender;
    }

    //Display methods

    public void displayZodiacCompatibility(string zodiac)
    {
        Console.WriteLine();
        Console.WriteLine(@"
 __                         __ __   ___        
|  |.-----.--.--.-----.    |  |__|.'  _|.-----.
|  ||  _  |  |  |  -__|    |  |  ||   _||  -__|
|__||_____|\___/|_____|    |__|__||__|  |_____|
                                               ");
        determine_zodiac_color(zodiac);
        switch (zodiac)
        {
            case "Aries":
                Console.WriteLine("Best Matches: Leo, Sagittarius, Gemini");
                Console.WriteLine("You vibe with people who match your passion, adventure, and confidence.");
                break;

            case "Taurus":
                Console.WriteLine("Best Matches: Virgo, Capricorn, Cancer");
                Console.WriteLine("You connect deeply with loyal, grounded partners who love stability and comfort.");
                break;

            case "Gemini":
                Console.WriteLine("Best Matches: Libra, Aquarius, Aries");
                Console.WriteLine("You need someone who can match your energy, wit, and curiosity for life.");
                break;

            case "Cancer":
                Console.WriteLine("Best Matches: Scorpio, Pisces, Taurus");
                Console.WriteLine("You blend best with partners who value emotion, loyalty, and deep connection.");
                break;

            case "Leo":
                Console.WriteLine("Best Matches: Aries, Sagittarius, Libra");
                Console.WriteLine("You shine brightest with someone who appreciates your confidence and heart.");
                break;

            case "Virgo":
                Console.WriteLine("Best Matches: Taurus, Capricorn, Scorpio");
                Console.WriteLine("You’re most compatible with those who respect your intelligence and calm energy.");
                break;

            case "Libra":
                Console.WriteLine("Best Matches: Gemini, Aquarius, Leo");
                Console.WriteLine("You vibe with charming, open-minded partners who bring balance and beauty to life.");
                break;

            case "Scorpio":
                Console.WriteLine("Best Matches: Cancer, Pisces, Virgo");
                Console.WriteLine("You need someone who can handle your passion, intensity, and loyalty.");
                break;

            case "Sagittarius":
                Console.WriteLine("Best Matches: Aries, Leo, Aquarius");
                Console.WriteLine("You click with free spirits who love travel, laughter, and chasing dreams.");
                break;

            case "Capricorn":
                Console.WriteLine("Best Matches: Taurus, Virgo, Scorpio");
                Console.WriteLine("You pair well with ambitious, steady people who share your drive and loyalty.");
                break;

            case "Aquarius":
                Console.WriteLine("Best Matches: Gemini, Libra, Sagittarius");
                Console.WriteLine("You thrive with partners who embrace your originality and give you space to dream.");
                break;

            case "Pisces":
                Console.WriteLine("Best Matches: Cancer, Scorpio, Capricorn");
                Console.WriteLine("You find peace with partners who are understanding, deep, and emotionally present.");
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unknown zodiac sign. Please check your input.");
                break;
        }
    }
    public void displayTraits(string zodiac, string gender)
    {
        determine_zodiac_color(zodiac);
        Console.WriteLine();
        Console.WriteLine(@"
 _______              __ __         
|_     _|.----.---.-.|__|  |_.-----.
  |   |  |   _|  _  ||  |   _|__ --|
  |___|  |__| |___._||__|____|_____|
                                    ");
        string Gender = gender.ToUpper();
        if (Gender == "M")
        {
            switch (zodiac)
            {
                case "Aquarius":

                    Console.WriteLine("Independent, creative, and forward-thinking.\r\nHe’s a bit unpredictable but always intriguing.\r\nValues freedom over routine.\r\nLoves ideas more than small talk.");
                    break;

                case "Pisces":

                    Console.WriteLine("Dreamy, emotional, and romantic.\r\nHe feels deeply and connects easily with others.\r\nA creative soul who gets lost in thought.\r\nGentle but needs grounding.");
                    break;

                case "Aries":

                    Console.WriteLine("Bold, confident, and restless — he dives into challenges head-first.\r\nHe thrives on competition and hates waiting around.\r\nSometimes impulsive, but always inspiring.\r\nHis energy lights up every room.");

                    break;

                case "Taurus":

                    Console.WriteLine("Calm, loyal, and dependable.\r\nHe enjoys good food, music, and peaceful routines.\r\nSlow to anger but stubborn once decided.\r\nHe values comfort, love, and trust.");

                    break;

                case "Gemini":

                    Console.WriteLine("Charming, witty, and talkative.\r\nHe loves new ideas and can adapt to any crowd.\r\nEasily bored, always searching for stimulation.\r\nHis mind never stops spinning.");

                    break;

                case "Cancer":

                    Console.WriteLine("Sensitive, loyal, and protective.\r\nHe may act tough, but he feels everything deeply.\r\nFamily means everything to him.\r\nOnce you earn his trust, he’s yours for good.");

                    break;

                case "Leo":

                    Console.WriteLine("Charismatic and proud, he was born to lead.\r\nHe loves attention but also protects those he loves.\r\nConfident yet generous, he inspires loyalty.\r\nA true king energy.");

                    break;

                case "Virgo":

                    Console.WriteLine("Smart, detail-driven, and calm under pressure.\r\nHe values logic and order.\r\nQuiet but deeply observant, always helping behind the scenes.\r\nHis love shows in action, not words.");

                    break;

                case "Libra":

                    Console.WriteLine("Smooth, diplomatic, and charming.\r\nHe loves peace, fairness, and balance.\r\nCan be indecisive but always means well.\r\nHe makes others feel seen and heard.");

                    break;

                case "Scorpio":

                    Console.WriteLine("Intense, loyal, and mysterious.\r\nHe feels deeply but hides it well.\r\nProtective and passionate, he loves all-in.\r\nWhen betrayed, he never forgets.");

                    break;

                case "Sagittarius":

                    Console.WriteLine("Adventurous, honest, and free-spirited.\r\nHe lives for travel, laughter, and big dreams.\r\nCan’t stand being tied down.\r\nHis optimism makes life fun.");

                    break;

                case "Capricorn":

                    Console.WriteLine("Ambitious, responsible, and patient.\r\nHe sets big goals and achieves them step by step.\r\nSerious but secretly sentimental.\r\nYou can rely on him no matter what.");

                    break;

                default:
                    Console.WriteLine("Unknown zodiac — no traits available.");
                    break;
            }

        }
        else if (Gender == "F")
        {
            switch (zodiac)
            {
                case "Aquarius":

                    Console.WriteLine("Unique and original, she doesn’t follow the crowd.\r\nShe’s kind yet detached — always in her own world.\r\nLoves deeply but on her own terms.\r\nShe’s electric energy in human form.");

                    break;

                case "Pisces":

                    Console.WriteLine("Intuitive, compassionate, and artistic.\r\nShe feels the world in colors and emotions.\r\nLoves unconditionally and forgives easily.\r\nHer heart is pure magic.");

                    break;

                case "Aries":

                    Console.WriteLine("Fierce and independent, she knows what she wants.\r\nShe’s brave enough to take the lead and doesn’t fear rejection.\r\nFull of fire, passion, and ambition.\r\nShe’s unstoppable when motivated.");

                    break;

                case "Taurus":

                    Console.WriteLine("Grounded yet sensual, she radiates steady energy.\r\nShe’s patient, nurturing, and loves beauty.\r\nWhen she loves, it’s deeply and genuinely.\r\nA Taurus woman is loyal for life.");

                    break;

                case "Gemini":

                    Console.WriteLine("Playful and curious, she’s full of stories and thoughts.\r\nShe shifts moods quickly but never loses her spark.\r\nSmart and sociable, she can connect with anyone.\r\nThere’s never a dull moment with her.");
                    break;

                case "Cancer":

                    Console.WriteLine("Gentle, caring, and emotionally intuitive.\r\nShe loves with her whole heart and remembers every detail.\r\nNurturing by nature but strong when needed.\r\nShe creates warmth wherever she goes.");

                    break;

                case "Leo":

                    Console.WriteLine("Radiant, bold, and glamorous.\r\nShe loves being admired but has a heart of gold.\r\nHer presence commands respect and joy.\r\nShe’s passionate, loyal, and unforgettable.");

                    break;

                case "Virgo":

                    Console.WriteLine("Elegant, intelligent, and graceful.\r\nShe’s organized and grounded in reality.\r\nCaring but careful — she doesn’t open up easily.\r\nOnce she does, she’s loyal for life.");

                    break;

                case "Libra":

                    Console.WriteLine("Stylish, kind, and socially gifted.\r\nShe values harmony and avoids drama.\r\nRomantic and idealistic, she believes in true love.\r\nShe’s the balance everyone needs.");

                    break;

                case "Scorpio":

                    Console.WriteLine("Magnetic and fearless, she owns her emotions.\r\nShe reads people instantly and never fakes connection.\r\nPassionate yet private — her mystery draws people in.\r\nLoyalty is everything to her.");

                    break;

                case "Sagittarius":

                    Console.WriteLine("Wild-hearted and curious about everything.\r\nShe speaks her mind and hates routine.\r\nIndependent but warm-hearted, she loves deeply.\r\nHer laughter is contagious.");

                    break;

                case "Capricorn":

                    Console.WriteLine("Strong, classy, and determined.\r\nShe builds her life with precision and grit.\r\nEmotionally guarded but incredibly loyal.\r\nA true boss with a soft core.");

                    break;

                default:
                    Console.WriteLine("Unknown zodiac — no traits available.");
                    break;
            }

        }
    }
    public void displayZodiacSign(string zodiacSign)
    {
        determine_zodiac_color(zodiacSign);

        switch (zodiacSign)
        {
            case "Aries":

                Console.WriteLine(@"
        .-.   .-.
       (_  \ /  _)
            |
            |
         Aries — The Ram
");
                break;

            case "Taurus":

                Console.WriteLine(@"
         .     .
         '.___.'
         .'   `.
        :       :
        :       :
         `.___.'
       Taurus — The Bull
");
                break;

            case "Gemini":

                Console.WriteLine(@"
         ._____.
           | |
           | |
          _|_|_
         '     '
       Gemini — The Twins
");
                break;

            case "Cancer":

                Console.WriteLine(@"
      .--.
     /   _`.     Cancer-  The Crab
    (_) ( )
   '.    /
     `--'");
                break;

            case "Leo":

                Console.WriteLine(@"
         .--.
        (    )
        (_)  /
            (_,
        Leo — The Lion
");
                break;

            case "Virgo":

                Console.WriteLine(@"
 _
  ' `:--.--.
     |  |  |_     Virgo-  The Virgin
     |  |  | )
     |  |  |/
          (J");
                break;

            case "Libra":

                Console.WriteLine(@"
        __
   ___.'  '.___   Libra-  The Balance
   ____________");
                break;

            case "Scorpio":

                Console.WriteLine(@"
   _
  ' `:--.--.
     |  |  |      Scorpius-  The Scorpion
     |  |  |
     |  |  |  ..,
           `---':");
                break;

            case "Sagittarius":

                Console.WriteLine(@"
          ...
          .':     Sagittarius-  The Archer
        .'
    `..'
    .'`.");
                break;

            case "Capricorn":

                Console.WriteLine(@"
            _
    \      /_)    Capricorn-  The Goat
     \    /`.
      \  /   ;
       \/ __.'
");
                break;

            case "Aquarius":

                Console.WriteLine(@"
 .-""-._.-""-._.-   Aquarius-  The Water Bearer
 .-""-._.-""-._.-");
                break;

            case "Pisces":

                Console.WriteLine(@"
     `-.    .-'   Pisces-  The Fishes
        :  :
      --:--:--
        :  :
     .-'    `-.");
                break;

            default:

                Console.WriteLine("Unknown zodiac — no ASCII art available.");
                break;
        }

        Console.ResetColor();
    }


    public void displayWelcomeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        //// Each letter is 7 lines tall. Only Z + spaces are used.
        //string[] Z = {
        //    "ZZZZZZZZ",
        //    "      ZZ",
        //    "     ZZ ",
        //    "   ZZ   ",
        //    "  ZZ    ",
        //    " ZZ     ",
        //    "ZZZZZZZZ"
        //};
        //string[] O = {
        //    " ZZZZZZ ",
        //    "ZZ    ZZ",
        //    "ZZ    ZZ",
        //    "ZZ    ZZ",
        //    "ZZ    ZZ",
        //    "ZZ    ZZ",
        //    " ZZZZZZ "
        //};
        //string[] D = {
        //    "ZZZZZZZ ",
        //    "ZZ     Z",
        //    "ZZ     Z",
        //    "ZZ     Z",
        //    "ZZ     Z",
        //    "ZZ     Z",
        //    "ZZZZZZZ "
        //};
        //string[] I = {
        //    "ZZZZZZZZ",
        //    "   ZZ   ",
        //    "   ZZ   ",
        //    "   ZZ   ",
        //    "   ZZ   ",
        //    "   ZZ   ",
        //    "ZZZZZZZZ"
        //};
        //string[] A = {
        //    "  ZZZZ  ",
        //    " ZZ  ZZ ",
        //    " ZZ  ZZ ",
        //    " ZZZZZZ ",
        //    " ZZ  ZZ ",
        //    " ZZ  ZZ ",
        //    " ZZ  ZZ "
        //};
        //string[] C = {
        //    " ZZZZZZ ",
        //    "ZZ      ",
        //    "ZZ      ",
        //    "ZZ      ",
        //    "ZZ      ",
        //    "ZZ      ",
        //    " ZZZZZZ "
        //};
        //string[] S = {
        //    " ZZZZZZ ",
        //    "ZZ      ",
        //    "ZZ      ",
        //    " ZZZZZZ ",
        //    "      ZZ",
        //    "      ZZ",
        //    " ZZZZZZ "
        //};
        //string[] EX = {
        //    "   ZZ   ",
        //    "   ZZ   ",
        //    "   ZZ   ",
        //    "   ZZ   ",
        //    "   ZZ   ",
        //    "        ",
        //    "   ZZ   "
        //};

        //int delayMs = 300; // animation speed per line

        //for (int i = 0; i < 7; i++)
        //{
        //    string line =
        //        Z[i] + "  " +
        //        O[i] + "  " +
        //        D[i] + "  " +
        //        I[i] + "  " +
        //        A[i] + "  " +
        //        C[i] + "  " +
        //        S[i] + "  " +
        //        EX[i] + " " + EX[i] + " " + EX[i]; // !!! made of Z
        //    Console.WriteLine(line);
        //    Thread.Sleep(delayMs);
        //}
        Console.Write(@"
              _ _            
             | (_)           
 _______   __| |_  __ _  ___ 
|_  / _ \ / _` | |/ _` |/ __|
 / / (_) | (_| | | (_| | (__ 
/___\___/ \__,_|_|\__,_|\___|");
        Console.Write(@"
          _            _       _             
          | |          | |     | |            
  ___ __ _| | ___ _   _| | __ _| |_ ___  _ __ 
 / __/ _` | |/ __| | | | |/ _` | __/ _ \| '__|
| (_| (_| | | (__| |_| | | (_| | || (_) | |   
 \___\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|   
                                              ");
        Console.ResetColor();
    }

    public void displayGoodbyeMessage()
    {
        string[] art1 =
        {
        "                          _",
        "                         / )",
        "                        / /    _",
        "              _        / /    / )",
        "             ( `.     / /-.  / /",
        "              `\\ \\   / // /`/ /",
        "                ; `-`  (_/ / /",
        "                |       (_/ /",
        "                \\          /",
        "                 )       /`",
        "                /      /`"
    };

        string[] art2 =
        {
        " _______                               ",
        "|     __|.-----.-----.    .--.--.---.-.",
        "|__     ||  -__|  -__|    |  |  |  _  |",
        "|_______||_____|_____|    |___  |___._|",
        "                          |_____|      "
    };

        ConsoleColor[] colors =
        {
        ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.DarkGreen
    };

        // animate first art
        for (int i = 0; i < art1.Length; i++)
        {
            Console.ForegroundColor = colors[i % colors.Length];
            Console.WriteLine(art1[i]);
            Thread.Sleep(80);
        }

        Console.WriteLine();
        Thread.Sleep(300);

        // animate second art
        for (int i = 0; i < art2.Length; i++)
        {
            Console.ForegroundColor = colors[(i + 1) % colors.Length];
            Console.WriteLine(art2[i]);
            Thread.Sleep(100);
        }

        Thread.Sleep(500);
        Console.ResetColor();
        Console.WriteLine();

        // typewriter outro
        string message = "Goodbye, have a great time!";
        int left = (Console.WindowWidth - message.Length) / 2;
        if (left > 0) Console.CursorLeft = left;

        foreach (char c in message)
        {
            Console.ForegroundColor = colors[c % colors.Length];
            Console.Write(c);
            Thread.Sleep(60);
        }

        Console.ResetColor();
        Console.WriteLine("\n");
    }

    public void displayReminder(string zodiac)
    {
        determine_zodiac_color(zodiac);
        Console.WriteLine(@"
         ,o888b,`?88888              Remember              88888P',d888o,
       ,8888 888   ?888    Zodiac signs are just for fun  888P   888 8888,
       8888888P'    888          and self-reflection.     888    `?8888888
       888P'        888               Peace!              888        `?888
       `88   O     d888        (Believe responsibly!)     888b     O   88'
         `?._  _.o88888                                   88888o._  _.P'
");
        Console.WriteLine("Don’t let them define your choices or relationships — trust your logic and life experiences too.");
    }

    public void displayCareer(string zodiac)
    {
        determine_zodiac_color(zodiac);
        Console.WriteLine(@"
 ______                              
|      |.---.-.----.-----.-----.----.
|   ---||  _  |   _|  -__|  -__|   _|
|______||___._|__| |_____|_____|__|  ");
        Console.WriteLine();
        switch (zodiac)
        {
            case "Aries":
                Console.WriteLine("Aries — The Leader");
                Console.WriteLine("Best Careers: Entrepreneur, Athlete, Military Officer, Emergency Responder");
                Console.WriteLine("Aries thrives where action, competition, and leadership are key.");
                break;

            case "Taurus":
                Console.WriteLine("Taurus — The Builder");
                Console.WriteLine("Best Careers: Banker, Chef, Interior Designer, Gardener, Musician");
                Console.WriteLine("They excel in stable, creative, and hands-on environments that offer comfort and reward.");
                break;

            case "Gemini":
                Console.WriteLine("Gemini — The Communicator");
                Console.WriteLine("Best Careers: Journalist, Marketer, Teacher, Public Relations, Software Developer");
                Console.WriteLine("Geminis succeed where they can share ideas, learn fast, and adapt to change.");
                break;

            case "Cancer":
                Console.WriteLine("Cancer — The Nurturer");
                Console.WriteLine("Best Careers: Counselor, Nurse, Social Worker, Chef, Real Estate Agent");
                Console.WriteLine("Cancers excel in emotionally supportive, people-focused roles that bring security to others.");
                break;

            case "Leo":
                Console.WriteLine("Leo — The Performer");
                Console.WriteLine("Best Careers: Actor, Manager, Designer, Politician, Influencer");
                Console.WriteLine("Leos shine in careers where they can inspire, lead, and be recognized for their creativity.");
                break;

            case "Virgo":
                Console.WriteLine("Virgo — The Analyst");
                Console.WriteLine("Best Careers: Editor, Doctor, Data Analyst, Researcher, Engineer");
                Console.WriteLine("Virgos do best in precise, detail-driven environments that value order and efficiency.");
                break;

            case "Libra":
                Console.WriteLine("Libra — The Diplomat");
                Console.WriteLine("Best Careers: Lawyer, Mediator, Designer, HR Specialist, Event Planner");
                Console.WriteLine("Libras succeed where balance, harmony, and teamwork are essential.");
                break;

            case "Scorpio":
                Console.WriteLine("Scorpio — The Strategist");
                Console.WriteLine("Best Careers: Psychologist, Detective, Scientist, Financial Analyst, Surgeon");
                Console.WriteLine("Scorpios thrive in deep, investigative, and high-stakes environments.");
                break;

            case "Sagittarius":
                Console.WriteLine("Sagittarius — The Explorer");
                Console.WriteLine("Best Careers: Travel Blogger, Professor, Pilot, Writer, Entrepreneur");
                Console.WriteLine("Sagittarians love freedom, exploration, and big ideas — they need space to roam and grow.");
                break;

            case "Capricorn":
                Console.WriteLine("Capricorn — The Achiever");
                Console.WriteLine("Best Careers: CEO, Engineer, Architect, Accountant, Project Manager");
                Console.WriteLine("Capricorns excel in structured careers that demand responsibility, patience, and strategy.");
                break;

            case "Aquarius":
                Console.WriteLine("Aquarius — The Visionary");
                Console.WriteLine("Best Careers: Scientist, Inventor, Tech Developer, Activist, Researcher");
                Console.WriteLine("Aquarians thrive where innovation, originality, and community impact matter most.");
                break;

            case "Pisces":
                Console.WriteLine("Pisces — The Dreamer");
                Console.WriteLine("Best Careers: Artist, Therapist, Musician, Writer, Photographer");
                Console.WriteLine("Pisces shine in creative or healing roles that let them express empathy and imagination.");
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unknown zodiac sign. Please check your input.");
                break;
        }
    }

    public void displayBuddah()
    {
        string buddahArt = @"
                           _
                        _ooOoo_
                       o8888888o
                       88"" . ""88
                       (| -_- |)
                       O\  =  /O
                    ____/`---'\____
                  .'  \\|     |//  `.
                 /  \\|||  :  |||//  \
                /  _||||| -:- |||||_  \
                |   | \\\  -  /'| |   |
                | \_|  `\`---'//  |_/ |
                \  .-\__ `-. -'__/-.  /
              ___`. .'  /--.--\  `. .'___
           ."""" '<  `.___\_<|>_/___.' _> \"""".
          | | :  `- \`. ;`. _/; .'/ /  .' ; |
          \  \ `-.   \_\_`. _.'_/_/  -' _.' /
===========`-.`___`-.__\ \___  /__.-'_.'_.-'================";
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        foreach (var line in buddahArt.Split('\n'))
        {
            Console.WriteLine(line);
            Thread.Sleep(100);// tweak speed if you want
        }
        Console.ResetColor();
    }
    public void displayHell()
    {
        Console.ForegroundColor = ConsoleColor.Red;

        // 1) show the art first (no outro text inside)
        string hellArt = @"
          (_)L|J
     )      ("" ) |     (
     ,(. A `/ \-|   (,`)
    )' (' \/\ / |  ) (.
   (' ),).  _W_ | (,)' )
  ^^^^^^^^^^^^^^^^^^^^^^^

 ,    ,    /\   /\
/( /\ )\  _\ \_/ /_
|\_||_/| < \_   _/ >
\______/  \|0   0|/
  _\/_   _(_  ^  _)_
 ( () ) /`\|V""""""V|/`\
   {}   \  \_____/  /
   ()   /\   )=(   /\
   {}  /  \_/\=/\_/  \";

        foreach (var line in hellArt.Split('\n'))
        {
            Console.WriteLine(line);
            Thread.Sleep(150); // tweak speed if you want
        }

        Console.WriteLine(); // spacer

        // 2) typewriter outro
        Typewrite("Time to pay for your sins.", 100); // ms per char

        Console.ResetColor();
    }

    static void Typewrite(string text, int delayMs)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMs);
        }
        Console.WriteLine();
    }

    public void displayHeaven()
    {
        Console.ForegroundColor=ConsoleColor.DarkYellow;
        string heavenArt = @"
             .---.
            / ,-- \
    .--.   ( (^_^) )   .--.
  ,'    \  (.-`-'(_)  /    `.
 /       `-/ \ `.  \-'       \
: (_,' .  / (.\_ "") \  . `._) :
|   `-'(_,\ \     / /._)`-'   |
|       .  `.\,O,'.'  .   :   |
|   . : !   /\_  /\   ! . !   |
| ! |-'-|  : """"T"""" :  |-'-| | |
| |-'   `-'|   H   |`-'   `-| |
`-'        |   H .:|        `-'
           | . H !||
           | : H :!|
           | ! H !||
           | | H |||
           | | H |||  
           /_,'V.L|.\ ";
        foreach (var line in heavenArt.Split('\n'))
        {
            Console.WriteLine(line);
            Thread.Sleep(150); // tweak speed if you want
        }

        Console.WriteLine(); // spacer
        Typewrite("Welcome to Heaven, my child", 100); // ms per char
        Console.ResetColor();
    }

    public void displayMainLogo()
    {
        string logo = @"
______         _                      _   _             
| ___ \       | |                    | | (_)            
| |_/ /___  __| | ___ _ __ ___  _ __ | |_ _  ___  _ __  
|    // _ \/ _` |/ _ \ '_ ` _ \| '_ \| __| |/ _ \| '_ \ 
| |\ \  __/ (_| |  __/ | | | | | |_) | |_| | (_) | | | |
\_| \_\___|\__,_|\___|_| |_| |_| .__/ \__|_|\___/|_| |_|
                               | |                      
                               |_|                      ";
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        foreach (var line in logo.Split('\n'))
        {
            Console.WriteLine(line);
            Thread.Sleep(100); // tweak speed if you want
        }
        Console.ResetColor();
    }

    //Ask Inputs
    public string askDate()
    {
        Console.Write("Enter your birth date in the format of dd/m/yyyy(16.9.1999): ");
        string input = Console.ReadLine();
        return input;
    }
    public string askGender()
    {
        Console.Write("Enter your gender(M/F): ");
        string gender = Console.ReadLine().ToUpper();
        return gender;
    }

    //Inputs validations
    public bool validateDate(string input)
    {
        DateTime tempDate;

        // Accept dots or slashes, single or double digits
        string[] formats = {
        "d.M.yyyy", "dd.M.yyyy",
        "d/M/yyyy", "dd.M.yyyy"
    };

        //Try parsing the date
        bool valid = DateTime.TryParseExact(
            input,
            formats,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out tempDate
        );

        if (!valid)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid format. Please use dd/m/yyyy or dd.m.yyyy (e.g. 16/9/1999).");
            Console.ResetColor();
            return false;
        }

        //Logical validation
        int currentYear = DateTime.Now.Year;
        if (tempDate.Year < 1900 || tempDate.Year > currentYear || tempDate > DateTime.Now)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorry,John Connor,we don't accept time travellers here! Please enter a realistic birthdate.");
            Console.ResetColor();
            return false;
        }


        //Passed all checks
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Birthdate accepted: {tempDate:dd.M.yyyy}");
        Console.ResetColor();
        return true;
    }

    public bool validateGender(string input)
    {
        string gender = input.ToUpper();
        if (gender == "M" || gender == "F")
        {
            //Passed all checks
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Gender accepted: {(gender == "M" ? "Male" : "Female")}");
            Console.ResetColor();
            return true;
        }
        else
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please specify your gender correctly(M/F).");
            Console.ResetColor();
            return false;
        }
    }
}