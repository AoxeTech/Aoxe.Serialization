using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes<T>(this T t, Options options = null) =>
            JilHelper.Serialize(t, options);

        public static MemoryStream ToStream<T>(this T t, Options options = null, Encoding encoding = null) =>
            JilHelper.Pack(t, options, encoding);

        public static async Task<MemoryStream> ToStreamAsync<T>(this T t, Options options = null,
            Encoding encoding = null) =>
            await JilHelper.PackAsync(t, options, encoding);

        public static string ToJson<T>(this T t, Options options = null) =>
            JilHelper.SerializeToJson(t, options);

        public static void PackTo<T>(this T t, Stream stream, Options options = null, Encoding encoding = null) =>
            JilHelper.Pack(t, stream, options, encoding);

        public static byte[] ToBytes(this object obj, Options options = null) =>
            JilHelper.Serialize(obj, options);

        public static MemoryStream ToStream(this object obj, Options options = null, Encoding encoding = null) =>
            JilHelper.Pack(obj, options, encoding);

        public static async Task<MemoryStream> ToStreamAsync(this object obj, Options options = null,
            Encoding encoding = null) =>
            await JilHelper.PackAsync(obj, options, encoding);

        public static string ToJson(this object obj, Options options = null) =>
            JilHelper.SerializeToJson(obj, options);

        public static void PackTo(this object obj, Stream stream, Options options = null, Encoding encoding = null) =>
            JilHelper.Pack(obj, stream, options, encoding);

        public static async Task PackToAsync<T>(this T t, Stream stream, Options options = null,
            Encoding encoding = null) =>
            await JilHelper.PackAsync(t, stream, options, encoding);

        public static async Task PackToAsync(this object obj, Stream stream, Options options = null,
            Encoding encoding = null) =>
            await JilHelper.PackAsync(obj, stream, options, encoding);

        public static void ToJson<T>(this T t, TextWriter output, Options options = null) =>
            JilHelper.Serialize(t, output, options);

        public static void ToJson(this object obj, TextWriter output, Options options = null) =>
            JilHelper.Serialize(obj, output, options);
    }
}