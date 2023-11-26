namespace Zaabee.Tomlyn;

public static partial class TomlynHelper
{
    /// <summary>
    /// Serialize the value to toml string.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="tomlModelOptions"></param>
    /// <returns></returns>
    public static string ToToml(object? value, TomlModelOptions? tomlModelOptions = null) =>
        value is null ? string.Empty : Toml.FromModel(value, tomlModelOptions);
}
