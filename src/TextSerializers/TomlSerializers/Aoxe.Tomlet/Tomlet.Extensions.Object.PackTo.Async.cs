namespace Aoxe.Tomlet;

public static partial class TomletExtensions
{
    public static ValueTask PackToAsync<TValue>(
        this TValue? value,
        Stream? stream,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    ) => TomletHelper.PackAsync(value, stream, tomlSerializerOptions, encoding, cancellationToken);

    public static ValueTask PackToAsync(
        this object? value,
        Type type,
        Stream? stream,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    ) =>
        TomletHelper.PackAsync(
            type,
            value,
            stream,
            tomlSerializerOptions,
            encoding,
            cancellationToken
        );
}
