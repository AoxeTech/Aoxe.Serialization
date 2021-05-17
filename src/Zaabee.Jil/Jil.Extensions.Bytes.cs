using System;
using System.Text;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilExtensions
    {
        public static T FromBytes<T>(this byte[] bytes, Options options = null, Encoding encoding = null) =>
            JilHelper.Deserialize<T>(bytes, options, encoding);

        public static object FromBytes(this byte[] bytes, Type type, Options options = null,
            Encoding encoding = null) =>
            JilHelper.Deserialize(type, bytes, options, encoding);
    }
}