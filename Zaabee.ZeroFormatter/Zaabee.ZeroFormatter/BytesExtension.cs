using System;

namespace Zaabee.ZeroFormatter
{
    public static class BytesExtension
    {
        public static T FromZeroFormatter<T>(this byte[] bytes) =>
            ZeroFormatterHelper.Deserialize<T>(bytes);

        public static object FromZeroFormatter(this byte[] bytes, Type type) =>
            ZeroFormatterHelper.Deserialize(type, bytes);
    }
}