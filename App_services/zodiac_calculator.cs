using System;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
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
    public static void Typewrite(string text, int delayMs)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMs);
        }
        Console.WriteLine();
    }
    public void displayCareer(string zodiac)
    {
        determine_zodiac_color(zodiac);
        string career;
        string careerLogo = @"
 ______                              
|      |.---.-.----.-----.-----.----.
|   ---||  _  |   _|  -__|  -__|   _|
|______||___._|__| |_____|_____|__|  ";
      
        foreach (var line in careerLogo.Split('\n'))
        {
            Console.WriteLine(line);
            Thread.Sleep(100);
        }
        Console.WriteLine();

        switch (zodiac)
        {
            case "Aries":
                career = @"Aries — The Leader
Best Careers: Entrepreneur, Athlete, Military Officer, Emergency Responder
Aries thrives where action, competition, and leadership are key.";
                break;

            case "Taurus":
                career = @"Taurus — The Builder
Best Careers: Banker, Chef, Interior Designer, Gardener, Musician
They excel in stable, creative, and hands-on environments that offer comfort and reward.";
                break;

            case "Gemini":
                career = @"Gemini — The Communicator
Best Careers: Journalist, Marketer, Teacher, Public Relations, Software Developer
Geminis succeed where they can share ideas, learn fast, and adapt to change.";
                break;

            case "Cancer":
                career = @"Cancer — The Nurturer
Best Careers: Counselor, Nurse, Social Worker, Chef, Real Estate Agent
Cancers excel in emotionally supportive, people-focused roles that bring security to others.";
                break;

            case "Leo":
                career = @"Leo — The Performer
Best Careers: Actor, Manager, Designer, Politician, Influencer
Leos shine in careers where they can inspire, lead, and be recognized for their creativity.";
                break;

            case "Virgo":
                career = @"Virgo — The Analyst
Best Careers: Editor, Doctor, Data Analyst, Researcher, Engineer
Virgos do best in precise, detail-driven environments that value order and efficiency.";
                break;

            case "Libra":
                career = @"Libra — The Diplomat
Best Careers: Lawyer, Mediator, Designer, HR Specialist, Event Planner
Libras succeed where balance, harmony, and teamwork are essential.";
                break;

            case "Scorpio":
                career = @"Scorpio — The Strategist
Best Careers: Psychologist, Detective, Scientist, Financial Analyst, Surgeon
Scorpios thrive in deep, investigative, and high-stakes environments.";
                break;

            case "Sagittarius":
                career = @"Sagittarius — The Explorer
Best Careers: Travel Blogger, Professor, Pilot, Writer, Entrepreneur
Sagittarians love freedom, exploration, and big ideas — they need space to roam and grow.";
                break;

            case "Capricorn":
                career = @"Capricorn — The Achiever
Best Careers: CEO, Engineer, Architect, Accountant, Project Manager
Capricorns excel in structured careers that demand responsibility, patience, and strategy.";
                break;

            case "Aquarius":
                career = @"Aquarius — The Visionary
Best Careers: Scientist, Inventor, Tech Developer, Activist, Researcher
Aquarians thrive where innovation, originality, and community impact matter most.";
                break;

            case "Pisces":
                career = @"Pisces — The Dreamer
Best Careers: Artist, Therapist, Musician, Writer, Photographer
Pisces shine in creative or healing roles that let them express empathy and imagination.";
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                career = "Unknown zodiac sign. Please check your input.";
                Console.ResetColor();
                break;
        }
        Typewrite(career, 10);
    }
    public void displayZodiacCompatibility(string zodiac)
    {
        Console.WriteLine();
        string match;
        string loveLogo = @"
 __                         __ __   ___        
|  |.-----.--.--.-----.    |  |__|.'  _|.-----.
|  ||  _  |  |  |  -__|    |  |  ||   _||  -__|
|__||_____|\___/|_____|    |__|__||__|  |_____|";

        foreach (var line in loveLogo.Split('\n'))
        {
            Console.WriteLine(line);
            Thread.Sleep(100);
        }
        Console.WriteLine();

        determine_zodiac_color(zodiac);
        switch (zodiac)
        {
            case "Aries":
                match = @"Best Matches: Leo, Sagittarius, Gemini
You vibe with people who match your passion, adventure, and confidence.";
                break;

            case "Taurus":
                match = @"Best Matches: Virgo, Capricorn, Cancer
You connect deeply with loyal, grounded partners who love stability and comfort.";
                break;

            case "Gemini":
                match = @"Best Matches: Libra, Aquarius, Aries
You need someone who can match your energy, wit, and curiosity for life.";
                break;

            case "Cancer":
                match = @"Best Matches: Scorpio, Pisces, Taurus
You blend best with partners who value emotion, loyalty, and deep connection.";
                break;

            case "Leo":
                match = @"Best Matches: Aries, Sagittarius, Libra
You shine brightest with someone who appreciates your confidence and heart.";
                break;

            case "Virgo":
                match = @"Best Matches: Taurus, Capricorn, Scorpio
You’re most compatible with those who respect your intelligence and calm energy.";
                break;

            case "Libra":
                match = @"Best Matches: Gemini, Aquarius, Leo
You vibe with charming, open-minded partners who bring balance and beauty to life.";
                break;

            case "Scorpio":
                match = @"Best Matches: Cancer, Pisces, Virgo
You need someone who can handle your passion, intensity, and loyalty.";
                break;

            case "Sagittarius":
                match = @"Best Matches: Aries, Leo, Aquarius
You click with free spirits who love travel, laughter, and chasing dreams.";
                break;

            case "Capricorn":
                match = @"Best Matches: Taurus, Virgo, Scorpio
You pair well with ambitious, steady people who share your drive and loyalty.";
                break;

            case "Aquarius":
                match = @"Best Matches: Gemini, Libra, Sagittarius
You thrive with partners who embrace your originality and give you space to dream.";
                break;

            case "Pisces":
                match = @"Best Matches: Cancer, Scorpio, Capricorn
You find peace with partners who are understanding, deep, and emotionally present.";
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                match = "Unknown zodiac sign. Please check your input.";
                Console.ResetColor();
                break;
        }
        Typewrite(match, 10);
    }
    public void displayTraits(string zodiac, string gender)
    {
        determine_zodiac_color(zodiac);
        Console.WriteLine();
        string traitsLogo = @"
 _______              __ __         
|_     _|.----.---.-.|__|  |_.-----.
  |   |  |   _|  _  ||  |   _|__ --|
  |___|  |__| |___._||__|____|_____|";
 
        foreach (var line in traitsLogo.Split('\n'))
        {
            Console.WriteLine(line);
            Thread.Sleep(100);
        }
        Console.WriteLine();
        string Gender = gender.ToUpper();
        string traits;
        if (Gender == "M")
        {
            switch (zodiac)
            {
                case "Aquarius":
                    traits = @"Independent, creative, and forward-thinking.
He’s a bit unpredictable but always intriguing.
Values freedom over routine.
Loves ideas more than small talk.";
                    break;

                case "Pisces":
                    traits = @"Dreamy, emotional, and romantic.
He feels deeply and connects easily with others.
A creative soul who gets lost in thought.
Gentle but needs grounding.";
                    break;

                case "Aries":
                    traits = @"Bold, confident, and restless — he dives into challenges head-first.
He thrives on competition and hates waiting around.
Sometimes impulsive, but always inspiring.
His energy lights up every room.";
                    break;

                case "Taurus":
                    traits = @"Calm, loyal, and dependable.
He enjoys good food, music, and peaceful routines.
Slow to anger but stubborn once decided.
He values comfort, love, and trust.";
                    break;

                case "Gemini":
                    traits = @"Charming, witty, and talkative.
He loves new ideas and can adapt to any crowd.
Easily bored, always searching for stimulation.
His mind never stops spinning.";
                    break;

                case "Cancer":
                    traits = @"Sensitive, loyal, and protective.
He may act tough, but he feels everything deeply.
Family means everything to him.
Once you earn his trust, he’s yours for good.";
                    break;

                case "Leo":
                    traits = @"Charismatic and proud, he was born to lead.
He loves attention but also protects those he loves.
Confident yet generous, he inspires loyalty.
A true king energy.";
                    break;

                case "Virgo":
                    traits = @"Smart, detail-driven, and calm under pressure.
He values logic and order.
Quiet but deeply observant, always helping behind the scenes.
His love shows in action, not words.";
                    break;

                case "Libra":
                    traits = @"Smooth, diplomatic, and charming.
He loves peace, fairness, and balance.
Can be indecisive but always means well.
He makes others feel seen and heard.";
                    break;

                case "Scorpio":
                    traits = @"Intense, loyal, and mysterious.
He feels deeply but hides it well.
Protective and passionate, he loves all-in.
When betrayed, he never forgets.";
                    break;

                case "Sagittarius":
                    traits = @"Adventurous, honest, and free-spirited.
He lives for travel, laughter, and big dreams.
Can’t stand being tied down.
His optimism makes life fun.";
                    break;

                case "Capricorn":
                    traits = @"Ambitious, responsible, and patient.
He sets big goals and achieves them step by step.
Serious but secretly sentimental.
You can rely on him no matter what.";
                    break;

                default:
                    traits = "Unknown zodiac — no traits available.";
                    break;
            }
            Typewrite(traits, 10);
        }
        else if (Gender == "F")
        {
            switch (zodiac)
            {
                case "Aquarius":
                    traits = @"Unique and original, she doesn’t follow the crowd.
She’s kind yet detached — always in her own world.
Loves deeply but on her own terms.
She’s electric energy in human form.";
                    break;

                case "Pisces":
                    traits = @"Intuitive, compassionate, and artistic.
She feels the world in colors and emotions.
Loves unconditionally and forgives easily.
Her heart is pure magic.";
                    break;

                case "Aries":
                    traits = @"Fierce and independent, she knows what she wants.
She’s brave enough to take the lead and doesn’t fear rejection.
Full of fire, passion, and ambition.
She’s unstoppable when motivated.";
                    break;

                case "Taurus":
                    traits = @"Grounded yet sensual, she radiates steady energy.
She’s patient, nurturing, and loves beauty.
When she loves, it’s deeply and genuinely.
A Taurus woman is loyal for life.";
                    break;

                case "Gemini":
                    traits = @"Playful and curious, she’s full of stories and thoughts.
She shifts moods quickly but never loses her spark.
Smart and sociable, she can connect with anyone.
There’s never a dull moment with her.";
                    break;

                case "Cancer":
                    traits = @"Gentle, caring, and emotionally intuitive.
She loves with her whole heart and remembers every detail.
Nurturing by nature but strong when needed.
She creates warmth wherever she goes.";
                    break;

                case "Leo":
                    traits = @"Radiant, bold, and glamorous.
She loves being admired but has a heart of gold.
Her presence commands respect and joy.
She’s passionate, loyal, and unforgettable.";
                    break;

                case "Virgo":
                    traits = @"Elegant, intelligent, and graceful.
She’s organized and grounded in reality.
Caring but careful — she doesn’t open up easily.
Once she does, she’s loyal for life.";
                    break;

                case "Libra":
                    traits = @"Stylish, kind, and socially gifted.
She values harmony and avoids drama.
Romantic and idealistic, she believes in true love.
She’s the balance everyone needs.";
                    break;

                case "Scorpio":
                    traits = @"Magnetic and fearless, she owns her emotions.
She reads people instantly and never fakes connection.
Passionate yet private — her mystery draws people in.
Loyalty is everything to her.";
                    break;

                case "Sagittarius":
                    traits = @"Wild-hearted and curious about everything.
She speaks her mind and hates routine.
Independent but warm-hearted, she loves deeply.
Her laughter is contagious.";
                    break;

                case "Capricorn":
                    traits = @"Strong, classy, and determined.
She builds her life with precision and grit.
Emotionally guarded but incredibly loyal.
A true boss with a soft core.";
                    break;

                default:
                    traits = "Unknown zodiac — no traits available.";
                    break;
            }
            Typewrite(traits, 10);
        }
    }
    public void displayZodiacSign(string zodiacSign)
    {
        determine_zodiac_color(zodiacSign);
        string zodiacLogo;

        switch (zodiacSign)
        {
            case "Aries":
                zodiacLogo = @"
        .-.   .-.
       (_  \ /  _)
            |
            |
         Aries — The Ram
";
                break;

            case "Taurus":
                zodiacLogo = @"
         .     .
         '.___.'
         .'   `.
        :       :
        :       :
         `.___.'
       Taurus — The Bull
";
                break;

            case "Gemini":
                zodiacLogo = @"
         ._____.
           | |
           | |
          _|_|_
         '     '
       Gemini — The Twins
";
                break;

            case "Cancer":
                zodiacLogo = @"
      .--.
     /   _`.     
    (_) ( )
   '.    /
     `--'
     Cancer — The Crab
";
                break;

            case "Leo":
                zodiacLogo = @"
         .--.
        (    )
        (_)  /
            (_,
        Leo — The Lion
";
                break;

            case "Virgo":
                zodiacLogo = @"
 _
  ' `:--.--.
     |  |  |_     
     |  |  | )
     |  |  |/
          (J
     Virgo — The Virgin
";
                break;

            case "Libra":
                zodiacLogo = @"
        __
   ___.'  '.___   
   ____________
     Libra — The Balance
";
                break;

            case "Scorpio":
                zodiacLogo = @"
   _
  ' `:--.--.
     |  |  |      
     |  |  |
     |  |  |  ..,
           `---':
     Scorpio — The Scorpion
";
                break;

            case "Sagittarius":
                zodiacLogo = @"
          ...
          .':
        .'
    `..'
    .'`.
     Sagittarius — The Archer
";
                break;

            case "Capricorn":
                zodiacLogo = @"
            _
    \      /_)    
     \    /`.
      \  /   ;
       \/ __.'
     Capricorn — The Goat
";
                break;

            case "Aquarius":
                zodiacLogo = @"
 .-""-._.-""-._.-   
 .-""-._.-""-._.-
     Aquarius — The Water Bearer
";
                break;

            case "Pisces":
                zodiacLogo = @"
     `-.    .-'   
        :  :
      --:--:--
        :  :
     .-'    `-.
     Pisces — The Fishes
";
                break;

            default:
                zodiacLogo = "Unknown zodiac — no ASCII art available.";
                break;
        }

        foreach (var line in zodiacLogo.Split('\n'))
        {
            Console.WriteLine(line);
            Thread.Sleep(100);
        }

        Console.ResetColor();
    }

    public void displayStars()
    {
        string starsArtCombined = @"
                 '                                 .                      .
            *          .                           .                      ;
                   *      '                        :                  - --+- -
              *              *                     !           .          !
                                                   |        .             .
   *   '*                                          |_         +
          *                                     ,  | `.
                *                         --- --+-<#>-+- ---  --  -
                         *                      `._|_,'
               *                                   T
                      *                            |
                                                   ! 
                                                   :         . : 
                                                   .       *,
";
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        foreach (var line in starsArtCombined.Split('\n'))
        {
            Console.WriteLine(line);
            Thread.Sleep(100);// tweak speed if you want
        }
        Console.ResetColor();
        Typewrite("Let's see what the stars tell about you...",50);
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
    public void displayGoodbyeMessage(string name)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        string art2 = @"
     _____     _____
  ,gdPPPPRb, ,dPPPPRbg,
 dP'      `YdP'      `Yb
 8)        `8'        (8
 Yb,        ""        ,dP
  ""8bggg         gggd8""
  ,gdP""""         """"Ybg,
 dP'        a        `Yb
 8)        ,8,        (8
 Yb,      ,d8b       ,dP
  ""8baaaadP""8""Ybaaaad8""
    `""`""'   8   `""'""'
            8
            8
            8    
            8    
            8";

        //foreach (var line in art2.Split('\n'))
        //{
        //    Console.WriteLine(line);
        //    Thread.Sleep(100);
        //    Console.WriteLine();
        //}
        Typewrite(art2, 13);

        Typewrite("Good luck on your journey,"+name, 100);
        Console.ResetColor();
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
    public static void displayBuddah()
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
    public void displayHeaven()
    {
        Console.ForegroundColor=ConsoleColor.DarkYellow;
        string heavenArt = @"
_      `-._     `-.     `.   \      :      /   .'     .-'     _.-'      _
 `--._     `-._    `-.    `.  `.    :    .'  .'    .-'    _.-'     _.--'
      `--._    `-._   `-.   `.  \   :   /  .'   .-'   _.-'    _.--'
`--.__     `--._   `-._  `-.  `. `. : .' .'  .-'  _.-'   _.--'     __.--'
__    `--.__    `--._  `-._ `-. `. \:/ .' .-' _.-'  _.--'    __.--'    __
  `--..__   `--.__   `--._ `-._`-.`_=_'.-'_.-' _.--'   __.--'   __..--'
--..__   `--..__  `--.__  `--._`-q(-_-)p-'_.--'  __.--'  __..--'   __..--
      ``--..__  `--..__ `--.__ `-'_) (_`-' __.--' __..--'  __..--''
...___        ``--..__ `--..__`--/__/  \--'__..--' __..--''        ___...
      ```---...___    ``--..__`_(<_   _/)_'__..--''    ___...---'''
```-----....._____```---...___(__\_\_|_/__)___...---'''_____.....-----'''
 ___   __  ________   _______   _       _   _______    ___   __   _______
|| \\  ||     ||     ||_____))  \\     //  ||_____||  || \\  ||  ||_____||
||  \\_||  ___||___  ||     \\   \\___//   ||     ||  ||  \\_||  ||     ||";
        foreach (var line in heavenArt.Split('\n'))
        {
            Console.WriteLine(line);
            Thread.Sleep(150); // tweak speed if you want
        }

        Console.WriteLine(); // spacer
        Typewrite("Peace has returned to your heart — welcome to the realm beyond sorrow, my child.", 100); // ms per char
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

    public void displayOffering(string item)
    {
        Console.WriteLine();
        string flowerArt = @"
         \'-.      _.-""/             \""-._      .-'/              
     (\    :  :    /   /               \   \    :  :    /)         
      \'-.  i |   /   /                 \   \   | i  .-'/          
       '. \  \i  /_.-""                   ""-._\  i/  / .'           
         '-'-.; /""                           ""\ ;.-'-'             
              \/                               \/                  
            ('""""')                           ('""""')                
             \  /                             \  /                 
              )(                               )(                  
             i__i                             i__i                 
            i____i                           i____i            ";

        string candleArt = @"
              )
             (_)
            .-'-.
            |   |
            |   |
            |   |
            |   |
          __|   |__   .-.
       .-'  |   |  `-:   :
      :     `---'     :-'
       `-._       _.-'
           '""""""";

        string incenseArt = @"
        ~     ~      ~
         ~  ~    ~  ~
          ~   ~   ~
           ||  ||  ||
           ||  ||  ||
           ||  ||  ||
           ||  ||  ||
           ||  ||  ||
           ||  ||  ||
           ||  ||  ||
         __||__||__||__
        |______________|
";

        string yourselfArt = @"
       _=_
     q(-_-)p
     '_) (_`
     /__/  \
   _(<_   / )_
  (__\_\_|_/__)";

        switch (item)
        {
            case "flowers":
                Console.ForegroundColor = ConsoleColor.Green;
                Typewrite(@"You offered flowers to Buddha.
Their beauty fades, yet their fragrance lingers —
reminding us that all things bloom and pass in peace.", 20);
                foreach (var line in flowerArt.Split('\n'))
                {
                    Console.WriteLine(line);
                    Thread.Sleep(50);
                }
                break;
            case "candles":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Typewrite(@"You offered light to Buddha.
In that flame burns away ignorance,
and wisdom dawns — gentle, endless, pure.", 20);
                foreach (var line in candleArt.Split('\n'))
                {
                    Console.WriteLine(line);
                    Thread.Sleep(50);
                }
                Console.WriteLine(@"");
                break;
            case "incense sticks":
                Console.ForegroundColor = ConsoleColor.Yellow;
                Typewrite(@"You offered incense to Buddha.
Its smoke rises like prayers unspoken,
carrying your heart toward stillness and release.", 20);
                foreach (var line in incenseArt.Split('\n'))
                {
                    Console.WriteLine(line);
                    Thread.Sleep(50);
                }
                break;
            case "yourself":
                Console.ForegroundColor = ConsoleColor.Blue;
                Typewrite(@"You offered yourself to Buddha.
In surrender, the illusion of self dissolves —
what remains is peace, boundless and whole.", 20);
                foreach (var line in yourselfArt.Split('\n'))
                {
                    Console.WriteLine(line);
                    Thread.Sleep(50);
                }
                break;
            default:
                Typewrite("Cannot find the item.",20);
                break;
        }
        Console.ResetColor();
        Console.WriteLine();
        Thread.Sleep(2500);
        Console.Clear();
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