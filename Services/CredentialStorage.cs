using System.IO;
using System.Security.Cryptography;
using System.Text.Json;

namespace Filmju_Modern.Services;

public class CredentialStorage
{
    private readonly string _filePath;

    public CredentialStorage()
    {
        string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Filmju Modern");

        Directory.CreateDirectory(folder);

        _filePath = Path.Combine(folder, "credentials.dat");
    }

    public void Save(string username, string token)
    {
        var credentials = new SavedCredentials
        {
            Username = username,
            Token = token
        };

        byte[] plainBytes =
            JsonSerializer.SerializeToUtf8Bytes(credentials);

        byte[] encryptedBytes = ProtectedData.Protect(
            plainBytes,
            optionalEntropy: null,
            scope: DataProtectionScope.CurrentUser);

        File.WriteAllBytes(_filePath, encryptedBytes);
    }

    public SavedCredentials? Load()
    {
        if (!File.Exists(_filePath))
            return null;

        byte[] encryptedBytes = File.ReadAllBytes(_filePath);

        byte[] plainBytes = ProtectedData.Unprotect(
            encryptedBytes,
            optionalEntropy: null,
            scope: DataProtectionScope.CurrentUser);

        return JsonSerializer.Deserialize<SavedCredentials>(plainBytes);
    }

    public void Clear()
    {
        if (File.Exists(_filePath))
            File.Delete(_filePath);
    }

    public class SavedCredentials
    {
        public string Username { get; set; } = "";
        public string Token { get; set; } = "";
    }
}

