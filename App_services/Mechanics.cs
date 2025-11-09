using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App_services
{
    public class Prayer // methods belong to this class
    {
        private string prayer1;
        private string prayer2;
        private string prayer3;

        //public Prayer(string line1)
        //{ prayer1 = line1; }
        //public Prayer(string line1, string line2, string line3)
        //{ prayer1 = line1; prayer2 = line2;prayer3 = line3; }

        public string Line1 { get { return prayer1; } set { prayer1 = value; } }
        public string Line2 { get { return prayer2; } set { prayer2 = value; } }
        public string Line3 { get { return prayer3; } set { prayer3 = value; } }

    }

    public class Pray
    {
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
        public static int PrayerInstruction()
        {
            Prayer[] allprayer = CreatePrayer();
            Random rand = new Random();
            int Randindex = rand.Next(allprayer.Length);    //randomly pick index from this []
            Prayer Randprayer = allprayer[Randindex];       // get a random prayer from index of [] of prayers

            Console.WriteLine("Type your prayer... ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"| {Randprayer.Line1} |");   // Shows Line 1 of this prayer
            Console.ResetColor();
            string pray1 = Console.ReadLine();              // Get user's input

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"| {Randprayer.Line2} |");
            Console.ResetColor();
            string pray2 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"| {Randprayer.Line3} |");
            Console.ResetColor();
            string pray3 = Console.ReadLine();

            // clean up user input
            pray1 = pray1.Trim();
            pray2 = pray2.Trim();
            pray2 = pray2.Trim();

            while (pray1.Contains("  ") || pray2.Contains("  ") || pray3.Contains("  "))
            {
                pray1 = pray1.Replace("  ", " ");
                pray2 = pray2.Replace("  ", " ");
                pray3 = pray3.Replace("  ", " ");
            }

            string fixed1 = pray1.ToLower();
            string fixed2 = pray2.ToLower();
            string fixed3 = pray3.ToLower();

            string compare1 = Randprayer.Line1.ToLower();
            string compare2 = Randprayer.Line2.ToLower();
            string compare3 = Randprayer.Line3.ToLower();

            int score = 0;
            if (fixed1 == compare1) { score++; }
            if (fixed2 == compare2) { score++; }
            if (fixed3 == compare3) { score++; }

            return score;
        }
    }
}
// Namo Tatsa Pakawa To Araha To Summa Sumbhudda Sa
//prayers[1] = new Prayers("Ei Mina Sakaray Na Bhudthung Apibhu Shayama", "Ei Mina Sakaray Na Thummung Apibhu Shayama", "Ei Mina Sakaray Na Sungkhung Apibhu Shayama");
//prayers[2] = new Prayers("A hung Sukito Homi A hung nittukko Homi", )
