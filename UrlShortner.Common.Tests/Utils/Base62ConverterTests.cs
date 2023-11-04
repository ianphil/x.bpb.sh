namespace UrlShortner.Common.Tests.Utils;

using UrlShortner.Common.Utils;

public class Base62ConverterTests
{
    [Theory]
    [InlineData(0, "000000")]
    [InlineData(1, "000001")]
    [InlineData(61, "00000Z")]
    [InlineData(62, "000010")]
    [InlineData(3843, "0000ZZ")]
    [InlineData(long.MaxValue, "aZl8N0y58M7")]
    public void FromLong_GivenValue_ReturnsCorrectBase62String(long value, string expected)
    {
        // Act
        var result = Base62Converter.FromLong(value);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FromLong_GivenNegativeValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        long negativeValue = -1;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Base62Converter.FromLong(negativeValue));
        Assert.Equal("value", exception.ParamName);
        Assert.StartsWith("value must be non-negative", exception.Message);
    }
}