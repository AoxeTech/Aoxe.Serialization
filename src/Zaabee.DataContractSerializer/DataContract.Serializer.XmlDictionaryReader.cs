using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractSerializer
    {
        /// <summary>
        /// Deserializes the XML document contained by the specified XmlReader.
        /// </summary>
        /// <param name="xmlDictionaryReader"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(XmlDictionaryReader xmlDictionaryReader) =>
            (T)Deserialize(typeof(T), xmlDictionaryReader);

        /// <summary>
        /// Deserializes the XML document contained by the specified XmlReader.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xmlDictionaryReader"></param>
        /// <param name="verifyObjectName"></param>
        /// <param name="dataContractResolver"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, XmlDictionaryReader xmlDictionaryReader,
            bool verifyObjectName = true, DataContractResolver? dataContractResolver = null) =>
            GetSerializer(type).ReadObject(xmlDictionaryReader, verifyObjectName, dataContractResolver!);
    }
}