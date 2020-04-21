using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        public static async Task PackAsync(object obj, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            await NewtonsoftJsonSerializer.PackAsync(obj, stream, settings ?? DefaultSettings,
                encoding ?? DefaultEncoding);
    }
}