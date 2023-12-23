using Shared.Contracts.Catalog.Dtos;

namespace Web.Services;

public class CatalogService(HttpClient client)
{
    private readonly HttpClient _client = client;

    public async Task<BookDto[]> GetAllBooksAsync()
    {
        var books = await _client.GetFromJsonAsync<BookDto[]>("catalog");
        return books ?? [];
    }
}
