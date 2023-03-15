using System.Collections.Generic;

namespace CryptocurrenciesInfoWPF.Models.Entities;

public class Cryptocurrency
{
    public string? id { get; set; }
    public int? rank { get; set; }
    public string? symbol { get; set; }
    public string? name { get; set; }
    public string? supply { get; set; }
    public string? maxSupply { get; set; }
    public string? marketCapUsd { get; set; }
    public string? volumeUsd24Hr { get; set; }
    public string? priceUsd { get; set; }
    public double? changePercent24Hr { get; set; }
    public string? vwap24Hr { get; set; }
    public string? explorer { get; set; }
}

public class Root
{
    public Cryptocurrency[]? data { get; set; }
    public long timestamp { get; set; }
}
public class RootForSingleObjectResponse
{
    public Cryptocurrency? data { get; set; }
    public long timestamp { get; set; }
}

