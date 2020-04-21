using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class NewtonsoftJsonSerializer
    {
        #region Sync

        public static byte[] Serialize(object obj, JsonSerializerSettings settings, Encoding encoding) =>
            obj is null
                ? new byte[0]
                : encoding.GetBytes(SerializeToJson(obj, settings));

        public static Stream Pack(object obj, JsonSerializerSettings settings, Encoding encoding)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            Pack(obj, ms, settings, encoding);
            return ms;
        }

        public static void Pack(object obj, Stream stream, JsonSerializerSettings settings, Encoding encoding)
        {
            if (obj is null) return;
            var bytes = Serialize(obj, settings, encoding);
            stream.Write(bytes, 0, bytes.Length);
        }

        public static string SerializeToJson(object obj, JsonSerializerSettings settings) =>
            obj is null ? string.Empty : JsonConvert.SerializeObject(obj, settings);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerSettings settings, Encoding encoding) =>
            (T) Deserialize(typeof(T), bytes, settings, encoding);

        public static T Unpack<T>(Stream stream, JsonSerializerSettings settings, Encoding encoding) =>
            (T) Unpack(typeof(T), stream, settings, encoding);

        public static T Deserialize<T>(string json, JsonSerializerSettings settings) =>
            (T) Deserialize(typeof(T), json, settings);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerSettings settings, Encoding encoding) =>
            bytes is null || bytes.Length == 0
                ? default(Type)
                : Deserialize(type, encoding.GetString(bytes), settings);

        public static object Unpack(Type type, Stream stream, JsonSerializerSettings settings, Encoding encoding) =>
            stream is null
                ? default(Type)
                : Deserialize(type, encoding.GetString(ReadToEnd(stream)), settings);

        public static object Deserialize(Type type, string json, JsonSerializerSettings settings) =>
            string.IsNullOrWhiteSpace(json)
                ? default(Type)
                : JsonConvert.DeserializeObject(json, type, settings);

        #endregion

        #region Async

        public static async Task PackAsync(object obj, Stream stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            if (obj is null) return;
            var bytes = Serialize(obj, settings, encoding);
            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        #endregion
        
        private static byte[] ReadToEnd(this Stream stream)
        {
            if (stream is MemoryStream ms) return ms.ToArray();
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}