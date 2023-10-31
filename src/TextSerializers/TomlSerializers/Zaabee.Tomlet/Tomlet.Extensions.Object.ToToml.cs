namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static string ToToml(
        this object? value,
        TomlSerializerOptions? tomlSerializerOptions = null) =>
        TomletHelper.ToToml(value, tomlSerializerOptions);
}