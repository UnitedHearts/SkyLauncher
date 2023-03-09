using System.Text.Json.Serialization;

namespace SkyLauncher;
public class Response<T> : IResponse where T : class
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    [JsonPropertyName("error")]
    public Error? Error { get; set; }

    public bool IsValid => Error == null;

    public Error? GetError()
    {
        return IsValid ? null : Error;
    }
}