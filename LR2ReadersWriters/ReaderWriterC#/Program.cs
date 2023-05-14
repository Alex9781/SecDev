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
            Console.Write("[read]/[write]: ");
            string? input = Console.ReadLine();

            if (input != null)
            {
                List<string> splitedInput = input.Split(" ").ToList();

                switch (splitedInput[0])
                {
                    case "h":
                        Console.WriteLine("read [file]\nwrite [file]");
                        break;
                    case "read":
                        if (splitedInput.Count == 1)
                        {
                            Console.WriteLine("Type h for help");
                            break;
                        }
                        ReadFile(splitedInput[1]);
                        break;
                    case "write":
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
            File.WriteAllText(filename, toWrite);
            Console.WriteLine($"Writed: {toWrite}");
        }
    }
}