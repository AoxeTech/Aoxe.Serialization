namespace Zaabee.Tomlyn;

public static partial class TomlynExtensions
{
    public static void PackTo(
        this object? value,
        Stream? stream,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null) =>
        TomlynHelper.Pack(value, stream, tomlModelOptions, encoding);
}