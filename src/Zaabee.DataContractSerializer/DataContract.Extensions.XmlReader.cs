using System;
using System.Xml;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractExtensions
    {
        public static T ReadXml<T>(this XmlReader xmlReader) =>
            DataContractHelper.Deserialize<T>(xmlReader);

        public static object ReadXml(this XmlReader xmlReader, Type type) =>
            DataContractHelper.Deserialize(type, xmlReader);
    }
}