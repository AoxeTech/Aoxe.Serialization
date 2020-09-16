using System;
using System.Text;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilSerializer
    {
        public static byte[] Serialize<T>(T t, Options options, Encoding encoding) =>
            encoding.GetBytes(SerializeToJson(t, options));

        public static byte[] Serialize(object obj, Options options, Encoding encoding) =>
            encoding.GetBytes(SerializeToJson(obj, options));

        public static T Deserialize<T>(byte[] bytes, Options options, Encoding encoding) =>
            Deserialize<T>(encoding.GetString(bytes), options);

        public static object Deserialize(Type type, byte[] bytes, Options options, Encoding encoding) =>
            Deserialize(type, encoding.GetString(bytes), options);
    }
}