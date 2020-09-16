using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class ObjectExtension
    {
        public static string ToJson(this object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.SerializeToJson(obj, settings);

        public static byte[] ToBytes(this object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Serialize(obj, settings);

        public static MemoryStream ToStream(this object obj, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(obj, settings, encoding);

        public static async Task<MemoryStream> ToStreamAsync(this object obj, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            await NewtonsoftJsonHelper.PackAsync(obj, settings, encoding);

        public static void PackTo(this object obj, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(obj, stream, settings, encoding);

        public static async Task PackToAsync(this object obj, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            await NewtonsoftJsonHelper.PackAsync(obj, stream, settings, encoding);
    }
}