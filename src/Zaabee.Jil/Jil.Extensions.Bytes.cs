using System;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilExtensions
    {
        public static T FromBytes<T>(this byte[] bytes, Options options = null) =>
            JilHelper.Deserialize<T>(bytes, options);

        public static object FromBytes(this byte[] bytes, Type type, Options options = null) =>
            JilHelper.Deserialize(type, bytes, options);
    }
}