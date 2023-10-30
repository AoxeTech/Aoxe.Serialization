namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.FromStream<TValue>(stream, settings);

    public static object? FromStream(this Stream? stream, Type type, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.FromStream(type, stream, settings);
}