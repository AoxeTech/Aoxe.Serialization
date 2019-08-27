namespace Zaabee.Utf8Json
{
    public static class BytesExtension
    {
        /// <summary>
        /// Deserialize the json to the generic object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T FromUtf8Json<T>(this byte[] bytes) =>
            Utf8JsonHelper.Deserialize<T>(bytes);
    }
}