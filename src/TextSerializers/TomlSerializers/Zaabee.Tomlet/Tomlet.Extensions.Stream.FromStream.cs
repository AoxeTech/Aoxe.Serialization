namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static TValue? FromStream<TValue>(
        this Stream? stream,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    ) => TomletHelper.FromStream<TValue>(stream, tomlSerializerOptions, encoding);

    public static object? FromStream(
        this Stream? stream,
        Type type,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    ) => TomletHelper.FromStream(type, stream, tomlSerializerOptions, encoding);
}
