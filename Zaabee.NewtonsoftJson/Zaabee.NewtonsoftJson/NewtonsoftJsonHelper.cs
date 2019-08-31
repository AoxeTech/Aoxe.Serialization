using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class NewtonsoftJsonHelper
    {
        private static readonly Encoding DefaultEncoding = Encoding.UTF8;
        public static JsonSerializerSettings DefaultSettings;
        public static Formatting? DefaultFormatting;

        public static byte[] Serialize(object obj, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            obj == null ? new byte[0] : DefaultEncoding.GetBytes(SerializeToJson(obj, settings, formatting));

        public static Stream Pack(object obj, JsonSerializerSettings settings = null,
            Formatting? formatting = null)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            Pack(obj, ms, settings, formatting);
            return ms;
        }

        public static void Pack(object obj, Stream stream, JsonSerializerSettings settings = null,
            Formatting? formatting = null)
        {
            if (obj is null) return;
            var bytes = Serialize(obj, settings, formatting);
            stream.Write(bytes, 0, bytes.Length);
        }

        public static string SerializeToJson(object obj, JsonSerializerSettings settings = null,
            Formatting? formatting = null)
        {
            settings = settings ?? DefaultSettings;
            if (settings != null)
                settings.Formatting = formatting ?? (DefaultFormatting ?? Formatting.None);
            return JsonConvert.SerializeObject(obj, settings ?? DefaultSettings);
        }

        public static T Deserialize<T>(byte[] bytes, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            (T) Deserialize(typeof(T), bytes, settings, formatting);

        public static T Unpack<T>(Stream stream, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            (T) Unpack(typeof(T), stream, settings, formatting);

        public static T Deserialize<T>(string json, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            (T) Deserialize(typeof(T), json, settings, formatting);


        public static object Deserialize(Type type, byte[] bytes, JsonSerializerSettings settings = null,
            Formatting? formatting = null)
        {
            if (bytes == null || bytes.Length == 0) return default(Type);
            var json = DefaultEncoding.GetString(bytes);
            return Deserialize(type, json, settings, formatting);
        }

        public static object Unpack(Type type, Stream stream, JsonSerializerSettings settings = null,
            Formatting? formatting = null)
        {
            if (stream == null) return default(Type);
            var bytes = StreamToBytes(stream);
            return Deserialize(type, DefaultEncoding.GetString(bytes), settings, formatting);
        }

        public static object Deserialize(Type type, string json, JsonSerializerSettings settings = null,
            Formatting? formatting = null)
        {
            if (string.IsNullOrWhiteSpace(json)) return default(Type);
            settings = settings ?? DefaultSettings;
            if (settings != null)
                settings.Formatting = formatting ?? (DefaultFormatting ?? Formatting.None);
            return JsonConvert.DeserializeObject(json, type, settings);
        }

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