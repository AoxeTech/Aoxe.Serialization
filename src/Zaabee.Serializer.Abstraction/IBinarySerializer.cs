namespace Zaabee.Serializer.Abstraction
{
    public interface IBinarySerializer
    {
        byte[] SerializeToBytes<T>(T t);
        T DeserializeFromBytes<T>(byte[] bytes);
    }
}