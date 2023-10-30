namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static ValueTask PackByAsync<TValue>(this Stream? stream, TValue? value,
        NetJSONSettings? settings = null) =>
        Utf8JsonHelper.PackAsync(value, stream, settings);

    public static ValueTask PackByAsync(this Stream? stream, Type type, object? value,
        NetJSONSettings? settings = null) =>
        Utf8JsonHelper.PackAsync(type, value, stream, settings);
}