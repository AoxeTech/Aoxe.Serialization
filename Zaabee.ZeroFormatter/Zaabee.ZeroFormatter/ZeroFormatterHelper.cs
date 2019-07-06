using ZeroFormatter;

namespace Zaabee.ZeroFormatter
{
    public static class ZeroFormatterHelper
    {
        /// <summary>
        /// Serialize the object to byte[]
        /// </summary>
        /// <param name="o">obj
        /// ect</param>
        /// <returns>json</returns>
        public static byte[] Serialize<T>(T o)
        {
            return o == null ? new byte[0] : ZeroFormatterSerializer.Serialize(o);
        }

        /// <summary>
        /// Deserialize the byte[] to the generic object(if the byte[] is null the length equals 0 then return default(T))
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="bytes">json</param>
        /// <returns>generic object</returns>
        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return default(T);
            return ZeroFormatterSerializer.Deserialize<T>(bytes);
        }
    }
}