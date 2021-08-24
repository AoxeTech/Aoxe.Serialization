using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MessagePack;

namespace Zaabee.MessagePack
{
    public static partial class MessagePackExtensions
    {
        public static Task<MemoryStream> ToStreamAsync<T>(this T t, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackHelper.PackAsync(t, options, cancellationToken);

        public static Task<MemoryStream> ToStreamAsync(this object obj, Type type,
            MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackHelper.PackAsync(type, obj, options, cancellationToken);

        public static Task PackToAsync<T>(this T t, Stream stream, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackHelper.PackAsync(t, stream, options, cancellationToken);

        public static Task PackToAsync(this object obj, Type type, Stream stream,
            MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default) =>
            MessagePackHelper.PackAsync(type, obj, stream, options, cancellationToken);
    }
}