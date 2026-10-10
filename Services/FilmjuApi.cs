using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Filmju_Modern.Services;

public class FilmjuApi
{
    // 1. HTTP client and configuration
    readonly HttpClient _httpClient = new();

    string _currentUrl = DefaultURL;
    const string DefaultURL = "http://downloadfilesdirectlinktest.ir";
    const string AlternateServer = "http://raw.githubusercontent.com/irubibox/link/main/link-win.txt";
    const string key = "a7ed9scqfdcoixoec2yi4c0xb6nuqi4ssirp";

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
        string response = await GetAsync(AlternateServer);
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

        string response = await PostAsync(BuildApiUrl(EndPoints.Users, "login"), parameters);

        return ParseLoginResponse(response);
    }

    public async Task<UserSession?> RestoreSessionAsync(string username, string token)
    {
        _username = username;
        _token = token;

        string response = await PostAsync(BuildApiUrl(EndPoints.Users, "login"));

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


    public async Task<string> GetHomeDataAsync()
    {
        string url = BuildApiUrl(EndPoints.Vv1, "vitrin");
        return await PostAsync(url);
    }


    private string BuildApiUrl(EndPoints endPoints, string action)
    {
        string endpoint = endPoints switch
        {
            EndPoints.Vv1 => "vv1",
            EndPoints.Users => "users",
            _ => throw new ArgumentOutOfRangeException(nameof(endPoints))
        };

        return $"{_currentUrl}/app/wiinnap/{endpoint}?key={key}&action={Uri.EscapeDataString(action)}";
    }

    enum EndPoints
    {
        Vv1,
        Users
    }
}