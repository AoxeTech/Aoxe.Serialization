namespace Zaabee.Tomlyn;

public static partial class TomlynHelper
{
    /// <summary>
    /// Deserialize the toml to an instance of the <typeparamref name="TValue"/>.
    /// </summary>
    /// <param name="toml"></param>
    /// <param name="sourcePath"></param>
    /// <param name="tomlModelOptions"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromToml<TValue>(
        string? toml,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null
    )
        where TValue : class, new() =>
        string.IsNullOrWhiteSpace(toml)
            ? default
            : Toml.ToModel<TValue>(toml!, sourcePath, tomlModelOptions);

    /// <summary>
    /// Deserialize the toml to an TomlTable
    /// </summary>
    /// <param name="toml"></param>
    /// <param name="sourcePath"></param>
    /// <param name="tomlModelOptions"></param>
    /// <returns></returns>
    public static TomlTable? FromToml(
        string? toml,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null
    ) =>
        string.IsNullOrWhiteSpace(toml)
            ? default
            : Toml.ToModel(toml!, sourcePath, tomlModelOptions);
}
