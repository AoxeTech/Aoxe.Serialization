namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterHelper
{
    /// <summary>
    /// Deserialize the bytes to an generic instance.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ZeroFormatterSerializer.Deserialize<TValue>(bytes);

    /// <summary>
    /// Deserialize the bytes to an object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static object? FromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes);
}