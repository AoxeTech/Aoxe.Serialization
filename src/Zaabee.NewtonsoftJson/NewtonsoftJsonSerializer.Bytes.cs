using System;
using System.Text;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonSerializer
    {
        public static byte[] Serialize(object obj, JsonSerializerSettings settings, Encoding encoding) =>
            encoding.GetBytes(SerializeToJson(obj, settings));

        public static T Deserialize<T>(byte[] bytes, JsonSerializerSettings settings, Encoding encoding) =>
            (T) Deserialize(typeof(T), bytes, settings, encoding);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerSettings settings, Encoding encoding) =>
            Deserialize(type, encoding.GetString(bytes), settings);
    }
}