using System;
using System.Xml;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractHelper
    {
        public static void Serialize<T>(XmlWriter xmlWriter, T t)
        {
            if (xmlWriter is null || t is null) return;
            DataContractSerializer.Serialize(xmlWriter, t);
        }

        public static void Serialize(Type type, XmlWriter xmlWriter, object obj)
        {
            if (type is null || xmlWriter is null || obj is null) return;
            DataContractSerializer.Serialize(type, xmlWriter, obj);
        }
    }
}