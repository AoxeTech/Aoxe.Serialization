using System;
using System.Xml;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        /// <summary>
        /// Deserializes the XML document contained by the specified XmlReader.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(XmlReader xmlReader) => (T) Deserialize(typeof(T), xmlReader);

        /// <summary>
        /// Deserializes the XML document contained by the specified XmlReader.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xmlReader"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, XmlReader xmlReader) =>
            GetSerializer(type).Deserialize(xmlReader);
    }
}