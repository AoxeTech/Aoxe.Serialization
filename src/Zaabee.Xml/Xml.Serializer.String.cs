namespace Zaabee.Xml;

public static partial class XmlSerializer
{
    /// <summary>
    ///  Serialize the object into a memory stream,get bytes from it and return the decode result.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string SerializeToXml<TValue>(TValue? value) =>
        SerializeToXml(typeof(TValue), value);

    /// <summary>
    /// Serialize the object into a memory stream,get bytes from it and return the decode result.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string SerializeToXml(Type type, object? value)
    {
        using var ms = Pack(type, value);
        return Encoding.UTF8.GetString(ms.ReadToEnd());
    }

    /// <summary>
    /// Encode the xml to a bytes and initialize a memory stream by it,deserialize to a object.
    /// </summary>
    /// <param name="xml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(string xml) =>
        (TValue?) Deserialize(typeof(TValue), xml);

    /// <summary>
    /// Encode the xml to a bytes and initialize a memory stream by it,deserialize to a object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, string xml)
    {
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        return Unpack(type, ms);
    }
}