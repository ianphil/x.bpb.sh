namespace UrlShortner.Common.Data;

public class InMemoryCounterStore : ICounterStore
{
    private long _currentCounter;

    public long GetNextUniqueValue()
    {
        return Interlocked.Increment(ref _currentCounter);
    }
}
