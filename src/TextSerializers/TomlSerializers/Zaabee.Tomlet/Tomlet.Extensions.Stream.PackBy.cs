namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static void PackBy<TValue>(
        this Stream? stream,
        TValue? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) =>
        TomletHelper.Pack(value, stream, tomlSerializerOptions, encoding);
}