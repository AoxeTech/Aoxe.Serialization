using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilExtension
    {
        public static Task PackByAsync<T>(this Stream stream, T t, Options options = null,
            Encoding encoding = null) =>
            JilHelper.PackAsync(t, stream, options, encoding);

        public static Task PackByAsync(this Stream stream, object obj, Options options = null,
            Encoding encoding = null) =>
            JilHelper.PackAsync(obj, stream, options, encoding);

        public static Task<T> UnpackAsync<T>(this Stream stream, Options options = null, Encoding encoding = null) =>
            JilHelper.UnpackAsync<T>(stream, options, encoding);

        public static Task<object> UnpackAsync(this Stream stream, Type type, Options options = null,
            Encoding encoding = null) =>
            JilHelper.UnpackAsync(type, stream, options, encoding);
        
    }
}