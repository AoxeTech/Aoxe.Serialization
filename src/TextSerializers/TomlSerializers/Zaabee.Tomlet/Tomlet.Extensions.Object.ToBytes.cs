namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static byte[] ToBytes<TValue>(
        this TValue? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) =>
        TomletHelper.ToBytes(value, tomlSerializerOptions, encoding);
}