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
        
        /// <summary>
        /// Deserialize from protobuf bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToProtobufWithoutAttr<T>(this T obj)
        {
            SerializerBuilder.Build<T>();
            return ProtobufHelper.Serialize(obj);
        }
    }
}