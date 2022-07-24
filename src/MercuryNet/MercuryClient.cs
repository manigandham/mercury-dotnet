using System.Text;
using System.Text.Json;

namespace MercuryNet;

public class MercuryClient
{
    private readonly string _apiToken;

    public MercuryClient(string apiToken)
    {
        _apiToken = apiToken;
    }

    public async Task<RecipientResponse?> CreateRecipient(RecipientRequest recipientRequest)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mercury.com/api/v1/recipients");
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("Authorization", $"Bearer {_apiToken}");

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var postData = JsonSerializer.Serialize(recipientRequest, options);
        request.Content = new StringContent(postData, Encoding.UTF8, "application/json");

        using var httpClient = new HttpClient();
        var response = await httpClient.SendAsync(request);
        var resData = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<RecipientResponse>(resData, options);
    }

    public async Task<TransactionResponse?> CreateTransaction(string accountId, TransactionRequest transactionRequest)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.mercury.com/api/v1/account/{accountId}/transactions");
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("Authorization", $"Bearer {_apiToken}");

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var postData = JsonSerializer.Serialize(transactionRequest, options);
        request.Content = new StringContent(postData, Encoding.UTF8, "application/json");

        using var httpClient = new HttpClient();
        var response = await httpClient.SendAsync(request);
        var resData = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TransactionResponse>(resData, options);
    }
}
