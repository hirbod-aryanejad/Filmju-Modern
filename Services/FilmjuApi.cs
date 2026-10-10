using System.Net.Http;
using System.Text.Json;


namespace Filmju_Modern.Services;

public class FilmjuApi
{
    // 1. HTTP client and configuration

    private readonly HttpClient _httpClient = new();

    private string _currentUrl = DefaultURL;

    private const string DefaultURL = "http://downloadfilesdirectlinktest.ir";
    private const string AlternateURL = "http://raw.githubusercontent.com/irubibox/link/main/link-win.txt";

    private const string LoginURL = "/app/wiinnap/users?key=a7ed9scqfdcoixoec2yi4c0xb6nuqi4ssirp&action=login";

    private const string KeyURL = "key=a7ed9scqfdcoixoec2yi4c0xb6nuqi4ssirp&";
    private const string Vv1URL = "/app/wiinnap/vv1?";
    private const string UsersURL = "/app/wiinnap/users?";


    // These values will be supplied by the app/session configuration.
    private string _auth = "";
    private string _username = "";
    private string _token = "";
    private string _language = "";
    private string _fontSize = "";
    private string _appName = "Fj";


    // 2. Shared GET and POST request methods

    private async Task<string> GetAsync(string url)
    {
        using HttpResponseMessage response =
            await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    private async Task<string> PostAsync(string url, Dictionary<string, string>? parameters = null)
    {
        parameters ??= new Dictionary<string, string>();

        // Preserve the common fields sent by the original application.
        parameters["body"] = CreateConfig(_auth);
        parameters["font_size"] = _fontSize;
        parameters["user_name"] = _username;
        parameters["token"] = _token;
        parameters["langueg"] = _language;
        parameters["apname"] = _appName;

        using var content = new FormUrlEncodedContent(parameters);

        using HttpResponseMessage response = await _httpClient.PostAsync(url, content);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    private static string CreateConfig(string auth)
    {
        long timestamp = DateTime.Now.ToFileTime();

        return timestamp + auth + "y87mdjsodonc215sfxd545fgsoxcusd" + Random.Shared.Next(500) + "Scjsix" + timestamp + "PDcdsifudi";
    }


    // 3. Public server operations

    public async Task<string> GetAlternateServerAsync()
    {
        string response = await GetAsync(AlternateURL);
        string serverUrl = response.Trim();

        if (string.IsNullOrWhiteSpace(serverUrl))
        {
            throw new InvalidOperationException("The alternate server address was empty.");
        }

        _currentUrl = serverUrl.TrimEnd('/');

        return _currentUrl;
    }

    public async Task<UserSession?> LoginAsync(string username, string password)
    {
        _username = username;

        var parameters = new Dictionary<string, string>
        {
            ["pass"] = password
        };

        string response = await PostAsync(_currentUrl + LoginURL, parameters);

        return ParseLoginResponse(response);
    }

    public async Task<UserSession?> RestoreSessionAsync(string username, string token)
    {
        _username = username;
        _token = token;

        string response = await PostAsync(_currentUrl + LoginURL);

        return ParseLoginResponse(response);
    }

    // 4. Private response parsing methods

    private static UserSession? ParseLoginResponse(string response)
    {
        using JsonDocument document = JsonDocument.Parse(response);

        JsonElement root = document.RootElement;

        if (root.ValueKind != JsonValueKind.Array ||
            root.GetArrayLength() == 0)
        {
            throw new JsonException("The login response was not a non-empty JSON array.");
        }

        JsonElement userData = root[0];

        string ReadString(string key)
        {
            return userData.TryGetProperty(key, out JsonElement value) ? value.ToString() : "";
        }

        var session = new UserSession
        {
            LoginState = ReadString("login"),
            Auth = ReadString("auth")
        };

        if (!session.IsLoggedIn) return session;

        session.AccountState = ReadString("stete_account");
        session.Name = ReadString("name");
        session.SubscriptionExpiryDate = ReadString("tosal");
        session.Token = ReadString("token");
        session.UserState = ReadString("state_user");
        session.Username = ReadString("user_name");
        session.LanguageTitleMovies = ReadString("langueg_title_movies");

        return session;
    }
}