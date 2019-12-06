using System;
using System.IO;
using System.Threading.Tasks;
using ZeroFormatter;

namespace Zaabee.ZeroFormatter
{
    public static partial class ZeroFormatterHelper
    {
        public static async Task<byte[]> SerializeAsync<T>(T t) =>
            t is null ? new byte[0] : await Task.Run(() => ZeroFormatterSerializer.Serialize(t));

        public static async Task<Stream> PackAsync<T>(T t)
        {
            var ms = new MemoryStream();
            if (t is null) return ms;
            await PackAsync(t, ms);
            return ms;
        }

        public static async Task PackAsync<T>(T t, Stream stream)
        {
            if (t != null) await Task.Run(() => ZeroFormatterSerializer.Serialize(stream, t));
        }

        public static async Task<T> DeserializeAsync<T>(byte[] bytes) =>
            bytes is null || bytes.Length == 0
                ? default
                : await Task.Run(() => ZeroFormatterSerializer.Deserialize<T>(bytes));

        public static async Task<T> UnpackAsync<T>(Stream stream) =>
            stream is null ? default : await Task.Run(() => ZeroFormatterSerializer.Deserialize<T>(stream));

        public static async Task<byte[]> SerializeAsync(Type type, object obj) =>
            obj is null ? new byte[0] : await Task.Run(() => ZeroFormatterSerializer.NonGeneric.Serialize(type, obj));

        public static async Task<Stream> PackAsync(Type type, object obj)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            await PackAsync(type, obj, ms);
            return ms;
        }

        public static async Task PackAsync(Type type, object obj, Stream stream)
        {
            if (obj != null) await Task.Run(() => ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, obj));
        }

        public static async Task<object> DeserializeAsync(Type type, byte[] bytes) =>
            bytes is null || bytes.Length == 0
                ? default(Type)
                : await Task.Run(() => ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes));

        public static async Task<object> UnpackAsync(Type type, Stream stream) =>
            stream is null
                ? default(Type)
                : await Task.Run(() => ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream));
    }
}