using System.IO;
using System.Threading.Tasks;
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

        public static async Task<byte[]> ToBytesAsync<T>(this T t, Options options = null) =>
            await JilHelper.SerializeAsync(t, options);

        public static async Task<Stream> PackAsync<T>(this T t, Options options = null) =>
            await JilHelper.PackAsync(t, options);

        public static async Task<string> ToJsonAsync<T>(this T t, Options options = null) =>
            await JilHelper.SerializeToJsonAsync(t, options);

        public static async Task PackToAsync<T>(this T t, Stream stream, Options options = null) =>
            await JilHelper.PackAsync(t, stream, options);

        public static async Task SerializeAsync<T>(this object obj, TextWriter textWriter, Options options = null) =>
            await JilHelper.SerializeAsync(obj, textWriter, options);

        public static async Task<byte[]> ToBytesAsync(this object obj, Options options = null) =>
            await JilHelper.SerializeAsync(obj, options);

        public static async Task<Stream> PackAsync(this object obj, Options options = null) =>
            await JilHelper.PackAsync(obj, options);

        public static async Task<string> ToJsonAsync(this object obj, Options options = null) =>
            await JilHelper.SerializeToJsonAsync(obj, options);

        public static async Task PackToAsync(this object obj, Stream stream, Options options = null) =>
            await JilHelper.PackAsync(obj, stream, options);
    }
}