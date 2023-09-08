namespace Zaabee.Tomlyn;

public static partial class TomlynExtensions
{
    public static ValueTask PackByAsync(
        this Stream? stream,
        object? value,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        TomlynHelper.PackAsync(value, stream, tomlModelOptions, encoding, cancellationToken);
}