namespace Zaabee.Jil;

public static partial class JilHelper
{
    private static Encoding _defaultEncoding = Encoding.UTF8;

    public static Encoding? DefaultEncoding
    {
        get => _defaultEncoding;
        set => _defaultEncoding = value ?? _defaultEncoding;
    }
}