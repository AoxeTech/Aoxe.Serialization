using System.IO;
using System.Threading.Tasks;
using MsgPack.Serialization;
using Zaabee.Extensions;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackSerializer
    {
        public static async Task<MemoryStream> PackAsync<T>(T t)
        {
            var ms = new MemoryStream();
            await PackAsync(t, ms);
            return ms;
        }

        public static async Task PackAsync<T>(T t, Stream stream)
        {
            await MessagePackSerializer.Get<T>().PackAsync(stream, t);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream)
        {
            var result = await MessagePackSerializer.Get<T>().UnpackAsync(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}