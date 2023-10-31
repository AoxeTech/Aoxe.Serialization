namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static ValueTask PackByAsync(
        this Stream? stream,
        object? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        TomletHelper.PackAsync(value, stream, tomlSerializerOptions, encoding, cancellationToken);
}