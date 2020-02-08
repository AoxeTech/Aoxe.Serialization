using System;
using System.IO;
using System.Text;
using Jil;

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

        public static Options DefaultOptions;

        public static byte[] Serialize<T>(T t, Options options = null) =>
            JilSerializer.Serialize(t, options ?? DefaultOptions, DefaultEncoding);

        public static Stream Pack<T>(T t, Options options = null) =>
            JilSerializer.Pack(t, options ?? DefaultOptions, DefaultEncoding);

        public static void Pack<T>(T t, Stream stream, Options options = null) =>
            JilSerializer.Pack(t, stream, options ?? DefaultOptions, DefaultEncoding);

        public static string SerializeToJson<T>(T t, Options options = null) =>
            JilSerializer.SerializeToJson(t, options ?? DefaultOptions);

        public static void Serialize<T>(T t, TextWriter output, Options options = null) =>
            JilSerializer.Serialize(t, output, options ?? DefaultOptions);

        public static void Serialize(object obj, TextWriter output, Options options = null) =>
            JilSerializer.Serialize(obj, output, options ?? DefaultOptions);

        public static T Deserialize<T>(byte[] bytes, Options options = null) =>
            JilSerializer.Deserialize<T>(bytes, options ?? DefaultOptions, DefaultEncoding);

        public static T Unpack<T>(Stream stream, Options options = null) =>
            JilSerializer.Unpack<T>(stream, options ?? DefaultOptions, DefaultEncoding);

        public static T Deserialize<T>(string json, Options options = null) =>
            JilSerializer.Deserialize<T>(json, options ?? DefaultOptions);

        public static string SerializeToJson(object obj, Options options = null) =>
            JilSerializer.SerializeToJson(obj, options ?? DefaultOptions);

        public static object Deserialize(Type type, byte[] bytes, Options options = null) =>
            JilSerializer.Deserialize(type, bytes, options ?? DefaultOptions, DefaultEncoding);

        public static object Unpack(Type type, Stream stream, Options options = null) =>
            JilSerializer.Unpack(type, stream, options ?? DefaultOptions, DefaultEncoding);

        public static object Deserialize(Type type, string json, Options options = null) =>
            JilSerializer.Deserialize(type, json, options ?? DefaultOptions);

        public static T Deserialize<T>(TextReader reader, Options options = null) =>
            JilSerializer.Deserialize<T>(reader, options ?? DefaultOptions);

        public static object Deserialize(Type type, TextReader reader, Options options = null) =>
            JilSerializer.Deserialize(type, reader, options ?? DefaultOptions);
    }
}