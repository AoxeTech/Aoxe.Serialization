namespace Zaabee.MsgPack
{
    public static class BytesExtension
    {
        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T FromMsgPak<T>(this byte[] bytes)
        {
            return MsgPackHelper.Deserialize<T>(bytes);
        }
    }
}