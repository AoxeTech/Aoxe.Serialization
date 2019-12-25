using System;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes, Options options = null) =>
            JilHelper.Deserialize<T>(bytes, options);

        public static object FromBytes(this byte[] bytes, Type type, Options options = null) =>
            JilHelper.Deserialize(type, bytes, options);
    }
}