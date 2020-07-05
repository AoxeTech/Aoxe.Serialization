using System.IO;
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

        public static MemoryStream ToStream(this object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Pack(obj, settings);

        public static async Task<MemoryStream> ToStreamAsync(this object obj, JsonSerializerSettings settings = null) =>
            await NewtonsoftJsonHelper.PackAsync(obj, settings);

        public static void PackTo(this object obj, Stream stream, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Pack(obj, stream, settings);

        public static async Task PackToAsync(this object obj, Stream stream, JsonSerializerSettings settings = null) =>
            await NewtonsoftJsonHelper.PackAsync(obj, stream, settings);
    }
}