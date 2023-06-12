namespace SkyLauncher;
public static class AccountManager
{
    static readonly Account Empty = new Account();
    static Account _account;
    static string _token;
    public static event Action? OnLogOut;
    public static event Action<Account>? OnLogIn;
    public static event Action<Account>? AccountChanged;
    public static event Action<string>? TokenChanged;

    static AccountManager()
    {
        _account = new();
        _token = "";
    }

    /// <summary>
    /// Представляет текущего пользователя
    /// </summary>
    public static Account Current
    {
        get => _account;
        set
        {
            _account = value;
            //_account.Id = value.Id;
            //_account.Name = value.Name;
            //_account.Email = value.Email;
            //_account.Password = value.Password;
            //_account.EmailConfirmed = value.EmailConfirmed;
            //_account.Active = value.Active;
            AccountChanged?.Invoke(_account);
        }
    }
    public static string? Token
    {
        get => _token;
        set
        {
            _token = value ?? "";
            TokenChanged?.Invoke(_token);
        }
    }
    /// <summary>
    /// Получает и сохраняет пользователя в программе
    /// </summary>
    /// <param name="account"></param>
    public static async Task LogInLauncher(Account account, string token)
    {
        Current = account ?? AccountManager.Empty;
        Token = account is null ? "" : token;
        OnLogIn?.Invoke(Current);
    }

    /// <summary>
    /// Удаляет пользователя из системы
    /// </summary>
    public static void LogOut()
    {
        Current = Empty;
        Token = null;
        OnLogOut?.Invoke();
    }
}