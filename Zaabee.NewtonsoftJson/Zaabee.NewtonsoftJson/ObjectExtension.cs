using System.Collections.Generic;

namespace Zaabee.NewtonsoftJson
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
        /// <param name="dateTimeFormat"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T obj, IEnumerable<string> lstDisplayField = null,
            bool toLowerCamel = false, string dateTimeFormat = null)
        {
            return JsonHelper.Serialize(obj, lstDisplayField, toLowerCamel, dateTimeFormat);
        }
    }
}