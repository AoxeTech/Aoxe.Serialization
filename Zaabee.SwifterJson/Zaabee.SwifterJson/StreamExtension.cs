using System;
using System.IO;
using System.Text;

namespace Zaabee.SwifterJson
{
    public static class StreamExtension
    {
        public static void PackBy<T>(this Stream stream, T obj, Encoding encoding = null) =>
            SwifterJsonHelper.Pack(obj, stream, encoding);

        public static T Unpack<T>(this Stream stream, Encoding encoding = null) =>
            SwifterJsonHelper.Unpack<T>(stream, encoding);

        public static object Unpack(this Stream stream, Type type, Encoding encoding = null) =>
            SwifterJsonHelper.Unpack(type, stream, encoding);
    }
}