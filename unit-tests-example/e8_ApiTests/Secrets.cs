namespace e8_ApiTests;

public class Secrets
{
    public static string GetSecret(string fileName)
    {
        var path = Directory.GetCurrentDirectory();
        var pathSecretFile = Path.Combine(path, fileName);

        StreamReader secretFile = File.OpenText(pathSecretFile);
        var secret = secretFile.ReadLine();
        secretFile.Close();
        return secret;
    }
}