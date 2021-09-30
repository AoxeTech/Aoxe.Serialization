using System;
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

        public byte[] SerializeToBytes(Type type, object obj) =>
            SystemTextJsonSerializer.Serialize(type, obj, _options);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            SystemTextJsonSerializer.Deserialize<T>(bytes, _options);

        public object DeserializeFromBytes(Type type, byte[] bytes) =>
            SystemTextJsonSerializer.Deserialize(type, bytes, _options);

        public string SerializeToString<T>(T t) =>
            SystemTextJsonSerializer.SerializeToJson(t, _options);

        public string SerializeToString(Type type, object obj) =>
            SystemTextJsonSerializer.SerializeToJson(type, obj, _options);

        public T DeserializeFromString<T>(string text) =>
            SystemTextJsonSerializer.Deserialize<T>(text, _options);

        public object DeserializeFromString(Type type, string text) =>
            SystemTextJsonSerializer.Deserialize(type, text, _options);

        public Stream SerializeToStream<T>(T t) =>
            SystemTextJsonSerializer.Pack(t, _options);

        public Stream SerializeToStream(Type type, object obj) =>
            SystemTextJsonSerializer.Pack(type, obj, _options);

        public T DeserializeFromStream<T>(Stream stream) =>
            SystemTextJsonSerializer.Unpack<T>(stream, _options);

        public object DeserializeFromStream(Type type, Stream stream) =>
            SystemTextJsonSerializer.Unpack(type, stream, _options);
    }
}