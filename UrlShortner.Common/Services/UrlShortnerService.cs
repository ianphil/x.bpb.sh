using UrlShortner.Common.Data;
using UrlShortner.Common.Services;

public class UrlShortnerService
{
    const string baseUrl = "http://x.bpb.sh:5220";
    private readonly UniqueKeyService _uniqueKeyService;
    private readonly IRepository<string, string> _repository;

    public UrlShortnerService(UniqueKeyService uniqueKeyService, IRepository<string, string> repository)
    {
        _uniqueKeyService = uniqueKeyService;
        _repository = repository;
    }

    public string ShortenUrl(string origiinalUrl)
    {
        string uniquePath = _uniqueKeyService.GenerateUniqueKey(6);

        if (_repository.Contains(uniquePath))
            throw new Exception("Key already exists");
        else
            _repository.Add(uniquePath, origiinalUrl);

        return $"{baseUrl}/{uniquePath}";
    }

    public string LengthenUrl(string shortUrl)
    {
        var key = new Uri(shortUrl).AbsolutePath;

        try
        {
            return _repository.Get(key);
        }
        catch (KeyNotFoundException up)
        {
            return up.Message;
        }
    }
}