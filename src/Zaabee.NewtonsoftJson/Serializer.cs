using System.IO;
using System.Text;
using Newtonsoft.Json;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.NewtonsoftJson
{
    public class Serializer : ITextSerializer
    {
        private readonly JsonSerializerSettings _settings;
        private readonly Encoding _encoding;

        public Serializer(JsonSerializerSettings settings = null, Encoding encoding = null) =>
            (_settings, _encoding) = (settings, encoding ?? NewtonsoftJsonHelper.DefaultEncoding);

        public byte[] SerializeToBytes<T>(T t) =>
            NewtonsoftJsonSerializer.Serialize(t, _settings, _encoding);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            NewtonsoftJsonSerializer.Deserialize<T>(bytes, _settings, _encoding);

        public string SerializeToString<T>(T t) =>
            NewtonsoftJsonSerializer.SerializeToJson(t, _settings);

        public T DeserializeFromString<T>(string text) =>
            NewtonsoftJsonSerializer.Deserialize<T>(text, _settings);

        public Stream SerializeToStream<T>(T t) =>
            NewtonsoftJsonSerializer.Pack(t, _settings, _encoding);

        public T DeserializeFromStream<T>(Stream stream) =>
            NewtonsoftJsonSerializer.Unpack<T>(stream, _settings, _encoding);
    }
}