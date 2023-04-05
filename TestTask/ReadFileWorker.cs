namespace TestTask;

internal static class ReadFileWorker
{
    public static int[,] GetModelSpace()
    {
        var path = Environment.CurrentDirectory + "\\data.txt";
        var allLine = File.ReadAllLines(path);

        return ConvertTextToSpace(allLine);
    }

    private static int[,] ConvertTextToSpace(string[] lines)
    {
        var result = new int[lines.Length, lines.First().Trim(',', '\n').Length];
        for (var i = 1; i < lines.Length; i++)
        {
            var symbols = lines[i].Split(",", StringSplitOptions.TrimEntries);
            for (var j = 1; j < symbols.Length; j++)
                result[i,j] = int.Parse(symbols[j]);
        }

        return result;
    }
}
