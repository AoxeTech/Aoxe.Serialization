namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    public static Encoding DefaultEncoding { get; set; } = Encoding.UTF8;

    private static string GetString(Encoding? encoding, byte[] bytes) =>
        (encoding ?? DefaultEncoding).GetString(bytes);

    private static byte[] GetBytes(Encoding? encoding, string text) =>
        (encoding ?? DefaultEncoding).GetBytes(text);
}