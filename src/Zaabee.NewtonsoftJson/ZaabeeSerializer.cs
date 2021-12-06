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

        public byte[] SerializeToBytes<TValue>(TValue value) =>
            NewtonsoftJsonSerializer.Serialize(value, _settings, _encoding);

        public byte[] SerializeToBytes(Type type, object? value) =>
            NewtonsoftJsonSerializer.Serialize(type, value, _settings, _encoding);

        public TValue DeserializeFromBytes<TValue>(byte[] bytes) =>
            NewtonsoftJsonSerializer.Deserialize<TValue>(bytes, _settings, _encoding);

        public object DeserializeFromBytes(Type type, byte[] bytes) =>
            NewtonsoftJsonSerializer.Deserialize(type, bytes, _settings, _encoding);

        public string SerializeToString<TValue>(TValue value) =>
            NewtonsoftJsonSerializer.SerializeToJson(value, _settings);

        public string SerializeToString(Type type, object? value) =>
            NewtonsoftJsonSerializer.SerializeToJson(type, value, _settings);

        public TValue DeserializeFromString<TValue>(string text) =>
            NewtonsoftJsonSerializer.Deserialize<TValue>(text, _settings);

        public object DeserializeFromString(Type type, string text) =>
            NewtonsoftJsonSerializer.Deserialize(type, text, _settings);

        public Stream? SerializeToStream<TValue>(TValue value) =>
            NewtonsoftJsonSerializer.Pack(value, _settings, _encoding);

        public Stream? SerializeToStream(Type type, object? value) =>
            NewtonsoftJsonSerializer.Pack(type, value, _settings, _encoding);

        public TValue DeserializeFromStream<TValue>(Stream? stream) =>
            NewtonsoftJsonSerializer.Unpack<TValue>(stream, _settings, _encoding);

        public object DeserializeFromStream(Type type, Stream? stream) =>
            NewtonsoftJsonSerializer.Unpack(type, stream, _settings, _encoding);
    }
}