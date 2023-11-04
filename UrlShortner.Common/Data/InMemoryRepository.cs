namespace UrlShortner.Common.Data;

public class InMemoryRepository<TKey, TValue> : IRepository<TKey, TValue> 
    where TKey : notnull
    where TValue : class
{
    private readonly Dictionary<TKey, TValue> _store = new();

    public void Add(TKey key, TValue value)
    {
        _store[key] = value;
    }

    public bool Contains(TKey key)
    {
        return _store.ContainsKey(key);
    }

    public TValue Get(TKey key)
    {
        if (_store.TryGetValue(key, out TValue? value))
        {
            return value;
        }
        else
        {
            throw new KeyNotFoundException("The key was not found in the in memory repo");
        }
    }
}