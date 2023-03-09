using System.Text.Json.Serialization;

namespace SkyLauncher;

public class LoginModel : IRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    [JsonIgnore]
    public bool IsValid
    {
        get
        {
            if (string.IsNullOrEmpty(Email)) return false;
            if (string.IsNullOrEmpty(Password)) return false;
            return true;
        }
    }
}