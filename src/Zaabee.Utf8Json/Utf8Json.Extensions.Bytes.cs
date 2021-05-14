using System;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonExtensions
    {
        public static T FromBytes<T>(this byte[] bytes, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Deserialize<T>(bytes, resolver);

        public static object FromBytes(this byte[] bytes, Type type, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Deserialize(type, bytes, resolver);
    }
}