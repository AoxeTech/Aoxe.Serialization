using System;
using System.IO;

namespace Zaabee.Binary
{
    public static class StreamExtension
    {
        public static void PackBinary<T>(this Stream stream, T obj) =>
            BinaryHelper.Pack(obj, stream);

        public static T UnpackBinary<T>(this Stream stream) =>
            BinaryHelper.Unpack<T>(stream);

        public static object UnpackBinary(this Stream stream, Type type) =>
            BinaryHelper.Unpack(type, stream);
    }
}