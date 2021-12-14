namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static Task PackByAsync<TValue>(this Stream? stream, TValue? value, JsonSerializerSettings? settings = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        NewtonsoftJsonHelper.PackAsync(value, stream, settings, encoding, cancellationToken);

    public static Task PackByAsync(this Stream? stream, Type type, object? value,
        JsonSerializerSettings? settings = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        NewtonsoftJsonHelper.PackAsync(type, value, stream, settings, encoding, cancellationToken);
}