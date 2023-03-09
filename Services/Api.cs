using Microsoft.Win32;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace SkyLauncher;
public static class Api
{

    public static async Task<Response<Account>> CreateAccount(RegisterRequest reg)
    {
        var requestData = JsonSerializer.Serialize(reg);
        var result = await Sender.Send<Account>(requestData, Endpoints.CreateAccount, HttpMethod.Post);
        return result;
    }

    public static async Task<Response<Account>> LogIn(LoginModel reg)
    {
        var requestData = JsonSerializer.Serialize(reg);
        var result = await Sender.Send<Account>(requestData, Endpoints.Login, HttpMethod.Post);
        return result;
    }

    class Endpoints
    {
        public static string CreateAccount = "/Account/Create";
        public static string GetAccount = "/Account/Get";
        public static string Login = "/Authorization/Login";
    }

    static class Sender
    {
        static HttpClient _client = new HttpClient(); 
        static string BaseUrl = "https://localhost:7109";
        //static string BaseUrl = "https://lonewald.ru";
        public static async Task<Response<T>> Send<T>(string requestBody, string endPoint, HttpMethod method) where T : class
        {
            var request = new HttpRequestMessage(method, BaseUrl + endPoint);
            request.Content = new StringContent(requestBody, Encoding.UTF8, method == HttpMethod.Get || method == HttpMethod.Delete ? "application/x-www-form-urlencoded" : "application/json");
            var response = await _client.SendAsync(request);
            var str = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                if ((int)response.StatusCode >= 500)
                    return new Response<T>() { Error = new(response.ReasonPhrase)};
            var resultObject = JsonSerializer.Deserialize<Response<T>>(str);
            return resultObject;
        }
    }
}
