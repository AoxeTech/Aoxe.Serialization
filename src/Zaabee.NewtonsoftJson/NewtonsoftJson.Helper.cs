namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    private static Encoding _encoding = Encoding.UTF8;

    public static Encoding DefaultEncoding
    {
        get => _encoding;
        set => _encoding = value ?? _encoding;
    }

    public static JsonSerializerSettings DefaultSettings { get; set; }
}