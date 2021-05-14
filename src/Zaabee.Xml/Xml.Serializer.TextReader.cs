using System;
using System.IO;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        /// <summary>
        /// Deserializes the XML document contained by the specified TextReader.
        /// </summary>
        /// <param name="textReader"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(TextReader textReader) =>
            (T) Deserialize(typeof(T), textReader);

        /// <summary>
        /// Deserializes the XML document contained by the specified TextReader.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="textReader"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, TextReader textReader) =>
            GetSerializer(type).Deserialize(textReader);
    }
}