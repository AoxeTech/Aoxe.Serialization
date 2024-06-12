namespace Aoxe.Ini;

public static partial class IniParserExtensions
{
    public static void PackBy<TValue>(
        this Stream? stream,
        TValue? value,
        Encoding? encoding = null
    ) => IniParserHelper.Pack(value, stream, encoding);

    public static void PackBy(this Stream? stream, object? value, Encoding? encoding = null) =>
        IniParserHelper.Pack(value, stream, encoding);

    public static void PackBy(
        this Stream? stream,
        Type type,
        object? value,
        Encoding? encoding = null
    ) => IniParserHelper.Pack(type, value, stream, encoding);
}
