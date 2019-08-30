using System;
using System.IO;

namespace Zaabee.Jil
{
    public static class StreamExtension
    {
        public static void Pack<T>(this Stream stream, T t) =>
            JilHelper.Pack(t, stream);

        public static void Pack(this Stream stream, object obj) =>
            JilHelper.Pack(obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            JilHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            JilHelper.Unpack(type, stream);
    }
}