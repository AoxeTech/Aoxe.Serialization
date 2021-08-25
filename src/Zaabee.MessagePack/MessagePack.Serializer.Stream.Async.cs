using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MessagePack;
using Zaabee.Extensions;

namespace Zaabee.MessagePack
{
    public static partial class MessagePackCSharpSerializer
    {
        public static async Task<MemoryStream> PackAsync<T>(T t, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var ms = new MemoryStream();
            await PackAsync(t, ms, options, cancellationToken);
            return ms;
        }

        public static async Task PackAsync<T>(T t, Stream stream, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            await MessagePackSerializer.SerializeAsync(stream, t, options, cancellationToken);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<MemoryStream> PackAsync(Type type, object obj, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var ms = new MemoryStream();
            await PackAsync(type, obj, ms, options, cancellationToken);
            return ms;
        }

        public static async Task PackAsync(Type type, object obj, Stream stream,
            MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            await MessagePackSerializer.SerializeAsync(type, stream, obj, options, cancellationToken);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async ValueTask<T> UnpackAsync<T>(Stream stream, MessagePackSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var result = await MessagePackSerializer.DeserializeAsync<T>(stream, options, cancellationToken);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static async ValueTask<object> UnpackAsync(Type type, Stream stream,
            MessagePackSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            var result = await MessagePackSerializer.DeserializeAsync(type, stream, options, cancellationToken);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}