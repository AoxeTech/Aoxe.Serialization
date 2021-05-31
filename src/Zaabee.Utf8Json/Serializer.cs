using System.IO;
using Utf8Json;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Utf8Json
{
    public class Serializer : ITextSerializer
    {
        private readonly IJsonFormatterResolver _resolver;

        public Serializer(IJsonFormatterResolver resolver = null) =>
            _resolver = resolver;

        public byte[] SerializeToBytes<T>(T t) =>
            Utf8JsonSerializer.Serialize(t, _resolver);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            Utf8JsonSerializer.Deserialize<T>(bytes, _resolver);

        public string SerializeToString<T>(T t) =>
            Utf8JsonSerializer.SerializeToJson(t, _resolver);

        public T DeserializeFromString<T>(string text) =>
            Utf8JsonSerializer.Deserialize<T>(text, _resolver);

        public Stream SerializeToStream<T>(T t) =>
            Utf8JsonSerializer.Pack(t, _resolver);

        public T DeserializeFromStream<T>(Stream stream) =>
            Utf8JsonSerializer.Unpack<T>(stream, _resolver);
    }
}