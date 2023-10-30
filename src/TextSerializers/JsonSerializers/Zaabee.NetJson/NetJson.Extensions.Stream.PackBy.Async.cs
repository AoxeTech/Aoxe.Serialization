namespace Zaabee.NetJson;

public static partial class NetJsonExtensions
{
    public static ValueTask PackByAsync<TValue>(this Stream? stream, TValue? value,
        NetJSONSettings? settings = null) =>
        NetJsonHelper.PackAsync(value, stream, settings);

    public static ValueTask PackByAsync(this Stream? stream, object? value,
        NetJSONSettings? settings = null) =>
        NetJsonHelper.PackAsync(value, stream, settings);

    public static ValueTask PackByAsync(this Stream? stream, Type type, object? value,
        NetJSONSettings? settings = null) =>
        NetJsonHelper.PackAsync(type, value, stream, settings);
}