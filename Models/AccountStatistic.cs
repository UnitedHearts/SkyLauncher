using System.Text.Json.Serialization;

namespace SkyLauncher.Models;
public class AccountStatistic
{
    [JsonPropertyName("plays")]
    public int Plays { get; set; }
    [JsonPropertyName("wins")]
    public int Wins { get; set; }
    [JsonPropertyName("deaths")]
    public int Deaths { get; set; }
    [JsonPropertyName("exp")]
    public double Exp { get; set; }
}
