using System;
using System.IO;

namespace Zaabee.Protobuf
{
    public static partial class ProtobufSerializer
    {
        public static byte[] Serialize(object obj)
        {
            using var ms = Pack(obj);
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