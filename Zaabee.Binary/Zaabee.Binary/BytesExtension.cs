using System;

namespace Zaabee.Binary
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes) =>
            BinaryHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) =>
            BinaryHelper.Deserialize(type, bytes);
    }
}