namespace Zaabee.Binary
{
    public static partial class BinaryExtensions
    {
        public static T DeserializeFromBase64<T>(this string text) => BinaryHelper.DeserializeFromBase64<T>(text);
        public static object DeserializeFromBase64(this string text) => BinaryHelper.DeserializeFromBase64(text);
    }
}