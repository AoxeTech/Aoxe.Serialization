namespace Zaabee.Serializer.Abstractions
{
    public interface IBytesSerializer
    {
        byte[] SerializeToBytes<T>(T t);
        T DeserializeFromBytes<T>(byte[] bytes);
    }
}