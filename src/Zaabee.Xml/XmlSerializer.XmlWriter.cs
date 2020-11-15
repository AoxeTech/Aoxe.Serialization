using System;
using System.Xml;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using the specified XmlWriter.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static void Serialize<T>(XmlWriter xmlWriter, T t) =>
            Serialize(typeof(T), xmlWriter, t);

        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using the specified XmlWriter.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xmlWriter"></param>
        /// <param name="obj"></param>
        public static void Serialize(Type type, XmlWriter xmlWriter, object obj) =>
            GetSerializer(type).Serialize(xmlWriter, obj);
    }
}