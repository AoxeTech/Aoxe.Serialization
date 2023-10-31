namespace Zaabee.Tomlet;

public static partial class TomletHelper
{
    /// <summary>
    /// Serialize the value to toml string.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <returns></returns>
    public static string ToToml(
        object? value,
        TomlSerializerOptions? tomlSerializerOptions = null) =>
        value is null
            ? string.Empty
            : TomletMain.TomlStringFrom(TomletMain.DocumentFrom(value, tomlSerializerOptions));
}