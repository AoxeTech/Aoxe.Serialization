namespace Zaabee.Tomlet;

public static partial class TomletHelper
{
    /// <summary>
    /// Deserialize the toml to an instance of the <typeparamref name="TValue"/>.
    /// </summary>
    /// <param name="toml"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromToml<TValue>(
        string? toml,
        TomlSerializerOptions? tomlSerializerOptions = null) =>
        string.IsNullOrWhiteSpace(toml)
            ? default
            : TomletMain.To<TValue>(toml, tomlSerializerOptions);

    /// <summary>
    /// Deserialize the toml to an object of the <paramref name="type"/>. 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="toml"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <returns></returns>
    public static object? FromToml(
        Type type,
        string? toml,
        TomlSerializerOptions? tomlSerializerOptions = null) =>
        string.IsNullOrWhiteSpace(toml)
            ? default
            : TomletMain.To(type, new TomlParser().Parse(toml), tomlSerializerOptions);
}