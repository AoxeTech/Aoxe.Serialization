namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static byte[] ToBytes(
        this object? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) =>
        TomletHelper.ToBytes(value, tomlSerializerOptions, encoding);
}