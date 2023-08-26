using System;

public class Program
{
    public static void Main(string[] args)
    {
        var count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            var totalItems = convert(Console.ReadLine());
            var basketItems = basket(Console.ReadLine().Split(' ').Select(convert));
            var totalPrice = 0;
            foreach (var item in basketItems)
            {
                totalPrice += calculateTotalPrice(item.Key, item.Value);
            }
                Console.WriteLine(totalPrice);

        }
    }
    static Dictionary<int,int> basket (IEnumerable<int> values) 
        => values.GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());
    static int freeItemsCount(int items) => items / 3;
    static int Sum (int price, int items) => price * items;
    static int convert(string s) => int.Parse(s);
    static int calculateTotalPrice(int price, int items) => Sum(price, items - freeItemsCount(items));
}