namespace UrlShortner.Common.Data;

/// <summary>
/// This class is used only for debugging and testing in lower environments.
/// Everytime the application starts this class will reset the counter and start
/// the URLs over.
/// </summary>
public class InMemoryCounterStore : ICounterStore
{
    private long _currentCounter;

    public long GetNextUniqueValue()
    {
        return Interlocked.Increment(ref _currentCounter);
    }
}
