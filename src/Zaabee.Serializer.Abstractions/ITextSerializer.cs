namespace Zaabee.Serializer.Abstractions
{
    public interface ITextSerializer : IBytesSerializer
    {
        string SerializeToString<T>(T t);
        T DeserializeFromString<T>(string text);
    }
}