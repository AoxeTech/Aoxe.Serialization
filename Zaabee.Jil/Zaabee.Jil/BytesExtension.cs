using System;

namespace Zaabee.Jil
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes) =>
            JilHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) =>
            JilHelper.Deserialize(type, bytes);
    }
}