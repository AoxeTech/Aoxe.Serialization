namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static TValue? FromToml<TValue>(
        this string? toml,
        TomlSerializerOptions? tomlSerializerOptions = null)
        where TValue : class, new() =>
        TomletHelper.FromToml<TValue>(toml, tomlSerializerOptions);

    public static object? FromToml(
        this string? toml,
        Type type,
        TomlSerializerOptions? tomlSerializerOptions = null) =>
        TomletHelper.FromToml(type, toml, tomlSerializerOptions);
}