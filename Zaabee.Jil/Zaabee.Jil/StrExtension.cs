using System;
using Jil;

namespace Zaabee.Jil
{
    public static class StrExtension
    {
        /// <summary>
        /// Deserialize the json to the generic object(if the string is null or white space then return default(T))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T FromJil<T>(this string json, Options options = null)
        {
            return JilHelper.Deserialize<T>(json, options);
        }

        /// <summary>
        /// Deserialize the json to the specify type(if the string is null or white space then return null)
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromJil(this string json, Type type, Options options = null)
        {
            return JilHelper.Deserialize(json, type, options);
        }
    }
}