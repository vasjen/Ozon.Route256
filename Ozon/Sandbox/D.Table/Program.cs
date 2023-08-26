public static class Program
{
    public static void Main(string[] args)
    {
        var queries = convert(Console.ReadLine());
        Console.ReadLine();
        for (var i = 0; i < queries; i++)
        {
            var dict = new Dictionary<int, IEnumerable<int>>();
            var matrix = new List<List<int>>();
            var size = Console.ReadLine().Split(' ').Select(p => convert(p)).ToList();
            for (int j = 0; j < size[0] ; j++)
            {
                matrix.Add(readRow(Console.ReadLine()));
                
            }

            Console.ReadLine();
            var index = Console.ReadLine().Split(' ').Select(p => convert(p)).ToArray();
            
            for (int j = 0; j < index.Length; j++)
            {   
                matrix = matrix.sortMatrix(index[j]);
            }

            foreach (var lines in matrix)
            {
                Console.WriteLine(string.Join(" ", lines.Select(p => p.ToString())));
            }

            Console.ReadLine();
            Console.WriteLine();
        }
    }
    static int convert(string s) => Int32.Parse(s);
    static List<int> readRow(string row) => row.Split(' ').Select(p => convert(p)).ToList();

    static List<List<int>> sortMatrix(this List<List<int>> matrix, int index)
     => matrix.OrderBy(row => row[index - 1]).ToList();
    
    

}