using Zaabee.Extensions;

namespace Zaabee.Binary
{
    public static partial class BinaryHelper
    {
        public static string SerializeToBase64(object obj) =>
            obj is null
                ? string.Empty
                : BinarySerializer.SerializeToBase64(obj);

        public static T DeserializeFromBase64<T>(string base64) =>
            base64.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : BinarySerializer.DeserializeFromBase64<T>(base64);

        public static object DeserializeFromBase64(string base64) =>
            base64.IsNullOrEmpty()
                ? null
                : BinarySerializer.DeserializeFromBase64(base64);
    }
}