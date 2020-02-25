using System;
using System.IO;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        public static async Task PackAsync<T>(T t, Stream stream, Options options = null) =>
            await JilSerializer.PackAsync(t, stream, options, DefaultEncoding);

        public static async Task<T> UnpackAsync<T>(Stream stream, Options options = null) =>
            await JilSerializer.UnpackAsync<T>(stream, options, DefaultEncoding);

        public static async Task<object> UnpackAsync(Type type, Stream stream, Options options = null) =>
            await JilSerializer.UnpackAsync(type, stream, options, DefaultEncoding);
    }
}