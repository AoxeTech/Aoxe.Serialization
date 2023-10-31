namespace Zaabee.Tomlet;

public static partial class TomletExtensions
{
    public static ValueTask PackToAsync(
        this object? value,
        Stream? stream,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        TomletHelper.PackAsync(value, stream, tomlSerializerOptions, encoding, cancellationToken);
}