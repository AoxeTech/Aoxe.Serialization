using System;
using System.Threading;
using MessagePack;

namespace Zaabee.MessagePack
{
    public static partial class MessagePackExtensions
    {
        public static T FromBytes<T>(this byte[] bytes, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackHelper.Deserialize<T>(bytes, options, cancellationToken);

        public static object FromBytes(this byte[] bytes, Type type, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackHelper.Deserialize(type, bytes, options, cancellationToken);
    }
}