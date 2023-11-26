namespace Zaabee.Ini;

public static partial class IniParserExtensions
{
    public static void PackTo<TValue>(
        this TValue? value,
        Stream? stream,
        Encoding? encoding = null
    ) => IniParserHelper.Pack(value, stream, encoding);

    public static void PackTo(this object? value, Stream? stream, Encoding? encoding = null) =>
        IniParserHelper.Pack(value, stream, encoding);

    public static void PackTo(
        this object? value,
        Type type,
        Stream? stream,
        Encoding? encoding = null
    ) => IniParserHelper.Pack(type, value, stream, encoding);
}
