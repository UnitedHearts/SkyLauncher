using SkyLauncher.Models;
using System.Text.Json.Serialization;

namespace SkyLauncher;
public class Account
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
    [JsonPropertyName("emailConfirmed")]
    public bool EmailConfirmed { get; set; }
    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("cash")]
    public Cash Cash { get; set; }
    [JsonPropertyName("statistic")]
    public AccountStatistic Statistic { get; set; }
}