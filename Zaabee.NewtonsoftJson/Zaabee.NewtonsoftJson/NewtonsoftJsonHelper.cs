using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        private static Encoding _encoding = Encoding.UTF8;

        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        public static JsonSerializerSettings DefaultSettings;

        public static byte[] Serialize(object obj, JsonSerializerSettings settings = null) =>
            obj == null
                ? new byte[0]
                : DefaultEncoding.GetBytes(SerializeToJson(obj, settings));

        public static Stream Pack(object obj, JsonSerializerSettings settings = null)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            Pack(obj, ms, settings);
            return ms;
        }

        public static void Pack(object obj, Stream stream, JsonSerializerSettings settings = null)
        {
            if (obj is null) return;
            var bytes = Serialize(obj, settings);
            stream.Write(bytes, 0, bytes.Length);
        }

        public static string SerializeToJson(object obj, JsonSerializerSettings settings = null) =>
            obj == null ? string.Empty : JsonConvert.SerializeObject(obj, settings ?? DefaultSettings);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerSettings settings = null) =>
            (T) Deserialize(typeof(T), bytes, settings);

        public static T Unpack<T>(Stream stream, JsonSerializerSettings settings = null) =>
            (T) Unpack(typeof(T), stream, settings);

        public static T Deserialize<T>(string json, JsonSerializerSettings settings = null) =>
            (T) Deserialize(typeof(T), json, settings);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerSettings settings = null) =>
            bytes == null || bytes.Length == 0
                ? default(Type)
                : Deserialize(type, DefaultEncoding.GetString(bytes), settings);

        public static object Unpack(Type type, Stream stream, JsonSerializerSettings settings = null) =>
            stream == null
                ? default(Type)
                : Deserialize(type, DefaultEncoding.GetString(StreamToBytes(stream)), settings);

        public static object Deserialize(Type type, string json, JsonSerializerSettings settings = null) =>
            string.IsNullOrWhiteSpace(json)
                ? default(Type)
                : JsonConvert.DeserializeObject(json, type, settings ?? DefaultSettings);

        private static byte[] StreamToBytes(Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.Position > 0 && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}