namespace Zaabee.Serializer.Abstractions
{
    public interface IBytesSerializer : IStreamSerializer
    {
        byte[] SerializeToBytes<T>(T t);
        T DeserializeFromBytes<T>(byte[] bytes);
    }
}