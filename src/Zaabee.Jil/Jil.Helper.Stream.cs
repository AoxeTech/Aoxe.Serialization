using System;
using System.IO;
using System.Text;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        public static MemoryStream Pack<T>(T t, Options options = null, Encoding encoding = null) =>
            t is null
                ? new MemoryStream()
                : JilSerializer.Pack(t, options ?? DefaultOptions, encoding ?? DefaultEncoding);

        public static void Pack<T>(T t, Stream stream, Options options = null, Encoding encoding = null)
        {
            if (t is null || stream is null) return;
            JilSerializer.Pack(t, stream, options ?? DefaultOptions, encoding ?? DefaultEncoding);
        }

        public static MemoryStream Pack(object obj, Options options = null, Encoding encoding = null) =>
            obj is null
                ? new MemoryStream()
                : JilSerializer.Pack(obj, options ?? DefaultOptions, encoding ?? DefaultEncoding);

        public static void Pack(object obj, Stream stream, Options options = null, Encoding encoding = null)
        {
            if (obj is null || stream is null) return;
            JilSerializer.Pack(obj, stream, options ?? DefaultOptions, encoding ?? DefaultEncoding);
        }

        public static T Unpack<T>(Stream stream, Options options = null, Encoding encoding = null) =>
            stream.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : JilSerializer.Unpack<T>(stream, options ?? DefaultOptions, encoding ?? DefaultEncoding);

        public static object Unpack(Type type, Stream stream, Options options = null, Encoding encoding = null) =>
            stream.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : JilSerializer.Unpack(type, stream, options ?? DefaultOptions, encoding ?? DefaultEncoding);
    }
}