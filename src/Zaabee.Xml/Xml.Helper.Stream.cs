namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static void Pack<TValue>(TValue value, Stream? stream)
    {
        if (value is null || stream is null) return;
        XmlSerializer.Pack(value, stream);
    }

    public static void Pack(Type type, object? value, Stream? stream)
    {
        if (type is null || value is null || stream is null) return;
        XmlSerializer.Pack(type, value, stream);
    }
        
    public static Stream Pack<TValue>(TValue value) =>
        value is null ? Stream.Null : XmlSerializer.Pack(value);
        
    public static Stream Pack(Type type, object? value) =>
        value is null ? Stream.Null : XmlSerializer.Pack(type, value);
        
    public static TValue? Unpack<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : XmlSerializer.Unpack<TValue>(stream);
        
    public static object? Unpack(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : XmlSerializer.Unpack(type, stream);
}