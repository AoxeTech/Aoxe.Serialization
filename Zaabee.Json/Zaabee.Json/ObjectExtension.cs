using System.Collections.Generic;

namespace Zaabee.Json
{
    /// <summary>
    /// object extension method
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="lstDisplayField"></param>
        /// <param name="toLowerCamel"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T obj, IEnumerable<string> lstDisplayField = null,
            bool toLowerCamel = false)
        {
            return JsonHelper.Serialize(obj, lstDisplayField, toLowerCamel);
        }
    }
}