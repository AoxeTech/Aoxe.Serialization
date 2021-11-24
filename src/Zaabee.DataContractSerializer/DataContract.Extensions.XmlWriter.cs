using System;
using System.Xml;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractExtensions
    {
        public static void WriteXml<T>(this XmlWriter xmlWriter, T t) =>
            DataContractHelper.Serialize(xmlWriter, t);

        public static void WriteXml(this XmlWriter xmlWriter, Type type, object obj) =>
            DataContractHelper.Serialize(type, xmlWriter, obj);
    }
}