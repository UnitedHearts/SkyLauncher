namespace SkyLauncher;
public static class AccountManager
{
    static readonly Account Empty = new Account();
    static Account _account;
    public static event Action? OnLogOut;
    public static event Action<Account>? OnLogIn;
    public static event Action<Account>? AccountChanged;
    
    static AccountManager()
    {
        _account = new();
    }

    /// <summary>
    /// Представляет текущего пользователя
    /// </summary>
    public static Account Current
    {
        get => _account;
        set
        {
            _account.Id = value.Id;
            _account.Name = value.Name;
            _account.Email = value.Email;
            _account.Password = value.Password;
            _account.EmailConfirmed = value.EmailConfirmed;
            _account.Active = value.Active;
            AccountChanged?.Invoke(_account);
        }
    }

    /// <summary>
    /// Сохраняет пользователя в системе
    /// </summary>
    /// <param name="account"></param>
    public static void LogIn(Account account)
    {
        Current = account;
        OnLogIn?.Invoke(account);
    }

    /// <summary>
    /// Удаляет пользователя из системы
    /// </summary>
    public static void LogOut()
    {
        Current = Empty;
        OnLogOut?.Invoke();
    }
}