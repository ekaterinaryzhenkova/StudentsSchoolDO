using System.Net;

namespace HW2
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Choose option:");
                Console.WriteLine("1 - To read the file");
                Console.WriteLine("2 - To record the code");
                Console.WriteLine("3 - To calculate the fibonacci number");
                Console.WriteLine("4 - To finish the work");

                int choice = DoChoice(1, 4);

                switch (choice)
                {
                    case 1:
                        ReadMenu();
                        break;
                    case 2:
                        WriteMenu();
                        break;
                    case 3:
                        FibonacciMenu();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void FibonacciMenu()
        {
            Console.Write("Enter the number: ");

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                FibonacciCalculator(num);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input error");
            }

            TaskRepeated();
            int choice = DoChoice(1, 2);

            if (choice == 1)
            {
                FibonacciMenu();
            }
        }

        static void ReadMenu()
        {
            Console.WriteLine("Enter path to the file: ");
            string path = Console.ReadLine();

            Console.Write("Enter count of the line: ");
            if (int.TryParse(Console.ReadLine(), out int linesCount))
            {
                FileReader(path, linesCount);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input error");
            }

            TaskRepeated();
            int choice = DoChoice(1, 2);

            if (choice == 1)
            {
                ReadMenu();
            }
        }

        static void WriteMenu()
        {
            Console.Write("Enter web link: ");
            string path = Console.ReadLine();

            CodeRecorder(path);

            TaskRepeated();
            int choice = DoChoice(1, 2);

            if (choice == 1)
            {
                WriteMenu();
            }
        }

        static void FileReader(string path, int linesCount)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                using (StreamReader streamReader = new StreamReader(path))
                {
                    for (int i = 0; i < linesCount && !streamReader.EndOfStream; i++)
                    {
                        string line = streamReader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong file path");
            }
        }

        static void CodeRecorder(string str)
        {
            string path = "C:\\Users\\Екатерина\\Desktop\\Recorder.txt";
            string htmlCode;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    htmlCode = streamReader.ReadToEnd();
                }

                using (StreamWriter outputFile = new StreamWriter(path))
                {
                    outputFile.WriteLine(htmlCode);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong file path");
            }
        }

        static void FibonacciCalculator(int num)
        {
            int firstNumber = 1;
            int secondNumber = 1;

            if (num < 3)
            {
                Console.WriteLine(firstNumber);
            }

            for (int i = 3; i <= num; i++)
            {
                int timeNum = secondNumber;
                secondNumber = firstNumber + secondNumber;
                firstNumber = timeNum;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(secondNumber);
        }

        static int DoChoice(int min, int max)
        {
            int choice;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your choise: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= min && choice <= max)
                    {
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input error, try again");
            }

            return choice;
        }

        static void TaskRepeated()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Repeat the task?");
            Console.WriteLine("1 - Yes");
            Console.WriteLine("2 - No");
        }
    }
}