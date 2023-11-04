namespace UrlShortner.Common.Data;

public interface IRepository<TKey, TValue>
{
    void Add(TKey key, TValue value);
    TValue Get(TKey key);
    bool Contains(TKey key);
}