namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static byte[] Serialize<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : XmlSerializer.Serialize(value);

    public static byte[] Serialize(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : XmlSerializer.Serialize(type, value);

    public static TValue? Deserialize<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : XmlSerializer.Deserialize<TValue>(bytes!);

    public static object? Deserialize(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : XmlSerializer.Deserialize(type, bytes!);
}