namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static ValueTask PackToAsync<TValue>(this TValue? value, Stream? stream,
        NetJSONSettings? settings = null) =>
        Utf8JsonHelper.PackAsync(value, stream, settings);

    public static ValueTask PackToAsync(this object? value, Stream? stream,
        NetJSONSettings? settings = null) =>
        Utf8JsonHelper.PackAsync(value, stream, settings);

    public static ValueTask PackToAsync(this object? value, Type type, Stream? stream,
        NetJSONSettings? settings = null) =>
        Utf8JsonHelper.PackAsync(type, value, stream, settings);
}