using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        public static Stream Pack<TValue>(TValue value, JsonSerializerSettings settings = null, Encoding encoding = null) =>
            value is null
                ? Stream.Null
                : NewtonsoftJsonSerializer.Pack(value, settings ?? DefaultSettings, encoding ?? DefaultEncoding);

        public static Stream Pack(Type type, object? value, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            value is null
                ? Stream.Null
                : NewtonsoftJsonSerializer.Pack(type, value, settings ?? DefaultSettings, encoding ?? DefaultEncoding);

        public static void Pack<TValue>(TValue value, Stream? stream, JsonSerializerSettings settings = null, Encoding encoding = null)
        {
            if (value is null || stream is null) return;
            NewtonsoftJsonSerializer.Pack(value, stream, settings ?? DefaultSettings, encoding ?? DefaultEncoding);
        }

        public static void Pack(Type type, object? value, Stream? stream, JsonSerializerSettings settings = null,
            Encoding encoding = null)
        {
            if (value is null || stream is null) return;
            NewtonsoftJsonSerializer.Pack(type, value, stream, settings ?? DefaultSettings, encoding ?? DefaultEncoding);
        }

        public static TValue? Unpack<TValue>(Stream? stream, JsonSerializerSettings settings = null, Encoding encoding = null) =>
            stream.IsNullOrEmpty()
                ? default
                : NewtonsoftJsonSerializer.Unpack<TValue>(stream, settings ?? DefaultSettings, encoding ?? DefaultEncoding);

        public static object? Unpack(Type type, Stream? stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            stream.IsNullOrEmpty()
                ? default
                : NewtonsoftJsonSerializer.Unpack(type, stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);
    }
}