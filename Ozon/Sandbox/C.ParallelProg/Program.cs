using System;

public class Program
{
    public static void Main(string[] args)
    {
        var queries = convert(Console.ReadLine());
        someFunction();

    }
    static int convert(string s) => Int32.Parse(s);

    static void someFunction()
    {
        var some = Scratch.ReadFromFile("input.txt");
        int count = convert(Console.ReadLine());
        var test = "2 1 3 1 1 4";
        var employees = test.Split(' ').ToDictionary(x => x.IndexOf(x), x => convert(x));
        foreach (var item in employees)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }
    }
}