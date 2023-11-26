namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterHelper
{
    /// <summary>
    /// Serialize the specified generic instance to a bytes.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(TValue? value) => ZeroFormatterSerializer.Serialize(value);

    /// <summary>
    /// Serialize the specified object to a bytes.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static byte[] ToBytes(Type type, object? value) =>
        ZeroFormatterSerializer.NonGeneric.Serialize(type, value);
}
