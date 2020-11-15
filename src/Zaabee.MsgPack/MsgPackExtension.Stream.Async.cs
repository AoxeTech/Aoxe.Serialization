using System.IO;
using System.Threading.Tasks;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackExtension
    {
        public static Task PackByAsync<T>(this Stream stream, T obj) => MsgPackHelper.PackAsync(obj, stream);

        public static Task<T> UnpackAsync<T>(this Stream stream) => MsgPackHelper.UnpackAsync<T>(stream);
    }
}