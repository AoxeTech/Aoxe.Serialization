using System.IO;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class ObjectExtension
    {
        public static string ToJson(this object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.SerializeToJson(obj, settings);

        public static byte[] ToBytes(this object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Serialize(obj, settings);

        public static Stream Pack(this object obj, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Pack(obj, settings);

        public static void PackTo(this object obj, Stream stream, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Pack(obj, stream, settings);
    }
}