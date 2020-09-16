using System;
using System.IO;
using Zaabee.Extensions;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        public static MemoryStream Pack<T>(T t) =>
            Pack(typeof(T), t);

        public static MemoryStream Pack(Type type, object obj)
        {
            var ms = new MemoryStream();
            Pack(type, obj, ms);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream) =>
            Pack(typeof(T), t, stream);

        public static void Pack(Type type, object obj, Stream stream)
        {
            GetSerializer(type).Serialize(stream, obj);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream) =>
            (T) Unpack(typeof(T), stream);

        public static object Unpack(Type type, Stream stream)
        {
            var result = GetSerializer(type).Deserialize(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}