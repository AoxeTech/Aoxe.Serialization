using System;
using System.IO;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static class TextReaderExtension
    {
        public static T FromJson<T>(this TextReader textReader, Options options = null) =>
            JilHelper.Deserialize<T>(textReader, options);

        public static object FromJson(this TextReader textReader, Type type, Options options = null) =>
            JilHelper.Deserialize(type, textReader, options);

        public static async Task<T> FromJsonAsync<T>(this TextReader textReader, Options options = null) =>
            await JilHelper.DeserializeAsync<T>(textReader, options);

        public static async Task<object> FromJsonAsync(this TextReader textReader, Type type, Options options = null) =>
            await JilHelper.DeserializeAsync(type, textReader, options);
    }
}