using System;

namespace Zaabee.Binary
{
    public static class BytesExtension
    {
        public static T FromBinary<T>(this byte[] bytes) =>
            BinaryHelper.Deserialize<T>(bytes);

        public static object FromBinary(this byte[] bytes, Type type) =>
            BinaryHelper.Deserialize(type, bytes);
    }
}