using System;
using System.IO;

namespace Zaabee.Protobuf
{
    public static class StreamExtension
    {
        /// <summary>
        /// Deserialize from stream
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T FromProtobuf<T>(this Stream stream)
        {
            return ProtobufHelper.Deserialize<T>(stream);
        }

        /// <summary>
        /// Deserialize from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromProtobuf(this Stream stream, Type type)
        {
            return ProtobufHelper.Deserialize(stream, type);
        }

        /// <summary>
        /// Serialize the object to the stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="obj"></param>
        public static void PackByProtobuf(this Stream stream, object obj)
        {
            ProtobufHelper.Serialize(stream, obj);
        }
    }
}