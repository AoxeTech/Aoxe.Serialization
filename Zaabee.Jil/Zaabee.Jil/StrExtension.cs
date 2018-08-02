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
        /// <param name="str"></param>
        /// <returns></returns>
        public static T FromJil<T>(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? default(T) : JSON.Deserialize<T>(str);
        }

        /// <summary>
        /// Deserialize the json to the specify type(if the string is null or white space then return null)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromJil(this string str, Type type)
        {
            return string.IsNullOrWhiteSpace(str) ? null : JSON.Deserialize(str, type);
        }
    }
}