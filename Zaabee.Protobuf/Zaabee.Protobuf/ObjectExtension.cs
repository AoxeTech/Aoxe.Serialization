namespace Zaabee.Protobuf
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToProtobuf<T>(this T obj)
        {
            return ProtobufHelper.Serialize(obj);
        }
    }
}