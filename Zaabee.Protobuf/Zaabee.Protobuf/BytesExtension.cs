using System;

namespace Zaabee.Protobuf
{
    public static class BytesExtension
    {
        /// <summary>
        /// Deserialize from protobuf bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T FromProtobuf<T>(this byte[] bytes)
        {
            return ProtobufHelper.Deserialize<T>(bytes);
        }

        /// <summary>
        /// Deserialize from protobuf bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromProtobuf(this byte[] bytes, Type type)
        {
            return ProtobufHelper.Deserialize(bytes, type);
        }
    }
}