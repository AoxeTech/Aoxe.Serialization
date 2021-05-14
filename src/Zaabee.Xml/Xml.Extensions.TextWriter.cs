using System;
using System.IO;

namespace Zaabee.Xml
{
    public static partial class XmlExtensions
    {
        public static void WriteXml<T>(this TextWriter textWriter, T t) =>
            XmlHelper.Serialize(textWriter, t);

        public static void WriteXml(this TextWriter textWriter, Type type, object obj) =>
            XmlHelper.Serialize(type, textWriter, obj);
    }
}