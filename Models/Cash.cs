using System.Text.Json.Serialization;

namespace SkyLauncher.Models;

public  class Cash
{
    [JsonPropertyName("current")]
    public double Current { get; set; }
    [JsonPropertyName("totalHistory")]
    public double TotalHistory { get; set; }
}
