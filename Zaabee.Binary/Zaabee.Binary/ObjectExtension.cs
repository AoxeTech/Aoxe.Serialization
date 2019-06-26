namespace Zaabee.Binary
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to byte[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToBytes<T>(this T obj)
        {
            return BinaryHelper.Serialize(obj);
        }
    }
}