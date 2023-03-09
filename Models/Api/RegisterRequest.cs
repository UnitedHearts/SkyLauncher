namespace SkyLauncher;
public class RegisterRequest : IRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public bool IsValid
    {
        get
        {
            if (string.IsNullOrEmpty(Name)) return false;
            if (string.IsNullOrEmpty(Email)) return false;
            if (string.IsNullOrEmpty(Password)) return false;
            return true;
        }
    }
}