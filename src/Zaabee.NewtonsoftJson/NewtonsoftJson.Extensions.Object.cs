using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonExtensions
    {
        public static string ToJson<T>(this T t, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.SerializeToJson(t, settings);

        public static string ToJson(this object obj, Type type, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.SerializeToJson(type, obj, settings);

        public static byte[] ToBytes<T>(this T t, JsonSerializerSettings settings = null, Encoding encoding = null) =>
            NewtonsoftJsonHelper.Serialize(t, settings, encoding);

        public static byte[] ToBytes(this object obj, Type type, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Serialize(type, obj, settings, encoding);

        public static MemoryStream ToStream<T>(this T t, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(t, settings, encoding);

        public static MemoryStream ToStream(this object obj, Type type, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(type, obj, settings, encoding);

        public static void PackTo<T>(this T t, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(t, stream, settings, encoding);

        public static void PackTo(this object obj, Type type, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(type, obj, stream, settings, encoding);
    }
}