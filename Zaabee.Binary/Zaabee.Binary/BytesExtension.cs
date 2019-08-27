namespace Zaabee.Binary
{
    public static class BytesExtension
    {
        /// <summary>
        /// Deserialize the json to the generic object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T FromBytes<T>(this byte[] bytes) => BinaryHelper.Deserialize<T>(bytes);
    }
}