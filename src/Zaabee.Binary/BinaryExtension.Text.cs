namespace Zaabee.Binary
{
    public static partial class BinaryExtension
    {
        public static T FromBase64<T>(this string text) => BinaryHelper.DeserializeFromBase64<T>(text);
        public static object FromBase64(this string text) => BinaryHelper.DeserializeFromBase64(text);
    }
}