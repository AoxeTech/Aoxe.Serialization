namespace Zaabee.MsgPack
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToMsgPack<T>(this T obj)
        {
            return MsgPackHelper.Serialize(obj);
        }
    }
}