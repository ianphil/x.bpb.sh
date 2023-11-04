namespace UrlShortner.Common.Tests.Data;

using UrlShortner.Common.Data;

public class InMemoryRepositoryTests
{
    [Fact]
    public void Add_Url_To_Store()
    {
        InMemoryRepository<string, string> repo = new();

        string key = "FirstName";
        string value = "Ian";

        repo.Add(key, value);

        Assert.True(repo.Contains(key));
        Assert.Equal(repo.Get(key), value);
    }
}