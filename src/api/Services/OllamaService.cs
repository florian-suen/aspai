using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;

namespace api.Services;

public partial class OllamaService
{
    private readonly HttpClient _httpClient;
    private readonly List<Message>  _messages; 

    public OllamaService(HttpClient httpClient, IOptions<Config> config, MessageStore  messageStore)
    {
        _messages = messageStore.Messages;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(config.Value.Api.Url);
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

        _messages.AddRange(messages);
     
      
        var request = new
        {
            model,
            messages = _messages,
            stream = false
        };

        var response = await _httpClient.PostAsJsonAsync("chat", request);
        response.EnsureSuccessStatusCode(); 
        
        
        var result = await response.Content.ReadFromJsonAsync<OllamaChatResponse>(); 
        var input = result?.Message?.Content ?? string.Empty;
       
       _messages.Add(new("assistant",input));
       var output = MyRegex().Replace(input, "").Trim();
       return output;


    }

    [GeneratedRegex(@"<think>[\s\S]*?</think>")]
    private static partial Regex MyRegex();
}

public record OllamaCompletionResponse(string Response);
public record OllamaChatResponse(Message Message, string Model);
public record Message(string Role, string Content);


public  class MessageStore
{
    public readonly List<Message>  Messages = []; 
}
