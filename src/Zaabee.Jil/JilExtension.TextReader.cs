using System;
using System.IO;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilExtension
    {
        public static T ReadJson<T>(this TextReader textReader, Options options = null) =>
            JilHelper.Deserialize<T>(textReader, options);

        public static object ReadJson(this TextReader textReader, Type type, Options options = null) =>
            JilHelper.Deserialize(type, textReader, options);
    }
}