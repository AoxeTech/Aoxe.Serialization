namespace Zaabee.Tomlyn;

public static partial class TomlynExtensions
{
    public static Task PackToAsync(
        this object? value,
        Stream? stream,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        TomlynHelper.PackAsync(value, stream, tomlModelOptions, encoding, cancellationToken);
}