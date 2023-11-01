namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static string ToToml<TValue>(
        this TValue? value,
        TomlSerializerOptions? tomlSerializerOptions = null) =>
        TomletHelper.ToToml(value, tomlSerializerOptions);
}