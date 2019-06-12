namespace Zaabee.Utf8Json
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Utf8JsonToString<T>(this T obj)
        {
            return Utf8JsonHelper.SerializeToString(obj);
        }

        /// <summary>
        /// Serialize the object to byte[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Utf8JsonToBytes<T>(this T obj)
        {
            return Utf8JsonHelper.SerializeToByte(obj);
        }
    }
}