using System.IO;
using System.Threading.Tasks;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackHelper
    {
        public static async Task PackAsync<T>(T t, Stream stream) => await MsgPackSerializer.PackAsync(t, stream);

        public static async Task<T> UnpackAsync<T>(Stream stream) => await MsgPackSerializer.UnpackAsync<T>(stream);
    }
}