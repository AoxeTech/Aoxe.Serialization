namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.ToBytes(value, settings);

    public static byte[] ToBytes(this object? value, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.ToBytes(value, settings);

    public static byte[] ToBytes(this object? value, Type type, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.ToBytes(type, value, settings);
}