namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.ToStream(value, settings);

    public static MemoryStream ToStream(this object? value, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.ToStream(value, settings);

    public static MemoryStream ToStream(this object? value, Type type, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.ToStream(type, value, settings);
}