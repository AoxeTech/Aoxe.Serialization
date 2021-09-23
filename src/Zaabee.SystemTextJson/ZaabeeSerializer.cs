using System.IO;
using System.Text.Json;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.SystemTextJson
{
    public class ZaabeeSerializer : ITextSerializer
    {
        private readonly JsonSerializerOptions _options;

        public ZaabeeSerializer(JsonSerializerOptions options = null) =>
            _options = options;

        public byte[] SerializeToBytes<T>(T t) =>
            SystemTextJsonSerializer.Serialize(t, _options);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            SystemTextJsonSerializer.Deserialize<T>(bytes, _options);

        public string SerializeToString<T>(T t) =>
            SystemTextJsonSerializer.SerializeToJson(t, _options);

        public T DeserializeFromString<T>(string text) =>
            SystemTextJsonSerializer.Deserialize<T>(text, _options);

        public Stream SerializeToStream<T>(T t) =>
            SystemTextJsonSerializer.Pack(t, _options);

        public T DeserializeFromStream<T>(Stream stream) =>
            SystemTextJsonSerializer.Unpack<T>(stream, _options);
    }
}