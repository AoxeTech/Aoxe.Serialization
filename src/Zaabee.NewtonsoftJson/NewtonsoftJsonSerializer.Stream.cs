using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonSerializer
    {
        public static MemoryStream Pack(object obj, JsonSerializerSettings settings, Encoding encoding)
        {
            var ms = new MemoryStream();
            Pack(obj, ms, settings, encoding);
            return ms;
        }

        public static void Pack(object obj, Stream stream, JsonSerializerSettings settings, Encoding encoding)
        {
            Serialize(obj, settings, encoding).WriteTo(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream, JsonSerializerSettings settings, Encoding encoding) =>
            (T) Unpack(typeof(T), stream, settings, encoding);

        public static object Unpack(Type type, Stream stream, JsonSerializerSettings settings, Encoding encoding)
        {
            var result = Deserialize(type, encoding.GetString(stream.ReadToEnd()), settings);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}