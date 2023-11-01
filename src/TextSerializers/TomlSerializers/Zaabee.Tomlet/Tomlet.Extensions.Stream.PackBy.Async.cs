namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static ValueTask PackByAsync<TValue>(
        this Stream? stream,
        TValue? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        TomletHelper.PackAsync(value, stream, tomlSerializerOptions, encoding, cancellationToken);
}