namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static void PackTo<TValue>(this TValue? value, Stream? stream, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.Pack(value, stream, settings);

    public static void PackTo(this object? value, Stream? stream, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.Pack(value, stream, settings);

    public static void PackTo(this object? value, Type type, Stream? stream, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.Pack(type, value, stream, settings);
}