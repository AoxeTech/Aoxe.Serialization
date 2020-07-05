using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static class JilSerializer
    {
        #region Bytes

        public static byte[] Serialize<T>(T t, Options options, Encoding encoding) =>
            encoding.GetBytes(SerializeToJson(t, options));

        public static byte[] Serialize(object obj, Options options, Encoding encoding) =>
            encoding.GetBytes(SerializeToJson(obj, options));

        public static T Deserialize<T>(byte[] bytes, Options options, Encoding encoding) =>
            Deserialize<T>(encoding.GetString(bytes), options);

        public static object Deserialize(Type type, byte[] bytes, Options options, Encoding encoding) =>
            Deserialize(type, encoding.GetString(bytes), options);

        #endregion

        #region Stream

        public static MemoryStream Pack<T>(T t, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(t, ms, options, encoding);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream, Options options, Encoding encoding)
        {
            var bytes = Serialize(t, options, encoding);
            stream.Write(bytes, 0, bytes.Length);
        }

        public static MemoryStream Pack(object obj, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(obj, ms, options, encoding);
            return ms;
        }

        public static void Pack(object obj, Stream stream, Options options, Encoding encoding)
        {
            var bytes = Serialize(obj, options, encoding);
            stream.Write(bytes, 0, bytes.Length);
        }

        public static T Unpack<T>(Stream stream, Options options, Encoding encoding) =>
            Deserialize<T>(encoding.GetString(stream.ReadToEnd()), options);

        public static object Unpack(Type type, Stream stream, Options options, Encoding encoding) =>
            Deserialize(type, encoding.GetString(stream.ReadToEnd()), options);

        #endregion

        #region StreamAsync

        public static async Task<MemoryStream> PackAsync<T>(T t, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            var bytes = Serialize(t, options, encoding);
            await ms.WriteAsync(bytes, 0, bytes.Length);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static async Task PackAsync<T>(T t, Stream stream, Options options, Encoding encoding)
        {
            var bytes = Serialize(t, options, encoding);
            await stream.WriteAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
        }

        public static async Task<MemoryStream> PackAsync(object obj, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            var bytes = Serialize(obj, options, encoding);
            await ms.WriteAsync(bytes, 0, bytes.Length);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static async Task PackAsync(object obj, Stream stream, Options options, Encoding encoding)
        {
            var bytes = Serialize(obj, options, encoding);
            await stream.WriteAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
        }

        #endregion

        #region Text

        public static string SerializeToJson<T>(T t, Options options) =>
            JSON.Serialize(t, options);

        public static string SerializeToJson(object obj, Options options) =>
            JSON.SerializeDynamic(obj, options);

        public static T Deserialize<T>(string json, Options options) =>
            JSON.Deserialize<T>(json, options);

        public static object Deserialize(Type type, string json, Options options) =>
            JSON.Deserialize(json, type, options);

        #endregion

        #region TextWriter/TextReader

        public static void Serialize<T>(T t, TextWriter output, Options options) =>
            JSON.Serialize(t, output, options);

        public static void Serialize(object obj, TextWriter output, Options options) =>
            JSON.SerializeDynamic(obj, output, options);

        public static T Deserialize<T>(TextReader reader, Options options) =>
            JSON.Deserialize<T>(reader, options);

        public static object Deserialize(Type type, TextReader reader, Options options) =>
            JSON.Deserialize(reader, type, options);

        #endregion
    }
}