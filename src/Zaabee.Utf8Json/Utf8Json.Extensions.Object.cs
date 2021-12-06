namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static string ToJson<TValue>(this TValue value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.SerializeToJson(value, resolver);

    public static byte[] ToBytes<TValue>(this TValue value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Serialize(value, resolver);

    public static ArraySegment<byte> ToBytesUnsafe<TValue>(this TValue value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.SerializeUnsafe(value, resolver);

    public static void PackTo<TValue>(this TValue value, Stream? stream, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Pack(value, stream, resolver);

    public static Stream ToStream<TValue>(this TValue value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Pack(value, resolver);

    public static string ToJson(this object? value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.SerializeToJson(value, resolver);

    public static string ToJson(this object? value, Type type, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.SerializeToJson(type, value, resolver);

    public static byte[] ToBytes(this object? value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Serialize(value, resolver);

    public static byte[] ToBytes(this object? value, Type type, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Serialize(type, value, resolver);

    public static ArraySegment<byte> ToBytesUnsafe(this object? value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.SerializeUnsafe(value, resolver);

    public static ArraySegment<byte> ToBytesUnsafe(this object? value, Type type,
        IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.SerializeUnsafe(type, value, resolver);

    public static Stream ToStream(this object? value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Pack(value, resolver);

    public static Stream ToStream(this object? value, Type type, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Pack(type, value, resolver);

    public static void PackTo(this object? value, Stream? stream, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Pack(value, stream, resolver);

    public static void PackTo(this object? value, Type type, Stream? stream, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Pack(type, value, stream, resolver);
}