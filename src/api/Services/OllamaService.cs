namespace api.Services;

public class OllamaService
{
    private readonly HttpClient _httpClient;

    public OllamaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:11434/api/");
    }

    public async Task<string> GenerateCompletion(string model, string prompt)
    {
        var request = new
        {
            model,
            prompt,
            stream = false
        };

        var response = await _httpClient.PostAsJsonAsync("generate", request);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<OllamaCompletionResponse>();
        return result?.Response ?? string.Empty;
    }

    public async Task<string> ChatCompletion(string model, List<Message> messages)
    {
        var request = new
        {
            model,
            messages,
            stream = false
        };

        var response = await _httpClient.PostAsJsonAsync("chat", request);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<OllamaChatResponse>();
        return result?.Message?.Content ?? string.Empty;
    }
}

public record OllamaCompletionResponse(string Response);
public record OllamaChatResponse(Message Message);
public record Message(string Role, string Content);