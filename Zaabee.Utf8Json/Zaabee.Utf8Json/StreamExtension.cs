using System;
using System.IO;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T obj) =>
            Utf8JsonHelper.Pack(obj, stream);

        public static void PackBy(this Stream stream, Type type, object obj) =>
            Utf8JsonHelper.Pack(type, obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            Utf8JsonHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            Utf8JsonHelper.Unpack(type, stream);

        public static object Unpack(this Stream stream, Type type, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Unpack(type, stream, resolver);
    }
}