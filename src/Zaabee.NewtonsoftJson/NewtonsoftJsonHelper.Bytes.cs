using System;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        public static byte[] Serialize(object obj, JsonSerializerSettings settings = null) =>
            obj is null
                ? new byte[0]
                : NewtonsoftJsonSerializer.Serialize(obj, settings ?? DefaultSettings, DefaultEncoding);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerSettings settings = null) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : NewtonsoftJsonSerializer.Deserialize<T>(bytes, settings ?? DefaultSettings, DefaultEncoding);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerSettings settings = null) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : NewtonsoftJsonSerializer.Deserialize(type, bytes, settings ?? DefaultSettings, DefaultEncoding);
    }
}