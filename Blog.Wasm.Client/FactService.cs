namespace Blog.Wasm.Client;

public class FactService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;
    private Random random = new Random();

    public async Task<string> GetRandomFact()
    {
        var response = await _httpClient.GetStringAsync("facts.txt");
        var lines = response.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return lines[random.Next(lines.Length)];
    }
}