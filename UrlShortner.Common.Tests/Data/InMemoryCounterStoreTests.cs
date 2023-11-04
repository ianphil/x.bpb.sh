namespace UrlShortner.Common.Tests.Data;

using UrlShortner.Common.Data;

public class InMemoryCounterStoreTests
{
    [Fact]
    public void GetNextUniqueValue_WithInitialSeed_ReturnsIncrementedValue()
    {
        // Arrange
        var counterStore = new InMemoryCounterStore();

        // Act
        var firstValue = counterStore.GetNextUniqueValue();
        var secondValue = counterStore.GetNextUniqueValue();

        // Assert
        Assert.Equal(1, firstValue);
        Assert.Equal(2, secondValue);
    }
}