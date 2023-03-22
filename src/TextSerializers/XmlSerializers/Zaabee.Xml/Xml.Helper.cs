namespace Zaabee.Xml;

public static partial class XmlHelper
{
    private static readonly ConcurrentDictionary<Type, System.Xml.Serialization.XmlSerializer> SerializerCache =
        new();

    private static System.Xml.Serialization.XmlSerializer GetSerializer(Type type) =>
        SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
}