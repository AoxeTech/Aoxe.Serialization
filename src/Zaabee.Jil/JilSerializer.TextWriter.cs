using System.IO;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilSerializer
    {
        public static void Serialize<T>(T t, TextWriter output, Options options) =>
            JSON.Serialize(t, output, options);

        public static void Serialize(object obj, TextWriter output, Options options) =>
            JSON.SerializeDynamic(obj, output, options);
    }
}