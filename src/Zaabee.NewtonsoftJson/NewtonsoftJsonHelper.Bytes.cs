using System;
using System.Text;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        public static byte[] Serialize<T>(T t, JsonSerializerSettings settings = null, Encoding encoding = null) =>
            t is null
                ? new byte[0]
                : NewtonsoftJsonSerializer.Serialize(t, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static byte[] Serialize(Type type, object obj, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            obj is null
                ? new byte[0]
                : NewtonsoftJsonSerializer.Serialize(type, obj, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : NewtonsoftJsonSerializer.Deserialize<T>(bytes, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : NewtonsoftJsonSerializer.Deserialize(type, bytes, settings ?? DefaultSettings,
                    encoding ?? DefaultEncoding);
    }
}