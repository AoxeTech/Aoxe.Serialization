namespace Aoxe.Ini;

public static partial class IniParserExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes, Encoding? encoding = null) =>
        IniParserHelper.FromBytes<TValue>(bytes, encoding);

    public static object? FromBytes(this byte[]? bytes, Type type, Encoding? encoding = null) =>
        IniParserHelper.FromBytes(type, bytes, encoding);
}
