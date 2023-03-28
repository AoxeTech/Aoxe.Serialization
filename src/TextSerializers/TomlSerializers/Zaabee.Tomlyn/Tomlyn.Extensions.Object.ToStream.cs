namespace Zaabee.Tomlyn;

public static partial class TomlynExtensions
{
    public static MemoryStream ToStream(
        this object? value,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null) =>
        TomlynHelper.ToStream(value, tomlModelOptions, encoding);
}