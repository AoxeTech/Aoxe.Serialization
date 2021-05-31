namespace Zaabee.Serializer.Abstractions
{
    public interface ITextSerializer : ISerializer
    {
        string SerializeToString<T>(T t);
        T DeserializeFromString<T>(string text);
    }
}