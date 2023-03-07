namespace SkyLauncher;

public class Account
{
    static Account _instance;
    public static Account Instance => _instance;

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool Active { get; set; }
}