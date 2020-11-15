using System;
using System.IO;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class SystemTextJsonExtension
    {
        public static void PackBy<T>(this Stream stream, T obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Pack(obj, stream, resolver);

        public static void PackBy(this Stream stream, Type type, object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Pack(type, obj, stream, resolver);

        public static T Unpack<T>(this Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Unpack<T>(stream, resolver);

        public static object Unpack(this Stream stream, Type type, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Unpack(type, stream, resolver);
    }
}