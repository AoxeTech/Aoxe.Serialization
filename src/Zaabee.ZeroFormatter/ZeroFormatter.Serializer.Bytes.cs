namespace Zaabee.ZeroFormatter;

public static partial class ZeroSerializer
{
    /// <summary>
    /// Serialize the specified generic instance to a bytes.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] Serialize<TValue>(TValue value) =>
        ZeroFormatterSerializer.Serialize(value);

    /// <summary>
    /// Serialize the specified object to a bytes.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static byte[] Serialize(Type type, object? value) =>
        ZeroFormatterSerializer.NonGeneric.Serialize(type, value);

    /// <summary>
    /// Deserialize the bytes to an generic instance.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(byte[] bytes) =>
        ZeroFormatterSerializer.Deserialize<TValue>(bytes);

    /// <summary>
    /// Deserialize the bytes to an object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, byte[] bytes) =>
        ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes);
}