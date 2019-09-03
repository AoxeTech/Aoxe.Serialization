using System;
using System.IO;
using System.Text;
using Swifter.Json;

namespace Zaabee.SwifterJson
{
    public static class SwifterJsonHelper
    {
        private static Encoding _encoding = Encoding.UTF8;

        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        public static string SerializeToJson<T>(T o) =>
            JsonFormatter.SerializeObject(o);

        public static T Deserialize<T>(string json) =>
            string.IsNullOrWhiteSpace(json) ? default(T) : JsonFormatter.DeserializeObject<T>(json);

        public static object Deserialize(Type type, string json) =>
            string.IsNullOrWhiteSpace(json) ? default(Type) : JsonFormatter.DeserializeObject(json, type);

        public static byte[] Serialize<T>(T o, Encoding encoding = null) =>
            JsonFormatter.SerializeObject(o, encoding ?? DefaultEncoding);

        public static T Deserialize<T>(byte[] bytes, Encoding encoding = null) =>
            bytes == null
                ? default(T)
                : JsonFormatter.DeserializeObject<T>((encoding ?? DefaultEncoding).GetString(bytes));

        public static object Deserialize(Type type, byte[] bytes, Encoding encoding = null) =>
            bytes == null
                ? default(Type)
                : JsonFormatter.DeserializeObject((encoding ?? DefaultEncoding).GetString(bytes), type);

        public static Stream Pack<T>(T value, Encoding encoding = null)
        {
            var ms = new MemoryStream();
            Pack(value, ms, encoding);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack<T>(T value, Stream stream, Encoding encoding = null) =>
            JsonFormatter.SerializeObject(value, stream, encoding ?? DefaultEncoding);

        public static T Unpack<T>(Stream stream, Encoding encoding = null) =>
            JsonFormatter.DeserializeObject<T>(stream, encoding ?? DefaultEncoding);

        public static object Unpack(Type type, Stream stream, Encoding encoding = null) =>
            JsonFormatter.DeserializeObject(stream, encoding ?? DefaultEncoding, type);
    }
}