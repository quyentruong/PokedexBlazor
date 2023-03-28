using System.Text.RegularExpressions;

namespace PokedexBlazor.Utils;

public class BasicUtility
{
    public static string ConvertToHashCode(int number)
    {
        return "#" + number.ToString().Trim().PadLeft(4, '0');
    }

    public static string GetChipClass(string context)
    {
        context = context.ToLower();
        return $"background-color-{context}";
    }

    public static int GetNumStars(int value, int maxValue = 200, int maxStars = 10)
    {
        return (int)Math.Round((double)value * maxStars / maxValue);
    }

    public static string Capitalize(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        // split the string into words
        string[] words = str.Split('-', StringSplitOptions.RemoveEmptyEntries);

        // capitalize the first character of each word
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = char.ToUpper(words[i][0]) + words[i][1..];
        }

        // join the words and return the result
        return string.Join(" ", words);
    }

    public static int ExtractNumberFromUrl(string url)
    {
        Regex regex = new(@"\/(\d+)\/?");
        Match match = regex.Match(url);
        if (match.Success && match.Groups.Count > 1)
        {
            _ = int.TryParse(match.Groups[1].Value, out int result);
            return result;
        }
        return 0;
    }
}