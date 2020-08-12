using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static class NewtonsoftJsonSerializer
    {
        #region Bytes

        public static byte[] Serialize(object obj, JsonSerializerSettings settings, Encoding encoding) =>
            obj is null
                ? new byte[0]
                : encoding.GetBytes(SerializeToJson(obj, settings));

        public static T Deserialize<T>(byte[] bytes, JsonSerializerSettings settings, Encoding encoding) =>
            bytes.IsNullOrEmpty() ? default : (T) Deserialize(typeof(T), bytes, settings, encoding);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerSettings settings, Encoding encoding) =>
            bytes.IsNullOrEmpty() ? type.GetDefaultValue() : Deserialize(type, encoding.GetString(bytes), settings);

        #endregion

        #region Stream

        public static MemoryStream Pack(object obj, JsonSerializerSettings settings, Encoding encoding)
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

        public static T Unpack<T>(Stream stream, JsonSerializerSettings settings, Encoding encoding) =>
            (T) Unpack(typeof(T), stream, settings, encoding);

        public static object Unpack(Type type, Stream stream, JsonSerializerSettings settings, Encoding encoding) =>
            stream is null
                ? type.GetDefaultValue()
                : Deserialize(type, encoding.GetString(stream.ReadToEnd()), settings);

        public static async Task<MemoryStream> PackAsync(object obj, JsonSerializerSettings settings, Encoding encoding)
        {
            var ms = new MemoryStream();
            var bytes = Serialize(obj, settings, encoding);
            await ms.WriteAsync(bytes, 0, bytes.Length);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static async Task PackAsync(object obj, Stream stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            if (obj is null) return;
            var bytes = Serialize(obj, settings, encoding);
            await stream.WriteAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
        }

        #endregion

        #region Json

        public static string SerializeToJson(object obj, JsonSerializerSettings settings) =>
            obj is null ? string.Empty : JsonConvert.SerializeObject(obj, settings);

        public static T Deserialize<T>(string json, JsonSerializerSettings settings) =>
            string.IsNullOrWhiteSpace(json)
                ? default
                : JsonConvert.DeserializeObject<T>(json, settings);

        public static object Deserialize(Type type, string json, JsonSerializerSettings settings) =>
            string.IsNullOrWhiteSpace(json)
                ? type.GetDefaultValue()
                : JsonConvert.DeserializeObject(json, type, settings);

        #endregion
    }
}