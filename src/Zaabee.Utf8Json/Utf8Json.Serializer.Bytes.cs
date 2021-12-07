namespace Zaabee.Utf8Json;

public static partial class Utf8JsonSerializer
{
    /// <summary>
    /// Serialize to binary with specified resolver.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] Serialize<TValue>(TValue value, IJsonFormatterResolver? resolver) =>
        JsonSerializer.Serialize(value, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static byte[] Serialize(Type type, object? value, IJsonFormatterResolver? resolver) =>
        JsonSerializer.NonGeneric.Serialize(type, value, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static byte[] Serialize(object? value, IJsonFormatterResolver? resolver) =>
        JsonSerializer.NonGeneric.Serialize(value, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver. Get the raw memory pool byte[]. The result can not share across thread and can not hold, so use quickly.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static ArraySegment<byte> SerializeUnsafe<TValue>(TValue value, IJsonFormatterResolver? resolver) =>
        JsonSerializer.SerializeUnsafe(value, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver. Get the raw memory pool byte[]. The result can not share across thread and can not hold, so use quickly.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static ArraySegment<byte> SerializeUnsafe(Type type, object? value, IJsonFormatterResolver? resolver) =>
        JsonSerializer.NonGeneric.SerializeUnsafe(type, value, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver. Get the raw memory pool byte[]. The result can not share across thread and can not hold, so use quickly.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static ArraySegment<byte> SerializeUnsafe(object? value, IJsonFormatterResolver? resolver) =>
        JsonSerializer.NonGeneric.SerializeUnsafe(value, resolver);

    /// <summary>
    /// Deserialize bytes to object.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(byte[] bytes, IJsonFormatterResolver? resolver) =>
        JsonSerializer.Deserialize<TValue>(bytes, resolver);

    /// <summary>
    /// Deserialize bytes to object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, byte[] bytes, IJsonFormatterResolver? resolver) =>
        JsonSerializer.NonGeneric.Deserialize(type, bytes, resolver);
}