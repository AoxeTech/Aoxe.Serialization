using System;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilSerializer
    {
        public static string SerializeToJson<T>(T t, Options options) =>
            JSON.Serialize(t, options);

        public static string SerializeToJson(object obj, Options options) =>
            JSON.SerializeDynamic(obj, options);

        public static T Deserialize<T>(string json, Options options) =>
            JSON.Deserialize<T>(json, options);

        public static object Deserialize(Type type, string json, Options options) =>
            JSON.Deserialize(json, type, options);
    }
}