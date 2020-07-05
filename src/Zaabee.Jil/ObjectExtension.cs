using System.IO;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes<T>(this T t, Options options = null) =>
            JilHelper.Serialize(t, options);

        public static MemoryStream ToStream<T>(this T t, Options options = null) =>
            JilHelper.Pack(t, options);

        public static async Task<MemoryStream> ToStreamAsync<T>(this T t, Options options = null) =>
            await JilHelper.PackAsync(t, options);

        public static string ToJson<T>(this T t, Options options = null) =>
            JilHelper.SerializeToJson(t, options);

        public static void PackTo<T>(this T t, Stream stream, Options options = null) =>
            JilHelper.Pack(t, stream, options);

        public static byte[] ToBytes(this object obj, Options options = null) =>
            JilHelper.Serialize(obj, options);

        public static MemoryStream ToStream(this object obj, Options options = null) =>
            JilHelper.Pack(obj, options);

        public static async Task<MemoryStream> ToStreamAsync(this object obj, Options options = null) =>
            await JilHelper.PackAsync(obj, options);

        public static string ToJson(this object obj, Options options = null) =>
            JilHelper.SerializeToJson(obj, options);

        public static void PackTo(this object obj, Stream stream, Options options = null) =>
            JilHelper.Pack(obj, stream, options);

        public static async Task PackToAsync<T>(this T t, Stream stream, Options options = null) =>
            await JilHelper.PackAsync(t, stream, options);

        public static async Task PackToAsync(this object obj, Stream stream, Options options = null) =>
            await JilHelper.PackAsync(obj, stream, options);

        public static void ToJson<T>(this T t, TextWriter output, Options options = null) =>
            JilHelper.Serialize(t, output, options);

        public static void ToJson(this object obj, TextWriter output, Options options = null) =>
            JilHelper.Serialize(obj, output, options);
    }
}