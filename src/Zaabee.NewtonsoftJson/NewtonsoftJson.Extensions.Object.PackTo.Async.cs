namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static Task PackToAsync<TValue>(this TValue? value, Stream? stream,
        JsonSerializerSettings? settings = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        NewtonsoftJsonHelper.PackAsync(value, stream, settings, encoding, cancellationToken);

    public static Task PackToAsync(this object? value, Type type, Stream? stream,
        JsonSerializerSettings? settings = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        NewtonsoftJsonHelper.PackAsync(type, value, stream, settings, encoding, cancellationToken);
}