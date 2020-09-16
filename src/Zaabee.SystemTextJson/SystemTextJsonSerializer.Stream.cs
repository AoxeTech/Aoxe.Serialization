using System;
using System.IO;
using System.Text.Json;
using Zaabee.Extensions;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonSerializer
    {
        public static MemoryStream Pack<T>(T value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            Pack(value, ms, options);
            return ms;
        }

        public static MemoryStream Pack(Type type, object value, JsonSerializerOptions options)
        {
            var ms = new MemoryStream();
            Pack(type, value, ms, options);
            return ms;
        }

        public static void Pack<T>(T value, Stream stream, JsonSerializerOptions options)
        {
            JsonSerializer.SerializeToUtf8Bytes(value, options).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static void Pack(Type type, object value, Stream stream, JsonSerializerOptions options)
        {
            JsonSerializer.SerializeToUtf8Bytes(value, type, options).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream, JsonSerializerOptions options)
        {
            var result = Deserialize<T>(stream.ReadToEnd(), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static object Unpack(Type type, Stream stream, JsonSerializerOptions options)
        {
            var result = Deserialize(type, stream.ReadToEnd(), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}