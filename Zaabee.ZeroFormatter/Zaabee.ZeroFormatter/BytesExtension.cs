namespace Zaabee.ZeroFormatter
{
    public static class BytesExtension
    {
        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T FromZeroFormatter<T>(this byte[] bytes) =>
            ZeroFormatterHelper.Deserialize<T>(bytes);
    }
}