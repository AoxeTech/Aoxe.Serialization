using System;
using System.IO;
using System.Text;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilSerializer
    {
        public static MemoryStream Pack<T>(T t, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(t, ms, options, encoding);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream, Options options, Encoding encoding)
        {
            Serialize(t, options, encoding).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static MemoryStream Pack(object obj, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(obj, ms, options, encoding);
            return ms;
        }

        public static void Pack(object obj, Stream stream, Options options, Encoding encoding)
        {
            Serialize(obj, options, encoding).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream, Options options, Encoding encoding)
        {
            var result = Deserialize<T>(encoding.GetString(stream.ReadToEnd()), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static object Unpack(Type type, Stream stream, Options options, Encoding encoding)
        {
            var result = Deserialize(type, encoding.GetString(stream.ReadToEnd()), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}