using TODO_LIST.Frontend.Models;

namespace TODO_LIST.Frontend.Clients;

public class GenresClient(HttpClient httpClient)
{
    public async Task<Genre[]> GetGenresAsync() => 
        await httpClient.GetFromJsonAsync<Genre[]>($"genres") ?? [];
}