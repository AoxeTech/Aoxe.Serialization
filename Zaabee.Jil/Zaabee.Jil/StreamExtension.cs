using System;
using System.IO;
using Jil;

namespace Zaabee.Jil
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T t, Options options = null) =>
            JilHelper.Pack(t, stream, options);

        public static void PackBy(this Stream stream, object obj, Options options = null) =>
            JilHelper.Pack(obj, stream, options);

        public static T Unpack<T>(this Stream stream, Options options = null) =>
            JilHelper.Unpack<T>(stream, options);

        public static object Unpack(this Stream stream, Type type, Options options = null) =>
            JilHelper.Unpack(type, stream, options);
    }
}