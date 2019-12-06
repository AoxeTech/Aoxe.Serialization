using System;
using System.Threading.Tasks;

namespace Zaabee.Protobuf
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes) =>
            ProtobufHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) =>
            ProtobufHelper.Deserialize(type, bytes);
    }
}