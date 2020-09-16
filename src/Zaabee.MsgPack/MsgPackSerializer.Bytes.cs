using System;
using System.IO;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackSerializer
    {
        public static byte[] Serialize<T>(T t)
        {
            using var ms = Pack(t);
            return ms.ToArray();
        }

        public static byte[] Serialize(Type type, object obj)
        {
            using var ms = Pack(type, obj);
            return ms.ToArray();
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Unpack<T>(ms);
        }

        public static object Deserialize(Type type, byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Unpack(type, ms);
        }
    }
}