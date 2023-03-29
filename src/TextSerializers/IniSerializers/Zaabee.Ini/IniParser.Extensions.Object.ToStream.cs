namespace Zaabee.Ini;

public static partial class IniParserExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value, Encoding? encoding = null) =>
        IniParserHelper.ToStream(value, encoding);

    public static MemoryStream ToStream(this object? value, Encoding? encoding = null) =>
        IniParserHelper.ToStream(value, encoding);

    public static MemoryStream ToStream(this object? value, Type type, Encoding? encoding = null) =>
        IniParserHelper.ToStream(type, value, encoding);
}