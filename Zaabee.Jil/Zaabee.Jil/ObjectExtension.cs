using Jil;

namespace Zaabee.Jil
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ToJil<T>(this T obj, Options options = null) =>
            JilHelper.Serialize(obj, options);
    }
}