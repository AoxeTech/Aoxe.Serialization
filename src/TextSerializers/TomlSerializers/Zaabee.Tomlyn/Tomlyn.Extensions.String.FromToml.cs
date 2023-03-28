namespace Zaabee.Tomlyn;

public static partial class TomlynExtensions
{
    public static TValue? FromToml<TValue>(
        this string? toml,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null)
        where TValue : class, new() =>
        TomlynHelper.FromToml<TValue>(toml, sourcePath, tomlModelOptions);

    public static TomlTable? FromToml(
        this string? toml,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null) =>
        TomlynHelper.FromToml(toml, sourcePath, tomlModelOptions);
}