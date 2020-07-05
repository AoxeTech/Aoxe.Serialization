using System;
using System.IO;
using Zaabee.Extensions;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackHelper
    {
        #region Bytes

        public static byte[] Serialize<T>(T t) =>
            t is null
                ? new byte[0]
                : MsgPackSerializer.Serialize(t);

        public static byte[] Serialize(Type type, object obj) =>
            obj is null
                ? new byte[0]
                : MsgPackSerializer.Serialize(type, obj);

        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty()
                ? default
                : MsgPackSerializer.Deserialize<T>(bytes);

        public static object Deserialize(Type type, byte[] bytes) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : MsgPackSerializer.Deserialize(type, bytes);

        #endregion

        #region Stream

        public static MemoryStream Pack<T>(T t) =>
            t is null
                ? new MemoryStream()
                : MsgPackSerializer.Pack(t);

        public static void Pack<T>(T t, Stream stream)
        {
            if (t is null || stream is null) return;
            MsgPackSerializer.Pack(t, stream);
        }

        public static MemoryStream Pack(Type type, object obj) =>
            obj is null
                ? new MemoryStream()
                : MsgPackSerializer.Pack(type, obj);

        public static void Pack(Type type, object obj, Stream stream)
        {
            if (obj is null || stream is null) return;
            MsgPackSerializer.Pack(type, obj, stream);
        }

        public static T Unpack<T>(Stream stream) =>
            stream is null
                ? default
                : MsgPackSerializer.Unpack<T>(stream);

        public static object Unpack(Type type, Stream stream) =>
            stream is null
                ? type.GetDefaultValue()
                : MsgPackSerializer.Unpack(type, stream);

        #endregion
    }
}