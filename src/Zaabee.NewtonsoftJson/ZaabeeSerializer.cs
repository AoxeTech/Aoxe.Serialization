using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.NewtonsoftJson
{
    public class ZaabeeSerializer : ITextSerializer
    {
        private readonly JsonSerializerSettings _settings;
        private readonly Encoding _encoding;

        public ZaabeeSerializer(JsonSerializerSettings settings = null, Encoding encoding = null) =>
            (_settings, _encoding) = (settings, encoding ?? NewtonsoftJsonHelper.DefaultEncoding);

        public byte[] SerializeToBytes<T>(T t) =>
            NewtonsoftJsonSerializer.Serialize(t, _settings, _encoding);

        public byte[] SerializeToBytes(Type type, object obj) =>
            NewtonsoftJsonSerializer.Serialize(type, obj, _settings, _encoding);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            NewtonsoftJsonSerializer.Deserialize<T>(bytes, _settings, _encoding);

        public object DeserializeFromBytes(Type type, byte[] bytes) =>
            NewtonsoftJsonSerializer.Deserialize(type, bytes, _settings, _encoding);

        public string SerializeToString<T>(T t) =>
            NewtonsoftJsonSerializer.SerializeToJson(t, _settings);

        public string SerializeToString(Type type, object obj) =>
            NewtonsoftJsonSerializer.SerializeToJson(type, obj, _settings);

        public T DeserializeFromString<T>(string text) =>
            NewtonsoftJsonSerializer.Deserialize<T>(text, _settings);

        public object DeserializeFromString(Type type, string text) =>
            NewtonsoftJsonSerializer.Deserialize(type, text, _settings);

        public Stream SerializeToStream<T>(T t) =>
            NewtonsoftJsonSerializer.Pack(t, _settings, _encoding);

        public Stream SerializeToStream(Type type, object obj) =>
            NewtonsoftJsonSerializer.Pack(type, obj, _settings, _encoding);

        public T DeserializeFromStream<T>(Stream stream) =>
            NewtonsoftJsonSerializer.Unpack<T>(stream, _settings, _encoding);

        public object DeserializeFromStream(Type type, Stream stream) =>
            NewtonsoftJsonSerializer.Unpack(type, stream, _settings, _encoding);
    }
}