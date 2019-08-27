using System;
using System.IO;
using Jil;

namespace Zaabee.Jil
{
    public static class TextReaderExtension
    {
        /// <summary>
        /// Deserialize the textReader to the generic object(if the textReader is null then return default(T))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="textReader"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T FromJil<T>(this TextReader textReader, Options options = null) =>
            JilHelper.Deserialize<T>(textReader, options);

        /// <summary>
        /// Deserialize the textReader to the specify type(if the textReader is null then return null)
        /// </summary>
        /// <param name="textReader"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromJil(this TextReader textReader, Type type, Options options = null) =>
            JilHelper.Deserialize(textReader, type, options);
    }
}