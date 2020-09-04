using System;
using System.IO;
using System.Text;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        private static Encoding _encoding = Encoding.UTF8;

        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        public static Options DefaultOptions { get; set; }

        #region Bytes

        public static byte[] Serialize<T>(T t, Options options = null) =>
            t is null
                ? new byte[0]
                : JilSerializer.Serialize(t, options ?? DefaultOptions, DefaultEncoding);

        public static byte[] Serialize(object obj, Options options = null) =>
            obj is null
                ? new byte[0]
                : JilSerializer.Serialize(obj, options ?? DefaultOptions, DefaultEncoding);

        public static T Deserialize<T>(byte[] bytes, Options options = null) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : JilSerializer.Deserialize<T>(bytes, options ?? DefaultOptions, DefaultEncoding);

        public static object Deserialize(Type type, byte[] bytes, Options options = null) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : JilSerializer.Deserialize(type, bytes, options ?? DefaultOptions, DefaultEncoding);

        #endregion

        #region Stream

        public static MemoryStream Pack<T>(T t, Options options = null) =>
            t is null
                ? new MemoryStream()
                : JilSerializer.Pack(t, options ?? DefaultOptions, DefaultEncoding);

        public static void Pack<T>(T t, Stream stream, Options options = null)
        {
            if (t is null || stream is null) return;
            JilSerializer.Pack(t, stream, options ?? DefaultOptions, DefaultEncoding);
        }

        public static MemoryStream Pack(object obj, Options options = null) =>
            obj is null
                ? new MemoryStream()
                : JilSerializer.Pack(obj, options ?? DefaultOptions, DefaultEncoding);

        public static void Pack(object obj, Stream stream, Options options = null)
        {
            if (obj is null || stream is null) return;
            JilSerializer.Pack(obj, stream, options ?? DefaultOptions, DefaultEncoding);
        }

        public static T Unpack<T>(Stream stream, Options options = null) =>
            stream is null
                ? (T) typeof(T).GetDefaultValue()
                : JilSerializer.Unpack<T>(stream, options ?? DefaultOptions, DefaultEncoding);

        public static object Unpack(Type type, Stream stream, Options options = null) =>
            stream is null
                ? type.GetDefaultValue()
                : JilSerializer.Unpack(type, stream, options ?? DefaultOptions, DefaultEncoding);

        #endregion

        #region Text

        public static string SerializeToJson<T>(T t, Options options = null) =>
            JilSerializer.SerializeToJson(t, options ?? DefaultOptions);

        public static T Deserialize<T>(string json, Options options = null) =>
            json.IsNullOrWhiteSpace()
                ? (T) typeof(T).GetDefaultValue()
                : JilSerializer.Deserialize<T>(json, options ?? DefaultOptions);

        public static string SerializeToJson(object obj, Options options = null) =>
            JilSerializer.SerializeToJson(obj, options ?? DefaultOptions);

        public static object Deserialize(Type type, string json, Options options = null) =>
            json.IsNullOrWhiteSpace()
                ? type.GetDefaultValue()
                : JilSerializer.Deserialize(type, json, options ?? DefaultOptions);

        #endregion

        #region TextWriter/TextReader

        public static void Serialize<T>(T t, TextWriter output, Options options = null)
        {
            if (t is null || output is null) return;
            JilSerializer.Serialize(t, output, options ?? DefaultOptions);
        }

        public static void Serialize(object obj, TextWriter output, Options options = null)
        {
            if (obj is null || output is null) return;
            JilSerializer.Serialize(obj, output, options ?? DefaultOptions);
        }

        public static T Deserialize<T>(TextReader reader, Options options = null) =>
            reader is null
                ? (T) typeof(T).GetDefaultValue()
                : JilSerializer.Deserialize<T>(reader, options ?? DefaultOptions);

        public static object Deserialize(Type type, TextReader reader, Options options = null) =>
            reader is null
                ? type.GetDefaultValue()
                : JilSerializer.Deserialize(type, reader, options ?? DefaultOptions);

        #endregion
    }
}