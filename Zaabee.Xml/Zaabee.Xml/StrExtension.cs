using System.Text;

namespace Zaabee.Xml
{
    public static class StrExtension
    {
        /// <summary>
        /// Deserialize the xml to the generic object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T FromXml<T>(this string str, Encoding encoding = null) where T : class
        {
            return XmlHelper.Deserialize<T>(str);
        }
    }
}