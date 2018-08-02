using Jil;

namespace Zaabee.Jil
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJil<T>(this T obj)
        {
            return JSON.Serialize(obj);
        }
    }
}