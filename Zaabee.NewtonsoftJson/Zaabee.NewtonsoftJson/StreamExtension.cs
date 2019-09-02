using System;
using System.IO;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class StreamExtension
    {
        public static void PackBy(this Stream stream, object obj, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            NewtonsoftJsonHelper.Pack(obj, stream, settings, formatting);

        public static T Unpack<T>(this Stream stream, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            NewtonsoftJsonHelper.Unpack<T>(stream, settings, formatting);

        public static object Unpack(this Stream stream, Type type, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            NewtonsoftJsonHelper.Unpack(type, stream, settings, formatting);
    }
}