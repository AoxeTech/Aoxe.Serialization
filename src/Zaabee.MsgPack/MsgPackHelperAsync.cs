using System.IO;
using System.Threading.Tasks;
using MsgPack.Serialization;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackHelper
    {
        public static async Task PackAsync<T>(T t, Stream stream)
        {
            if (t is null) return;
            var serializer = MessagePackSerializer.Get<T>();
            await serializer.PackAsync(stream, t);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream)
        {
            if (stream is null) return default;
            var serializer = MessagePackSerializer.Get<T>();
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return await serializer.UnpackAsync(stream);
        }
    }
}