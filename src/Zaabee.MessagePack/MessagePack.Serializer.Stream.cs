using System;
using System.IO;
using System.Threading;
using MessagePack;
using Zaabee.Extensions;

namespace Zaabee.MessagePack
{
    public static partial class MessagePackCSharpSerializer
    {
        public static MemoryStream Pack<T>(T t, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var ms = new MemoryStream();
            Pack(t, ms, options, cancellationToken);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            MessagePackSerializer.Serialize(stream, t, options, cancellationToken);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static MemoryStream Pack(Type type, object obj, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var ms = new MemoryStream();
            Pack(type, obj, ms, options, cancellationToken);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            MessagePackSerializer.Serialize(type, stream, obj, options, cancellationToken);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackSerializer.Deserialize<T>(stream, options, cancellationToken);

        public static object Unpack(Type type, Stream stream, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackSerializer.Deserialize(type, stream, options, cancellationToken);
    }
}