using System;
using System.IO;

namespace Zaabee.Binary
{
    public static class StreamExtension
    {
        public static void Pack<T>(this Stream stream, T obj) =>
            BinaryHelper.Pack(obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            BinaryHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            BinaryHelper.Unpack(type, stream);
    }
}