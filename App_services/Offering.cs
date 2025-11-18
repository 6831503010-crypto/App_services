using System;

class Offering
{
    // Structure to hold each quiz item
    public class Quiz
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string[] Options { get; set; }
        public char CorrectAnswer { get; set; }
    }

    // Typewriter effect for text display
    static void Typewrite(string text, int delayMs)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMs);
        }
        Console.WriteLine();
    }

    // Array of quizzes
    public Quiz[] Quizzes;
    public Quiz[] randomQuizess;

    //For tracking question display order and question IDs
    public Dictionary<int, int> QuestionDisplayNumber = new Dictionary<int, int>();


    // Store user answers: Key = question ID, Value = answer
    public Dictionary<int, char> UserAnswers = new Dictionary<int, char>();

    // Constructor to initialize quizzes
    public Offering()
    {
        Quizzes = new Quiz[]
        {
            new Quiz
            {
                Id = 1,
                Question = "What was the original name of the Buddha?",
                Options = new string[]
                {
                    "A. Prince Siddhartha",
                    "B. Prince Ajatashatru",
                    "C. Prince Devadatta"
                },
                CorrectAnswer = 'A'
            },
            new Quiz
            {
                Id = 2,
                Question = "Who were the father and mother of Prince Siddhartha?",
                Options = new string[]
                {
                    "A. King Bimbisara and Queen Revadee",
                    "B. Emperor Ashoka and Queen Pimpaa",
                    "C. King Suddhodana and Queen Sirimahamaya"
                },
                CorrectAnswer = 'C'
            },
            new Quiz
            {
                Id = 3,
                Question = "At what age did the Buddha attain enlightenment?",
                Options = new string[]
                {
                    "A. 29",
                    "B. 35",
                    "C. 40"
                },
                CorrectAnswer = 'B'
            },
            new Quiz
            {
                Id = 4,
                Question = "Who was the Buddha's chief disciple on the right side?",
                Options = new string[]
                {
                    "A. Venerable Ananda",
                    "B. Venerable Sariputta",
                    "C. Venerable Moggallana"
                },
                CorrectAnswer = 'B'
            },
            new Quiz
            {
                Id = 5,
                Question = "Who was the first monk in Buddhism?",
                Options = new string[]
                {
                    "A. Assaji",
                    "B. Venerable Ananda",
                    "C. Venerable Kondanna"
                },
                CorrectAnswer = 'C'
            },
            new Quiz
            {
                Id = 6,
                Question = "What do the Four Noble Truths refer to?",
                Options = new string[]
                {
                    "A. The path to end suffering",
                    "B. Four sublime truths",
                    "C. The law of karma"
                },
                CorrectAnswer = 'B'
            },
            new Quiz
            {
                Id = 7,
                Question = "Which of the following is NOT one of the Five Precepts?",
                Options = new string[]
                {
                    "A. Not chanting",
                    "B. Not killing",
                    "C. Not stealing"
                },
                CorrectAnswer = 'A'
            },
            new Quiz
            {
                Id = 8,
                Question = "Where was the Buddha born?",
                Options = new string[]
                {
                    "A. Kapilavastu",
                    "B. Varanasi",
                    "C. Lumbini Garden"
                },
                CorrectAnswer = 'C'
            },
            new Quiz
            {
                Id = 9,
                Question = "Who were the first listeners of the Buddha's sermon?",
                Options = new string[]
                {
                    "A. Venerable Ananda",
                    "B. Venerable Sariputta",
                    "C. The Five Ascetics (Pancavaggiya)"
                },
                CorrectAnswer = 'C'
            },
            new Quiz
            {
                Id = 10,
                Question = "What were the Four Divine Messengers (Deva Duta) that Prince Siddhartha saw?",
                Options = new string[]
                {
                    "A. Old man, sick person, dead body, ascetic (monk)",
                    "B. Poor man, rich man, good person, bad person",
                    "C. Sick person, healthy person, beautiful person, ugly person"
                },
                CorrectAnswer = 'A'
            }
        };

        randomQuizess = GetRandomQuiz(5);
    }

    //generate random quizzes
    public Quiz[] GetRandomQuiz(int amount)
    {
        // Make sure amount is not bigger than available questions
        if (amount > Quizzes.Length)
            amount = Quizzes.Length;

        // Copy the original quiz list so we don’t modify it
        List<Quiz> pool = new List<Quiz>(Quizzes);

        // Random selected questions
        List<Quiz> selected = new List<Quiz>();
        Random rnd = new Random();

        for (int i = 0; i < amount; i++)
        {
            int index = rnd.Next(pool.Count); // get a random index
            selected.Add(pool[index]);        // add that quiz
            pool.RemoveAt(index);             // remove,so no duplicates
        }

        return selected.ToArray();
    }

    // Read and validate user answer input
    char ReadAnswer()
    {
        while (true)
        {
            string input = Console.ReadLine().Trim().ToUpper();

            if (input.Length == 1 && "ABC".Contains(input))//Making sure input is only one character and is A, B, or C
                return input[0];

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Invalid input. Enter A, B, or C: ");
            Console.ResetColor();
        }
    }


    //Display quizzes to the user and collect answers
    public void DisplayQuizzes()
    {
        //reset the dictionaries before starting a new quiz round.
        UserAnswers.Clear();
        QuestionDisplayNumber.Clear();

        int i = 1;

        foreach (var q in randomQuizess)
        {
            Console.WriteLine($"\nQuestion {i}: {q.Question}");

            foreach (string opt in q.Options)
                Console.WriteLine(opt);

            Console.Write("\nEnter your answer (A-C): ");
            char ans = ReadAnswer();

            UserAnswers[q.Id] = ans;
            QuestionDisplayNumber[q.Id] = i;   // ⭐ STORE DISPLAY NUMBER HERE

            i++;
        }
    }

    // Get option text based on answer letter
    private string GetOptionText(Quiz q, char answerLetter)
    {
        char letter = char.ToUpper(answerLetter);
        int index = letter - 'A'; // A→0, B→1, C→2

        if (index >= 0 && index < q.Options.Length)
        {
            return q.Options[index];   // e.g. "B. Prince Siddhartha"
        }

        // Fallback if something goes wrong
        return letter.ToString();
    }

    // 🔹 SCORE FUNCTION
    public int CalculateScore()
    {
        int score = 0;

        Console.WriteLine("\n===== RESULT SUMMARY =====\n");

        foreach (var q in randomQuizess)
        {
            if (UserAnswers.ContainsKey(q.Id))
            {
                char userAns = UserAnswers[q.Id];
                char correct = q.CorrectAnswer;

                if (userAns == correct)
                {
                    score++;
                }
                else
                {
                    int displayNum = QuestionDisplayNumber[q.Id];

                    string userAnsText = GetOptionText(q, userAns);
                    string correctAnsText = GetOptionText(q, correct);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Typewrite($"Question {displayNum}: {q.Question}", 20);
                    Typewrite($"Your answer: {userAnsText}", 20);
                    Typewrite($"Correct answer: {correctAnsText}", 20);
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"❗ Question {q.Id} was not answered.");
            }
        }

        Typewrite($"You scored {score} out of {randomQuizess.Length}\n", 50);
        return score;
    }

    // Reward user based on score
    public string[] GetRewards(string[] inventory, int score)
    {
        string item = "";

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        if (score <= 1)
        {
            item = "Incense sticks";
            Typewrite("You received Incense as a reward.",50);
        }
        else if (score <= 3)
        {
            item = "Flowers";
            Typewrite("You received Flowers as a reward.",50);
        }
        else
        {
            item = "Candle";
            Typewrite("You received a Candle as a reward.",50);
        }
        Console.ResetColor();

        // Convert array → list to add item
        List<string> list = new List<string>(inventory);
        list.Add(item);

        return list.ToArray();
    }
}
