namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        TomletHelper.FromStreamAsync<TValue>(stream, tomlSerializerOptions, encoding,
            cancellationToken: cancellationToken);

    public static ValueTask<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        TomletHelper.FromStreamAsync(type, stream, tomlSerializerOptions, encoding, cancellationToken);
}