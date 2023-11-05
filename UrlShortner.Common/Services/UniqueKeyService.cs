namespace UrlShortner.Common.Services;

using System.Security.Cryptography;

public class UniqueKeyService
{
    public string GenerateUniqueKey(int length)
    {
        const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var stringChars = new char[length];

        for (int i = 0; i < stringChars.Length; i++)
        {
            int randomIndex = RandomNumberGenerator.GetInt32(chars.Length); // Get a random index
            stringChars[i] = chars[randomIndex]; // Pick a random character
        }

        return new String(stringChars);
    }
}