namespace TestTask;

internal static class GettingSpace
{
    public static int[][] GetModelSpaceFromFile()
    {
        var path = Environment.CurrentDirectory + "\\data.txt";
        var allLine = File.ReadAllLines(path);

        return ConvertTextToSpace(allLine);
    }

    private static int[][] ConvertTextToSpace(string[] lines)
    {
        var result = new int[lines.Length][];
        for (var i = 0; i < lines.Length; i++)
        {
            var symbols = lines[i].Split(",", StringSplitOptions.TrimEntries);
        
            var resultLine = new List<int>(symbols.Length);
            foreach (var symbol in symbols)
                resultLine.Add(int.Parse(symbol));

            result[i] = resultLine.ToArray();
        }

        return result;
    }
}
