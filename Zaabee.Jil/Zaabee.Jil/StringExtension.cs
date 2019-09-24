using System;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static class StringExtension
    {
        public static T FromJson<T>(this string str, Options options = null) =>
            JilHelper.Deserialize<T>(str, options);

        public static object FromJson(this string str, Type type, Options options = null) =>
            JilHelper.Deserialize(type, str, options);

        public static async Task<T> FromJsonAsync<T>(this string str, Options options = null) =>
            await JilHelper.DeserializeAsync<T>(str, options);

        public static async Task<object> FromJsonAsync(this string str, Type type, Options options = null) =>
            await JilHelper.DeserializeAsync(type, str, options);
    }
}