namespace Zaabee.Ini;

public static partial class IniParserExtensions
{
    public static async Task<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        await IniParserHelper.FromStreamAsync<TValue>(stream, encoding, cancellationToken);

    public static async Task<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        await IniParserHelper.FromStreamAsync(type, stream, encoding, cancellationToken);
}