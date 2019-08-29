using System;
using System.IO;

namespace Zaabee.Xml
{
    public static class StreamExtension
    {
        public static void Pack<T>(this Stream stream, T t) =>
            XmlHelper.Pack(t, stream);

        public static void Pack(this Stream stream, Type type, object obj) =>
            XmlHelper.Pack(type, obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            XmlHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            XmlHelper.Unpack(type, stream);
    }
}