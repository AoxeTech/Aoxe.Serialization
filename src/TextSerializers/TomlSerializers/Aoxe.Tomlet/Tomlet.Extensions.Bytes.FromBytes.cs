namespace Aoxe.Tomlet;

public static partial class TomletExtensions
{
    public static TValue? FromBytes<TValue>(
        this byte[]? bytes,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    ) => TomletHelper.FromBytes<TValue>(bytes, tomlSerializerOptions, encoding);

    public static object? FromBytes(
        this byte[]? bytes,
        Type type,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    ) => TomletHelper.FromBytes(type, bytes, tomlSerializerOptions, encoding);
}
