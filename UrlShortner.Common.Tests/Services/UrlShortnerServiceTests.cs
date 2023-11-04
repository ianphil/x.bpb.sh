namespace UrlShortner.Common.Tests.Services;

using UrlShortner.Common.Data;
using UrlShortner.Common.Services;

public class UrlShortnerServiceTests
{
    [Fact]
    public void ShortenUrl_WhenCalled_ReturnsShortenedUrl()
    {
        // Arrange
        var uniqueKeyService = new UniqueKeyService(new InMemoryCounterStore());
        var repository = new InMemoryRepository<string, string>();
        var shortenerService = new UrlShortnerService(uniqueKeyService, repository);
        var originalUrl = "https://example.com/very/long/url/path/that/needs/to/be/shortened";

        var expected = "https://x.bpb.sh/000001";

        // Act
        var shortenedUrl = shortenerService.ShortenUrl(originalUrl);

        // Assert
        Assert.StartsWith("https://x.bpb.sh/", shortenedUrl);
        Assert.Equal(expected, shortenedUrl);
    }

    [Fact(Skip = "Skipping this test because of a known issue with unique key generation.")]
    public void ShortenUrl_WithExistingKey_ThrowsException()
    {
        // Arrange
        var uniqueKeyService = new UniqueKeyService(new InMemoryCounterStore());
        var repository = new InMemoryRepository<string, string>();
        var shortenerService = new UrlShortnerService(uniqueKeyService, repository);
        var originalUrl = "https://example.com/another/long/url/path";
        var existingKey = uniqueKeyService.GenerateUniqueKey();
        repository.Add(existingKey, originalUrl); // Simulate existing shortened URL

        // Act & Assert
        var exception = Record.Exception(() => shortenerService.ShortenUrl(originalUrl));
        Assert.NotNull(exception);
        Assert.IsType<Exception>(exception);
    }
}