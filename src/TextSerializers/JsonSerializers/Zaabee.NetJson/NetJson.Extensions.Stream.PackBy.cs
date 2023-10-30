namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.Pack(value, stream, settings);

    public static void PackBy(this Stream? stream, Type type, object? value, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.Pack(type, value, stream, settings);
}