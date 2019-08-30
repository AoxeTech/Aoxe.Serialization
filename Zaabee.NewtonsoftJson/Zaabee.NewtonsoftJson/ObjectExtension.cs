using System.Collections.Generic;

namespace Zaabee.NewtonsoftJson
{
    public static class ObjectExtension
    {
        public static string ToJson<T>(this T obj, IEnumerable<string> lstDisplayField = null,
            bool toLowerCamel = false, string dateTimeFormat = null) =>
            NewtonsoftJsonHelper.Serialize(obj, lstDisplayField, toLowerCamel, dateTimeFormat);
    }
}