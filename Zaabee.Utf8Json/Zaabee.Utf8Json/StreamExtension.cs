using System;
using System.IO;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class StreamExtension
    {
        /// <summary>
        /// Deserialize the json to the generic object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T FromUtf8Json<T>(this Stream stream) =>
            Utf8JsonHelper.Deserialize<T>(stream);

        public static object FromUtf8Json(this Stream stream, Type type) =>
            Utf8JsonHelper.Deserialize(type, stream);

        public static object FromUtf8Json(this Stream stream, Type type, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Deserialize(type, stream, resolver);
    }
}