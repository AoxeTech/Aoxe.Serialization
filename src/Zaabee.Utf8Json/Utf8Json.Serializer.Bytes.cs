namespace Zaabee.Utf8Json;

public static partial class Utf8JsonSerializer
{
    /// <summary>
    /// Serialize to binary with specified resolver.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static byte[] Serialize<T>(T value, IJsonFormatterResolver resolver) =>
        JsonSerializer.Serialize(value, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static byte[] Serialize(Type type, object obj, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.Serialize(type, obj, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static byte[] Serialize(object obj, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.Serialize(obj, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver. Get the raw memory pool byte[]. The result can not share across thread and can not hold, so use quickly.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ArraySegment<byte> SerializeUnsafe<T>(T value, IJsonFormatterResolver resolver) =>
        JsonSerializer.SerializeUnsafe(value, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver. Get the raw memory pool byte[]. The result can not share across thread and can not hold, so use quickly.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static ArraySegment<byte> SerializeUnsafe(Type type, object obj, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.SerializeUnsafe(type, obj, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver. Get the raw memory pool byte[]. The result can not share across thread and can not hold, so use quickly.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static ArraySegment<byte> SerializeUnsafe(object obj, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.SerializeUnsafe(obj, resolver);

    /// <summary>
    /// Deserialize bytes to object.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Deserialize<T>(byte[] bytes, IJsonFormatterResolver resolver) =>
        JsonSerializer.Deserialize<T>(bytes, resolver);

    /// <summary>
    /// Deserialize bytes to object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static object Deserialize(Type type, byte[] bytes, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.Deserialize(type, bytes, resolver);
}