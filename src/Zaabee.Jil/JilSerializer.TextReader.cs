using System;
using System.IO;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilSerializer
    {
        public static T Deserialize<T>(TextReader reader, Options options) =>
            JSON.Deserialize<T>(reader, options);

        public static object Deserialize(Type type, TextReader reader, Options options) =>
            JSON.Deserialize(reader, type, options);
    }
}