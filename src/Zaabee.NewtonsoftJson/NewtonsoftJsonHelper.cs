using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Zaabee.Extensions;

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
            obj is null
                ? new byte[0]
                : NewtonsoftJsonSerializer.Serialize(obj, settings ?? DefaultSettings, DefaultEncoding);

        public static MemoryStream Pack(object obj, JsonSerializerSettings settings = null) =>
            obj is null
                ? new MemoryStream()
                : NewtonsoftJsonSerializer.Pack(obj, settings ?? DefaultSettings, DefaultEncoding);

        public static void Pack(object obj, Stream stream, JsonSerializerSettings settings = null)
        {
            if (obj is null || stream is null) return;
            NewtonsoftJsonSerializer.Pack(obj, stream, settings ?? DefaultSettings, DefaultEncoding);
        }

        public static string SerializeToJson(object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonSerializer.SerializeToJson(obj, settings ?? DefaultSettings);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerSettings settings = null) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : NewtonsoftJsonSerializer.Deserialize<T>(bytes, settings ?? DefaultSettings, DefaultEncoding);

        public static T Deserialize<T>(string json, JsonSerializerSettings settings = null) =>
            json.IsNullOrWhiteSpace()
                ? (T) typeof(T).GetDefaultValue()
                : NewtonsoftJsonSerializer.Deserialize<T>(json, settings ?? DefaultSettings);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerSettings settings = null) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : NewtonsoftJsonSerializer.Deserialize(type, bytes, settings ?? DefaultSettings, DefaultEncoding);

        public static object Deserialize(Type type, string json, JsonSerializerSettings settings = null) =>
            json.IsNullOrWhiteSpace()
                ? type.GetDefaultValue()
                : NewtonsoftJsonSerializer.Deserialize(type, json, settings ?? DefaultSettings);

        public static T Unpack<T>(Stream stream, JsonSerializerSettings settings = null) =>
            stream is null
                ? (T) typeof(T).GetDefaultValue()
                : NewtonsoftJsonSerializer.Unpack<T>(stream, settings ?? DefaultSettings, DefaultEncoding);

        public static object Unpack(Type type, Stream stream, JsonSerializerSettings settings = null) =>
            stream is null
                ? type.GetDefaultValue()
                : NewtonsoftJsonSerializer.Unpack(type, stream, settings ?? DefaultSettings, DefaultEncoding);
    }
}