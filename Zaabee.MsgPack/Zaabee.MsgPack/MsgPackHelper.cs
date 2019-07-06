using System.IO;
using MsgPack.Serialization;

namespace Zaabee.MsgPack
{
    public static class MsgPackHelper
    {
        /// <summary>
        /// Serialize the object to byte[](if the generic object == null then return new byte[0])
        /// </summary>
        /// <param name="t">generic object</param>
        /// <returns>bytes</returns>
        public static byte[] Serialize<T>(T t)
        {
            if (t == null) return new byte[0];
            var serializer = MessagePackSerializer.Get<T>();
            using (var ms = new MemoryStream())
            {
                serializer.Pack(ms, t);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Deserialize the byte[] to the generic object(if the bytes is null or its length equals 0 then return default(T))
        /// </summary>
        /// <typeparam name="T">generic</typeparam>
        /// <param name="bytes">bytes</param>
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