using System.Text.Json.Serialization;

namespace SkyLauncher;
public interface IRequest
{
    [JsonIgnore]
    public bool IsValid { get; }
}