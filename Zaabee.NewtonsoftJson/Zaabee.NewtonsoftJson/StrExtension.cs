using System;

namespace Zaabee.NewtonsoftJson
{
    /// <summary>
    /// string extension method
    /// </summary>
    public static class StrExtension
    {
        /// <summary>
        /// Deserialize the json to the generic object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string str) =>
            NewtonsoftJsonHelper.Deserialize<T>(str);

        /// <summary>
        /// Deserialize the json to the specify type
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromJson(this string str, Type type) =>
            NewtonsoftJsonHelper.Deserialize(str, type);
    }
}