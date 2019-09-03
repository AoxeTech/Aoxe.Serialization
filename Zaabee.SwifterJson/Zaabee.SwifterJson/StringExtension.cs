using System;

namespace Zaabee.SwifterJson
{
    public static class StringExtension
    {
        public static T FromJson<T>(this string json) =>
            SwifterJsonHelper.Deserialize<T>(json);

        public static object FromJson(this string json, Type type) =>
            SwifterJsonHelper.Deserialize(type, json);
    }
}