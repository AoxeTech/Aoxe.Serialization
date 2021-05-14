using Zaabee.Extensions;

namespace Zaabee.Binary
{
    public static partial class BinarySerializer
    {
        /// <summary>
        /// Serialize the object into bytes and convert it to a base64 string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToBase64(object obj) =>
            Serialize(obj).ToBase64String();

        /// <summary>
        /// Deserialize a base64 string to generic object.
        /// </summary>
        /// <param name="base64"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBase64<T>(string base64) =>
            Deserialize<T>(base64.FromBase64ToBytes());

        /// <summary>
        /// Deserialize a base64 string to object.
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static object DeserializeFromBase64(string base64) =>
            Deserialize(base64.FromBase64ToBytes());
    }
}