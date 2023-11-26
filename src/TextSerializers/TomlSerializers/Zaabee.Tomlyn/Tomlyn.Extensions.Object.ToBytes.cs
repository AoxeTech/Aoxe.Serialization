namespace Zaabee.Tomlyn;

public static partial class TomlynExtensions
{
    public static byte[] ToBytes(
        this object? value,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null
    ) => TomlynHelper.ToBytes(value, tomlModelOptions, encoding);
}
