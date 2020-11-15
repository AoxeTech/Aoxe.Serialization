using System;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonExtension
    {
        public static T FromBytes<T>(this byte[] bytes, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Deserialize<T>(bytes, settings);

        public static object FromBytes(this byte[] bytes, Type type, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Deserialize(type, bytes, settings);
    }
}