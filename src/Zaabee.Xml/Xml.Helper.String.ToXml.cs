namespace Zaabee.Xml;

public static partial class XmlHelper
{
    /// <summary>
    ///  Serialize the object into a memory stream,get bytes from it and return the decode result.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToXml<TValue>(TValue? value) =>
        ToXml(typeof(TValue), value);

    /// <summary>
    /// Serialize the object into a memory stream,get bytes from it and return the decode result.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToXml(Type type, object? value)
    {
        using var ms = ToStream(type, value);
        return Encoding.UTF8.GetString(ms.ReadToEnd());
    }
}