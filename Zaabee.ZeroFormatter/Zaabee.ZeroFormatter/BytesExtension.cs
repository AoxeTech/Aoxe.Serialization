using System;

namespace Zaabee.ZeroFormatter
{
    public static class BytesExtension
    {
        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T DeserializeByZeroFormatter<T>(this byte[] bytes) =>
            ZeroFormatterHelper.Deserialize<T>(bytes);

        public static object DeserializeByZeroFormatter(this byte[] bytes, Type type) =>
            ZeroFormatterHelper.Deserialize(type, bytes);
    }
}