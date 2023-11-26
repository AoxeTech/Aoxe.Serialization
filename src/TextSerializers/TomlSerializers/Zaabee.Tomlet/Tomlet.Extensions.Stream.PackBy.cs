namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static void PackBy<TValue>(
        this Stream? stream,
        TValue? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    ) => TomletHelper.Pack(value, stream, tomlSerializerOptions, encoding);

    public static void PackBy(
        this Stream? stream,
        Type type,
        object? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    ) => TomletHelper.Pack(type, value, stream, tomlSerializerOptions, encoding);
}
