using PokedexBlazor.Models;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

namespace PokedexBlazor.Utils;

public class BasicUtility
{
    public static string PokemonImage(int id)
    {
        return $"https://raw.githubusercontent.com/quyentruong/PokemonSprites/main/sprites/pokemon/other/official-artwork/{id}.webp";
    }

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
        var temp = (int)Math.Round((double)value * maxStars / maxValue);
        return temp > maxStars ? maxStars : temp;
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

    public static string CompressStringDeflate(string text)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(text);

        using var memoryStream = new MemoryStream();
        using (var gzipStream = new DeflateStream(memoryStream, CompressionMode.Compress, true))
        {
            gzipStream.Write(buffer, 0, buffer.Length);
        }

        byte[] compressedData = memoryStream.ToArray();
        return Convert.ToBase64String(compressedData);
    }

    public static string DecompressStringDeflate(string compressedText)
    {
        byte[] compressedData = Convert.FromBase64String(compressedText);

        using var memoryStream = new MemoryStream(compressedData);
        using var gzipStream = new DeflateStream(memoryStream, CompressionMode.Decompress);

        using var streamReader = new StreamReader(gzipStream);
        return streamReader.ReadToEnd();
    }

    public static string CompressStringGzip(string text)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(text);
        MemoryStream memoryStream = new MemoryStream();
        using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
        {
            gzipStream.Write(buffer, 0, buffer.Length);
        }
        memoryStream.Position = 0;
        byte[] compressedData = new byte[memoryStream.Length];
        memoryStream.Read(compressedData, 0, compressedData.Length);

        return Convert.ToBase64String(compressedData);
    }

    public static string DecompressStringGzip(string compressedText)
    {
        byte[] compressedBytes = Convert.FromBase64String(compressedText);

        using MemoryStream ms = new(compressedBytes);
        using GZipStream gzip = new(ms, CompressionMode.Decompress);
        using StreamReader reader = new(gzip);
        return reader.ReadToEnd();
    }

    public static long CalculateSize(List<PokemonLite> list)
    {
        long size = 0;

        // Iterate over each item in the list
        foreach (var item in list)
        {
            if (item.Id != 0)
            {
                // Calculate size of int and string properties
                size += sizeof(int);
                size += sizeof(char) * item.N.Length;

                foreach (var w in item.Wns)
                    size += sizeof(char) * w.Length;
                foreach (var t in item.Ts)
                    size += sizeof(char) * t.Length;
                foreach (var s in item.Sgs)
                    size += sizeof(char) * s.Length;

                // Calculate size of PokemonLiteStat list
                size += sizeof(int) * item.Sts.Capacity;
                foreach (var stat in item.Sts)
                {
                    size += sizeof(char) * stat.N.Length;
                    size += sizeof(int);
                }
            }
        }

        return size;
    }
}