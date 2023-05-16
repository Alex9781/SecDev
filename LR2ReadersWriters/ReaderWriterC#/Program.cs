using System.Text;

namespace ReaderWriter
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("This is simple file reader/writer program");
            Console.WriteLine("Type h for help");
            ProcessInput();
        }

        static void ProcessInput()
        {
            Console.Write("[r]/[w]: ");
            string? input = Console.ReadLine();

            if (input != null)
            {
                List<string> splitedInput = input.Split(" ").ToList();

                switch (splitedInput[0])
                {
                    case "h":
                        Console.WriteLine("r [file]\nw [file]");
                        break;
                    case "r":
                        if (splitedInput.Count == 1)
                        {
                            Console.WriteLine("Type h for help");
                            break;
                        }
                        ReadFile(splitedInput[1]);
                        break;
                    case "w":
                        if (splitedInput.Count == 1)
                        {
                            Console.WriteLine("Type h for help");
                            break;
                        }
                        WriteFile(splitedInput[1]);
                        break;
                    default:
                        Console.WriteLine("Type h for help");
                        break;
                }
            }
            ProcessInput();
        }

        static void ReadFile(string filename)
        {
            Console.WriteLine(File.ReadAllText(filename));
        }

        static void WriteFile(string filename)
        {
            string toWrite = DateTime.Now.ToString();

            FileStream file = new(filename, FileMode.Open);
            file.Write(Encoding.UTF8.GetBytes(toWrite));
            file.Flush();
            file.Close();

            Console.WriteLine(toWrite);
        }
    }
}
