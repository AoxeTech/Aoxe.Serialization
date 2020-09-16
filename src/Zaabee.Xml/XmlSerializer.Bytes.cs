using System;
using System.IO;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        public static byte[] Serialize<T>(T t) => Serialize(typeof(T), t);

        public static byte[] Serialize(Type type, object obj)
        {
            using var ms = Pack(type, obj);
            return ms.ToArray();
        }

        public static T Deserialize<T>(byte[] bytes) =>
            (T) Deserialize(typeof(T), bytes);

        public static object Deserialize(Type type, byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Unpack(type, ms);
        }
    }
}