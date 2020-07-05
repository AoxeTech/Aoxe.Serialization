using System.IO;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        #region Stream

        public static async Task<MemoryStream> PackAsync<T>(T t, Options options = null)
        {
            if (t is null) return new MemoryStream();
            return await JilSerializer.PackAsync(t, options, DefaultEncoding);
        }

        public static async Task PackAsync<T>(T t, Stream stream, Options options = null)
        {
            if (t is null || stream is null) return;
            await JilSerializer.PackAsync(t, stream, options, DefaultEncoding);
        }

        public static async Task<MemoryStream> PackAsync(object obj, Options options = null)
        {
            if (obj is null) return new MemoryStream();
            return await JilSerializer.PackAsync(obj, options, DefaultEncoding);
        }

        public static async Task PackAsync(object obj, Stream stream, Options options = null)
        {
            if (obj is null || stream is null) return;
            await JilSerializer.PackAsync(obj, stream, options, DefaultEncoding);
        }

        #endregion
    }
}