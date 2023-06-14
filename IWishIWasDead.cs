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
                Highlight("\n^c^[1] ^w^Play");
                Highlight("\n^c^[2] ^w^Select Questions");
                Highlight("\n^r^[0] ^w^Exit");
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
            int[] order = new int[questions.Length];
            for (int i = 0; i < order.Length; i++) order[i] = i;
            int temp;
            int index1;
            int index2;
            Random rand = new Random();
            for (int i  = 0; i < order.Length; i++)
            {
                index1 = rand.Next(order.Length);
                do
                {
                    index2 = rand.Next(order.Length);
                } while (index1 == index2);
                temp = order[index1];
                order[index1] = order[index2];
                order[index2] = temp;
            }
            foreach (int i in order)
            {
                Console.Clear();
                Console.WriteLine("Question:\n" + questions[i]);
                Highlight("^c^Press ENTER to reveal answer >>>  ^g^");
                Console.ReadLine();
                Highlight("^w^\n");
                Console.WriteLine("Answer\n" + answers[i]);
                Highlight("^c^Press ENTER to go to next question >>>  ^g^");
                Console.ReadLine();
                Highlight("^w^\n");
            }
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

        public static void Highlight(string text)
        {
            string[] split = text.Split('^');
            foreach (string s in split)
            {
                switch (s)
                {
                    case "b":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "c":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "g":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case "r":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "s":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "w":
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "y":
                        Console.ForegroundColor = ConsoleColor.Yellow;
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