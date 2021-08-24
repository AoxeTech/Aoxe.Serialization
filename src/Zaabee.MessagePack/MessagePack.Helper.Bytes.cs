using System;
using System.Threading;
using MessagePack;
using Zaabee.Extensions;

namespace Zaabee.MessagePack
{
    public static partial class MessagePackHelper
    {
        public static byte[] Serialize<T>(T t, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            t is null
                ? Array.Empty<byte>()
                : MessagePackCSharpSerializer.Serialize(t, options ?? DefaultOptions, cancellationToken);

        public static byte[] Serialize(Type type, object obj, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            obj is null
                ? Array.Empty<byte>()
                : MessagePackCSharpSerializer.Serialize(type, obj, options ?? DefaultOptions, cancellationToken);

        public static T Deserialize<T>(ReadOnlyMemory<byte> bytes, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            bytes.IsEmpty
                ? (T)typeof(T).GetDefaultValue()
                : MessagePackCSharpSerializer.Deserialize<T>(bytes, options ?? DefaultOptions, cancellationToken);

        public static object Deserialize(Type type, ReadOnlyMemory<byte> bytes,
            MessagePackSerializerOptions options = null, CancellationToken cancellationToken = default) =>
            bytes.IsEmpty
                ? type.GetDefaultValue()
                : MessagePackCSharpSerializer.Deserialize(type, bytes, options ?? DefaultOptions, cancellationToken);
    }
}