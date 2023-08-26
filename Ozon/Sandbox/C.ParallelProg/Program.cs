using System;

public class Program
{
    public static void Main(string[] args)
    {
        var queries = convert(Console.ReadLine());
        for (int i = 0; i < queries; i++)
        {
            var employeesCount = convert(Console.ReadLine());
            var employees = Console.ReadLine().Split(' ').Select(p => convert(p)).ToList();
            var dic = employees.Select((value, index) => new { Index = index, Value = value })
                .ToDictionary(item => item.Index + 1, item => item.Value);
            
            while (dic.Count > 0)
            {
                var first = dic.First();
                
                dic.Remove(first.Key);
                var compare = 0;
                var second = new KeyValuePair<int, int>();
                while (second.Key == 0)
                {
                    second = dic.Where(p => Math.Abs(first.Value - p.Value) == compare).FirstOrDefault();
                    compare++;
                }
                Console.WriteLine($"{first.Key} {second.Key}");
                dic.Remove(second.Key);
                
            }
            if (i != queries - 1)
            Console.WriteLine();
        }

    }
    static int convert(string s) => Int32.Parse(s);
}