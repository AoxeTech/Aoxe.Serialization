namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static ValueTask PackToAsync<TValue>(
        this TValue? value,
        Stream? stream,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    ) => NewtonsoftJsonHelper.PackAsync(value, stream, settings, encoding, cancellationToken);

    public static ValueTask PackToAsync(
        this object? value,
        Type type,
        Stream? stream,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    ) => NewtonsoftJsonHelper.PackAsync(type, value, stream, settings, encoding, cancellationToken);
}
