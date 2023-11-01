namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static string ToToml<TValue>(
        this TValue? value,
        TomlSerializerOptions? tomlSerializerOptions = null) =>
        TomletHelper.ToToml(value, tomlSerializerOptions);

    public static string ToToml(
        this object? value,
        Type type,
        TomlSerializerOptions? tomlSerializerOptions = null) =>
        TomletHelper.ToToml(type, value, tomlSerializerOptions);
}