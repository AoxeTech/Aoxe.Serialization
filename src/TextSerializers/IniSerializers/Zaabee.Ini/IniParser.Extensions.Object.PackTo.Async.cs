namespace Zaabee.Ini;

public static partial class IniParserExtensions
{
    public static Task PackToAsync<TValue>(
        this TValue? value,
        Stream? stream,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        IniParserHelper.PackAsync(value, stream, encoding, cancellationToken);

    public static Task PackToAsync(
        this object? value,
        Stream? stream,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        IniParserHelper.PackAsync(value, stream, encoding, cancellationToken);

    public static Task PackToAsync(
        this object? value,
        Type type,
        Stream? stream,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        IniParserHelper.PackAsync(type, value, stream, encoding, cancellationToken);
}