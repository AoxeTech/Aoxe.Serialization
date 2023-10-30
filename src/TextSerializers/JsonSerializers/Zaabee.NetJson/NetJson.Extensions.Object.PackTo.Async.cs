namespace Zaabee.NetJson;

public static partial class NetJsonExtensions
{
    public static ValueTask PackToAsync<TValue>(this TValue? value, Stream? stream,
        NetJSONSettings? settings = null) =>
        NetJsonHelper.PackAsync(value, stream, settings);

    public static ValueTask PackToAsync(this object? value, Stream? stream,
        NetJSONSettings? settings = null) =>
        NetJsonHelper.PackAsync(value, stream, settings);

    public static ValueTask PackToAsync(this object? value, Type type, Stream? stream,
        NetJSONSettings? settings = null) =>
        NetJsonHelper.PackAsync(type, value, stream, settings);
}