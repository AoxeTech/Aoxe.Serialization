using System;
using System.Text;

namespace Zaabee.SwifterJson
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes, Encoding encoding = null) =>
            SwifterJsonHelper.Deserialize<T>(bytes, encoding);

        public static object FromBytes(this byte[] bytes, Type type, Encoding encoding = null) =>
            SwifterJsonHelper.Deserialize(type, bytes, encoding);
    }
}