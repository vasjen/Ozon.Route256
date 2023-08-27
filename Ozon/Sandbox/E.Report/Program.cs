using System.Threading.Channels;

public static class Program
{
    public static void Main(string[] args)
    {
        var queries = convert(Console.ReadLine());
        for (var i = 0; i < queries; i++)
        {
            Console.ReadLine();
            var res = isContinued(Console.ReadLine().Split(' ').Select(p => convert(p)).ToList());
            Console.WriteLine(res ? "YES" : "NO");
        }
       
    
    }
    static int convert(string s) => Int32.Parse(s);

    static bool isContinued(List<int> values)
    {
        Dictionary<int, int> dic = values.Select((value, index) => new { Index = index, Value = value })
            .ToDictionary(item => item.Index + 1, item => item.Value);
        var groupedValues = dic.GroupBy(p => p.Value)
            .ToDictionary(p => p.Key, p => p.Select(p => p.Key)
                .ToList());
        foreach (var item in groupedValues.Values)
        {
            if (item.Count > 1)
            {
                for (int i = 0; i < item.Count - 1; i++)
                {
                    if( Math.Abs(item[i] - item[i + 1]) != 1)
                    {
                        return false;
                    }
                }
            }
           
        }
        
        return true;
    }



}