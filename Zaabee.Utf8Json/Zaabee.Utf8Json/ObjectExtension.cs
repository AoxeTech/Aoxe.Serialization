using System;
using System.IO;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class ObjectExtension
    {
        public static string ToJson<T>(this T t) =>
            Utf8JsonHelper.SerializeToJson(t);

        public static string ToJson(this object obj, Type type) =>
            Utf8JsonHelper.SerializeToJson(type, obj);

        public static string ToJson(this object obj, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.SerializeToJson(obj, resolver);

        public static string ToJson(this object obj, Type type, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.SerializeToJson(type, obj, resolver);

        public static byte[] ToBytes<T>(this T t) =>
            Utf8JsonHelper.Serialize(t);

        public static byte[] ToBytes(this object obj, Type type) =>
            Utf8JsonHelper.Serialize(type, obj);

        public static byte[] ToBytes(this object obj, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Serialize(obj, resolver);

        public static byte[] ToBytes(this object obj, Type type, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Serialize(type, obj, resolver);

        public static Stream Pack<T>(this T t) =>
            Utf8JsonHelper.Pack(t);

        public static void PackTo<T>(this T t, Stream stream) =>
            Utf8JsonHelper.Pack(t, stream);

        public static Stream Pack<T>(this T t, Type type) =>
            Utf8JsonHelper.Pack(type, t);

        public static void PackTo(this object obj, Type type, Stream stream) =>
            Utf8JsonHelper.Pack(type, obj, stream);

        public static Stream Pack<T>(this T t, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Pack(t, resolver);

        public static void PackTo(this object obj, Stream stream, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Pack(obj, stream, resolver);

        public static Stream Pack<T>(this T t, Type type, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Pack(type, t, resolver);

        public static void PackTo(this object obj, Type type, Stream stream,
            IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Pack(type, obj, stream, resolver);
    }
}