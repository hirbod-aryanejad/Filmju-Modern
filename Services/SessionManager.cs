using Filmju_Modern.Services;

namespace Filmju_Modern;

public class SessionManager
{
    private readonly FilmjuApi _api;
    private readonly CredentialStorage _storage;

    public UserSession? CurrentSession { get; private set; }

    public bool IsLoggedIn => CurrentSession?.IsLoggedIn == true;

    public SessionManager()
    {
        _api = new FilmjuApi();
        _storage = new CredentialStorage();
    }

    public async Task<bool> LoginAsync(string username, string token)
    {
        UserSession? session = await _api.LoginAsync(username, token);

        if (session == null || !session.IsLoggedIn)
        {
            CurrentSession = null;
            return false;
        }

        CurrentSession = session;

        _storage.Save(session.Username, session.Token);

        return true;
    }

    public async Task<bool> RestoreSessionAsync()
    {
        CredentialStorage.SavedCredentials? credentials;

        try
        {
            credentials = _storage.Load();
        }
        catch (Exception)
        {
            _storage.Clear();
            return false;
        }

        if (credentials == null)
            return false;

        return await LoginAsync(
            credentials.Username,
            credentials.Token);
    }

    public void Logout()
    {
        CurrentSession = null;
        _storage.Clear();
    }
}
