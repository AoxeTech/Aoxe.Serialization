namespace Zaabee.Ini;

public static partial class IniParserExtensions
{
    public static Task<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        IniParserHelper.FromStreamAsync<TValue>(stream, encoding, cancellationToken);

    public static Task<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        IniParserHelper.FromStreamAsync(type, stream, encoding, cancellationToken);
}