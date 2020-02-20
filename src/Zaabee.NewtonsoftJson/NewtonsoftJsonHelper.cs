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

        public static JsonSerializerSettings DefaultSettings { get; set; }

        public static byte[] Serialize(object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.Serialize(obj, settings ?? DefaultSettings, DefaultEncoding);

        public static Stream Pack(object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.Pack(obj, settings ?? DefaultSettings, DefaultEncoding);

        public static void Pack(object obj, Stream stream, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.Pack(obj, stream, settings ?? DefaultSettings, DefaultEncoding);

        public static string SerializeToJson(object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.SerializeToJson(obj, settings ?? DefaultSettings);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.Deserialize<T>(bytes, settings ?? DefaultSettings, DefaultEncoding);

        public static T Unpack<T>(Stream stream, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.Unpack<T>(stream, settings ?? DefaultSettings, DefaultEncoding);

        public static T Deserialize<T>(string json, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.Deserialize<T>(json, settings ?? DefaultSettings);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.Deserialize(type, bytes, settings ?? DefaultSettings, DefaultEncoding);

        public static object Unpack(Type type, Stream stream, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.Unpack(type, stream, settings ?? DefaultSettings, DefaultEncoding);

        public static object Deserialize(Type type, string json, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.Deserialize(type, json, settings ?? DefaultSettings);
    }
}