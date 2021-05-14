using System;
using System.IO;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        public static T Deserialize<T>(TextReader reader, Options options = null) =>
            reader is null
                ? (T) typeof(T).GetDefaultValue()
                : JilSerializer.Deserialize<T>(reader, options ?? DefaultOptions);

        public static object Deserialize(Type type, TextReader reader, Options options = null) =>
            reader is null
                ? type.GetDefaultValue()
                : JilSerializer.Deserialize(type, reader, options ?? DefaultOptions);
    }
}