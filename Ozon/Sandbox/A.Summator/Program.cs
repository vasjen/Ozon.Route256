using System;

namespace Ozon.Sandbox.A.Summator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int convert(string s) => int.Parse(s);
            var count = convert(Console.ReadLine());
            int Summator(int a, int b) => a + b;
            for(int i = 0; i < count; i++)
            {
                var line = Console.ReadLine().Split(' ');
                Console.WriteLine(Summator(convert(line[0]), convert(line[1])));
            }
        }
    }
}



