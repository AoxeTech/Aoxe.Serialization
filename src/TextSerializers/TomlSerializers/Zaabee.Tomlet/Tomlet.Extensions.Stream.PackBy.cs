namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static void PackBy(
        this Stream? stream,
        object? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) =>
        TomletHelper.Pack(value, stream, tomlSerializerOptions, encoding);
}