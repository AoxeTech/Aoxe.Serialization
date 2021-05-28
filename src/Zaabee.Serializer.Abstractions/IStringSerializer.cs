namespace Zaabee.Serializer.Abstractions
{
    public interface IStringSerializer
    {
        string SerializeToString<T>(T t);
        T DeserializeFromString<T>(string text);
    }
}