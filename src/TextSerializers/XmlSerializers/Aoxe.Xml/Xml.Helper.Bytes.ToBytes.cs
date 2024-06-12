namespace Aoxe.Xml;

public static partial class XmlHelper
{
    /// <summary>
    /// Serialize the object to a memory stream and return a bytes contain the stream content.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(TValue? value) => ToBytes(typeof(TValue), value);

    /// <summary>
    /// Serialize the object to a memory stream and return a bytes contain the stream content.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static byte[] ToBytes(Type type, object? value)
    {
        using var ms = ToStream(type, value);
        return ms.ToArray();
    }
}
