using System.Text.Json.Serialization;

namespace SkyLauncher;
public class Error
{
    public Error()
    {
    }
    public Error(string message)
    {
        Id = Guid.NewGuid();
        Message = message;
    }
    public Error(string message, Guid id)
    {
        Id = id;
        Message = message;
    }
    [JsonPropertyName("id")]
    public Guid? Id { get; set; }
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}