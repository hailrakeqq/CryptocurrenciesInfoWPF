using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CryptocurrenciesInfoWPF.Models;

public static class HttpClientService
{
    private static readonly HttpClient _httpClient;

    static HttpClientService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public static async Task<string> GetJsonFromAPIResponseAsync(string apiEndpoint)
    {
        var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, apiEndpoint));
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }          
}