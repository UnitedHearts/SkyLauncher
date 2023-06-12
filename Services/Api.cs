using Microsoft.Win32;
using System.Net.Http.Headers;
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

    public static async Task<Response<string>> LogIn(LoginModel reg)
    {
        var requestData = JsonSerializer.Serialize(reg);
        var result = await Sender.Send<string>(requestData, Endpoints.Login, HttpMethod.Post);
        return result;
    }

    public static async Task<Response<Account>> AccountInfo(string token)
    {
        var result = await Sender.Send<Account>("", Endpoints.WhoIAm, HttpMethod.Get, token);
        return result;
    }

    class Endpoints
    {
        public static string CreateAccount = "/Account/Create";
        public static string GetAccount = "/Account/Get";
        public static string Login = "/Authorization/Login";
        public static string WhoIAm = "/Authorization/WhoIAm";
    }

    static class Sender
    {
        static HttpClient _client = new HttpClient();
        //static string BaseUrl = "https://localhost:7109";
        static string BaseUrl = "https://lonewald.ru";
        public static async Task<Response<T>> Send<T>(string requestBody, string endPoint, HttpMethod method) where T : class
        {
            return await Send<T>(requestBody, endPoint, method, String.Empty);
        }

        public static async Task<Response<T>> Send<T>(string requestBody, string endPoint, HttpMethod method, string token) where T : class
        {
            var request = new HttpRequestMessage(method, BaseUrl + endPoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = new StringContent(requestBody, Encoding.UTF8, method == HttpMethod.Get || method == HttpMethod.Delete ? "application/x-www-form-urlencoded" : "application/json");
            HttpResponseMessage response;
            try
            {
                response = await _client.SendAsync(request);
            }
            catch (Exception e)
            {
                return new Response<T>() { Error = new(e.Message) };
            }
            var str = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                if ((int)response.StatusCode >= 500)
                    return new Response<T>() { Error = new(response.ReasonPhrase) };
            var resultObject = JsonSerializer.Deserialize<Response<T>>(str);
            return resultObject;
        }
    }
}
