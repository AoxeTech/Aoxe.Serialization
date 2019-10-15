using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zaabee.Xml
{
    public static partial class XmlHelper
    {
        public static async Task<byte[]> SerializeAsync<T>(T t) => await SerializeAsync(typeof(T), t);

        public static async Task<Stream> PackAsync<T>(T t) => await PackAsync(typeof(T), t);

        public static async Task PackAsync<T>(T t, Stream stream) =>
            await PackAsync(typeof(T), t, stream);

        public static async Task<string> SerializeToXmlAsync<T>(T t, Encoding encoding = null) =>
            await SerializeToXmlAsync(typeof(T), t, encoding);

        public static async Task<byte[]> SerializeAsync(Type type, object obj)
        {
            if (obj is null) return new byte[0];
            using (var stream = await PackAsync(type, obj))
                return await StreamToBytesAsync(stream);
        }

        public static async Task<Stream> PackAsync(Type type, object obj)
        {
            if (obj is null) return new MemoryStream();
            var ms = new MemoryStream();
            await PackAsync(type, obj, ms);
            return ms;
        }

        public static async Task PackAsync(Type type, object obj, Stream stream)
        {
            if (obj is null) return;
            var serializer = new XmlSerializer(type);
            await Task.Run(() => serializer.Serialize(stream, obj));
        }

        public static async Task<string> SerializeToXmlAsync(Type type, object obj, Encoding encoding = null)
        {
            if (obj is null) return string.Empty;
            encoding = encoding ?? DefaultEncoding;
            using (var stream =await PackAsync(type, obj))
                return encoding.GetString(await StreamToBytesAsync(stream));
        }

        public static async Task<T> DeserializeAsync<T>(byte[] bytes) =>
            (T) await DeserializeAsync(typeof(T), bytes);

        public static async Task<T> UnpackAsync<T>(Stream stream) => (T) await UnpackAsync(typeof(T), stream);

        public static async Task<T> DeserializeAsync<T>(string xml, Encoding encoding = null) =>
            (T) await DeserializeAsync(typeof(T), xml, encoding);

        public static async Task<object> DeserializeAsync(Type type, byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0) return default(Type);
            var xmlSerializer = new XmlSerializer(type);
            using (var ms = new MemoryStream(bytes))
                return await Task.Run(() => xmlSerializer.Deserialize(ms));
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream)
        {
            if (stream is null || stream.Length == 0) return default(Type);
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            var xmlSerializer = new XmlSerializer(type);
            return await Task.Run(() => xmlSerializer.Deserialize(stream));
        }

        public static async Task<object> DeserializeAsync(Type type, string xml, Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(xml)) return default(Type);
            encoding = encoding ?? DefaultEncoding;
            var xmlSerializer = new XmlSerializer(type);
            using (var ms = new MemoryStream(encoding.GetBytes(xml)))
                return await Task.Run(() => xmlSerializer.Deserialize(ms));
        }

        private static async Task<byte[]> StreamToBytesAsync(Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.Position > 0 && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            await stream.ReadAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}