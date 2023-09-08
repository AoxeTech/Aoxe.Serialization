namespace Zaabee.Ini;

public static partial class IniParserExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        IniParserHelper.FromStreamAsync<TValue>(stream, encoding, cancellationToken);

    public static ValueTask<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        IniParserHelper.FromStreamAsync(type, stream, encoding, cancellationToken);
}