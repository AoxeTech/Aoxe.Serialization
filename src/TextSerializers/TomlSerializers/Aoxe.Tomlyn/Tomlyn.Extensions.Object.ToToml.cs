namespace Aoxe.Tomlyn;

public static partial class TomlynExtensions
{
    public static string ToToml(this object? value, TomlModelOptions? tomlModelOptions = null) =>
        TomlynHelper.ToToml(value, tomlModelOptions);
}
