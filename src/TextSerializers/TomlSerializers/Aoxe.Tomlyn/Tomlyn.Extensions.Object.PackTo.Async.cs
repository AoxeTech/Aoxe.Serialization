namespace Aoxe.Tomlyn;

public static partial class TomlynExtensions
{
    public static ValueTask PackToAsync(
        this object? value,
        Stream? stream,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    ) => TomlynHelper.PackAsync(value, stream, tomlModelOptions, encoding, cancellationToken);
}
