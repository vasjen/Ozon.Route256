using System.Collections.Generic;

public static class Scratch
{
    public static IEnumerable<string> ReadFromFile(string path)
    {
        using (var reader = new System.IO.StreamReader(path))
        {
            string line;
            List<string> lines = new();
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
                yield return line;
            }
        }
    }
}