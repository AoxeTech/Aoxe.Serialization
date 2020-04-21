using System.IO;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        public static async Task PackAsync<T>(T t, Stream stream, Options options = null) =>
            await JilSerializer.PackAsync(t, stream, options, DefaultEncoding);
    }
}