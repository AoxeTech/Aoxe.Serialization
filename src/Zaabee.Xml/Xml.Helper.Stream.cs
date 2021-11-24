namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static void Pack<T>(T t, Stream stream)
    {
        if (t is null || stream is null) return;
        XmlSerializer.Pack(t, stream);
    }

    public static void Pack(Type type, object obj, Stream stream)
    {
        if (type is null || obj is null || stream is null) return;
        XmlSerializer.Pack(type, obj, stream);
    }
        
    public static MemoryStream Pack<T>(T t) =>
        t is null ? new MemoryStream() : XmlSerializer.Pack(t);
        
    public static MemoryStream Pack(Type type, object obj) =>
        obj is null ? new MemoryStream() : XmlSerializer.Pack(type, obj);
        
    public static T Unpack<T>(Stream stream) =>
        stream.IsNullOrEmpty()
            ? (T) typeof(T).GetDefaultValue()
            : XmlSerializer.Unpack<T>(stream);
        
    public static object Unpack(Type type, Stream stream) =>
        stream.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : XmlSerializer.Unpack(type, stream);
}