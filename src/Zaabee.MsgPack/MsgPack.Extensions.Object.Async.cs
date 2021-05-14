using System.IO;
using System.Threading.Tasks;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackExtensions
    {
        public static Task<MemoryStream> ToStreamAsync<T>(this T t) => MsgPackHelper.PackAsync(t);

        public static Task PackToAsync<T>(this T t, Stream stream) => MsgPackHelper.PackAsync(t, stream);
    }
}