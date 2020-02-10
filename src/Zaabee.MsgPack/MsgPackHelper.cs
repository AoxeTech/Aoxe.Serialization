using System;
using System.IO;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackHelper
    {
        public static byte[] Serialize<T>(T t) => MsgPackSerializer.Serialize(t);

        public static Stream Pack<T>(T t) => MsgPackSerializer.Pack(t);

        public static void Pack<T>(T t, Stream stream) => MsgPackSerializer.Pack(t, stream);

        public static byte[] Serialize(Type type, object obj) => MsgPackSerializer.Serialize(type, obj);

        public static Stream Pack(Type type, object obj) => MsgPackSerializer.Pack(type, obj);

        public static void Pack(Type type, object obj, Stream stream) => MsgPackSerializer.Pack(type, obj, stream);

        public static T Deserialize<T>(byte[] bytes) => MsgPackSerializer.Deserialize<T>(bytes);

        public static T Unpack<T>(Stream stream) => MsgPackSerializer.Unpack<T>(stream);

        public static object Deserialize(Type type, byte[] bytes) => MsgPackSerializer.Deserialize(type, bytes);

        public static object Unpack(Type type, Stream stream) => MsgPackSerializer.Unpack(type, stream);
    }
}