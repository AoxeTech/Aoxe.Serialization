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
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string SerializeToXml<T>(T t) => SerializeToXml(typeof(T), t);

        /// <summary>
        /// Serialize the object into a memory stream,get bytes from it and return the decode result.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToXml(Type type, object obj)
        {
            using var ms = Pack(type, obj);
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        /// <summary>
        /// Encode the xml to a bytes and initialize a memory stream by it,deserialize to a object.
        /// </summary>
        /// <param name="xml"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string xml) =>
            (T) Deserialize(typeof(T), xml);

        /// <summary>
        /// Encode the xml to a bytes and initialize a memory stream by it,deserialize to a object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            return Unpack(type, ms);
        }
    }
}