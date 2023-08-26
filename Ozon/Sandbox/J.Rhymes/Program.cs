using System;
using System.Text;
 
public static class Program
{
    static int convert(string s) => int.Parse(s);
    
    public static void Main(string[] args)
    {
        var dicSize = convert(Console.ReadLine());
        HashSet<string> dic = new();
        for (var i = 0; i < dicSize; i++)
        {
            dic.Add(Console.ReadLine());
        }
        var wordsCount = convert(Console.ReadLine());
        // StringBuilder sb = new();
        for (var i = 0; i < wordsCount; i++)
        {
            var word = Console.ReadLine();
            // ReadLinesb.Append(word);
            var compare = dic.Where(p => p != word).ToArray();
            while (word.Length > 0)
            {
                word = word.Remove(0,1);
                if (compare.Any(p => p.EndsWith(word)))
                {
                    Console.WriteLine(compare.First(p => p.EndsWith(word)));
                    break;
                }
            }
            word = string.Empty;
        }
    }
}