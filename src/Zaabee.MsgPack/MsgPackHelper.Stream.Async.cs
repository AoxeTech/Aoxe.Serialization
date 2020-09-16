using System.IO;
using System.Threading.Tasks;
using Zaabee.Extensions;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackHelper
    {
        public static async Task<MemoryStream> PackAsync<T>(T t)
        {
            if (t is null) return new MemoryStream();
            return await MsgPackSerializer.PackAsync(t);
        }

        public static async Task PackAsync<T>(T t, Stream stream)
        {
            if (t is null || stream is null) return;
            await MsgPackSerializer.PackAsync(t, stream);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream) =>
            stream is null
                ? (T) typeof(T).GetDefaultValue()
                : await MsgPackSerializer.UnpackAsync<T>(stream);
    }
}