using System.IO;
using MsgPack.Serialization;

namespace Zaabee.MsgPack
{
    public static class MsgPackHelper
    {
        /// <summary>
        /// Serialize the object to byte[]
        /// </summary>
        /// <param name="o">obj
        /// ect</param>
        /// <returns>json</returns>
        public static byte[] Serialize<T>(T o)
        {
            if (o == null) return new byte[0];
            var serializer = MessagePackSerializer.Get<T>();
            using (var ms = new MemoryStream())
            {
                serializer.Pack(ms, o);
                return ms.ToArray();
            }
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
            var serializer = MessagePackSerializer.Get<T>();
            using (var ms = new MemoryStream(bytes))
                return serializer.Unpack(ms);
        }
    }
}