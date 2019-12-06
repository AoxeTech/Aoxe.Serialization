using System;
using System.Threading.Tasks;

namespace Zaabee.MsgPack
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes) =>
            MsgPackHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) =>
            MsgPackHelper.Deserialize(type, bytes);
    }
}