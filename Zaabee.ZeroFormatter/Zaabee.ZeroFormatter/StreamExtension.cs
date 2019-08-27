using System;
using System.IO;

namespace Zaabee.ZeroFormatter
{
    public static class StreamExtension
    {
        public static T UnPack<T>(this Stream stream) =>
            ZeroFormatterHelper.UnPack<T>(stream);

        public static object UnPack(this Stream stream, Type type) =>
            ZeroFormatterHelper.UnPack(type, stream);
    }
}