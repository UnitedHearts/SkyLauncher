using Microsoft.VisualBasic.Logging;
using System.Text.Json;

namespace SkyLauncher;
public static class AutoLoginer
{
    static string _path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    static string _folder = "LemonApi/";
    static string _file = "User.json";
    static Login EmptyLogin { get => new Login(); }
    public static string FilePath { get => _path + "/" + _folder + _file; }
    /// <summary>
    /// Проверяет, существует ли файл для возможности автологгирования
    /// </summary>
    /// <returns></returns>
    public static bool LoginExist
    {
        get
        {
            if (Directory.Exists(_path + "/" + _folder))
                if (File.Exists(_path + "/" + _folder + _file))
                    return true;
            return false;
        }
    }

    static async Task CreateFile()
    {
        var folder = new DirectoryInfo(_path + "/" + _folder);
        var file = new FileInfo(_path + "/" + _folder + _file);
        if (!Directory.Exists(_path + "/" + _folder))
            folder.Create();
        if (!file.Exists)
            file.Create();
        await File.WriteAllTextAsync(FilePath, JsonSerializer.Serialize(EmptyLogin));
    }
    public async static void SetAutoLogin(Login login)
    {
        if (!LoginExist)
            await CreateFile();
        var str = JsonSerializer.Serialize(login);
        await File.WriteAllTextAsync(FilePath, str);
    }

    public async static Task<Login> GetAutoLogin()
    {
        if (!LoginExist)
            await CreateFile();
        var str = await File.ReadAllTextAsync(FilePath);
        var login = JsonSerializer.Deserialize<Login>(str);
        return login;
    }
}