using System;

namespace Zaabee.Serializer.Abstractions
{
    public interface IBytesSerializer : IStreamSerializer
    {
        byte[] SerializeToBytes<T>(T t);
        T DeserializeFromBytes<T>(byte[] bytes);
        byte[] SerializeToBytes(Type type, object obj);
        object DeserializeFromBytes(Type type, byte[] bytes);
    }
}