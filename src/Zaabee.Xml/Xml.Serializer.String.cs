using System;
using System.IO;
using System.Text;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        /// <summary>
        ///  Serialize the object into a memory stream,get bytes from it and return the decode result.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string SerializeToXml<T>(T t, Encoding encoding) => SerializeToXml(typeof(T), t, encoding);

        /// <summary>
        /// Serialize the object into a memory stream,get bytes from it and return the decode result.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string SerializeToXml(Type type, object obj, Encoding encoding)
        {
            using var ms = Pack(type, obj);
            return encoding.GetString(ms.ToArray());
        }

        /// <summary>
        /// Encode the xml to a bytes and initialize a memory stream by it,deserialize to a object.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string xml, Encoding encoding) =>
            (T) Deserialize(typeof(T), xml, encoding);

        /// <summary>
        /// Encode the xml to a bytes and initialize a memory stream by it,deserialize to a object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml, Encoding encoding)
        {
            using var ms = new MemoryStream(encoding.GetBytes(xml));
            return Unpack(type, ms);
        }
    }
}