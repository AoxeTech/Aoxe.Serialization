namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(this Stream? stream,
        NetJSONSettings? settings = null) =>
        Utf8JsonHelper.FromStreamAsync<TValue>(stream, settings);

    public static ValueTask<object?> FromStreamAsync(this Stream? stream, Type type,
        NetJSONSettings? settings = null) =>
        Utf8JsonHelper.FromStreamAsync(type, stream, settings);
}