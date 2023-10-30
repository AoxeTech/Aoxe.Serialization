namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.FromBytes<TValue>(bytes, settings);

    public static object? FromBytes(this byte[]? bytes, Type type, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.FromBytes(type, bytes, settings);
}