using System;

namespace Zaabee.ZeroFormatter
{
    public static partial class ZeroFormatterExtensions
    {
        public static T DeserializeFromBase64<T>(this string base64) =>
            ZeroFormatterHelper.DeserializeFromBase64<T>(base64);

        public static object DeserializeFromBase64(this string base64, Type type) =>
            ZeroFormatterHelper.DeserializeFromBase64(type, base64);
    }
}