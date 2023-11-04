namespace UrlShortner.Common.Services;

using UrlShortner.Common.Data;
using UrlShortner.Common.Utils;

public class UniqueKeyService
{
    private readonly ICounterStore _counterStore;

    public UniqueKeyService(ICounterStore counterStore)
    {
        _counterStore = counterStore ?? throw new ArgumentNullException(nameof(counterStore));
    }

    public string GenerateUniqueKey()
    {
        long counterValue;
        string uniquePath;

        counterValue = _counterStore.GetNextUniqueValue();
        uniquePath = Base62Converter.FromLong(counterValue);

        // Return the unique path
        return uniquePath;
    }
}