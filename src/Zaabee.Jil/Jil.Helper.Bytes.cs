using System;
using System.Text;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        public static byte[] Serialize<T>(T t, Options options = null, Encoding encoding = null) =>
            t is null
                ? Array.Empty<byte>()
                : JilSerializer.Serialize(t, options ?? DefaultOptions, encoding ?? DefaultEncoding);

        public static byte[] Serialize(object obj, Options options = null, Encoding encoding = null) =>
            obj is null
                ? Array.Empty<byte>()
                : JilSerializer.Serialize(obj, options ?? DefaultOptions, encoding ?? DefaultEncoding);

        public static T Deserialize<T>(byte[] bytes, Options options = null, Encoding encoding = null) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : JilSerializer.Deserialize<T>(bytes, options ?? DefaultOptions, encoding ?? DefaultEncoding);

        public static object Deserialize(Type type, byte[] bytes, Options options = null, Encoding encoding = null) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : JilSerializer.Deserialize(type, bytes, options ?? DefaultOptions, encoding ?? DefaultEncoding);
    }
}