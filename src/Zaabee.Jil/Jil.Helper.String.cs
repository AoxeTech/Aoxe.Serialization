using System;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        public static string SerializeToJson<T>(T t, Options options = null) =>
            JilSerializer.SerializeToJson(t, options ?? DefaultOptions);

        public static T Deserialize<T>(string json, Options options = null) =>
            json.IsNullOrWhiteSpace()
                ? (T) typeof(T).GetDefaultValue()
                : JilSerializer.Deserialize<T>(json, options ?? DefaultOptions);

        public static string SerializeToJson(object obj, Options options = null) =>
            JilSerializer.SerializeToJson(obj, options ?? DefaultOptions);

        public static object Deserialize(Type type, string json, Options options = null) =>
            json.IsNullOrWhiteSpace()
                ? type.GetDefaultValue()
                : JilSerializer.Deserialize(type, json, options ?? DefaultOptions);
    }
}