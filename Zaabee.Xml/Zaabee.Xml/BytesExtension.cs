using System;

namespace Zaabee.Xml
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes) =>
            XmlHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) =>
            XmlHelper.Deserialize(type, bytes);
    }
}