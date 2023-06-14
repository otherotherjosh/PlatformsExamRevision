namespace NotLookingForwardToThisExam
{
    internal class IWishIWasDead
    {
        static int[] sections = new int[] { 1 };
        static string[] questions = new string[0];
        static string[] answers = new string[0];

        static void Main(string[] args)
        {
            OpenMenu();
        }

        public static void OpenMenu()
        {
            int key;
            do
            {
                Console.Clear();
                Highlight("\nMain Menu\n");
                Highlight("\n^r^[0] ^w^Exit");
                Highlight("\n^c^[1] ^w^Play");
                Highlight("\n\n\n>>> ");
                string temp;
                temp = ReadLower();
                key = Convert.ToInt32(temp);
                switch (key)
                {
                    default:
                        Console.Clear();
                        Console.WriteLine("invalid selection!  try again in 1 sec");
                        Thread.Sleep(1000);
                        break;
                    case 0:
                        Console.WriteLine("\n\nClosing menu! :D byeeee");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case 1:
                        GetQuestions(sections);
                        Play();
                        break;
                }
            } while (key != 0);
        }

        static void GetQuestions(int[] sections)
        {
            string line;
            string fileName;
            Array.Resize(ref questions, 0);
            Array.Resize(ref answers, 0);
            foreach (int section in sections)
            {
                fileName = GetFileName(section);
                StreamReader r = new StreamReader(fileName);
                bool question = false;
                bool answer = false;
                while (!r.EndOfStream)
                {
                    line = r.ReadLine().Trim();
                    switch (line)
                    {
                        case null:
                            break;
                        case "Q.":
                            question = true;
                            answer = false;
                            Array.Resize(ref questions, questions.Length + 1);
                            break;
                        case "A.":
                            answer = true;
                            question = false;
                            Array.Resize(ref answers, answers.Length + 1);
                            break;
                        default:
                            if (question)
                            {
                                questions[questions.Length - 1] += line + "\n";
                            }
                            else if (answer)
                            {
                                answers[answers.Length - 1] += line + "\n";
                            }
                            break;
                    }
                }
            }
        }

        static void Play()
        {
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine("Question:\n" + questions[i]);
                Console.WriteLine("Answer\n" + answers[i]);
            }
            Console.ReadLine();
        }

        static string GetFileName(int section)
        {
            string fileName;
            switch (section)
            {
                case 1:
                    fileName = @"../../../Questions1.txt";
                    break;
                case 2:
                    fileName = @"../../../Questions2.txt";
                    break;
                case 3:
                    fileName = @"../../../Questions3.txt";
                    break;
                case 4:
                    fileName = @"../../../Questions4.txt";
                    break;
                case 5:
                    fileName = @"../../../Questions5.txt";
                    break;
                case 6:
                    fileName = @"../../../Questions6.txt";
                    break;
                default:
                    fileName = "AAA";
                    break;
            }
            return fileName;
        }

        /* static void TestRead(string[] questions, string fileName)
         * {
         *     StreamReader r = new StreamReader(fileName);
         *     int i = 0;
         *     while (!r.EndOfStream)
         *     {
         *         Array.Resize(ref testReader, testReader.Length + 1);
         *         testReader[i] = r.ReadLine();
         *         if (!(testReader[i] == "" || testReader[i].StartsWith("//"))) Console.WriteLine($"Line {i}: \"{testReader[i]}\"");
         *         i++;
         *     }
         *     r.Close();
         * }
         */

        public static void Highlight(string text)
        {
            string[] split = text.Split('^');
            foreach (string s in split)
            {
                switch (s)
                {
                    case "g":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "y":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "c":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "r":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "w":
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.Write(s);
                        break;
                }
            }
        }

        static string ReadLower()
        {
            /* this exists so we don't have to write
             * .Trim().ToLower() every time
             * we take user input
             */
            string output;
            output = Console.ReadLine().Trim().ToLower();
            return output;
        }
    }
}