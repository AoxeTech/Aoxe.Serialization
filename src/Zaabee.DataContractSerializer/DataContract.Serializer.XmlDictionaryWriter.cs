using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractSerializer
    {
        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using the specified XmlWriter.
        /// </summary>
        /// <param name="xmlDictionaryWriter"></param>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static void Serialize<T>(XmlDictionaryWriter xmlDictionaryWriter, T t) =>
            Serialize(typeof(T), xmlDictionaryWriter, t);

        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using the specified XmlWriter.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xmlDictionaryWriter"></param>
        /// <param name="obj"></param>
        /// <param name="dataContractResolver"></param>
        public static void Serialize(Type type, XmlDictionaryWriter xmlDictionaryWriter, object obj,
            DataContractResolver? dataContractResolver = null) =>
            GetSerializer(type).WriteObject(xmlDictionaryWriter, obj, dataContractResolver!);
    }
}