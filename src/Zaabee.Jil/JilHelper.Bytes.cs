using System;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        public static byte[] Serialize<T>(T t, Options options = null) =>
            t is null
                ? new byte[0]
                : JilSerializer.Serialize(t, options ?? DefaultOptions, DefaultEncoding);

        public static byte[] Serialize(object obj, Options options = null) =>
            obj is null
                ? new byte[0]
                : JilSerializer.Serialize(obj, options ?? DefaultOptions, DefaultEncoding);

        public static T Deserialize<T>(byte[] bytes, Options options = null) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : JilSerializer.Deserialize<T>(bytes, options ?? DefaultOptions, DefaultEncoding);

        public static object Deserialize(Type type, byte[] bytes, Options options = null) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : JilSerializer.Deserialize(type, bytes, options ?? DefaultOptions, DefaultEncoding);
    }
}