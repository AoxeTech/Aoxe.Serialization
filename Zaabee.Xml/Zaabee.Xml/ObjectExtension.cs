using System.Text;

namespace Zaabee.Xml
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to xml
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToXml<T>(this T obj, Encoding encoding = null) where T : class
        {
            return XmlHelper.Serialize(obj, encoding);
        }
    }
}