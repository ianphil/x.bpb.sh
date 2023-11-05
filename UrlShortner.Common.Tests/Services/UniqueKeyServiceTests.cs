namespace UrlShortner.Common.Tests.Services;

using UrlShortner.Common.Services;

public class UniqueKeyServiceTests
{
    [Fact]
    public void GenerateRandomString_ReturnsStringOfCorrectLength()
    {
        var uniqueKeyService = new UniqueKeyService();

        // Arrange
        int length = 10;

        // Act
        string result = uniqueKeyService.GenerateUniqueKey(length);

        // Assert
        Assert.Equal(length, result.Length);
    }

    [Fact]
    public void GenerateRandomString_ReturnsStringWithExpectedCharacters()
    {
        var uniqueKeyService = new UniqueKeyService();

        // Arrange
        int length = 100; // Use a larger sample to increase the chance of catching an error
        const string allowedChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // Act
        string result = uniqueKeyService.GenerateUniqueKey(length);

        // Assert
        foreach (var character in result)
        {
            Assert.Contains(character, allowedChars);
        }
    }

    [Fact]
    public void GenerateRandomString_ReturnsNonDeterministicResults()
    {
        var uniqueKeyService = new UniqueKeyService();

        // Arrange
        int length = 10;
        var resultSet = new HashSet<string>();

        // Act
        for (int i = 0; i < 100; i++) // Generate multiple strings
        {
            resultSet.Add(uniqueKeyService.GenerateUniqueKey(length));
        }

        // Assert
        Assert.True(resultSet.Count > 1, "Generated strings should have unique values.");
    }
}