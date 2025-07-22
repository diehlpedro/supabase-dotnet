using System.Text.Json;

public class SupabaseService
{
    private readonly HttpClient _httpClient;

    public SupabaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Reading>> GetReadingsAsync()
    {
        var res = await _httpClient.GetAsync("rest/v1/readings"); // relative path
        res.EnsureSuccessStatusCode();

        var content = await res.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Reading>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }

    public async Task<bool> CreateReadingAsync(Reading reading)
    {
        var json = JsonSerializer.Serialize(reading);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var res = await _httpClient.PostAsync("rest/v1/readings", content);
        return res.IsSuccessStatusCode;
    }
}
