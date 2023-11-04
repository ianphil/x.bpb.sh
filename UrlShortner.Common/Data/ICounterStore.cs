namespace UrlShortner.Common.Data;

public interface ICounterStore
{
    long GetNextUniqueValue();
}