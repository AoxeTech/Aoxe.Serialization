namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static void PackTo(
        this object? value,
        Stream? stream,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) =>
        TomletHelper.Pack(value, stream, tomlSerializerOptions, encoding);
}