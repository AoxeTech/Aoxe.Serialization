namespace Aoxe.Ini;

public static partial class IniParserExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream, Encoding? encoding = null) =>
        IniParserHelper.FromStream<TValue>(stream, encoding);

    public static object? FromStream(this Stream? stream, Type type, Encoding? encoding = null) =>
        IniParserHelper.FromStream(type, stream, encoding);
}
