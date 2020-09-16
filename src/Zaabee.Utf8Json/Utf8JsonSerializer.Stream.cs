using System;
using System.IO;
using Utf8Json;
using Zaabee.Extensions;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonSerializer
    {
        public static MemoryStream Pack<T>(T value, IJsonFormatterResolver resolver)
        {
            var ms = new MemoryStream();
            Pack(value, ms, resolver);
            return ms;
        }

        public static void Pack<T>(T value, Stream stream, IJsonFormatterResolver resolver)
        {
            JsonSerializer.Serialize(stream, value, resolver);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static MemoryStream Pack(object obj, IJsonFormatterResolver resolver)
        {
            var ms = new MemoryStream();
            Pack(obj, ms, resolver);
            return ms;
        }

        public static void Pack(object obj, Stream stream, IJsonFormatterResolver resolver)
        {
            JsonSerializer.NonGeneric.Serialize(stream, obj, resolver);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static MemoryStream Pack(Type type, object obj, IJsonFormatterResolver resolver)
        {
            var ms = new MemoryStream();
            Pack(type, obj, ms, resolver);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream, IJsonFormatterResolver resolver)
        {
            JsonSerializer.NonGeneric.Serialize(type, stream, obj, resolver);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream, IJsonFormatterResolver resolver)
        {
            var result = JsonSerializer.Deserialize<T>(stream, resolver);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static object Unpack(Type type, Stream stream, IJsonFormatterResolver resolver)
        {
            var result = JsonSerializer.NonGeneric.Deserialize(type, stream, resolver);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}