using System.IO;
using Jil;

namespace Zaabee.Jil
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes<T>(this T t, Options options = null) =>
            JilHelper.Serialize(t, options);

        public static Stream Pack<T>(this T t, Options options = null) =>
            JilHelper.Pack(t, options);

        public static string ToJson<T>(this T t, Options options = null) =>
            JilHelper.SerializeToJson(t, options);

        public static void PackTo<T>(this T t, Stream stream, Options options = null) =>
            JilHelper.Pack(t, stream, options);

        public static void Serialize<T>(this object obj, TextWriter textWriter, Options options = null) =>
            JilHelper.Serialize(obj, textWriter, options);

        public static byte[] ToBytes(this object obj, Options options = null) =>
            JilHelper.Serialize(obj, options);

        public static Stream Pack(this object obj, Options options = null) =>
            JilHelper.Pack(obj, options);

        public static string ToJson(this object obj, Options options = null) =>
            JilHelper.SerializeToJson(obj, options);

        public static void PackTo(this object obj, Stream stream, Options options = null) =>
            JilHelper.Pack(obj, stream, options);
    }
}