using System;
using System.IO;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class StreamExtension
    {
        public static void PackBy(this Stream stream, object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Pack(obj, stream, settings);

        public static T Unpack<T>(this Stream stream, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Unpack<T>(stream, settings);

        public static object Unpack(this Stream stream, Type type, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Unpack(type, stream, settings);
    }
}