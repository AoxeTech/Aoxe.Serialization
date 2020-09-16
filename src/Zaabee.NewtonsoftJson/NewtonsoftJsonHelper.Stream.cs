using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        public static MemoryStream Pack(object obj, JsonSerializerSettings settings = null, Encoding encoding = null) =>
            obj is null
                ? new MemoryStream()
                : NewtonsoftJsonSerializer.Pack(obj, settings ?? DefaultSettings, encoding ?? DefaultEncoding);

        public static void Pack(object obj, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null)
        {
            if (obj is null || stream is null) return;
            NewtonsoftJsonSerializer.Pack(obj, stream, settings ?? DefaultSettings, encoding ?? DefaultEncoding);
        }

        public static T Unpack<T>(Stream stream, JsonSerializerSettings settings = null, Encoding encoding = null) =>
            stream is null
                ? (T) typeof(T).GetDefaultValue()
                : NewtonsoftJsonSerializer.Unpack<T>(stream, settings ?? DefaultSettings, encoding ?? DefaultEncoding);

        public static object Unpack(Type type, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            stream is null
                ? type.GetDefaultValue()
                : NewtonsoftJsonSerializer.Unpack(type, stream, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);
    }
}