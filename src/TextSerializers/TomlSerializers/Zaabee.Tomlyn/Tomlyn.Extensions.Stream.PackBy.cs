namespace Zaabee.Tomlyn;

public static partial class TomlynExtensions
{
    public static void PackBy(
        this Stream? stream,
        object? value,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null) =>
        TomlynHelper.Pack(value, stream, tomlModelOptions, encoding);
}