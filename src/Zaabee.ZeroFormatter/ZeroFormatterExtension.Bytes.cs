using System;

namespace Zaabee.ZeroFormatter
{
    public static partial class ZeroFormatterExtension
    {
        public static T FromBytes<T>(this byte[] bytes) => ZeroFormatterHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) => ZeroFormatterHelper.Deserialize(type, bytes);
    }
}