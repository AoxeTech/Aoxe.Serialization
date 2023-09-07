namespace Zaabee.Ini;

public static partial class IniParserExtensions
{
    public static Task PackByAsync<TValue>(
        this Stream? stream,
        TValue? value,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        IniParserHelper.PackAsync(value, stream, encoding, cancellationToken);

    public static Task PackByAsync(
        this Stream? stream,
        object? value,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        IniParserHelper.PackAsync(value, stream, encoding, cancellationToken);

    public static Task PackByAsync(
        this Stream? stream,
        Type type, object? value,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        IniParserHelper.PackAsync(type, value, stream, encoding, cancellationToken);
}