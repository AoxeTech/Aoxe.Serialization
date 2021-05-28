using System.IO;
using System.Text;
using Jil;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Jil
{
    public class Serializer : ISerializer
    {
        private readonly Options _options;
        private readonly Encoding _encoding;

        public Serializer(Options options = null, Encoding encoding = null) =>
            (_options, _encoding) = (options, encoding ?? JilHelper.DefaultEncoding);

        public byte[] SerializeToBytes<T>(T t) =>
            JilSerializer.Serialize(t, _options, _encoding);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            JilSerializer.Deserialize<T>(bytes, _options, _encoding);

        public string BytesToString(byte[] bytes) =>
            _encoding.GetString(bytes);

        public string SerializeToString<T>(T t) =>
            JilSerializer.SerializeToJson(t, _options);

        public T DeserializeFromString<T>(string text) =>
            JilSerializer.Deserialize<T>(text, _options);

        public byte[] StringToBytes(string text) =>
            _encoding.GetBytes(text);

        public Stream SerializeToStream<T>(T t) =>
            JilSerializer.Pack(t, _options, _encoding);

        public T DeserializeFromStream<T>(Stream stream) =>
            JilSerializer.Unpack<T>(stream, _options, _encoding);
    }
}