namespace UrlShortner.Common.Tests.Services;

using UrlShortner.Common.Data;
using UrlShortner.Common.Services;
using UrlShortner.Common.Utils;

public class UniqueKeyServiceTests
{
    [Fact]
    public void GenerateUniqueKey_ReturnsBase62EncodedKey()
    {
        // InMemoryCounterStore.ResetCounter();

        var counterStore = new InMemoryCounterStore();
        var uniqueKeyService = new UniqueKeyService(counterStore);

        string uniqueKey = uniqueKeyService.GenerateUniqueKey();
        string expectedKey = Base62Converter.FromLong(1);

        Assert.Equal(expectedKey, uniqueKey);
    }
}