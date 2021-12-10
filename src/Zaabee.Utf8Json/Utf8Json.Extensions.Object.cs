namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static string ToJson<TValue>(this TValue? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToJson(value, resolver);

    public static string ToJson(this object? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToJson(value, resolver);

    public static string ToJson(this object? value, Type type, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToJson(type, value, resolver);

    public static byte[] ToBytes<TValue>(this TValue? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToBytes(value, resolver);

    public static byte[] ToBytes(this object? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToBytes(value, resolver);

    public static byte[] ToBytes(this object? value, Type type, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToBytes(type, value, resolver);

    public static MemoryStream ToStream<TValue>(this TValue? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToStream(value, resolver);

    public static MemoryStream ToStream(this object? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToStream(value, resolver);

    public static MemoryStream ToStream(this object? value, Type type, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToStream(type, value, resolver);

    public static void PackTo<TValue>(this TValue? value, Stream? stream, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.Pack(value, stream, resolver);

    public static void PackTo(this object? value, Stream? stream, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.Pack(value, stream, resolver);

    public static void PackTo(this object? value, Type type, Stream? stream, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.Pack(type, value, stream, resolver);
}