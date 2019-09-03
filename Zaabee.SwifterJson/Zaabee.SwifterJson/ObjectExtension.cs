using System.IO;
using System.Text;

namespace Zaabee.SwifterJson
{
    public static class ObjectExtension
    {
        public static string ToJson<T>(this T t) =>
            SwifterJsonHelper.SerializeToJson(t);

        public static byte[] ToBytes<T>(this T t, Encoding encoding = null) =>
            SwifterJsonHelper.Serialize(t, encoding);

        public static void PackTo<T>(this T t, Stream stream, Encoding encoding = null) =>
            SwifterJsonHelper.Pack(t, stream, encoding);

        public static Stream Pack<T>(this T t, Encoding encoding = null) =>
            SwifterJsonHelper.Pack(t, encoding);
    }
}