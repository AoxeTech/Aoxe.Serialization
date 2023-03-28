namespace Zaabee.Tomlyn;

public static partial class TomlynExtensions
{
    public static TValue? FromBytes<TValue>(
        this byte[]? bytes,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null)
        where TValue : class, new() =>
        TomlynHelper.FromBytes<TValue>(bytes, sourcePath, tomlModelOptions, encoding);

    public static TomlTable? FromBytes(
        this byte[]? bytes,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null) =>
        TomlynHelper.FromBytes(bytes, sourcePath, tomlModelOptions, encoding);
}