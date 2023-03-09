using System;
using System.IO;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace SkyLauncher;
public static class AutoLoginer
{
    static string _folder;
    static string _fileName;
    static AutoLoginer()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        _folder = path + "/LemonApi/";
        _fileName = "User.json";
    }

    /// <summary>
    /// Пустые авторизационные данные
    /// </summary>
    static LoginModel EmptyLogin { get => new LoginModel(); }

    /// <summary>
    /// Полный путь к файлу
    /// </summary>
    public static string FilePath { get => _folder + _fileName; }

    /// <summary>
    /// Проверяет, существует ли файл для возможности автологгирования
    /// </summary>
    /// <returns></returns>
    public static bool FileExist
    {
        get
        {
            if (Directory.Exists(_folder))
                if (File.Exists(FilePath))
                    return true;
            return false;
        }
    }

    /// <summary>
    /// Удаляет текущие данные в файле авто-логина
    /// </summary>
    /// <returns></returns>
    public static async Task Clear()
    {
        await SetAutoLogin(EmptyLogin);
    }

    /// <summary>
    /// Устанавливает данные авторизациИ в файл для дальнейшего авто-логина
    /// </summary>
    /// <param name="login"></param>
    public async static Task SetAutoLogin(LoginModel login)
    {
        if (!FileExist)
            await CreateFile(_folder, _fileName, JsonSerializer.Serialize(login));
        else 
            await WriteToFile(FilePath, JsonSerializer.Serialize(login));
    }

    /// <summary>
    /// Получает данные из фала для авто-логина
    /// </summary>
    /// <returns></returns>
    public async static Task<LoginModel> GetAutoLogin()
    {
        if (!FileExist)
            await CreateFile();
        string str = "";
        using (FileStream fs = new FileStream(FilePath, FileMode.Open))
        {
            byte[] buffer = new byte[fs.Length];
            await fs.ReadAsync(buffer, 0, buffer.Length);
            str = Encoding.Default.GetString(buffer);
        }
        try
        {
            var login = JsonSerializer.Deserialize<LoginModel>(str);
            return login;
        }
        catch
        {
            return EmptyLogin;
        }
    }

    /// <summary>
    /// Создает файл с пустыми авторизационными данными
    /// </summary>
    /// <returns></returns>
    static async Task CreateFile()
    {
        await CreateFile(_folder, _fileName);
    }

    /// <summary>
    /// Создает файл с пустыми авторизационными данными
    /// </summary>
    /// <param name="directory">Путь к директории файла</param>
    /// <param name="fileName">Имя файла</param>
    /// <returns></returns>
    static async Task CreateFile(string directory, string fileName)
    {
        await CreateFile(directory, fileName, JsonSerializer.Serialize(EmptyLogin));
    }

    /// <summary>
    /// Создает по указанному пути файл, и заполняет его содержимым
    /// </summary>
    /// <param name="directory">Директория файла</param>
    /// <param name="fileName">Имя файла</param>
    /// <param name="content">Текст, записываемый в файл</param>
    /// <returns></returns>
    static async Task CreateFile(string directory, string fileName, string content)
    {
        var folder = new DirectoryInfo(directory);
        var file = new FileInfo(directory+fileName);
        if (!Directory.Exists(directory))
            folder.Create();
        if (!file.Exists)
            await WriteToFile(directory + fileName, content);
    }

    /// <summary>
    /// Записывает срочку в указанный файл
    /// </summary>
    /// <param name="path">Путь к файлу</param>
    /// <param name="text">Текст, записываемый в файл</param>
    /// <returns></returns>
    static async Task WriteToFile(string path, string text)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            byte[] buffer = Encoding.Default.GetBytes(text);
            fs.SetLength(0);
            await fs.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}