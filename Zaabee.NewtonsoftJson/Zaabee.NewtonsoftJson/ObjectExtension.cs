using System.IO;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class ObjectExtension
    {
        public static string ToJson(this object obj, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            NewtonsoftJsonHelper.SerializeToJson(obj, settings, formatting);

        public static byte[] ToBytes(this object obj, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            NewtonsoftJsonHelper.Serialize(obj, settings, formatting);

        public static Stream Pack(this object obj, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            NewtonsoftJsonHelper.Pack(obj, settings, formatting);

        public static void PackTo(this object obj, Stream stream, JsonSerializerSettings settings = null,
            Formatting? formatting = null) =>
            NewtonsoftJsonHelper.Pack(obj, stream, settings, formatting);
    }
}