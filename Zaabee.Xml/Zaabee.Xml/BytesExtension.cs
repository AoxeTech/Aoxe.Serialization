using System;
using System.Threading.Tasks;

namespace Zaabee.Xml
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes) =>
            XmlHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) =>
            XmlHelper.Deserialize(type, bytes);

        public static async Task<T> FromBytesAsync<T>(this byte[] bytes) =>
            await XmlHelper.DeserializeAsync<T>(bytes);

        public static async Task<object> FromBytesAsync(this byte[] bytes, Type type) =>
            await XmlHelper.DeserializeAsync(type, bytes);
    }
}