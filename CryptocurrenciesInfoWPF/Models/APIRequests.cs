using CryptocurrenciesInfoWPF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesInfoWPF.Models;

public static class APIRequests
{
    public static async Task<Cryptocurrency> GetCryptocurrencyInfoById(string apiEndpoint,string id)
    {
        var data = await HttpClientService.GetJsonFromAPIResponseAsync($"{apiEndpoint}/{id.ToLower()}");
        return await Toolchain.GetCryptocurrencyObjectFromJson(data);
    }

    public static async Task<Cryptocurrency[]> GetCryptocurrencyCollection(string apiEndpoint, string urlOption = null)
    {
        string response = "";
        if (urlOption != null)
            response = await HttpClientService.GetJsonFromAPIResponseAsync($"{apiEndpoint}?{urlOption}")!;
        else 
            response = await HttpClientService.GetJsonFromAPIResponseAsync($"{apiEndpoint}")!;

        return await Toolchain.GetCryptocurrencyCollectionFromJson(response)!;
    }
}
