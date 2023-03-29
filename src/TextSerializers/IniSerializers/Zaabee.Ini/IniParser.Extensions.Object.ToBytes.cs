namespace Zaabee.Ini;

public static partial class IniParserExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value, Encoding? encoding = null) =>
        IniParserHelper.ToBytes(value, encoding);

    public static byte[] ToBytes(this object? value, Encoding? encoding = null) =>
        IniParserHelper.ToBytes(value, encoding);

    public static byte[] ToBytes(this object? value, Type type, Encoding? encoding = null) =>
        IniParserHelper.ToBytes(type, value, encoding);
}