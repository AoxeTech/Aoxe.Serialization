using System.IO;

namespace Zaabee.Serializer.Abstraction
{
    public interface IStreamSerializer
    {
        Stream SerializeToStream<T>(T t);
        T DeserializeFromStream<T>(Stream stream);
    }
}