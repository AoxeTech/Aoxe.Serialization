using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonExtensions
    {
        public static string ToJson<TValue>(this TValue value, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.SerializeToJson(value, settings);

        public static string ToJson(this object? value, Type type, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.SerializeToJson(type, value, settings);

        public static byte[] ToBytes<TValue>(this TValue value, JsonSerializerSettings settings = null, Encoding encoding = null) =>
            NewtonsoftJsonHelper.Serialize(value, settings, encoding);

        public static byte[] ToBytes(this object? value, Type type, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Serialize(type, value, settings, encoding);

        public static Stream ToStream<TValue>(this TValue value, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(value, settings, encoding);

        public static Stream ToStream(this object? value, Type type, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(type, value, settings, encoding);

        public static void PackTo<TValue>(this TValue value, Stream? stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(value, stream, settings, encoding);

        public static void PackTo(this object? value, Type type, Stream? stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(type, value, stream, settings, encoding);
    }
}