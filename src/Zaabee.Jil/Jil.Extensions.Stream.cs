using System;
using System.IO;
using System.Text;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilExtensions
    {
        public static void PackBy<T>(this Stream stream, T t, Options options = null, Encoding encoding = null) =>
            JilHelper.Pack(t, stream, options, encoding);

        public static void PackBy(this Stream stream, object obj, Options options = null, Encoding encoding = null) =>
            JilHelper.Pack(obj, stream, options, encoding);

        public static T Unpack<T>(this Stream stream, Options options = null, Encoding encoding = null) =>
            JilHelper.Unpack<T>(stream, options, encoding);

        public static object Unpack(this Stream stream, Type type, Options options = null, Encoding encoding = null) =>
            JilHelper.Unpack(type, stream, options, encoding);
    }
}