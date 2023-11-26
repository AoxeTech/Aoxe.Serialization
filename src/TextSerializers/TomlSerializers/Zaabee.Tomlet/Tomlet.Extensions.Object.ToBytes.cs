namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static byte[] ToBytes<TValue>(
        this TValue? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    ) => TomletHelper.ToBytes(value, tomlSerializerOptions, encoding);

    public static byte[] ToBytes(
        this object? value,
        Type type,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    ) => TomletHelper.ToBytes(type, value, tomlSerializerOptions, encoding);
}
