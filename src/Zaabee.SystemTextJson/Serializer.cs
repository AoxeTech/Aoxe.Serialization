using System.IO;
using System.Text;
using System.Text.Json;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.SystemTextJson
{
    public class Serializer : ISerializer
    {
        private readonly JsonSerializerOptions _options;

        public Serializer(JsonSerializerOptions options = null) =>
            _options = options;

        public byte[] SerializeToBytes<T>(T t) =>
            SystemTextJsonSerializer.Serialize(t, _options);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            SystemTextJsonSerializer.Deserialize<T>(bytes, _options);

        public string BytesToString(byte[] bytes) =>
            Encoding.UTF8.GetString(bytes);

        public string SerializeToString<T>(T t) =>
            SystemTextJsonSerializer.SerializeToJson(t, _options);

        public T DeserializeFromString<T>(string text) =>
            SystemTextJsonSerializer.Deserialize<T>(text, _options);

        public byte[] StringToBytes(string text) =>
            Encoding.UTF8.GetBytes(text);

        public Stream SerializeToStream<T>(T t) =>
            SystemTextJsonSerializer.Pack(t, _options);

        public T DeserializeFromStream<T>(Stream stream) =>
            SystemTextJsonSerializer.Unpack<T>(stream, _options);
    }
}