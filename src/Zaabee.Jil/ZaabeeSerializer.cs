using System;
using System.IO;
using System.Text;
using Jil;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Jil
{
    public class ZaabeeSerializer : ITextSerializer
    {
        private readonly Options _options;
        private readonly Encoding _encoding;

        public ZaabeeSerializer(Options options = null, Encoding encoding = null) =>
            (_options, _encoding) = (options, encoding ?? JilHelper.DefaultEncoding);

        public byte[] SerializeToBytes<T>(T t) =>
            JilSerializer.Serialize(t, _options, _encoding);

        public byte[] SerializeToBytes(Type type, object obj) =>
            JilSerializer.Serialize(obj, _options, _encoding);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            JilSerializer.Deserialize<T>(bytes, _options, _encoding);

        public object DeserializeFromBytes(Type type, byte[] bytes) =>
            JilSerializer.Deserialize(type, bytes, _options, _encoding);

        public string SerializeToString<T>(T t) =>
            JilSerializer.SerializeToJson(t, _options);

        public string SerializeToString(Type type, object obj) =>
            JilSerializer.SerializeToJson(obj, _options);

        public T DeserializeFromString<T>(string text) =>
            JilSerializer.Deserialize<T>(text, _options);

        public object DeserializeFromString(Type type, string text) =>
            JilSerializer.Deserialize(type, text, _options);

        public Stream SerializeToStream<T>(T t) =>
            JilSerializer.Pack(t, _options, _encoding);

        public Stream SerializeToStream(Type type, object obj) =>
            JilSerializer.Pack(obj, _options, _encoding);

        public T DeserializeFromStream<T>(Stream stream) =>
            JilSerializer.Unpack<T>(stream, _options, _encoding);

        public object DeserializeFromStream(Type type, Stream stream) =>
            JilSerializer.Unpack(type, stream, _options, _encoding);
    }
}