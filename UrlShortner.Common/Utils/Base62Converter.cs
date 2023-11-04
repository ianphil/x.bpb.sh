namespace UrlShortner.Common.Utils;

using System.Text;

public static class Base62Converter
{
    private const string Base62Chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string FromLong(long value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "value must be non-negative");
        
        var sb = new StringBuilder();
        do
        {
            sb.Insert(0, Base62Chars[(int)(value % 62)]);
            value /= 62;
        } while (value > 0);

        // Pad the string with '0' to ensure the string is at least 6 characters long
        while (sb.Length < 6)
        {
            sb.Insert(0, '0');
        }

        return sb.ToString();
    }
}