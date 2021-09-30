using System;
using System.IO;

namespace Zaabee.Serializer.Abstractions
{
    public interface IStreamSerializer
    {
        Stream SerializeToStream<T>(T t);
        T DeserializeFromStream<T>(Stream stream);
        Stream SerializeToStream(Type type, object obj);
        object DeserializeFromStream(Type type, Stream stream);
    }
}