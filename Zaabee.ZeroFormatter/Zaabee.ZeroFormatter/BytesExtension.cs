using System;

namespace Zaabee.ZeroFormatter
{
    public static class BytesExtension
    {
        public static T DeserializeByZeroFormatter<T>(this byte[] bytes) =>
            ZeroFormatterHelper.Deserialize<T>(bytes);

        public static object DeserializeByZeroFormatter(this byte[] bytes, Type type) =>
            ZeroFormatterHelper.Deserialize(type, bytes);
    }
}