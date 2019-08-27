namespace Zaabee.ZeroFormatter
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToZeroFormatter<T>(this T obj) =>
            ZeroFormatterHelper.Serialize(obj);
    }
}