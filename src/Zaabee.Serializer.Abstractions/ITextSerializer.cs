using System;

namespace Zaabee.Serializer.Abstractions
{
    public interface ITextSerializer : IBytesSerializer
    {
        string SerializeToString<T>(T t);
        T DeserializeFromString<T>(string text);
        string SerializeToString(Type type, object obj);
        object DeserializeFromString(Type type, string text);
    }
}