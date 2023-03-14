using CryptocurrenciesInfoWPF.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrenciesInfoWPF;

public static class Toolchain
{
    public static List<Cryptocurrency>? GetCryptocurrencyCollectionFromJson(string json)
    {
        return JsonConvert.DeserializeObject<Root>(json).data;
    }
}
