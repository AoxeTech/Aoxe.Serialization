using System;
using System.Threading;
using MessagePack;

namespace Zaabee.MessagePack
{
    public static partial class MessagePackCSharpSerializer
    {
        public static byte[] Serialize<T>(T t, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackSerializer.Serialize(t, options, cancellationToken);

        public static byte[] Serialize(Type type, object obj, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackSerializer.Serialize(type, obj, options, cancellationToken);

        public static T Deserialize<T>(ReadOnlyMemory<byte> bytes, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackSerializer.Deserialize<T>(bytes, options, cancellationToken);

        public static object Deserialize(Type type, ReadOnlyMemory<byte> bytes,
            MessagePackSerializerOptions options = null, CancellationToken cancellationToken = default) =>
            MessagePackSerializer.Deserialize(type, bytes, options, cancellationToken);
    }
}