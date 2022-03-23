using System;
using System.IO;

namespace BuilderPersons
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ReadCsv();
        }

        private static void ReadCsv()
        {
            var reader = new StreamReader("persons_with_address.csv");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null) continue;
                var parts = line.Split(';');
                try
                {
                    var person = new Person.Builder(parts[0], parts[1]).Age(int.Parse(parts[2])).Phone(parts[3]).Address(parts[4]).Build();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(line);
                }
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
